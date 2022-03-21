# from tensorflow.keras.optimizers import SGD
from keras.optimizers import gradient_descent_v2
import os
import numpy as np
import pandas as pd
import yfinance as yf
import matplotlib.pyplot as plt
from sklearn.preprocessing import MinMaxScaler
from keras.models import Sequential
from keras.layers import Dense,SimpleRNN,GRU,LSTM
from keras import optimizers
from keras.optimizers import *
# SGD = keras.optimizer_experimental.sgd.SGD
os.environ['TF_CPP_MIN_LOG_LEVEL']='3'


AMZN = yf.download('AMZN',
                   start='2013-01-01',
                   end='2019-12-31',
                   progress=False
                   )
print(AMZN)
all_data=AMZN[['Adj Close','Open',"High",'Low',"Close","Volume"]].round(2)
all_data.head(10)
all_data.head(10)


print("2018",str(all_data[:'2018'].shape))
print("2019",str(all_data['2019':].shape))
# all_data['Adj Close'].plot()
# plt.show()
sc = MinMaxScaler(feature_range=(0, 1))


# def ts_tarin_test(all_data,time_steps,for_periods):
#     ts_train=all_data[:'2018'].iloc[:,0:1].values
#     ts_test = all_data['2019':].iloc[:,0:1].values
#     ts_train_len = len(ts_train)
#     ts_test_len= len(ts_test)
#
#     # sc=MinMaxScaler(feature_range=(0,1))
#     ts_train_scaled=sc.fit_transform(ts_train)
#
#     X_train=[]
#     y_train = []
#     y_train_stacked=[]
#     for i in range(time_steps,ts_train_len -1):
#         X_train.append(ts_train[i-time_steps:i,0])
#         y_train.append(ts_train[i:i+for_periods,0])
#     X_train,y_train=np.array(X_train),np.array(y_train)
#
#     X_train=np.reshape(X_train,(X_train.shape[0],X_train.shape[1],1))
#
#     inputs=pd.concat((all_data["Adj Close"][:'2018'],all_data["Adj Close"]["2019":]),axis=0).values
#     inputs=inputs[len(inputs)-len(ts_test)-time_steps:]
#     inputs= inputs.reshape(-1,1)
#     X_test=[]
#     for i in range(time_steps,ts_test_len+time_steps-for_periods):
#         X_test.append(inputs[i-time_steps:i,0])
#     X_test=np.array(X_test)
#     X_test=np.reshape(X_test,(X_test.shape[0],X_test.shape[1],1))
#     return X_train,y_train,X_test


def ts_train_test_normalize(all_data, time_steps, for_periods):
    """
    input:
        data: dataframe with dates and price data
    output:
        X_train, y_train: data from 2013/1/1-2018/12/31
        X_test : data from 2019-
        sc :     insantiated MinMaxScaler object fit to the training data
    """
    # create training and test set
    #1부터 2018까지 1500개?
    ts_train = all_data[:'2018'].iloc[:, 0:1].values
    #2019부터 끝까지 200개?
    ts_test = all_data['2019':].iloc[:, 0:1].values
    ts_train_len = len(ts_train)
    ts_test_len = len(ts_test)

    # scale the data
    from sklearn.preprocessing import MinMaxScaler
    #0,1로 변환
    sc = MinMaxScaler(feature_range=(0, 1))
    ts_train_scaled = sc.fit_transform(ts_train)

    # create training data of s samples and t time steps
    X_train = []
    y_train = []
    for i in range(time_steps, ts_train_len - 1):
        X_train.append(ts_train_scaled[i - time_steps:i, 0])
        y_train.append(ts_train_scaled[i:i + for_periods, 0])
    X_train, y_train = np.array(X_train), np.array(y_train)

    # Reshaping X_train for efficient modelling
    X_train = np.reshape(X_train, (X_train.shape[0], X_train.shape[1], 1))

    inputs = pd.concat((all_data["Adj Close"][:'2018'], all_data["Adj Close"]['2019':]), axis=0).values
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

X_train, y_train, X_test, sc = ts_train_test_normalize(all_data, 5,2)
X_train.shape[0], X_train.shape[1]
# Convert the 3D shape of X_train to a data frame so we can see:
X_train_see = pd.DataFrame(np.reshape(X_train, (X_train.shape[0], X_train.shape[1])))
y_train_see = pd.DataFrame(y_train)
pd.concat([X_train_see, y_train_see], axis = 1)

# Convert the 3D shape of X_test to a data frame so we can see:
X_test_see = pd.DataFrame(np.reshape(X_test, (X_test.shape[0], X_test.shape[1])))
pd.DataFrame(X_test_see)

