using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_payment
{
    public class DataManaber_form2

    {
        //const string ORADB = "Data Source=(DESCRIPTION=(ADDRESS_LIST=" +
        //       "(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))" +
        //       "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));" +
        //       "User Id=c##scott;Password=tiger;";
        const string ORADB = "Data Source=(DESCRIPTION=(ADDRESS_LIST=" +
              "(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))" +
              "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));" +
              "User Id=c##RYU;Password=newruh;";
        public static OracleConnection OraConn = new OracleConnection(ORADB);

        public static List<ParkingCar> cars = new List<ParkingCar>();
        const string TABLE = "ParkingCar";

        static void ConnectDB()
        {
            try
            {
                OraConn.Open();
            }
            catch (Exception ex)
            {

                throw new Exception("DB연결 애러" + ex.Message +
                    "애러 위치" + Environment.NewLine + ex.StackTrace);
            }
        }
        public static void selectQuery()
        {
            ConnectDB();
            string sql;
            sql = "select * from " + TABLE + " order by to_number(parkingspot)";
            OracleDataAdapter oda = new OracleDataAdapter();
            oda.SelectCommand = new OracleCommand();
            oda.SelectCommand.Connection = OraConn;
            oda.SelectCommand.CommandText = sql;

            DataSet ds = new DataSet();
            oda.Fill(ds, TABLE);

            cars.Clear();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                ParkingCar car = new ParkingCar();
                car.ParkingSpot = int.Parse(item["parkingspot"].ToString());
                car.CarNumber = item["carnumber"].ToString();
                car.DriverName = item["drivername"].ToString();
            
                car.result1 = item["result1"].ToString() + "원";

                cars.Add(car);
            }
            OraConn.Close();
        }

    }
}
