namespace QuanLyNhaHang
{
    partial class ucNhanSu
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
            groupBox2 = new GroupBox();
            dgvNhanVien = new DataGridView();
            groupBox1 = new GroupBox();
            btnLamMoi = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            txtDienThoai = new TextBox();
            txtDiaChi = new TextBox();
            cboQueQuan = new ComboBox();
            cboGioiTinh = new ComboBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label1 = new Label();
            label4 = new Label();
            dtpNgaySinh = new DateTimePicker();
            txtMaNV = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtTenNV = new TextBox();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvNhanVien);
            groupBox2.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            groupBox2.Location = new Point(505, 49);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(1025, 602);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách nhân viên";
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.Location = new Point(18, 32);
            dgvNhanVien.Margin = new Padding(3, 4, 3, 4);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.RowHeadersWidth = 51;
            dgvNhanVien.RowTemplate.Height = 24;
            dgvNhanVien.Size = new Size(1001, 545);
            dgvNhanVien.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnLamMoi);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Controls.Add(txtDienThoai);
            groupBox1.Controls.Add(txtDiaChi);
            groupBox1.Controls.Add(cboQueQuan);
            groupBox1.Controls.Add(cboGioiTinh);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(dtpNgaySinh);
            groupBox1.Controls.Add(txtMaNV);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtTenNV);
            groupBox1.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            groupBox1.Location = new Point(27, 49);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(472, 602);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin chi tiết";
            // 
            // btnLamMoi
            // 
            btnLamMoi.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnLamMoi.Location = new Point(334, 524);
            btnLamMoi.Margin = new Padding(3, 4, 3, 4);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(116, 40);
            btnLamMoi.TabIndex = 17;
            btnLamMoi.Text = "&Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnXoa.Location = new Point(181, 524);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(116, 40);
            btnXoa.TabIndex = 16;
            btnXoa.Text = "&Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            btnThem.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnThem.Location = new Point(22, 524);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(116, 40);
            btnThem.TabIndex = 15;
            btnThem.Text = "&Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // txtDienThoai
            // 
            txtDienThoai.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtDienThoai.Location = new Point(167, 422);
            txtDienThoai.Margin = new Padding(3, 4, 3, 4);
            txtDienThoai.Name = "txtDienThoai";
            txtDienThoai.Size = new Size(200, 27);
            txtDienThoai.TabIndex = 14;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtDiaChi.Location = new Point(167, 302);
            txtDiaChi.Margin = new Padding(3, 4, 3, 4);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(200, 27);
            txtDiaChi.TabIndex = 13;
            // 
            // cboQueQuan
            // 
            cboQueQuan.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            cboQueQuan.FormattingEnabled = true;
            cboQueQuan.Location = new Point(167, 362);
            cboQueQuan.Margin = new Padding(3, 4, 3, 4);
            cboQueQuan.Name = "cboQueQuan";
            cboQueQuan.Size = new Size(200, 28);
            cboQueQuan.TabIndex = 12;
            // 
            // cboGioiTinh
            // 
            cboGioiTinh.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            cboGioiTinh.FormattingEnabled = true;
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });
            cboGioiTinh.Location = new Point(167, 178);
            cboGioiTinh.Margin = new Padding(3, 4, 3, 4);
            cboGioiTinh.Name = "cboGioiTinh";
            cboGioiTinh.Size = new Size(200, 28);
            cboGioiTinh.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label7.Location = new Point(18, 311);
            label7.Name = "label7";
            label7.Size = new Size(66, 20);
            label7.TabIndex = 10;
            label7.Text = "Địa chỉ:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label6.Location = new Point(18, 431);
            label6.Name = "label6";
            label6.Size = new Size(89, 20);
            label6.TabIndex = 9;
            label6.Text = "Điện thoại:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label5.Location = new Point(18, 372);
            label5.Name = "label5";
            label5.Size = new Size(86, 20);
            label5.TabIndex = 8;
            label5.Text = "Quê quán:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label1.Location = new Point(18, 61);
            label1.Name = "label1";
            label1.Size = new Size(113, 20);
            label1.TabIndex = 1;
            label1.Text = "Mã nhân viên:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label4.Location = new Point(18, 251);
            label4.Name = "label4";
            label4.Size = new Size(88, 20);
            label4.TabIndex = 6;
            label4.Text = "Ngày sinh:";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(167, 242);
            dtpNgaySinh.Margin = new Padding(3, 4, 3, 4);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(200, 27);
            dtpNgaySinh.TabIndex = 7;
            // 
            // txtMaNV
            // 
            txtMaNV.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtMaNV.Location = new Point(167, 52);
            txtMaNV.Margin = new Padding(3, 4, 3, 4);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.Size = new Size(200, 27);
            txtMaNV.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label2.Location = new Point(18, 122);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 2;
            label2.Text = "Họ tên:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label3.Location = new Point(18, 188);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 5;
            label3.Text = "Giới tính:";
            // 
            // txtTenNV
            // 
            txtTenNV.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtTenNV.Location = new Point(167, 114);
            txtTenNV.Margin = new Padding(3, 4, 3, 4);
            txtTenNV.Name = "txtTenNV";
            txtTenNV.Size = new Size(200, 27);
            txtTenNV.TabIndex = 4;
            // 
            // ucNhanSu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ucNhanSu";
            Size = new Size(1531, 685);
            Load += ucNhanSu_Load_1;
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.ComboBox cboQueQuan;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenNV;
    }
}