print("There are " + str(X_train.shape[0]) + " samples in the training data")
print("There are " + str(X_test.shape[0]) + " samples in the test data")
# X_train,y_train,X_test=ts_tarin_test(all_data,5,2)
# X_train_see = pd.DataFrame(np.reshape(X_train,(X_train.shape[0],X_train.shape[1])))
# y_train_see= pd.DataFrame(y_train)
# pd.concat([X_train_see,y_train_see],axis=1)
#
# X_test_see = pd.DataFrame(np.reshape(X_test,(X_test.shape[0],X_test.shape[1])))
# pd.DataFrame(X_test_see)
#
# print("train",X_train)
# print("test",X_test)

def LSTM_model(X_train, y_train, X_test, sc):
    # create a model
    from keras.models import Sequential
    from keras.layers import Dense, SimpleRNN, GRU, LSTM
    # from keras.optimizers import SGD

    # The LSTM architecture
    my_LSTM_model = Sequential()
    my_LSTM_model.add(LSTM(units=50,
                           return_sequences=True,
                           input_shape=(X_train.shape[1], 1),
                           activation='tanh'))
    my_LSTM_model.add(LSTM(units=50, activation='tanh'))
    my_LSTM_model.add(Dense(units=2))

    # Compiling
    my_LSTM_model.compile(optimizer=gradient_descent_v2.SGD(learning_rate=0.01, decay=1e-7,
                                        momentum=0.9, nesterov=False),
                          loss='mean_squared_error')

    # Fitting to the training set
    my_LSTM_model.fit(X_train, y_train, epochs=50, batch_size=150, verbose=0)

    LSTM_prediction = my_LSTM_model.predict(X_test)
    LSTM_prediction = sc.inverse_transform(LSTM_prediction)

    return my_LSTM_model, LSTM_prediction


def actual_pred_plot(preds):
    """
    Plot the actual vs predition
    """
    actual_pred = pd.DataFrame(columns=['Adj. Close', 'prediction'])
    actual_pred['Adj. Close'] = all_data.loc['2019':, 'Adj Close'][0:len(preds)]
    actual_pred['prediction'] = preds[:, 0]

    from keras.metrics import MeanSquaredError
    m = MeanSquaredError()
    m.update_state(np.array(actual_pred['Adj. Close']), np.array(actual_pred['prediction']))

    return (m.result().numpy(), actual_pred.plot())



my_LSTM_model, LSTM_prediction = LSTM_model(X_train, y_train, X_test, sc)
LSTM_prediction[1:10]
actual_pred_plot(LSTM_prediction)
# plt.show()
from sklearn.metrics import mean_absolute_error, mean_squared_error, mean_squared_log_error, r2_score


def confirm_result(y_test, y_pred):
    MAE = mean_absolute_error(y_test, y_pred)
    RMSE = np.sqrt(mean_squared_error(y_test, y_pred))
    MSLE = mean_squared_log_error(y_test, y_pred)
    RMSLE = np.sqrt(mean_squared_log_error(y_test, y_pred))
    R2 = r2_score(y_test, y_pred)

    # pd.options.display.   float_format = '{:.5f}'.format()
    Result = pd.DataFrame(data=[MAE, RMSE, RMSLE, R2],
                          index=["MAE", "RMSE", "RMSLE", "R2"],
                          columns=['RESULTS'])
    return Result


def GRU_model(X_train,y_train,X_test,sc):
    from keras.models import Sequential
    from  keras.layers import Dense,SimpleRNN,GRU

    my_GRU_model=Sequential()
    my_GRU_model.add(GRU(units=50,
                         return_sequences=True,
                         input_shape=(X_train.shape[1],1),
                         activation='tanh'
                         ))
    my_GRU_model.add(GRU(units=50,
                         activation='tanh'
                         ))
    my_GRU_model.add(Dense(units=2))
    my_GRU_model.compile(optimizer=gradient_descent_v2.SGD(learning_rate=0.01,decay=1e-7,momentum=0.9,nesterov=False),loss='mean_squared_error')

    my_GRU_model.fit(X_train,y_train,epochs=50,batch_size=150,verbose=1)
    GRU_prediction=my_GRU_model.predict(X_test)
    GRU_prediction=sc.inverse_transform(GRU_prediction)



    return my_GRU_model,GRU_prediction

my_GRU_model,GRU_prediction = GRU_model(X_train,y_train,X_test,sc)
GRU_prediction[1:10]
actual_pred_plot(GRU_prediction)
plt.xlabel('dd')
plt.ylabel('aa')
plt.show()
y_pred_gru=pd.DataFrame(GRU_prediction[:,0])
y_test_gru=all_data.loc['2019':,'Adj Close'][0:len(GRU_prediction)]
y_test_gru.reset_index(drop=True,inplace=True)
confirm_result(y_test_gru,y_pred_gru)





