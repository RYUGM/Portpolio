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

#--- 공공데이터 포탈에서 데이터를 제공받는 부분 ---
today=str(datetime.date.today())
today= today.replace("-","")
yes_day=str(int(today)-1)
key=''
params='&pageNo=1&numOfRows=10&startCreateDt='+yes_day+'&endCreateDt='+today
url = 'http://openapi.data.go.kr/openapi/service/rest/Covid19/getCovid19InfStateJson?serviceKey='+key+params
url_all='http://openapi.data.go.kr/openapi/service/rest/Covid19/getCovid19InfStateJson?serviceKey='+key+'&pageNo=1&numOfRows=10000&startCreateDt=20200101&endCreateDt='+today
url=url_all
#--- 공공데이터 포탈에서 데이터를 제공받는 부분 ---

#--- 받은 데이터에서 필요한 부분을 파싱하는 과정 xml -> Json -> Dataframe 순으로 변환---
response = requests.get(url)
contents= response.text
js_string = json.dumps(xmltodict.parse(contents),indent=4)
result = json.loads(js_string)
result=pd.DataFrame(result['response']['body']['items']['item'])
result1=result.loc[:,['decideCnt']]
result1=result1.loc[::-1]
result_day=result.loc[:,['createDt']]
total_val=[]


total_val.append(result1['decideCnt'].values)
num_1=(len(total_val[0][8:]))
num_7= num_1-7
day=[]
day.append(result_day['createDt'].values)
result=result.loc[:,['decideCnt','deathCnt','seq','stateDt']]
result.columns=['total','total_death','total_cnt','wdate']
result=result.loc[::-1]
result=result.reset_index()
#--- 받은 데이터에서 필요한 부분을 파싱하는 과정 xml -> Json -> Dataframe 순으로 변환---


del result['index']
print(result)
result=result.rename_axis('Date')
cnt=int(result.iloc[-1]['total_cnt'])-34
cnt1=cnt-50
cnt2=cnt-49

result=result.apply(pd.to_numeric)

all_data=result




def ts_train_test_normalize(all_data, time_steps, for_periods): #데이터 정규화
    ts_train = all_data[:].iloc[:, 0:1].values
    ts_test = all_data[:].iloc[:, 0:1].values
    #train , test 배분
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


    X_test = []
    for i in range(time_steps, ts_test_len + time_steps - for_periods):
        X_test.append(inputs[i - time_steps:i, 0])

    X_test = np.array(X_test)
    X_test = np.reshape(X_test, (X_test.shape[0], X_test.shape[1], 1))
    # print("정규화",X_train, y_train, X_test, sc)

    return X_train, y_train, X_test, sc


X_train, y_train, X_test, sc = ts_train_test_normalize(all_data, 4,2)



def LSTM_model(X_train, y_train, X_test, sc): #LSTM 모델 구축
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

    LSTM_prediction = my_LSTM_model.predict(X_test) #LSTM 모델 예측
    LSTM_prediction = sc.inverse_transform(LSTM_prediction)

    return my_LSTM_model, LSTM_prediction


def actual_pred_plot(preds): #예측 값을 pyplot 으로 시각화 확인 확 수 있는 클래스
    actual_pred = pd.DataFrame(columns=['total.', 'prediction'])
    actual_pred['total.'] = all_data.loc[:, 'total'][:len(preds)]
    actual_pred['prediction'] = preds[:, 0]
   

    m = MeanSquaredError()
    m.update_state(np.array(actual_pred['total.']), np.array(actual_pred['prediction']))

    pre_val = actual_pred.loc[:, ['prediction']]

    total_pred_val = []

    total_pred_val.append(pre_val['prediction'].values)

    return (m.result().numpy(), actual_pred.plot())

def actual_pred(preds): #예측값을 MySql DB에 저장하기위한 클래스(스프링 부트와 연계하기 위한)
    actual_pred = pd.DataFrame(columns=['total.', 'prediction'])

    actual_pred['total.'] = all_data.loc[:, 'total'][:len(preds)]
    actual_pred['prediction'] = preds[:, 0]
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


def GRU_model(X_train,y_train,X_test,sc): #GRU 모델(LSTM모델과비교용)
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


print(GRU_prediction.tolist())

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



#예측 결과를 Json 타입으로 저장 and DB에저장하는 부분
my_db = pymysql.connect(


    )

cursor = my_db.cursor(pymysql.cursors.SSCursor)
sql = "DELETE FROM cvd_19;"
cursor.execute(sql)
my_db.commit()
num = len(total_val[0][:])
my_val = np.array(total_val[0][:]).astype(int).tolist()
my_pred_val = total_pred_val
my_pred_val = my_pred_val.astype(int).tolist()
my_pred_val = my_pred_val[:]
i = 0
cnt = []

while i < len(my_val): #Json 타입으로 변경후 저장
    cnt.append(i)
    i = i + 1

cvd_graphe = {"pred_val": my_pred_val, "total_val": my_val[:], "cnt": cnt[:]}
#pred_val =확진자 예측값 ,total_val = 실제 누적 확진자 ,cnt = 경과일
file_path = 'cvd_graphe.json'
with open(file_path, 'w') as f:
    json.dump(cvd_graphe, f)

print(len(my_pred_val),len(my_val),len(cnt))
i=0


while(i<len(my_pred_val)): #MySql DB에 저장

    sql = "insert into cvd_19(pred,pred_total,pred_cnt) values(%s,%s,%s)"
    # pred =확진자 예측값 ,pred_total = 실제 누적 확진자 ,pred_cnt = 경과일
    insert_val = [(my_pred_val[i]),(my_val[i]),(i)]
    cursor.execute(sql, insert_val)
    my_db.commit()
    i=i+1
my_db.close()
print("DB 삽입 완료")

