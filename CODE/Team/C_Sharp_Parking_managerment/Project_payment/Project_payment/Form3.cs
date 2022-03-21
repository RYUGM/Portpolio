using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_payment
{
    public partial class Form3 : Form
    {

        bool isGoToWork = true;
        public Form3()
        {


            InitializeComponent();
            uiDatePicker1.Value = System.DateTime.Now;
            uiRadioButton1.Checked=true;


            DataManager.selectQuery_form3_total(uiDatePicker1.Text);

            DataManager.selectQuery_form3(uiDatePicker1.Text);
           

           

            try
            {
                uiLabel1.Text = uiDatePicker1.Text + " 총 수익:";
                uiLabel2.Text = DataManager.his_t[0].total + "원";
                
            }
            catch (Exception)
            {

                throw;
            }
            refreshScreen();






        }
        void refreshScreen()
        {
            this.uiDataGridView1.DataSource = null;
            uiLabel2.Text = DataManager.his_t[0].total+"원";

            //dataGridView_Parking_Car_View1.DataSource = null;
            try
            {
                if (DataManager.his.Count > 0)
                {
                    this.uiDataGridView1.DataSource = DataManager.his;

                    //dataGridView_Parking_Car_View1.DataSource = DataManager.cars;
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void uiDatePicker1_ValueChanged(object sender, DateTime value)
        {
           
            
            DataManager.selectQuery_form3_total(uiDatePicker1.Text);
            DataManager.selectQuery_form3(uiDatePicker1.Text);
            
            
            

            try
            {
                uiLabel1.Text = uiDatePicker1.Text + " 총 수익:";
                uiLabel2.Text = DataManager.his_t[0].total + "원";
               

            }
            catch (Exception)
            {

                throw;
            }
            refreshScreen();


        }

        private void uiTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiDatePicker1_Click(object sender, EventArgs e)
        {
            
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (uiTextBox1.Text == "")
            {
                MessageBox.Show("메시지를 입력하세요");
                return;
            }

            DataManager.executeQuery_form3(uiDatePicker1.Text,uiTextBox1.Text);
            //DataManager.executeQuery_refresh_form3();
           
            DataManager.selectQuery_form3(uiDatePicker1.Text);
            refreshScreen();
            //try
            //{
            //    if (uiDatePicker1.Text == "")
            //    {
            //        MessageBox.Show("날자를 입력하세요");
            //        return;
            //    }

            //ParkingCar car = DataManager.selectQuery(int.Parse(textBox_parking_spot.Text));
            //    if ()
            //    {
            //        MessageBox.Show("이미 주차 됨");
            //    }
            //    else
            //    {
            //        DataManager.executeQuery("update", textBox_parking_spot.Text, textBox_carnum.Text,
            //            textBox_driver_name.Text, textBox_phone_num.Text);
            //        DataManager.selectQuery();
            //        DataManager.executeQuery_refresh();
            //        refreshScreen();

            //    }
            //}
            //catch (Exception ex)
            //{

            //    throw;
            //} 

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void uiLabel2_Click(object sender, EventArgs e)
        {
            
        }

        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }

        private void uiDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void uicheckd(object sender, EventArgs e)
        {

            if ((sender as UIRadioButton).Text == "출근")
                isGoToWork = true;
            else
                isGoToWork = false;
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            if (uiTextBox2.Text == "")
            {
                MessageBox.Show("이름 입력");
                return;
            }

            if (isGoToWork)
                uiTextBox3.Text = DateTime.Now.ToString() + uiTextBox2.Text + " 출근";
            else
                uiTextBox3.Text = DateTime.Now.ToString() + uiTextBox2.Text + " 퇴근";

            DataManager.executeQuery_form3(uiDatePicker1.Text, uiTextBox3.Text);
            DataManager.selectQuery_form3(uiDatePicker1.Text);
            refreshScreen();
        }

        private void uiGroupBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
