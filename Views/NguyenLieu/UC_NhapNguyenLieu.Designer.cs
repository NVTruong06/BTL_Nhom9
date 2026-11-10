namespace LTTQ_BTL.Views.NguyenLieu
{
    partial class UC_NhapNguyenLieu
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            panel1 = new Panel();
            dateTimePicker1 = new DateTimePicker();
            textBox7 = new TextBox();
            textBox6 = new TextBox();
            button2 = new Button();
            button1 = new Button();
            comboBox4 = new ComboBox();
            comboBox3 = new ComboBox();
            textBox5 = new TextBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(20, 42);
            label1.Name = "label1";
            label1.Size = new Size(253, 41);
            label1.TabIndex = 9;
            label1.Text = "Nhập nguyên liệu";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(textBox7);
            panel1.Controls.Add(textBox6);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(comboBox4);
            panel1.Controls.Add(comboBox3);
            panel1.Controls.Add(textBox5);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(20, 86);
            panel1.Name = "panel1";
            panel1.Size = new Size(777, 396);
            panel1.TabIndex = 10;
            panel1.Paint += panel1_Paint;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Anchor = AnchorStyles.None;
            dateTimePicker1.Location = new Point(23, 165);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 22;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // textBox7
            // 
            textBox7.Anchor = AnchorStyles.None;
            textBox7.Location = new Point(526, 62);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(215, 27);
            textBox7.TabIndex = 21;
            // 
            // textBox6
            // 
            textBox6.Anchor = AnchorStyles.None;
            textBox6.Location = new Point(526, 12);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(215, 27);
            textBox6.TabIndex = 20;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.Location = new Point(425, 337);
            button2.Name = "button2";
            button2.Size = new Size(120, 40);
            button2.TabIndex = 19;
            button2.Text = "xác nhận";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.Location = new Point(233, 337);
            button1.Name = "button1";
            button1.Size = new Size(120, 40);
            button1.TabIndex = 18;
            button1.Text = "Quay lại";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox4
            // 
            comboBox4.Anchor = AnchorStyles.None;
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(153, 112);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(214, 28);
            comboBox4.TabIndex = 17;
            // 
            // comboBox3
            // 
            comboBox3.Anchor = AnchorStyles.None;
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(153, 62);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(214, 28);
            comboBox3.TabIndex = 16;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // textBox5
            // 
            textBox5.Anchor = AnchorStyles.None;
            textBox5.Location = new Point(153, 12);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(214, 27);
            textBox5.TabIndex = 15;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.None;
            label10.AutoSize = true;
            label10.Location = new Point(23, 115);
            label10.Name = "label10";
            label10.Size = new Size(124, 20);
            label10.TabIndex = 14;
            label10.Text = "Tên nhà cung cấp";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.None;
            label9.AutoSize = true;
            label9.Location = new Point(23, 65);
            label9.Name = "label9";
            label9.Size = new Size(99, 20);
            label9.TabIndex = 13;
            label9.Text = "Tên nhân viên";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.AutoSize = true;
            label8.Location = new Point(23, 15);
            label8.Name = "label8";
            label8.Size = new Size(89, 20);
            label8.TabIndex = 12;
            label8.Text = "Mã hóa đơn";
            label8.Click += label8_Click;
            // 
            // textBox4
            // 
            textBox4.Anchor = AnchorStyles.None;
            textBox4.Location = new Point(233, 288);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(362, 27);
            textBox4.TabIndex = 10;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.None;
            textBox3.Location = new Point(526, 212);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(215, 27);
            textBox3.TabIndex = 9;
            textBox3.TextChanged += TinhThanhTien;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.None;
            textBox2.Location = new Point(526, 162);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(215, 27);
            textBox2.TabIndex = 8;
            textBox2.TextChanged += TinhThanhTien;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.None;
            textBox1.Location = new Point(526, 108);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(215, 27);
            textBox1.TabIndex = 6;
            textBox1.TextChanged += TinhThanhTien;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.Location = new Point(102, 291);
            label7.Name = "label7";
            label7.Size = new Size(78, 20);
            label7.TabIndex = 5;
            label7.Text = "Thành tiền";
            label7.Click += label7_Click;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Location = new Point(395, 215);
            label6.Name = "label6";
            label6.Size = new Size(86, 20);
            label6.TabIndex = 4;
            label6.Text = "Khuyến mãi";
            label6.Click += label6_Click;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Location = new Point(395, 165);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 3;
            label5.Text = "Số lượng";
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Location = new Point(395, 115);
            label4.Name = "label4";
            label4.Size = new Size(62, 20);
            label4.TabIndex = 2;
            label4.Text = "Đơn giá";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new Point(395, 65);
            label3.Name = "label3";
            label3.Size = new Size(110, 20);
            label3.TabIndex = 1;
            label3.Text = "Mã nguyên liệu";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(395, 15);
            label2.Name = "label2";
            label2.Size = new Size(112, 20);
            label2.TabIndex = 0;
            label2.Text = "Tên nguyên liệu";
            label2.Click += label2_Click;
            // 
            // UC_NhapNguyenLieu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "UC_NhapNguyenLieu";
            Size = new Size(817, 500);
            Load += UC_NhapNguyenLieu_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label label9;
        private Label label8;
        private Label label10;
        private ComboBox comboBox3;
        private TextBox textBox5;
        private ComboBox comboBox4;
        private Button button1;
        private Button button2;
        private TextBox textBox7;
        private TextBox textBox6;
        private DateTimePicker dateTimePicker1;
    }
}
