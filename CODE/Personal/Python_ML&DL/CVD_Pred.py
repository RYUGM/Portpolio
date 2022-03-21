import pymysql
import requests

import json
import xmltodict

import datetime


import os

import pandas as pd

from keras.optimizers import *

from keras.utils.np_utils import *

from keras.models import Sequential
from keras.layers import Dense, SimpleRNN, GRU, LSTM
from keras.metrics import MeanSquaredError
from sklearn.preprocessing import MinMaxScaler

from flask import Flask ,render_template,redirect,request,url_for

app = Flask(__name__)

os.environ['TF_CPP_MIN_LOG_LEVEL']='3'
# my_db = pymysql.connect(
#     user='root',
#     password='1234',
#     host='localhost',
#     db='aa',
#     charset='utf8'

# )


# cursor=my_db.cursor(pymysql.cursors.DictCursor)


today=str(datetime.date.today())
today= today.replace("-","")
yes_day=str(int(today)-1)


key=''
params='&pageNo=1&numOfRows=10&startCreateDt='+yes_day+'&endCreateDt='+today
url = 'http://openapi.data.go.kr/openapi/service/rest/Covid19/getCovid19InfStateJson?serviceKey='+key+params

url_all='http://openapi.data.go.kr/openapi/service/rest/Covid19/getCovid19InfStateJson?serviceKey='+key+'&pageNo=1&numOfRows=10000&startCreateDt=20200101&endCreateDt='+today

url=url_all
response = requests.get(url)
contents= response.text

js_string = json.dumps(xmltodict.parse(contents),indent=4)

result = json.loads(js_string)

result=pd.DataFrame(result['response']['body']['items']['item'])
result1=result.loc[:,['decideCnt']]
result1=result1.loc[::-1]
result_day=result.loc[:,['createDt']]
total_val=[]
# print(type(result1))
total_val.append(result1['decideCnt'].values)
print(len(total_val[0][8:]))
num_1=(len(total_val[0][8:]))
num_2=num_1-50
num_3=num_1-49
num_7= num_1-7
print(total_val[0])

day=[]
day.append(result_day['createDt'].values)
print('day',day)


result=result.loc[:,['decideCnt','deathCnt','seq','stateDt']]

result.columns=['total','total_death','total_cnt','wdate']
result=result.loc[::-1]
result=result.reset_index()
del result['index']
print(result)
result=result.rename_axis('Date')
cnt=int(result.iloc[-1]['total_cnt'])-34
cnt1=cnt-50
cnt2=cnt-49
# print(cnt)
result=result.apply(pd.to_numeric)

all_data=result

# print(all_data)

def ts_train_test_normalize(all_data, time_steps, for_periods):
    ts_train = all_data[:].iloc[:, 0:1].values
    ts_test = all_data[:].iloc[:, 0:1].values
    ts_train_len = len(ts_train)
    ts_test_len = len(ts_test)
    #0,1로 변환
    sc = MinMaxScaler(feature_range=(0, 1))
    ts_train_scaled = sc.fit_transform(ts_train)
    X_train = []
    y_train = []
    for i in range(time_steps, ts_train_len - 1):

        X_train.append(ts_train_scaled[i - time_steps:i, 0])
        y_train.append(ts_train_scaled[i:i + for_periods, 0])
    X_train, y_train = np.array(X_train), np.array(y_train)


    X_train = np.reshape(X_train, (X_train.shape[0], X_train.shape[1], 1))

    # inputs = pd.concat((all_data["total"][:756], all_data["total"][757:]), axis=0).values
    inputs = pd.concat((all_data["total"][:], all_data["total"][:]), axis=0).values
    inputs = inputs[len(inputs) - len(ts_test) - time_steps:]
    inputs = inputs.reshape(-1, 1)
    inputs = sc.transform(inputs)

    # Preparing X_test
    X_test = []
    for i in range(time_steps, ts_test_len + time_steps - for_periods):
        X_test.append(inputs[i - time_steps:i, 0])

    X_test = np.array(X_test)
    X_test = np.reshape(X_test, (X_test.shape[0], X_test.shape[1], 1))
    # print("정규화",X_train, y_train, X_test, sc)

    return X_train, y_train, X_test, sc


X_train, y_train, X_test, sc = ts_train_test_normalize(all_data, 4,2)
# X_train.shape[0], X_train.shape[1]

# X_train_see = pd.DataFrame(np.reshape(X_train, (X_train.shape[0], X_train.shape[1])))
# y_train_see = pd.DataFrame(y_train)
# pd.concat([X_train_see, y_train_see], axis = 1)
#
#
# X_test_see = pd.DataFrame(np.reshape(X_test, (X_test.shape[0], X_test.shape[1])))
# pd.DataFrame(X_test_see)


def LSTM_model(X_train, y_train, X_test, sc):
    my_LSTM_model = Sequential()
    my_LSTM_model.add(LSTM(units=100,
                           return_sequences=True,
                           input_shape=(X_train.shape[1], 1),
                           activation='tanh'))
    my_LSTM_model.add(LSTM(units=100, activation='tanh'))
    my_LSTM_model.add(Dense(units=2))
    my_LSTM_model.compile(optimizer=gradient_descent_v2.SGD(learning_rate=0.01, decay=1e-7,
                                        momentum=0.9, nesterov=False),
                          loss='mean_squared_error')
    my_LSTM_model.fit(X_train, y_train, epochs=500, batch_size=150, verbose=1)

    LSTM_prediction = my_LSTM_model.predict(X_test)
    LSTM_prediction = sc.inverse_transform(LSTM_prediction)

    return my_LSTM_model, LSTM_prediction

