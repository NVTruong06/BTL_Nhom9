namespace LTTQ_BTL.Views.NguyenLieu
{
    partial class UC_NguyenLieu
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
            panel1 = new Panel();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            button5 = new Button();
            button3 = new Button();
            button4 = new Button();
            label1 = new Label();
            panel2 = new Panel();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            button1 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(254, 254, 254);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button4);
            panel1.Location = new Point(20, 166);
            panel1.Name = "panel1";
            panel1.Size = new Size(777, 311);
            panel1.TabIndex = 0;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.BackColor = Color.FromArgb(98, 102, 247);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.FromArgb(254, 254, 254);
            button2.Location = new Point(263, 3);
            button2.Name = "button2";
            button2.Size = new Size(120, 40);
            button2.TabIndex = 11;
            button2.Text = "Thêm mới";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(14, 49);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(747, 249);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button5.BackColor = Color.FromArgb(98, 102, 247);
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.ForeColor = Color.FromArgb(254, 254, 254);
            button5.Location = new Point(641, 3);
            button5.Name = "button5";
            button5.Size = new Size(120, 40);
            button5.TabIndex = 9;
            button5.Text = "Xóa";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.BackColor = Color.FromArgb(98, 102, 247);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.FromArgb(254, 254, 254);
            button3.Location = new Point(389, 3);
            button3.Name = "button3";
            button3.Size = new Size(120, 40);
            button3.TabIndex = 3;
            button3.Text = "Nhập thêm";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button4.BackColor = Color.FromArgb(98, 102, 247);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = Color.FromArgb(254, 254, 254);
            button4.Location = new Point(515, 3);
            button4.Name = "button4";
            button4.Size = new Size(120, 40);
            button4.TabIndex = 4;
            button4.Text = "Sửa";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(20, 42);
            label1.Name = "label1";
            label1.Size = new Size(301, 41);
            label1.TabIndex = 8;
            label1.Text = "Quản Lý Nguyên Liệu";
            label1.Click += label1_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(254, 254, 254);
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(button1);
            panel2.Location = new Point(20, 86);
            panel2.Name = "panel2";
            panel2.Size = new Size(777, 74);
            panel2.TabIndex = 9;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 9F);
            textBox3.Location = new Point(339, 36);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Chống chỉ định...";
            textBox3.Size = new Size(296, 27);
            textBox3.TabIndex = 14;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 9F);
            textBox2.Location = new Point(14, 36);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Công dụng...";
            textBox2.Size = new Size(319, 27);
            textBox2.TabIndex = 13;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 9F);
            textBox1.Location = new Point(14, 3);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Tên nguyên liệu...";
            textBox1.Size = new Size(621, 27);
            textBox1.TabIndex = 12;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(98, 102, 247);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.FromArgb(254, 254, 254);
            button1.Location = new Point(641, 3);
            button1.Name = "button1";
            button1.Size = new Size(120, 40);
            button1.TabIndex = 11;
            button1.Text = "Tìm Kiếm";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // UC_NguyenLieu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "UC_NguyenLieu";
            Size = new Size(817, 500);
            Load += UC_NguyenLieu_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private DataGridView dataGridView1;
        private Button button3;
        private Button button4;
        private Label label1;
        private Button button5;
        private Button button2;
        private Panel panel2;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button button1;
    }
}
