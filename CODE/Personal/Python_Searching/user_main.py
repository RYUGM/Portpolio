import datetime

from PyQt5 import uic
import sys
import smtplib
from PyQt5.QtWidgets import *
from email.mime.multipart import MIMEMultipart
from email.mime.text import MIMEText
from  openpyxl import *
form_class = uic.loadUiType("for_user.ui")[0]
class MainWindow(QMainWindow,form_class):
    def __init__(self):
        super().__init__()

        self.setupUi(self)

        # self.link_btn.clicked.connect(self.)
        # self.num_btn.clicked.connect(self.)
        # self.addr_btn.clicked.connect(self.)
        # self.password_btn.clicked.connect(self.)
        self.pushButton.clicked.connect(self.create_btn)
        self.send_btn.clicked.connect(self.send_to_RYU)

    def create_btn(self):
        wb=Workbook()
        ws=wb.active
        ws.append(['Email','Subscribe',	'Item','CPrice','SPrice','RESULT','Name','HTML','Alter'])

        wb.save("Phase11.xlsx")
        wb.close()



    def send_to_RYU(self):
        wb=load_workbook("Phase11.xlsx")
        ws=wb.active
        print("??")
        now = datetime.datetime.now()
        print(now)

        link=self.lineEdit.text()
        price=self.lineEdit_3.text()

        print(str(link),int(price))

        ws.append([str(now),1,link,int(price)])
        print(link,price)

        wb.save("Phase11.xlsx")
        wb.close()


if __name__ == "__main__":
    app=QApplication(sys.argv)

    myWindow = MainWindow()
    myWindow.show()
    app.exec_()