def actual_pred_plot(preds):
    actual_pred = pd.DataFrame(columns=['total.', 'prediction'])
    actual_pred['total.'] = all_data.loc[:, 'total'][:len(preds)]
    actual_pred['prediction'] = preds[:, 0]
    # print("pred", actual_pred)

    m = MeanSquaredError()
    m.update_state(np.array(actual_pred['total.']), np.array(actual_pred['prediction']))
    # print("pred", actual_pred)
    pre_val = actual_pred.loc[:, ['prediction']]

    total_pred_val = []
    # print(type(result1))
    total_pred_val.append(pre_val['prediction'].values)
    # print("prediction",total_pred_val[0])
    # print(total_val[0])

    return (m.result().numpy(), actual_pred.plot())

def actual_pred(preds):
    actual_pred = pd.DataFrame(columns=['total.', 'prediction'])
    # actual_pred['total.'] = all_data.loc[:, 'total'][num_7:len(preds)]
    # actual_pred['prediction'] = preds[num_7:, 0]
    actual_pred['total.'] = all_data.loc[:, 'total'][4:len(preds)]
    actual_pred['prediction'] = preds[4:, 0]
    m = MeanSquaredError()
    m.update_state(np.array(actual_pred['total.']), np.array(actual_pred['prediction']))
    pre_val = actual_pred.loc[:, ['prediction']]
    total_pred_val = []
    total_pred_val.append(pre_val['prediction'].values)



    return np.round(total_pred_val[0])


# print("X_test",X_test)

#LSMT 예측
# my_LSTM_model, LSTM_prediction = LSTM_model(X_train, y_train, X_test, sc)
# LSTM_prediction[1:10]
# actual_pred_plot(LSTM_prediction)
# plt.title('LSTM')
# plt.xlabel('Time')
# plt.ylabel('Total')
# plt.legend(loc='upper left')
# plt.show()


def GRU_model(X_train,y_train,X_test,sc):
    my_GRU_model=Sequential()
    my_GRU_model.add(GRU(units=100,
                         return_sequences=True,
                         input_shape=(X_train.shape[1],1),
                         activation='tanh'
                         ))
    my_GRU_model.add(GRU(units=100,
                         activation='tanh'
                         ))
    my_GRU_model.add(Dense(units=2))
    my_GRU_model.compile(optimizer=gradient_descent_v2.SGD(learning_rate=0.01,
                                                           decay=1e-7,momentum=0.9,
                                                           nesterov=False),
                         loss='mean_squared_error')
    my_GRU_model.fit(X_train,y_train,epochs=100,batch_size=150,verbose=1)
    GRU_prediction=my_GRU_model.predict(X_test)
    GRU_prediction=sc.inverse_transform(GRU_prediction)
    return my_GRU_model,GRU_prediction

my_GRU_model,GRU_prediction = GRU_model(X_train,y_train,X_test,sc)
# GRU_prediction[1:]

print(GRU_prediction.tolist())
# total_pred_val=[]
# GRU_prediction_1=pd.DataFrame(GRU_prediction,columns=['1','2'])
# pred_val=GRU_prediction_1.loc[:,['1']]
#
# total_pred_val.append(pred_val['1'].values)
# print("total_pred_val", total_pred_val)
total_pred_val=[]
total_pred_val=actual_pred(GRU_prediction)
print("total_pred_val", len(total_pred_val))
# print("GRU_prediction",GRU_prediction[0][0])
# actual_pred_plot(GRU_prediction)

# plt.title('GRU')
# plt.xlabel('Time')
# plt.ylabel('Total')
# plt.legend(loc='upper left')
# plt.show()

my_db = pymysql.connect(

     

    )


cursor = my_db.cursor(pymysql.cursors.SSCursor)
sql = "DELETE FROM cvd_19;"
cursor.execute(sql)
my_db.commit()

num = len(total_val[0][8:]) + 1
    # my_val = np.array(total_val[0][num:]).astype(int).tolist()

my_val = np.array(total_val[0][8:]).astype(int).tolist()


my_pred_val = total_pred_val
my_pred_val = my_pred_val.astype(int).tolist()
my_pred_val = my_pred_val[:]

i = 0
cnt = []
while i < len(my_val) + 6:
    cnt.append(i)
    i = i + 1




cvd_graphe = {"pred_val": my_pred_val, "total_val": my_val[:], "cnt": cnt[:]}


file_path = 'cvd_graphe.json'
with open(file_path, 'w') as f:
    json.dump(cvd_graphe, f)

    # return render_template('graphe.html', pred_val = my_pred_val,total_val= my_val[num_7:], cnt = cnt[num_7:])


    # return render_template('graphe.html', pred_val=my_pred_val, total_val=my_val[:], cnt=cnt[:])

print(len(my_pred_val),len(my_val),len(cnt))
i=0
#
while(i<len(my_pred_val)):

    sql = "insert into cvd_19(pred,pred_total,pred_cnt) values(%s,%s,%s)"
    insert_val = [(my_pred_val[i]),(my_val[i]),(i)]
    cursor.execute(sql, insert_val)
    my_db.commit()


    i=i+1

my_db.close()
print("DB 삽입 완료")

