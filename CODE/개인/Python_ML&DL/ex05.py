
import pymysql


my_db = pymysql.connect(





)

cursor=my_db.cursor(pymysql.cursors.SSCursor)
sql="SELECT * from cvd_19"
cursor.execute(sql)
result = cursor.fetchall()
print(result)

