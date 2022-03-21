namespace Project_payment
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView_Parking_Car_View = new Sunny.UI.UIDataGridView();
            this.textBox_parking_spot = new Sunny.UI.UITextBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.textBox_phone_num = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.textBox_driver_name = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.textBox_carnum = new Sunny.UI.UITextBox();
            this.btn_del = new Sunny.UI.UIButton();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.btn_add = new Sunny.UI.UIButton();
            this.textBox_spot_manager = new Sunny.UI.UITextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uiButton5 = new Sunny.UI.UIButton();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.btn_park_in = new Sunny.UI.UIButton();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.uiGroupBox2 = new Sunny.UI.UIGroupBox();
            this.uiGroupBox3 = new Sunny.UI.UIGroupBox();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.button2 = new System.Windows.Forms.Button();
            this.parkingSpotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.driverNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parkingTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.result1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parkingCarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Parking_Car_View)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            this.uiGroupBox2.SuspendLayout();
            this.uiGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parkingCarBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Parking_Car_View
            // 
            this.dataGridView_Parking_Car_View.AllowUserToAddRows = false;
            this.dataGridView_Parking_Car_View.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(228)))), ((int)(((byte)(233)))));
            this.dataGridView_Parking_Car_View.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Parking_Car_View.AutoGenerateColumns = false;
            this.dataGridView_Parking_Car_View.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dataGridView_Parking_Car_View.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Parking_Car_View.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_Parking_Car_View.ColumnHeadersHeight = 32;
            this.dataGridView_Parking_Car_View.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_Parking_Car_View.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.parkingSpotDataGridViewTextBoxColumn,
            this.carNumberDataGridViewTextBoxColumn,
            this.driverNameDataGridViewTextBoxColumn,
            this.phoneNumberDataGridViewTextBoxColumn,
            this.parkingTimeDataGridViewTextBoxColumn,
            this.result1DataGridViewTextBoxColumn});
            this.dataGridView_Parking_Car_View.DataSource = this.parkingCarBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Parking_Car_View.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_Parking_Car_View.EnableHeadersVisualStyles = false;
            this.dataGridView_Parking_Car_View.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.dataGridView_Parking_Car_View.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(144)))), ((int)(((byte)(151)))));
            this.dataGridView_Parking_Car_View.Location = new System.Drawing.Point(369, 65);
            this.dataGridView_Parking_Car_View.Name = "dataGridView_Parking_Car_View";
            this.dataGridView_Parking_Car_View.ReadOnly = true;
            this.dataGridView_Parking_Car_View.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(144)))), ((int)(((byte)(151)))));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(228)))), ((int)(((byte)(233)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(144)))), ((int)(((byte)(151)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Parking_Car_View.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.dataGridView_Parking_Car_View.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView_Parking_Car_View.RowTemplate.Height = 23;
            this.dataGridView_Parking_Car_View.SelectedIndex = -1;
            this.dataGridView_Parking_Car_View.ShowGridLine = true;
            this.dataGridView_Parking_Car_View.Size = new System.Drawing.Size(879, 537);
            this.dataGridView_Parking_Car_View.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(228)))), ((int)(((byte)(233)))));
            this.dataGridView_Parking_Car_View.Style = Sunny.UI.UIStyle.Office2010Silver;
            this.dataGridView_Parking_Car_View.TabIndex = 1;
            this.dataGridView_Parking_Car_View.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Parking_Car_View_CellClick);
            this.dataGridView_Parking_Car_View.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Parking_Car_View_CellContentClick);
            // 
            // textBox_parking_spot
            // 
            this.textBox_parking_spot.ButtonSymbol = 61761;
            this.textBox_parking_spot.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.textBox_parking_spot.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.textBox_parking_spot.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.textBox_parking_spot.Location = new System.Drawing.Point(112, 28);
            this.textBox_parking_spot.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_parking_spot.Maximum = 2147483647D;
            this.textBox_parking_spot.Minimum = -2147483648D;
            this.textBox_parking_spot.MinimumSize = new System.Drawing.Size(1, 16);
            this.textBox_parking_spot.Name = "textBox_parking_spot";
            this.textBox_parking_spot.Size = new System.Drawing.Size(150, 29);
            this.textBox_parking_spot.Style = Sunny.UI.UIStyle.Custom;
            this.textBox_parking_spot.TabIndex = 3;
            this.textBox_parking_spot.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.textBox_parking_spot.TextChanged += new System.EventHandler(this.textBox_parking_spot_TextChanged);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.uiLabel4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.uiLabel4.Location = new System.Drawing.Point(13, 145);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(80, 23);
            this.uiLabel4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel4.TabIndex = 9;
            this.uiLabel4.Text = "전화 번호";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_phone_num
            // 
            this.textBox_phone_num.ButtonSymbol = 61761;
            this.textBox_phone_num.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.textBox_phone_num.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.textBox_phone_num.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.textBox_phone_num.Location = new System.Drawing.Point(112, 145);
            this.textBox_phone_num.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_phone_num.Maximum = 2147483647D;
            this.textBox_phone_num.Minimum = -2147483648D;
            this.textBox_phone_num.MinimumSize = new System.Drawing.Size(1, 16);
            this.textBox_phone_num.Name = "textBox_phone_num";
            this.textBox_phone_num.Size = new System.Drawing.Size(150, 29);
            this.textBox_phone_num.Style = Sunny.UI.UIStyle.Custom;
            this.textBox_phone_num.TabIndex = 8;
            this.textBox_phone_num.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.uiLabel3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.uiLabel3.Location = new System.Drawing.Point(25, 106);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(68, 23);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 7;
            this.uiLabel3.Text = "고객명";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.uiLabel2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.uiLabel2.Location = new System.Drawing.Point(13, 67);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(80, 23);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 7;
            this.uiLabel2.Text = "자량 번호";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_driver_name
            // 
            this.textBox_driver_name.ButtonSymbol = 61761;
            this.textBox_driver_name.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.textBox_driver_name.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.textBox_driver_name.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.textBox_driver_name.Location = new System.Drawing.Point(112, 106);
            this.textBox_driver_name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_driver_name.Maximum = 2147483647D;
            this.textBox_driver_name.Minimum = -2147483648D;
            this.textBox_driver_name.MinimumSize = new System.Drawing.Size(1, 16);
            this.textBox_driver_name.Name = "textBox_driver_name";
            this.textBox_driver_name.Size = new System.Drawing.Size(150, 29);
            this.textBox_driver_name.Style = Sunny.UI.UIStyle.Custom;
            this.textBox_driver_name.TabIndex = 6;
            this.textBox_driver_name.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.uiLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.uiLabel1.Location = new System.Drawing.Point(13, 28);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(80, 23);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 5;
            this.uiLabel1.Text = "주차 번호";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_carnum
            // 
            this.textBox_carnum.ButtonSymbol = 61761;
            this.textBox_carnum.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.textBox_carnum.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.textBox_carnum.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.textBox_carnum.Location = new System.Drawing.Point(112, 67);
            this.textBox_carnum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_carnum.Maximum = 2147483647D;
            this.textBox_carnum.Minimum = -2147483648D;
            this.textBox_carnum.MinimumSize = new System.Drawing.Size(1, 16);
            this.textBox_carnum.Name = "textBox_carnum";
            this.textBox_carnum.Size = new System.Drawing.Size(150, 29);
            this.textBox_carnum.Style = Sunny.UI.UIStyle.Custom;
            this.textBox_carnum.TabIndex = 6;
            this.textBox_carnum.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_del
            // 
            this.btn_del.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_del.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btn_del.Location = new System.Drawing.Point(172, 103);
            this.btn_del.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_del.Name = "btn_del";
            this.btn_del.RectSize = 2;
            this.btn_del.Size = new System.Drawing.Size(100, 35);
            this.btn_del.Style = Sunny.UI.UIStyle.Custom;
            this.btn_del.TabIndex = 10;
            this.btn_del.Text = "공간 삭제";
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // uiLabel8
            // 
            this.uiLabel8.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.uiLabel8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.uiLabel8.Location = new System.Drawing.Point(23, 37);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(80, 29);
            this.uiLabel8.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel8.TabIndex = 5;
            this.uiLabel8.Text = "주차 번호";
            this.uiLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel8.Click += new System.EventHandler(this.uiLabel8_Click);
            // 
            // btn_add
            // 
            this.btn_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_add.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btn_add.Location = new System.Drawing.Point(15, 103);
            this.btn_add.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_add.Name = "btn_add";
            this.btn_add.RectSize = 2;
            this.btn_add.Size = new System.Drawing.Size(100, 35);
            this.btn_add.Style = Sunny.UI.UIStyle.Custom;
            this.btn_add.TabIndex = 2;
            this.btn_add.Text = "공간 추가";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // textBox_spot_manager
            // 
            this.textBox_spot_manager.ButtonSymbol = 61761;
            this.textBox_spot_manager.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_spot_manager.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.textBox_spot_manager.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.textBox_spot_manager.Location = new System.Drawing.Point(122, 37);
            this.textBox_spot_manager.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_spot_manager.Maximum = 2147483647D;
            this.textBox_spot_manager.Minimum = -2147483648D;
            this.textBox_spot_manager.MinimumSize = new System.Drawing.Size(1, 16);
            this.textBox_spot_manager.Name = "textBox_spot_manager";
            this.textBox_spot_manager.Size = new System.Drawing.Size(150, 29);
            this.textBox_spot_manager.Style = Sunny.UI.UIStyle.Custom;
            this.textBox_spot_manager.TabIndex = 3;
            this.textBox_spot_manager.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(46, 403);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 2);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // uiButton5
            // 
            this.uiButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton5.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.uiButton5.Location = new System.Drawing.Point(162, 201);
            this.uiButton5.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton5.Name = "uiButton5";
            this.uiButton5.Size = new System.Drawing.Size(100, 35);
            this.uiButton5.Style = Sunny.UI.UIStyle.Custom;
            this.uiButton5.TabIndex = 11;
            this.uiButton5.Text = "정산";
            this.uiButton5.Click += new System.EventHandler(this.uiButton5_Click);
            // 
            // uiLabel5
            // 
            this.uiLabel5.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel5.Cursor = System.Windows.Forms.Cursors.Default;
            this.uiLabel5.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Bold);
            this.uiLabel5.ForeColor = System.Drawing.Color.Navy;
            this.uiLabel5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.uiLabel5.Location = new System.Drawing.Point(24, 4);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(334, 56);
            this.uiLabel5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel5.TabIndex = 12;
            this.uiLabel5.Text = "(주)KB 주차관리 프로그램";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel5.Click += new System.EventHandler(this.uiLabel5_Click);
            // 
            // btn_park_in
            // 
            this.btn_park_in.BackColor = System.Drawing.Color.Khaki;
            this.btn_park_in.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_park_in.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btn_park_in.Location = new System.Drawing.Point(17, 201);
            this.btn_park_in.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_park_in.Name = "btn_park_in";
            this.btn_park_in.RectSize = 2;
            this.btn_park_in.Size = new System.Drawing.Size(100, 35);
            this.btn_park_in.Style = Sunny.UI.UIStyle.Custom;
            this.btn_park_in.TabIndex = 11;
            this.btn_park_in.Text = "등록";
            this.btn_park_in.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button5.Location = new System.Drawing.Point(173, -3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(46, 40);
            this.button5.TabIndex = 17;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button6.Location = new System.Drawing.Point(121, 12);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(46, 25);
            this.button6.TabIndex = 16;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button7.Location = new System.Drawing.Point(225, 0);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(37, 34);
            this.button7.TabIndex = 15;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.uiGroupBox1.Controls.Add(this.button7);
            this.uiGroupBox1.Controls.Add(this.button6);
            this.uiGroupBox1.Controls.Add(this.button5);
            this.uiGroupBox1.FillColor = System.Drawing.Color.Transparent;
            this.uiGroupBox1.FillColor2 = System.Drawing.Color.Transparent;
            this.uiGroupBox1.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.uiGroupBox1.Location = new System.Drawing.Point(1004, 4);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.RectColor = System.Drawing.Color.Transparent;
            this.uiGroupBox1.Size = new System.Drawing.Size(265, 43);
            this.uiGroupBox1.Style = Sunny.UI.UIStyle.Custom;
            this.uiGroupBox1.TabIndex = 18;
            this.uiGroupBox1.Text = null;
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox1.Click += new System.EventHandler(this.uiGroupBox1_Click);
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.FillColor = System.Drawing.Color.Gold;
            this.uiButton1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiButton1.ForeColor = System.Drawing.Color.Black;
            this.uiButton1.Location = new System.Drawing.Point(1125, 614);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(123, 35);
            this.uiButton1.Style = Sunny.UI.UIStyle.Custom;
            this.uiButton1.TabIndex = 19;
            this.uiButton1.Text = "출/퇴근 관리";
            this.uiButton1.TipsFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click_1);
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.uiGroupBox2.Controls.Add(this.btn_del);
            this.uiGroupBox2.Controls.Add(this.textBox_spot_manager);
            this.uiGroupBox2.Controls.Add(this.uiLabel8);
            this.uiGroupBox2.Controls.Add(this.btn_add);
            this.uiGroupBox2.FillColor = System.Drawing.Color.Transparent;
            this.uiGroupBox2.FillColor2 = System.Drawing.Color.Transparent;
            this.uiGroupBox2.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiGroupBox2.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiGroupBox2.ForeColor = System.Drawing.Color.Transparent;
            this.uiGroupBox2.Location = new System.Drawing.Point(31, 444);
            this.uiGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox2.RectColor = System.Drawing.Color.Black;
            this.uiGroupBox2.RectSize = 2;
            this.uiGroupBox2.Size = new System.Drawing.Size(300, 158);
            this.uiGroupBox2.Style = Sunny.UI.UIStyle.Custom;
            this.uiGroupBox2.TabIndex = 23;
            this.uiGroupBox2.Text = "주차 공간 관리";
            this.uiGroupBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiGroupBox3
            // 
            this.uiGroupBox3.BackColor = System.Drawing.Color.Transparent;
            this.uiGroupBox3.Controls.Add(this.btn_park_in);
            this.uiGroupBox3.Controls.Add(this.textBox_carnum);
            this.uiGroupBox3.Controls.Add(this.textBox_parking_spot);
            this.uiGroupBox3.Controls.Add(this.uiLabel4);
            this.uiGroupBox3.Controls.Add(this.uiLabel1);
            this.uiGroupBox3.Controls.Add(this.textBox_phone_num);
            this.uiGroupBox3.Controls.Add(this.textBox_driver_name);
            this.uiGroupBox3.Controls.Add(this.uiLabel3);
            this.uiGroupBox3.Controls.Add(this.uiButton5);
            this.uiGroupBox3.Controls.Add(this.uiLabel2);
            this.uiGroupBox3.FillColor = System.Drawing.Color.Transparent;
            this.uiGroupBox3.FillColor2 = System.Drawing.Color.Transparent;
            this.uiGroupBox3.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiGroupBox3.Location = new System.Drawing.Point(41, 111);
            this.uiGroupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox3.Name = "uiGroupBox3";
            this.uiGroupBox3.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox3.RectColor = System.Drawing.Color.Black;
            this.uiGroupBox3.RectSize = 2;
            this.uiGroupBox3.Size = new System.Drawing.Size(290, 253);
            this.uiGroupBox3.Style = Sunny.UI.UIStyle.Custom;
            this.uiGroupBox3.TabIndex = 24;
            this.uiGroupBox3.Text = null;
            this.uiGroupBox3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel6
            // 
            this.uiLabel6.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel6.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLabel6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.uiLabel6.Location = new System.Drawing.Point(41, 429);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(169, 23);
            this.uiLabel6.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel6.TabIndex = 25;
            this.uiLabel6.Text = "주차 공간 관리";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel7
            // 
            this.uiLabel7.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel7.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLabel7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.uiLabel7.Location = new System.Drawing.Point(41, 95);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(169, 23);
            this.uiLabel7.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel7.TabIndex = 26;
            this.uiLabel7.Text = "주차 등록/정산";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button2.Location = new System.Drawing.Point(780, 608);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(52, 45);
            this.button2.TabIndex = 30;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // parkingSpotDataGridViewTextBoxColumn
            // 
            this.parkingSpotDataGridViewTextBoxColumn.DataPropertyName = "ParkingSpot";
            this.parkingSpotDataGridViewTextBoxColumn.HeaderText = "주차 번호";
            this.parkingSpotDataGridViewTextBoxColumn.Name = "parkingSpotDataGridViewTextBoxColumn";
            this.parkingSpotDataGridViewTextBoxColumn.ReadOnly = true;
            this.parkingSpotDataGridViewTextBoxColumn.Width = 130;
            // 
            // carNumberDataGridViewTextBoxColumn
            // 
            this.carNumberDataGridViewTextBoxColumn.DataPropertyName = "CarNumber";
            this.carNumberDataGridViewTextBoxColumn.HeaderText = "차량 번호";
            this.carNumberDataGridViewTextBoxColumn.Name = "carNumberDataGridViewTextBoxColumn";
            this.carNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.carNumberDataGridViewTextBoxColumn.Width = 130;
            // 
            // driverNameDataGridViewTextBoxColumn
            // 
            this.driverNameDataGridViewTextBoxColumn.DataPropertyName = "DriverName";
            this.driverNameDataGridViewTextBoxColumn.HeaderText = "고객명";
            this.driverNameDataGridViewTextBoxColumn.Name = "driverNameDataGridViewTextBoxColumn";
            this.driverNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.driverNameDataGridViewTextBoxColumn.Width = 130;
            // 
            // phoneNumberDataGridViewTextBoxColumn
            // 
            this.phoneNumberDataGridViewTextBoxColumn.DataPropertyName = "PhoneNumber";
            this.phoneNumberDataGridViewTextBoxColumn.HeaderText = "전화번호";
            this.phoneNumberDataGridViewTextBoxColumn.Name = "phoneNumberDataGridViewTextBoxColumn";
            this.phoneNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.phoneNumberDataGridViewTextBoxColumn.Width = 130;
            // 
            // parkingTimeDataGridViewTextBoxColumn
            // 
            this.parkingTimeDataGridViewTextBoxColumn.DataPropertyName = "ParkingTime";
            this.parkingTimeDataGridViewTextBoxColumn.HeaderText = "주차 시작 시간 ";
            this.parkingTimeDataGridViewTextBoxColumn.Name = "parkingTimeDataGridViewTextBoxColumn";
            this.parkingTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.parkingTimeDataGridViewTextBoxColumn.Width = 190;
            // 
            // result1DataGridViewTextBoxColumn
            // 
            this.result1DataGridViewTextBoxColumn.DataPropertyName = "result1";
            this.result1DataGridViewTextBoxColumn.HeaderText = "요금";
            this.result1DataGridViewTextBoxColumn.Name = "result1DataGridViewTextBoxColumn";
            this.result1DataGridViewTextBoxColumn.ReadOnly = true;
            this.result1DataGridViewTextBoxColumn.Width = 130;
            // 
            // parkingCarBindingSource
            // 
            this.parkingCarBindingSource.DataSource = typeof(Project_payment.ParkingCar);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1280, 661);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.uiLabel7);
            this.Controls.Add(this.uiLabel6);
            this.Controls.Add(this.uiGroupBox3);
            this.Controls.Add(this.uiGroupBox2);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.uiLabel5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_Parking_Car_View);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Parking_Car_View)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox2.ResumeLayout(false);
            this.uiGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.parkingCarBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UIDataGridView dataGridView_Parking_Car_View;
        private System.Windows.Forms.BindingSource parkingCarBindingSource;
        private Sunny.UI.UITextBox textBox_parking_spot;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UITextBox textBox_phone_num;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox textBox_driver_name;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox textBox_carnum;
        private Sunny.UI.UIButton btn_del;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UIButton btn_add;
        private Sunny.UI.UITextBox textBox_spot_manager;
        private System.Windows.Forms.Label label1;
        private Sunny.UI.UIButton uiButton5;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UIButton btn_park_in;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIGroupBox uiGroupBox2;
        private Sunny.UI.UIGroupBox uiGroupBox3;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UILabel uiLabel7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn parkingSpotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn carNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn driverNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn parkingTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn result1DataGridViewTextBoxColumn;
    }
}

