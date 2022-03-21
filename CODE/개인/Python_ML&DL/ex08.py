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
import matplotlib.pyplot as plt
import numpy as np
import pandas as pd
import pymysql

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
from keras.models import Sequential
from keras.layers import Dense,SimpleRNN,GRU
from keras.layers import *
from keras.models import *
from keras.utils import *
from keras.utils.np_utils import *
from sklearn.preprocessing import *
from sklearn.preprocessing import MinMaxScaler
from keras.models import Sequential
from keras.layers import Dense, SimpleRNN, GRU, LSTM
from keras.metrics import MeanSquaredError
from sklearn.preprocessing import MinMaxScaler
from sklearn.metrics import mean_absolute_error, mean_squared_error, mean_squared_log_error, r2_score

os.environ['TF_CPP_MIN_LOG_LEVEL']='3'