import matplotlib.pyplot as plt
from scipy.optimize import curve_fit
import numpy as np


def func(x, a, b):
    return a * np.exp(b * x)


day = np.arange(1, 16)
cases = np.array([30, 30, 31, 51, 104, 204, 433, 602, 833, 977, 1261, 1766, 2337, 3150, 3736])
plt.plot(day, cases, 'co', label='Total Number of Cases (Korea)')

popt, pcov = curve_fit(func, day, cases, p0=(1, 0.1))
plt.plot(day, func(day, *popt), 'r-', alpha=0.5, label='fit: a = %5.3f, b = %5.3f' % tuple(popt))


plt.xlabel('Days Since January 16')
plt.ylabel('Total Number of Cases (Korea)')
plt.legend()
plt.show()