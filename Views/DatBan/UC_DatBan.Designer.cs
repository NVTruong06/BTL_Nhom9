namespace LTTQ_BTL.Views.DatBan
{
    partial class UC_DatBan
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
            dataGridView1 = new DataGridView();
            panel2 = new Panel();
            button4 = new Button();
            comboBox4 = new ComboBox();
            comboBox3 = new ComboBox();
            textBox6 = new TextBox();
            dataGridView2 = new DataGridView();
            textBox3 = new TextBox();
            label9 = new Label();
            panel3 = new Panel();
            panel4 = new Panel();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            dataGridView3 = new DataGridView();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            textBox4 = new TextBox();
            textBox1 = new TextBox();
            label10 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(20, 42);
            label1.Name = "label1";
            label1.Size = new Size(351, 41);
            label1.TabIndex = 10;
            label1.Text = "Danh Sách Phiếu Đặt Bàn";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(254, 254, 254);
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(20, 86);
            panel1.Name = "panel1";
            panel1.Size = new Size(596, 150);
            panel1.TabIndex = 11;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(14, 14);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(565, 119);
            dataGridView1.TabIndex = 0;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(254, 254, 254);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(comboBox4);
            panel2.Controls.Add(comboBox3);
            panel2.Controls.Add(textBox6);
            panel2.Controls.Add(dataGridView2);
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(label9);
            panel2.Location = new Point(637, 86);
            panel2.Name = "panel2";
            panel2.Size = new Size(388, 601);
            panel2.TabIndex = 12;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button4.BackColor = Color.FromArgb(98, 102, 247);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = Color.FromArgb(254, 254, 254);
            button4.Location = new Point(290, 14);
            button4.Name = "button4";
            button4.Size = new Size(80, 61);
            button4.TabIndex = 20;
            button4.Text = "Tìm kiếm";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // comboBox4
            // 
            comboBox4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(152, 47);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(132, 28);
            comboBox4.TabIndex = 19;
            // 
            // comboBox3
            // 
            comboBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(14, 47);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(132, 28);
            comboBox3.TabIndex = 18;
            // 
            // textBox6
            // 
            textBox6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox6.Location = new Point(14, 14);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(270, 27);
            textBox6.TabIndex = 17;
            // 
            // dataGridView2
            // 
            dataGridView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(14, 102);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(356, 332);
            dataGridView2.TabIndex = 0;
            dataGridView2.CellBeginEdit += dataGridView2_CellBeginEdit;
            dataGridView2.CellValueChanged += dataGridView2_CellValueChanged;
            dataGridView2.CurrentCellDirtyStateChanged += dataGridView2_CurrentCellDirtyStateChanged;
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox3.Location = new Point(112, 474);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(258, 27);
            textBox3.TabIndex = 14;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(14, 477);
            label9.Name = "label9";
            label9.Size = new Size(69, 20);
            label9.TabIndex = 7;
            label9.Text = "Giảm giá";
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = Color.FromArgb(254, 254, 254);
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(dataGridView3);
            panel3.Controls.Add(dateTimePicker2);
            panel3.Controls.Add(dateTimePicker1);
            panel3.Controls.Add(comboBox2);
            panel3.Controls.Add(comboBox1);
            panel3.Controls.Add(textBox4);
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(20, 256);
            panel3.Name = "panel3";
            panel3.Size = new Size(596, 431);
            panel3.TabIndex = 13;
            panel3.Paint += panel3_Paint;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel4.Controls.Add(button1);
            panel4.Controls.Add(button2);
            panel4.Controls.Add(button3);
            panel4.Location = new Point(115, 377);
            panel4.Name = "panel4";
            panel4.Size = new Size(344, 51);
            panel4.TabIndex = 20;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.BackColor = Color.FromArgb(98, 102, 247);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.FromArgb(254, 254, 254);
            button1.Location = new Point(5, 3);
            button1.Name = "button1";
            button1.Size = new Size(94, 37);
            button1.TabIndex = 9;
            button1.Text = "Thêm";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button2.BackColor = Color.FromArgb(98, 102, 247);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.FromArgb(254, 254, 254);
            button2.Location = new Point(124, 3);
            button2.Name = "button2";
            button2.Size = new Size(94, 37);
            button2.TabIndex = 10;
            button2.Text = "Sửa";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button3.BackColor = Color.FromArgb(98, 102, 247);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.FromArgb(254, 254, 254);
            button3.Location = new Point(238, 3);
            button3.Name = "button3";
            button3.Size = new Size(94, 37);
            button3.TabIndex = 11;
            button3.Text = "Xóa";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // dataGridView3
            // 
            dataGridView3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(109, 179);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowHeadersWidth = 51;
            dataGridView3.Size = new Size(470, 152);
            dataGridView3.TabIndex = 19;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(377, 89);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(202, 27);
            dateTimePicker2.TabIndex = 18;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(377, 54);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(202, 27);
            dateTimePicker1.TabIndex = 17;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(115, 135);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(168, 28);
            comboBox2.TabIndex = 16;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(115, 96);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(168, 28);
            comboBox1.TabIndex = 14;
            // 
            // textBox4
            // 
            textBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBox4.Location = new Point(109, 344);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(196, 27);
            textBox4.TabIndex = 15;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(115, 54);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(168, 27);
            textBox1.TabIndex = 12;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label10.AutoSize = true;
            label10.Location = new Point(15, 347);
            label10.Name = "label10";
            label10.Size = new Size(78, 20);
            label10.TabIndex = 8;
            label10.Text = "Thành tiền";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 179);
            label8.Name = "label8";
            label8.Size = new Size(59, 20);
            label8.TabIndex = 6;
            label8.Text = "Món ăn";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(289, 94);
            label7.Name = "label7";
            label7.Size = new Size(82, 20);
            label7.TabIndex = 5;
            label7.Text = "Ngày dùng";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(289, 54);
            label6.Name = "label6";
            label6.Size = new Size(70, 20);
            label6.TabIndex = 4;
            label6.Text = "Ngày đặt";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 135);
            label5.Name = "label5";
            label5.Size = new Size(75, 20);
            label5.TabIndex = 3;
            label5.Text = "Nhân viên";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 96);
            label4.Name = "label4";
            label4.Size = new Size(86, 20);
            label4.TabIndex = 2;
            label4.Text = "Khách hàng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 57);
            label3.Name = "label3";
            label3.Size = new Size(71, 20);
            label3.TabIndex = 1;
            label3.Text = "Mã phiếu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(14, 14);
            label2.Name = "label2";
            label2.Size = new Size(200, 28);
            label2.TabIndex = 0;
            label2.Text = "Chi tiết phiếu đặt bàn";
            // 
            // UC_DatBan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "UC_DatBan";
            Size = new Size(1040, 700);
            Load += UC_DatBan_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox6;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private ComboBox comboBox4;
        private ComboBox comboBox3;
        private Button button4;
        private DataGridView dataGridView3;
        private Panel panel4;
    }
}
