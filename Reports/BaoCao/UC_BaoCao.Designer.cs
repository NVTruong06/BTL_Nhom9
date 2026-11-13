namespace LTTQ_BTL.Reports.BaoCao
{
    partial class UC_BaoCao
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            dgvBaoCao = new DataGridView();
            btnLamMoi = new Button();
            btnTaoBaoCao = new Button();
            dtpDenNgay = new DateTimePicker();
            dtpTuNgay = new DateTimePicker();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox5 = new GroupBox();
            groupBox4 = new GroupBox();
            cboNhanVien = new ComboBox();
            cboLoaiHoaDon = new ComboBox();
            btnXuatEccel = new Button();
            chartTopMonAn = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartDoanhThu6Thang = new System.Windows.Forms.DataVisualization.Charting.Chart();
            groupBox2 = new GroupBox();
            lblTongSoKH = new Label();
            lblTongSoKH_TieuDe = new Label();
            panel2 = new Panel();
            lblDoanhThuThang = new Label();
            lblDoanhThuThang_TieuDe = new Label();
            panel3 = new Panel();
            lblTongSoNV = new Label();
            lblTongSoNV_TieuDe = new Label();
            panel1 = new Panel();
            groupBox3 = new GroupBox();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).BeginInit();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartTopMonAn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartDoanhThu6Thang).BeginInit();
            groupBox2.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvBaoCao
            // 
            dgvBaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBaoCao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBaoCao.Location = new Point(16, 32);
            dgvBaoCao.Margin = new Padding(3, 4, 3, 4);
            dgvBaoCao.Name = "dgvBaoCao";
            dgvBaoCao.RowHeadersWidth = 51;
            dgvBaoCao.RowTemplate.Height = 24;
            dgvBaoCao.Size = new Size(1038, 304);
            dgvBaoCao.TabIndex = 0;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.FromArgb(255, 128, 0);
            btnLamMoi.Location = new Point(198, 266);
            btnLamMoi.Margin = new Padding(3, 4, 3, 4);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(144, 51);
            btnLamMoi.TabIndex = 9;
            btnLamMoi.Text = "[ Làm mới ]";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnTaoBaoCao
            // 
            btnTaoBaoCao.BackColor = SystemColors.Highlight;
            btnTaoBaoCao.Location = new Point(19, 266);
            btnTaoBaoCao.Margin = new Padding(3, 4, 3, 4);
            btnTaoBaoCao.Name = "btnTaoBaoCao";
            btnTaoBaoCao.Size = new Size(146, 51);
            btnTaoBaoCao.TabIndex = 8;
            btnTaoBaoCao.Text = "[ Tạo báo cáo ]";
            btnTaoBaoCao.UseVisualStyleBackColor = false;
            btnTaoBaoCao.Click += btnTaoBaoCao_Click;
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Location = new Point(156, 142);
            dtpDenNgay.Margin = new Padding(3, 4, 3, 4);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(369, 27);
            dtpDenNgay.TabIndex = 5;
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Location = new Point(156, 85);
            dtpTuNgay.Margin = new Padding(3, 4, 3, 4);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(369, 27);
            dtpTuNgay.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 205);
            label4.Name = "label4";
            label4.Size = new Size(98, 20);
            label4.TabIndex = 3;
            label4.Text = "Nhân viên:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 149);
            label3.Name = "label3";
            label3.Size = new Size(93, 20);
            label3.TabIndex = 2;
            label3.Text = "Đến ngày:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 94);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 1;
            label2.Text = "Từ ngày:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 40);
            label1.Name = "label1";
            label1.Size = new Size(123, 20);
            label1.TabIndex = 0;
            label1.Text = "Loại hóa đơn:";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(dgvBaoCao);
            groupBox5.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            groupBox5.Location = new Point(600, 620);
            groupBox5.Margin = new Padding(3, 4, 3, 4);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(3, 4, 3, 4);
            groupBox5.Size = new Size(1074, 344);
            groupBox5.TabIndex = 9;
            groupBox5.TabStop = false;
            groupBox5.Text = "DANH SÁCH BÁO CÁO CHI TIẾT";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(cboNhanVien);
            groupBox4.Controls.Add(cboLoaiHoaDon);
            groupBox4.Controls.Add(btnXuatEccel);
            groupBox4.Controls.Add(btnLamMoi);
            groupBox4.Controls.Add(btnTaoBaoCao);
            groupBox4.Controls.Add(dtpDenNgay);
            groupBox4.Controls.Add(dtpTuNgay);
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(label3);
            groupBox4.Controls.Add(label2);
            groupBox4.Controls.Add(label1);
            groupBox4.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            groupBox4.Location = new Point(54, 620);
            groupBox4.Margin = new Padding(3, 4, 3, 4);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 4, 3, 4);
            groupBox4.Size = new Size(540, 344);
            groupBox4.TabIndex = 8;
            groupBox4.TabStop = false;
            groupBox4.Text = "BỘ LỌC BÁO CÁO";
            // 
            // cboNhanVien
            // 
            cboNhanVien.FormattingEnabled = true;
            cboNhanVien.Location = new Point(156, 197);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(262, 28);
            cboNhanVien.TabIndex = 12;
            // 
            // cboLoaiHoaDon
            // 
            cboLoaiHoaDon.FormattingEnabled = true;
            cboLoaiHoaDon.Location = new Point(156, 32);
            cboLoaiHoaDon.Name = "cboLoaiHoaDon";
            cboLoaiHoaDon.Size = new Size(262, 28);
            cboLoaiHoaDon.TabIndex = 11;
            // 
            // btnXuatEccel
            // 
            btnXuatEccel.BackColor = Color.FromArgb(0, 192, 0);
            btnXuatEccel.Location = new Point(367, 266);
            btnXuatEccel.Name = "btnXuatEccel";
            btnXuatEccel.Size = new Size(158, 51);
            btnXuatEccel.TabIndex = 10;
            btnXuatEccel.Text = "Xuất Excel";
            btnXuatEccel.UseVisualStyleBackColor = false;
            btnXuatEccel.Click += btnXuatExcel_Click;
            // 
            // chartTopMonAn
            // 
            chartArea1.Name = "ChartArea1";
            chartTopMonAn.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartTopMonAn.Legends.Add(legend1);
            chartTopMonAn.Location = new Point(174, 32);
            chartTopMonAn.Margin = new Padding(3, 4, 3, 4);
            chartTopMonAn.Name = "chartTopMonAn";
            chartTopMonAn.Size = new Size(300, 241);
            chartTopMonAn.TabIndex = 0;
            chartTopMonAn.Text = "chart1";
            // 
            // chartDoanhThu6Thang
            // 
            chartArea2.Name = "ChartArea1";
            chartDoanhThu6Thang.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chartDoanhThu6Thang.Legends.Add(legend2);
            chartDoanhThu6Thang.Location = new Point(109, 32);
            chartDoanhThu6Thang.Margin = new Padding(3, 4, 3, 4);
            chartDoanhThu6Thang.Name = "chartDoanhThu6Thang";
            chartDoanhThu6Thang.Size = new Size(699, 241);
            chartDoanhThu6Thang.TabIndex = 0;
            chartDoanhThu6Thang.Text = "chart1";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(chartDoanhThu6Thang);
            groupBox2.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            groupBox2.Location = new Point(54, 289);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(907, 312);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tăng trưởng doanh thu 6 tháng gần nhất";
            // 
            // lblTongSoKH
            // 
            lblTongSoKH.AutoSize = true;
            lblTongSoKH.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblTongSoKH.ForeColor = Color.White;
            lblTongSoKH.Location = new Point(175, 81);
            lblTongSoKH.Name = "lblTongSoKH";
            lblTongSoKH.Size = new Size(0, 46);
            lblTongSoKH.TabIndex = 2;
            lblTongSoKH.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTongSoKH_TieuDe
            // 
            lblTongSoKH_TieuDe.AutoSize = true;
            lblTongSoKH_TieuDe.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lblTongSoKH_TieuDe.ForeColor = Color.White;
            lblTongSoKH_TieuDe.Location = new Point(103, 28);
            lblTongSoKH_TieuDe.Name = "lblTongSoKH_TieuDe";
            lblTongSoKH_TieuDe.Size = new Size(243, 25);
            lblTongSoKH_TieuDe.TabIndex = 1;
            lblTongSoKH_TieuDe.Text = "TỔNG SỐ KHÁCH HÀNG";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(255, 128, 0);
            panel2.Controls.Add(lblTongSoKH);
            panel2.Controls.Add(lblTongSoKH_TieuDe);
            panel2.Location = new Point(562, 32);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(428, 181);
            panel2.TabIndex = 1;
            // 
            // lblDoanhThuThang
            // 
            lblDoanhThuThang.AutoSize = true;
            lblDoanhThuThang.Font = new Font("Microsoft Sans Serif", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lblDoanhThuThang.ForeColor = Color.White;
            lblDoanhThuThang.Location = new Point(97, 81);
            lblDoanhThuThang.Name = "lblDoanhThuThang";
            lblDoanhThuThang.Size = new Size(128, 42);
            lblDoanhThuThang.TabIndex = 1;
            lblDoanhThuThang.Text = "0 VNĐ";
            // 
            // lblDoanhThuThang_TieuDe
            // 
            lblDoanhThuThang_TieuDe.AutoSize = true;
            lblDoanhThuThang_TieuDe.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblDoanhThuThang_TieuDe.ForeColor = Color.White;
            lblDoanhThuThang_TieuDe.Location = new Point(100, 32);
            lblDoanhThuThang_TieuDe.Name = "lblDoanhThuThang_TieuDe";
            lblDoanhThuThang_TieuDe.Size = new Size(294, 22);
            lblDoanhThuThang_TieuDe.TabIndex = 0;
            lblDoanhThuThang_TieuDe.Text = "DOANH THU THÁNG (11/2026)";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(0, 192, 0);
            panel3.Controls.Add(lblDoanhThuThang);
            panel3.Controls.Add(lblDoanhThuThang_TieuDe);
            panel3.Location = new Point(1081, 32);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(492, 181);
            panel3.TabIndex = 2;
            // 
            // lblTongSoNV
            // 
            lblTongSoNV.AutoSize = true;
            lblTongSoNV.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblTongSoNV.ForeColor = Color.White;
            lblTongSoNV.Location = new Point(142, 81);
            lblTongSoNV.Name = "lblTongSoNV";
            lblTongSoNV.Size = new Size(0, 46);
            lblTongSoNV.TabIndex = 1;
            lblTongSoNV.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTongSoNV_TieuDe
            // 
            lblTongSoNV_TieuDe.AutoSize = true;
            lblTongSoNV_TieuDe.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lblTongSoNV_TieuDe.ForeColor = Color.White;
            lblTongSoNV_TieuDe.Location = new Point(93, 28);
            lblTongSoNV_TieuDe.Name = "lblTongSoNV_TieuDe";
            lblTongSoNV_TieuDe.Size = new Size(217, 25);
            lblTongSoNV_TieuDe.TabIndex = 0;
            lblTongSoNV_TieuDe.Text = "TỔNG SỐ NHÂN VIÊN";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Highlight;
            panel1.Controls.Add(lblTongSoNV);
            panel1.Controls.Add(lblTongSoNV_TieuDe);
            panel1.Location = new Point(29, 32);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(427, 181);
            panel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(chartTopMonAn);
            groupBox3.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            groupBox3.Location = new Point(1007, 289);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(667, 312);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Top món ăn bán chạy";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(panel1);
            groupBox1.Controls.Add(panel3);
            groupBox1.Controls.Add(panel2);
            groupBox1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            groupBox1.Location = new Point(54, 36);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(1620, 232);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dashboard";
            // 
            // UC_BaoCao
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox2);
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UC_BaoCao";
            Size = new Size(1730, 1001);
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chartTopMonAn).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartDoanhThu6Thang).EndInit();
            groupBox2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBaoCao;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnTaoBaoCao;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTopMonAn;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu6Thang;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTongSoKH;
        private System.Windows.Forms.Label lblTongSoKH_TieuDe;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblDoanhThuThang;
        private System.Windows.Forms.Label lblDoanhThuThang_TieuDe;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTongSoNV;
        private System.Windows.Forms.Label lblTongSoNV_TieuDe;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private Button btnXuatEccel;
        private ComboBox cboLoaiHoaDon;
        private ComboBox cboNhanVien;
    }
}
