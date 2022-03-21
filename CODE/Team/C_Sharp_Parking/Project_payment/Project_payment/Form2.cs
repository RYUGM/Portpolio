using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_payment
{
    public partial class Form2 : Form
    {
        ParkingCar parkingCar = new ParkingCar();

        public Form2(ParkingCar car)
        {
            InitializeComponent();
            parkingCar = car;
            uiDatePicker1.Value = System.DateTime.Now;
            result_for_charge.Add(parkingCar);
            uiTextBox1.Text = (car.ParkingSpot.ToString());

            int spot = int.Parse(uiTextBox1.Text);
            DataManager.executeQuery_refresh1(spot);
            parkingCar = DataManager.selectQuery(spot);

            refreshScreen();

        }

        void refreshScreen()
        {

            dataGridView_Parking_Car_View.DataSource = null;
            try
            {
                // this.dataGridView_Parking_Car_View.DataSource = DataManager.cars;

                //뭔데 씨발 진짜 
                result_for_charge[0] = parkingCar;
                dataGridView_Parking_Car_View.DataSource = result_for_charge;
                //dataGridView_Parking_Car_View.Refresh();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message+"_"+ex.StackTrace);
            }
        }

      


        private void button7_Click(object sender, EventArgs e)
        {
            DataManager.executeQuery_refresh();
            //DataManager.selectQuery();
            //refreshScreen();
            Close();    
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (uiTextBox1.Text == "")
                {
                    MessageBox.Show("주차 공간 입력 하세요");
                    return;
                }

                ParkingCar car = DataManager.selectQuery(int.Parse(uiTextBox1.Text));
                if (car.CarNumber == "")
                {
                    MessageBox.Show("아직 차가 없습니다.");
                }
               
                else
                {


                    DataManager.executeQuery_refresh1(int.Parse(uiTextBox1.Text));

                    parkingCar = DataManager.selectQuery(int.Parse(uiTextBox1.Text));
                    refreshScreen();


                }
            }
            catch (Exception ex)
            {

                throw;
            }
        
    }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (uiTextBox1.Text == "")
                {
                    MessageBox.Show("주차 공간 입력 하세요");
                    return;
                }
                if (uiTextBox2.Text == "")
                {
                    MessageBox.Show("결제 방법 선택");
                    return;
                }

                ParkingCar car = DataManager.selectQuery(int.Parse(uiTextBox1.Text));
                if (car.CarNumber == "")
                {
                    MessageBox.Show("아직 차가 없습니다.");
                }
                else
                {
                    
                    
                    string result = DataManager.cars[0].result1;
                    string tempsrt = Regex.Replace(result, @"\D", "");

                    DataManager.executeQuery_form3_total(uiDatePicker1.Text, tempsrt);



                    DataManager.executeQuery("update", uiTextBox1.Text, "", "", "");

                    DataManager.executeQuery_refresh1(int.Parse(uiTextBox1.Text));

                    parkingCar = DataManager.selectQuery(int.Parse(uiTextBox1.Text));
                    refreshScreen();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void uiRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            uiTextBox2.Text = "현금/카드 결제";
        }

        private void uiRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            uiTextBox2.Text = "VIP";
        }

        private void uiRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            uiTextBox2.Text = "영수증고객";
        }

        private void dataGridView_Parking_Car_View_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_Parking_Car_View_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                Console.WriteLine("...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+"..."+ex.StackTrace);
            }
        }
    }
}
