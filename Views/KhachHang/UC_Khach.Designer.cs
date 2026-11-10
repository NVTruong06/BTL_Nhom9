namespace LTTQ_BTL.Views.Khach
{
    partial class UC_Khach
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
            groupBox1 = new GroupBox();
            btnLamMoi = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            txtDienThoai = new TextBox();
            txtDiaChi = new TextBox();
            txtTenKhach = new TextBox();
            txtMaKhach = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            dgvKhach = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhach).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnLamMoi);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Controls.Add(txtDienThoai);
            groupBox1.Controls.Add(txtDiaChi);
            groupBox1.Controls.Add(txtTenKhach);
            groupBox1.Controls.Add(txtMaKhach);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            groupBox1.Location = new Point(54, 44);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(442, 514);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin chi tiết";
            // 
            // btnLamMoi
            // 
            btnLamMoi.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnLamMoi.Location = new Point(324, 384);
            btnLamMoi.Margin = new Padding(3, 4, 3, 4);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(112, 41);
            btnLamMoi.TabIndex = 10;
            btnLamMoi.Text = "&Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnXoa.Location = new Point(167, 384);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(112, 41);
            btnXoa.TabIndex = 9;
            btnXoa.Text = "&Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThem
            // 
            btnThem.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnThem.Location = new Point(6, 384);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(112, 41);
            btnThem.TabIndex = 8;
            btnThem.Text = "&Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // txtDienThoai
            // 
            txtDienThoai.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtDienThoai.Location = new Point(180, 270);
            txtDienThoai.Margin = new Padding(3, 4, 3, 4);
            txtDienThoai.Name = "txtDienThoai";
            txtDienThoai.Size = new Size(223, 27);
            txtDienThoai.TabIndex = 7;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtDiaChi.Location = new Point(180, 190);
            txtDiaChi.Margin = new Padding(3, 4, 3, 4);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(223, 27);
            txtDiaChi.TabIndex = 6;
            // 
            // txtTenKhach
            // 
            txtTenKhach.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtTenKhach.Location = new Point(180, 116);
            txtTenKhach.Margin = new Padding(3, 4, 3, 4);
            txtTenKhach.Name = "txtTenKhach";
            txtTenKhach.Size = new Size(223, 27);
            txtTenKhach.TabIndex = 5;
            // 
            // txtMaKhach
            // 
            txtMaKhach.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtMaKhach.Location = new Point(180, 45);
            txtMaKhach.Margin = new Padding(3, 4, 3, 4);
            txtMaKhach.Name = "txtMaKhach";
            txtMaKhach.Size = new Size(223, 27);
            txtMaKhach.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label4.Location = new Point(20, 276);
            label4.Name = "label4";
            label4.Size = new Size(96, 22);
            label4.TabIndex = 3;
            label4.Text = "Điện thoại:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label3.Location = new Point(20, 196);
            label3.Name = "label3";
            label3.Size = new Size(70, 22);
            label3.TabIndex = 2;
            label3.Text = "Địa chỉ:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label2.Location = new Point(20, 122);
            label2.Name = "label2";
            label2.Size = new Size(92, 22);
            label2.TabIndex = 1;
            label2.Text = "Họ và tên:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label1.Location = new Point(20, 51);
            label1.Name = "label1";
            label1.Size = new Size(137, 22);
            label1.TabIndex = 0;
            label1.Text = "Mã khách hàng:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvKhach);
            groupBox2.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            groupBox2.Location = new Point(535, 44);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(600, 514);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách khách hàng";
            // 
            // dgvKhach
            // 
            dgvKhach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhach.Location = new Point(23, 45);
            dgvKhach.Margin = new Padding(3, 4, 3, 4);
            dgvKhach.Name = "dgvKhach";
            dgvKhach.RowHeadersWidth = 51;
            dgvKhach.RowTemplate.Height = 24;
            dgvKhach.Size = new Size(557, 439);
            dgvKhach.TabIndex = 0;
            // 
            // UC_Khach
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UC_Khach";
            Size = new Size(1194, 654);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvKhach).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtTenKhach;
        private System.Windows.Forms.TextBox txtMaKhach;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvKhach;
    }
}
