import datetime
import re
import sys

import requests
import requests
import pprint
from bs4 import BeautifulSoup
import json
import xmltodict
import xml.etree.ElementTree as et
import pandas as pd
from pandas.io.json import json_normalize
import pymysql
import datetime
import numpy as np
import matplotlib.pyplot as plt
from sklearn.model_selection import train_test_split
from sklearn.neighbors import  KNeighborsRegressor
from sklearn.metrics import mean_absolute_error
from sklearn.linear_model import LinearRegression

def getValue():
    today = str(datetime.date.today())
    today = today.replace("-", "")
    yes_day = str(int(today) - 1)

    url_all = 'http://openapi.data.go.kr/openapi/service/rest/Covid19/getCovid19InfStateJson?serviceKey=' \
              '&pageNo=1&numOfRows=10000&startCreateDt=20200101&endCreateDt=' + today
    url = url_all

    response = requests.get(url)
    contents = response.text
    
    js_string = json.dumps(xmltodict.parse(contents), indent=4)

    result = json.loads(js_string)
    arr_total = []
    arr_total_d = []
    arr_wdate = []
    arr_predate = []
    for temp in result['response']['body']['items']['item']:
        total = temp['decideCnt']
        total_d = temp['deathCnt']
        wdate = temp['seq']
        
        arr_total.append(int(total)) #누적 확진자
        arr_total_d.append(int(total_d)) #누적 사망자
        arr_wdate.append(int(wdate)) #번호(등록순)
        arr_predate.append(int(wdate) + 1) #예측 번호


    arr_total_np = np.array(arr_total)
    arr_wdate_np = np.array(arr_wdate)
    # print(arr_wdate_np[0])
    # print(arr_total_np)
    # print(arr_wdate_np)
    plt.scatter(arr_wdate_np,arr_total_np)
    plt.xlabel('date')
    plt.ylabel('total')
    # plt.show()

    train_input, test_input, train_target, test_target = train_test_split(arr_wdate_np , arr_total_np, random_state=42)


    train_input=train_input.reshape(-1,1)
    test_input=test_input.reshape(-1,1)

    knr=KNeighborsRegressor(n_neighbors=3)
    knr.fit(train_input,train_target)

    distances,indexes = knr.kneighbors([[792]])
    plt.scatter(train_input,train_target)
    plt.scatter(train_input[indexes],train_target[indexes],marker='D')
    plt.scatter(792,1400000,marker='^')
    plt.xlabel('total')
    plt.ylabel('cnt')
    plt.show()
    # print(np.mean(train_target[indexes]))


    # train_poly = np.column_stack((train_input**2,train_input))
    # test_poly = np.column_stack((test_input**2,test_input))

    # lr=LinearRegression()
    # lr.fit(train_input,train_target)
    # print(lr.predict([[790]]))









if __name__ == '__main__':
    getValue()


    

