import matplotlib.pyplot as plt
import numpy as np
import pandas as pd
import pymysql
# from tensorflow.keras.optimizers import SGD
from keras.optimizers import gradient_descent_v2
import os
import numpy as np
import  pandas as pd
import yfinance as yf
import matplotlib.pyplot as plt
from sklearn.preprocessing import MinMaxScaler
from keras.models import Sequential
from keras.layers import Dense,SimpleRNN,GRU,LSTM
from keras import optimizers
from keras.optimizers import *
from keras.models import Sequential
from  keras.layers import Dense,SimpleRNN,GRU
from keras.layers import *
from keras.models import *
from keras.utils import *
from keras.utils.np_utils import *
from sklearn.preprocessing import *
from sklearn.preprocessing import MinMaxScaler
from keras.models import Sequential
from keras.layers import Dense, SimpleRNN, GRU, LSTM
from keras.metrics import MeanSquaredError
from sklearn.metrics import mean_absolute_error, mean_squared_error, mean_squared_log_error, r2_score
os.environ['TF_CPP_MIN_LOG_LEVEL']='3'

my_db = pymysql.connect(

)


cursor=my_db.cursor(pymysql.cursors.SSCursor)


sql="SELECT * from cvd_api ORDER BY total_cnt"


cursor.execute(sql)
result = cursor.fetchall()
# print("result",result)
all_data =pd.DataFrame(result,columns=['total','total_death','total_cnt','wdate'])
# print("all_data",all_data)
all_data=all_data.rename_axis('Date')
print(all_data)

start=1
end=2

print(str(all_data.shape[0]))
# print(str(all_data[701:].shape[0]))

def ts_train_test_normalize(all_data, time_steps, for_periods):

    #1부터 2018까지 1500개?
    ts_train = all_data[1:].iloc[:, 0:1].values
    print("iloc[:, 0:1]",ts_train)
    #2019부터 끝까지 200개?
    ts_test = all_data[end:].iloc[:, 0:1].values
    print("iloc[:, 0:1]",ts_test)
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

    inputs = pd.concat((all_data["total"][1:], all_data["total"][end:]), axis=0).values
    inputs = inputs[len(inputs) - len(ts_test) - time_steps:]
    inputs = inputs.reshape(-1, 1)
    inputs = sc.transform(inputs)

    # Preparing X_test
    X_test = []
    for i in range(time_steps, ts_test_len + time_steps - for_periods):
        X_test.append(inputs[i - time_steps:i, 0])

    X_test = np.array(X_test)
    X_test = np.reshape(X_test, (X_test.shape[0], X_test.shape[1], 1))
    print("정규화",X_train, y_train, X_test, sc)

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
    my_LSTM_model.add(LSTM(units=500,
                           return_sequences=True,
                           input_shape=(X_train.shape[1], 1),
                           activation='tanh'))
    my_LSTM_model.add(LSTM(units=500, activation='tanh'))
    my_LSTM_model.add(Dense(units=2))
    #
    # my_LSTM_model.add(LSTM(units=100,
    #                        return_sequences=True,
    #                        input_shape=(X_train.shape[1], 1),
    #                        activation='relu'))
    # my_LSTM_model.add(LSTM(units=100, activation='relu'))
    # my_LSTM_model.add(Dense(units=1))


    my_LSTM_model.compile(optimizer=gradient_descent_v2.SGD(learning_rate=0.01, decay=1e-7,
                                        momentum=0.9, nesterov=False),
                          loss='mean_squared_error')


    my_LSTM_model.fit(X_train, y_train, epochs=1000, batch_size=150, verbose=1)
    print("X_test X_test",X_test)

    LSTM_prediction = my_LSTM_model.predict(X_test)
    LSTM_prediction = sc.inverse_transform(LSTM_prediction)

    return my_LSTM_model, LSTM_prediction

def actual_pred_plot(preds):


    actual_pred = pd.DataFrame(columns=['total.', 'prediction'])
    actual_pred['total.'] = all_data.loc[:, 'total'][5:len(preds)]
    actual_pred['prediction'] = preds[5:, 0]


    m = MeanSquaredError()
    m.update_state(np.array(actual_pred['total.']), np.array(actual_pred['prediction']))
    print("pred", preds)
    return (m.result().numpy(), actual_pred.plot())


print("X_test",X_test)
my_LSTM_model, LSTM_prediction = LSTM_model(X_train, y_train, X_test, sc)
print("LSTM_prediction",LSTM_prediction)
LSTM_prediction[1:]
actual_pred_plot(LSTM_prediction)
plt.title('LSTM')
plt.xlabel('Time')
plt.ylabel('Total')
plt.legend(loc='upper left')
# plt.show()


def GRU_model(X_train,y_train,X_test,sc):


    my_GRU_model=Sequential()
    my_GRU_model.add(GRU(units=500,
                         return_sequences=True,
                         input_shape=(X_train.shape[1],1),
                         activation='tanh'
                         ))
    my_GRU_model.add(GRU(units=500,
                         activation='tanh'
                         ))
    my_GRU_model.add(Dense(units=2))
    my_GRU_model.compile(optimizer=gradient_descent_v2.SGD(learning_rate=0.01,decay=1e-7,momentum=0.9,nesterov=False),loss='mean_squared_error')

    my_GRU_model.fit(X_train,y_train,epochs=1000,batch_size=150,verbose=1)

    GRU_prediction=my_GRU_model.predict(X_test)

    GRU_prediction=sc.inverse_transform(GRU_prediction)
    print(GRU_prediction)




    return my_GRU_model,GRU_prediction

my_GRU_model,GRU_prediction = GRU_model(X_train,y_train,X_test,sc)
GRU_prediction[1:]

print(GRU_prediction[0])
actual_pred_plot(GRU_prediction)
plt.title('RSM')
plt.xlabel('Time')
plt.ylabel('Total')
plt.legend(loc='upper left')
plt.show()
# y_pred_gru=pd.DataFrame(GRU_prediction[:,0])
# y_test_gru=all_data.loc[701:,'total'][0:len(GRU_prediction)]
# y_test_gru.reset_index(drop=True,inplace=True)
