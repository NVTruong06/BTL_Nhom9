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
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button3 = new Button();
            button4 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            button5 = new Button();
            textBox3 = new TextBox();
            button2 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(20, 226);
            panel1.Name = "panel1";
            panel1.Size = new Size(777, 251);
            panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(777, 251);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button1
            // 
            button1.Location = new Point(551, 103);
            button1.Name = "button1";
            button1.Size = new Size(120, 40);
            button1.TabIndex = 1;
            button1.Text = "Tìm Kiếm";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.Location = new Point(425, 180);
            button3.Name = "button3";
            button3.Size = new Size(120, 40);
            button3.TabIndex = 3;
            button3.Text = "Nhập thêm";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button4.Location = new Point(551, 180);
            button4.Name = "button4";
            button4.Size = new Size(120, 40);
            button4.TabIndex = 4;
            button4.Text = "Sửa";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 9F);
            textBox1.Location = new Point(20, 103);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Tên nguyên liệu...";
            textBox1.Size = new Size(525, 27);
            textBox1.TabIndex = 5;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 9F);
            textBox2.Location = new Point(20, 136);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Công dụng...";
            textBox2.Size = new Size(273, 27);
            textBox2.TabIndex = 7;
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
            // button5
            // 
            button5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button5.Location = new Point(677, 180);
            button5.Name = "button5";
            button5.Size = new Size(120, 40);
            button5.TabIndex = 9;
            button5.Text = "Xóa";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 9F);
            textBox3.Location = new Point(299, 136);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Chống chỉ định...";
            textBox3.Size = new Size(246, 27);
            textBox3.TabIndex = 10;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.Location = new Point(299, 180);
            button2.Name = "button2";
            button2.Size = new Size(120, 40);
            button2.TabIndex = 11;
            button2.Text = "Thêm mới";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // UC_NguyenLieu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button2);
            Controls.Add(textBox3);
            Controls.Add(button5);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(panel1);
            Name = "UC_NguyenLieu";
            Size = new Size(817, 500);
            Load += UC_NguyenLieu_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private DataGridView dataGridView1;
        private Button button1;
        private Button button3;
        private Button button4;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Button button5;
        private TextBox textBox3;
        private Button button2;
    }
}
