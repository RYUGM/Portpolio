using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_payment
{
    public class DataManager
    {
        //const string ORADB = "Data Source=(DESCRIPTION=(ADDRESS_LIST=" +
        //       "(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))" +
        //       "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));" +
        //       "User Id=;Password=;";
        //const string ORADB = "Data Source=(DESCRIPTION=(ADDRESS_LIST=" +
        //      "(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))" +
        //      "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));" +
        //      "User Id=;Password=;";
        const string ORADB = "data source=(description=(address_list=" +
             "(address=(protocol=tcp)(host=localhost)(port=1522)))" +
             "(connect_data=(server=dedicated)(service_name=xe)));" +
             "user id=c##;password=;";
        public static OracleConnection OraConn = new OracleConnection(ORADB);

        public static List<ParkingCar> cars = new List<ParkingCar>();
        public static List<ParkingCar> cars2 = new List<ParkingCar>();
        public static List<history> his = new List<history>();
        public static List<history_total> his_t = new List<history_total>();

        const string TABLE = "ParkingCar";

        static void ConnectDB()
        {
            try
            {
                OraConn.Open();
            }
            catch (Exception ex)
            {
                OraConn.Close();
                
                throw new Exception(" ConnectDB() DB연결 애러" + ex.Message +
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
                car.PhoneNumber = item["phonenumber"].ToString();
                car.ParkingTime = item["parkingtime"].ToString() ==
                    "" ? new DateTime() : DateTime.Parse(item["parkingtime"].ToString());

                car.result1 = item["result1"].ToString()+"원";

                cars.Add(car);
            }
            OraConn.Close();
        }

        public static void selectQuery_form3(string wdate)
        {
            ConnectDB();
            string sql;
            //캘린더에서 특정 날자를 선택시 선택한 날의 총 수익금액과 그날 남긴 기록(출/퇴근 기록, 전달사항 기록 등...)
            //을 parking_histroy 테이블 에서 가져오게 됩니다만, 문제는 금액과 전달사항이 동시에 담겨져 있을수가 없습니다.
            // 그래서 총 금액은 sum 함수를 통해 가져오고 기록은 not null 함수를 사용해서 빈값을 제외한 값만 추려올 수 있었습니다.
            sql = $"select post from parkingcar_history WHERE wdate='{wdate}' AND not post is null ORDER BY wdate";
            OracleDataAdapter oda = new OracleDataAdapter();
            oda.SelectCommand = new OracleCommand();
            oda.SelectCommand.Connection = OraConn;
            oda.SelectCommand.CommandText = sql;

            DataSet ds = new DataSet();
            oda.Fill(ds, TABLE);

             his.Clear();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                history hi = new history();
                
               
                hi.post = item["post"].ToString();
               
                his.Add(hi);

            }
            OraConn.Close();
            
        }
        public static void selectQuery_form3_total(string wdate)
        {

            ConnectDB();
            string sql;
            //wdate에는 오늘 날자가 예를들면 2022-01-25 같은 형식으로 저장되어 있습니다. 
            //이 wdate와 현재 캘린더가 가리키는값(기본값 = 오늘 날자) 이 같은 부분만 선택하고
            //캘린더가 가리키는 날자에 해당하는 날의 total 에 저장되어있는 최종 결제 금액을 찾아서
            //sum 함수를 통해 모두 더하면 캘린더가 가리키는 날의 총 결제 금액의 합이 나오게 됩니다.
            sql = $"select sum(total) as total from parkingcar_history where wdate='{wdate}'";

            OracleDataAdapter oda = new OracleDataAdapter();
            oda.SelectCommand = new OracleCommand();
            oda.SelectCommand.Connection = OraConn;
            oda.SelectCommand.CommandText = sql;

            DataSet ds = new DataSet();
            oda.Fill(ds, TABLE);

            his_t.Clear();
           
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                history_total hi_t = new history_total();
               
                hi_t.total = item["total"].ToString();
              

                his_t.Add(hi_t);
            }
            OraConn.Close();
        }



        public static ParkingCar selectQuery_Form2(int parkingspot)
        {
            ConnectDB();

            string sql;
            ParkingCar car = new ParkingCar();
            try
            {
                sql = $"select * from {TABLE} where PARKINGSPOT={parkingspot}";
            OracleDataAdapter oda = new OracleDataAdapter();
            oda.SelectCommand = new OracleCommand();
            oda.SelectCommand.Connection = OraConn;
            oda.SelectCommand.CommandText = sql;

            DataSet ds = new DataSet();
            oda.Fill(ds, TABLE);

            //cars.Clear();
            //foreach (DataRow item in ds.Tables[0].Rows)
            {
                DataRow item = ds.Tables[0].Rows[0];
                car.ParkingSpot = int.Parse(item["parkingspot"].ToString());
                car.CarNumber = item["carnumber"].ToString();
                car.result1 = item["result1"].ToString() + "원";

                    // cars.Add(car);
                }
            }
            catch (Exception ex)
            {
                OraConn.Close();
                System.Windows.Forms.MessageBox.Show("selectQuery_Form2" + ex.Message + "___" + ex.StackTrace);
            }
            OraConn.Close();
            return car;
        }


        public static ParkingCar selectQuery(int spot)
        {
            ConnectDB();
            ParkingCar car = new ParkingCar();
            try
            {
                string sql;
                sql = "select * from " + TABLE + " where parkingspot=" + spot + " order by to_number(parkingspot)";
                OracleDataAdapter oda = new OracleDataAdapter();
                oda.SelectCommand = new OracleCommand();
                oda.SelectCommand.Connection = OraConn;
                oda.SelectCommand.CommandText = sql;

                DataSet ds = new DataSet();
                oda.Fill(ds, TABLE);


                DataRow item = ds.Tables[0].Rows[0];
                car.ParkingSpot = int.Parse(item["parkingspot"].ToString());
                car.CarNumber = item["Carnumber"].ToString();
                car.DriverName = item["Drivername"].ToString();
                car.PhoneNumber = item["Phonenumber"].ToString();
                car.ParkingTime = item["Parkingtime"].ToString() ==
                    "" ? new DateTime() : DateTime.Parse(item["parkingtime"].ToString());

                car.result1 = item["result1"].ToString() + "원";
            }
            catch (Exception ex)
            {
                OraConn.Close();
                System.Windows.Forms.MessageBox.Show("selectQuery(int spot)"+ex.Message+"+"+ex.StackTrace);
            }

            OraConn.Close();
            return car;
        }

        static string Query(string menu, string parkingspot, string carnumber, string drivername, string phonenumber)
        {
            string query = "";
            switch (menu)
            {
                case "update":
                    query = $"update {TABLE} set " +
                        $"carnumber='{carnumber}',drivername='{drivername}'," +
                        $"phonenumber='{phonenumber}', parkingtime=sysdate , " +
                        //result 에 처음 주차공간에 차량을 등록 한 시점의 시간을 분단위로 변환해서 저장해 두어서,
                        //나중에 결제할때 결제할때의 시간(분단위로 바꾼) 빼기 이때 result에 저장한 시간에 곱하기 1000을 해서 
                        //시간당 천원을 부과 할 수 있게 됩니다.
                        $"result=(select round(to_char(systimestamp ,'sssss')/60) FROM parkingcar WHERE parkingspot={parkingspot}) " +

                        $" where parkingspot={parkingspot}";
                 
                    break;
                case "insert":
                    query = $"insert into {TABLE} (parkingspot) values({parkingspot})";
                    break;
                case "delete":
                    query = $"delete from {TABLE} where parkingspot = {parkingspot}";
                    break;

                default:
                    break;
            }
            return query;
        }

        static string Query_form3(string wdate,string post)
        {
            string query = $"insert into parkingcar_history (wdate,post) VALUES('{wdate}','{post}')";
           
                
              
                   
            return query;
        }
        static string Query_form3_total(string wdate, string total)
        {
            //결제 버튼을 누르면 parkingcar_history 테이블에 결제 한 날자(2022-01-01 형식)와 
            //결제한 최종 금액이 저장되어집니다.
            string query = $"insert into parkingcar_history (wdate,total) VALUES('{wdate}','{total}')";




            return query;
        }
        static string Query(string parkingspot)
        {

            //여기서 DB 쿼리로 (정산버튼을 누른 시간) - (주차 시작한시간) 곱하기 1000 을 해서 시간당 천원의 요금이 발생
           
            string query = $"update parkingcar set result1 = " +
                $"((SELECT ROUND((TO_DATE(sysdate) - TO_DATE(parkingtime)) * 24)*1000 " +
                $"FROM parkingcar WHERE parkingspot ={parkingspot})) WHERE parkingspot = {parkingspot}";
            


            return query;
        }
        public static void executeQuery(string menu, string parkingspot, string carnumber = null, string drivername = null, string phonenumber = null)
        {
            ConnectDB();
            string query = "";

            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = OraConn;
                query = Query(menu, parkingspot, carnumber, drivername, phonenumber);
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                OraConn.Close();
                throw new Exception("executeQuery(string menu, string parkingspot, string carnumber = null, string drivername = null, string phonenumber = null)" + ex.Message+"_"+ex.StackTrace);
            }

            OraConn.Close();

            selectQuery();
        }

        public static void executeQuery_form3(string wdate,string post)
        {
            ConnectDB();
            string query = "";

            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = OraConn;
                query = Query_form3(wdate,post);
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
            OraConn.Close();
                throw new Exception("executeQuery_form3"+ex.Message+"__"+ex.StackTrace);
            }

            OraConn.Close();

            //selectQuery_form3(wdate);
        }
        public static void executeQuery_form3_total(string wdate, string total)
        {
            ConnectDB();
            string query = "";

            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = OraConn;
                query = Query_form3_total(wdate, total);
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
            OraConn.Close();
                throw new Exception("executeQuery_form3_total" + ex.Message + "__" + ex.StackTrace);
            }

            OraConn.Close();

            //selectQuery_form3(wdate);
        }
        public static void executeQuery_charge(string parkingspot)
        {

            ConnectDB();
            //result1에 (현재시간을 분으로 바꾼 값) 빼기 (result에 저장된 주차 시작 시간을 분으로 바꾼값) 곱하기 1000(시간당 천원)
            //을 해 주어서 결과적으로 result1에 주차 시작 시작시간과 결제할때의 시간 만큼의 시간차이에 천원을 부과해서 최종 결제 금액을 산출
            string query = $"update parkingcar set result1 = " +
                $"round(((select trunc(((to_char(systimestamp ,'sssss')/60) - to_char(result)))  " +
                $"from parkingcar where parkingspot = {parkingspot})/ 60)*1000) " +
                $"WHERE parkingspot = {parkingspot}";


            try
            {

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = OraConn;
                //query = Query(parkingspot);
                //update와 주차 번호를 Query에 담고 실행
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = $"insert into parkingcar_history ()";

            }
            catch (Exception ex)
            {
                OraConn.Close();
                //throw;
               throw new Exception("executeQuery_charge" + ex.Message + "~~" + Environment.NewLine + ex.StackTrace);
                //query
            }

            OraConn.Close();

            selectQuery();
        }
        public static void executeQuery_refresh()
        {

            ConnectDB();
            string query = $"update parkingcar set result1 = round(((trunc((to_char(systimestamp ,'sssss')/60)-to_char(result)))/60)*1000)";

            try
            {

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = OraConn;
                //query = Query(parkingspot);
                //update와 주차 번호를 Query에 담고 실행
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                OraConn.Close();
                //throw;
                throw new Exception(ex.Message + "~~" + Environment.NewLine + ex.StackTrace);
                //query
            }

            OraConn.Close();

            selectQuery();
        }

   
        public static void executeQuery_refresh1(int pot)
        {

            ConnectDB();
            string query = $"update parkingcar set result1 = round(((trunc((to_char(systimestamp ,'sssss')/60)-to_char(result)))/60)*1000) where PARKINGSPOT={pot}";

            try
            {

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = OraConn;
                //query = Query(parkingspot);
                //update와 주차 번호를 Query에 담고 실행
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
              
            OraConn.Close();

                throw new Exception("executeQuery_refresh1"+ex.Message + "__" + ex.StackTrace);

            }

            OraConn.Close();
        }
    }

}
