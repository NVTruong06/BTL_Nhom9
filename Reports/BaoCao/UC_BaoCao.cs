using LTTQ_BTL.Dal;
using OfficeOpenXml;
using QuanLyNhaHang.DAL;
using OfficeOpenXml;
using System.IO;
using System;
using System.Data;
using System.Drawing;
using System.Security.Policy;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LTTQ_BTL.Reports.BaoCao
{
    public partial class UC_BaoCao : UserControl
    {
        public UC_BaoCao()
        {
            InitializeComponent();
        }

        private void UC_BaoCao_Load(object sender, EventArgs e)
        {
            try
            {
                lblTongSoNV.Text = BaoCaoDAL.LayTongSoNhanVien().ToString();
                lblTongSoKH.Text = BaoCaoDAL.LayTongSoKhachHang().ToString();

                decimal doanhThu = BaoCaoDAL.LayDoanhThuThangHienTai();
                lblDoanhThuThang.Text = doanhThu.ToString("N0") + " VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load Dashboard: " + ex.Message);
            }

            try
            {
                LoadChartDoanhThu6Thang();
                LoadChartTyLeGioiTinh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load Biểu đồ: " + ex.Message);
            }

            try
            {
                DataTable dtNhanVien = NhanVienDAL.LayDanhSachNhanVien();

                DataRow dr = dtNhanVien.NewRow();
                dr["MaNV"] = "";
                dr["TenNV"] = "-- Tất cả nhân viên --";
                dtNhanVien.Rows.InsertAt(dr, 0);

                cboNhanVien.DataSource = dtNhanVien;
                cboNhanVien.DisplayMember = "TenNV";
                cboNhanVien.ValueMember = "MaNV";

                cboNhanVien.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load ComboBox nhân viên: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                DateTime tuNgay = dtpTuNgay.Value;
                DateTime denNgay = dtpDenNgay.Value;
                string maNV = cboNhanVien.SelectedValue?.ToString();

                DataTable dt = BaoCaoDAL.LayDanhSachHoaDonChiTiet(tuNgay, denNgay, maNV);
                dgvBaoCao.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDashboardOverview()
        {
            try
            {
                lblTongSoNV.Text = BaoCaoDAL.LayTongSoNhanVien().ToString();
                lblTongSoKH.Text = BaoCaoDAL.LayTongSoKhachHang().ToString();

                decimal doanhThuThang = BaoCaoDAL.LayDoanhThuThangHienTai();
                lblDoanhThuThang.Text = doanhThuThang.ToString("N0") + " VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải số liệu Dashboard: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadChartDoanhThu6Thang()
        {
            chartDoanhThu6Thang.Series.Clear();

            var series = chartDoanhThu6Thang.Series.Add("DoanhThu");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            DateTime currentDate = DateTime.Now;

            for (int i = 5; i >= 0; i--)
            {
                DateTime targetDate = currentDate.AddMonths(-i);
                int thang = targetDate.Month;
                int nam = targetDate.Year;

                decimal doanhThu = BaoCaoDAL.LayDoanhThuTheoThang(thang, nam);

                series.Points.AddXY($"Tháng {thang}/{nam}", doanhThu);
            }
        }

        private void LoadChartTyLeGioiTinh()
        {
            chartTyLeGioiTinh.Series.Clear();
            var seriesTron = chartTyLeGioiTinh.Series.Add("TyLe");
            seriesTron.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

            int pNam = seriesTron.Points.AddXY("Nam (60%)", 60);
            seriesTron.Points[pNam].Color = Color.Blue;

            int pNu = seriesTron.Points.AddXY("Nữ (40%)", 40);
            seriesTron.Points[pNu].Color = Color.Orange;

            seriesTron["PieRadiusPercentage"] = "78";

            if (chartTyLeGioiTinh.Legends.Count > 0)
            {
                chartTyLeGioiTinh.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
                chartTyLeGioiTinh.Legends[0].Alignment = StringAlignment.Center;
            }

            seriesTron["PieLabelStyle"] = "Outside";
        }

        private void LoadDanhSachChiTiet()
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value;
                DateTime denNgay = dtpDenNgay.Value;
                string maNV = cboNhanVien.SelectedValue?.ToString();

                DataTable dt = BaoCaoDAL.LayDanhSachHoaDonChiTiet(tuNgay, denNgay, maNV);

                dgvBaoCao.DataSource = dt;

                if (dgvBaoCao.Columns["MaHD"] != null)
                    dgvBaoCao.Columns["MaHD"].HeaderText = "Mã HĐ Nhập";

                if (dgvBaoCao.Columns["NgayLap"] != null)
                {
                    dgvBaoCao.Columns["NgayLap"].HeaderText = "Ngày Nhập";
                    dgvBaoCao.Columns["NgayLap"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }

                if (dgvBaoCao.Columns["MaNhanVien"] != null)
                    dgvBaoCao.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";

                if (dgvBaoCao.Columns["TenNhanVien"] != null)
                    dgvBaoCao.Columns["TenNhanVien"].HeaderText = "Tên Nhân Viên";

                if (dgvBaoCao.Columns["TenKhachHang"] != null)
                    dgvBaoCao.Columns["TenKhachHang"].HeaderText = "Khách hàng / NCC";

                if (dgvBaoCao.Columns["TongTien"] != null)
                {
                    dgvBaoCao.Columns["TongTien"].HeaderText = "Tổng Tiền (VNĐ)";
                    dgvBaoCao.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                }

                dgvBaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTaoBaoCao_Click(object sender, EventArgs e)
        {
            LoadDashboardOverview();
            LoadChartDoanhThu6Thang();
            LoadChartTyLeGioiTinh();
            LoadDanhSachChiTiet();

            MessageBox.Show("Đã tạo báo cáo mới dựa trên điều kiện lọc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Now.AddMonths(-1);
            dtpDenNgay.Value = DateTime.Now;
            cboNhanVien.SelectedIndex = -1;

            LoadDashboardOverview();
            LoadChartDoanhThu6Thang();
            LoadChartTyLeGioiTinh();
            LoadDanhSachChiTiet();

            MessageBox.Show("Đã làm mới dữ liệu báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void XuatExcel(DataTable dt, string fileName)
        {
            ExcelPackage.License.SetNonCommercialPersonal("Hoang Trong Giap");

            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet ws = package.Workbook.Worksheets.Add("BaoCaoDoanhThu");
                ws.Cells["A1"].LoadFromDataTable(dt, true);

                using (var range = ws.Cells[1, 1, 1, dt.Columns.Count])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                }

                ws.Cells.AutoFitColumns();

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.FileName = fileName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo file = new FileInfo(saveFileDialog.FileName);
                    package.SaveAs(file);
                    MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void lblTongSoNV_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDanhSachChiTiet();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = dgvBaoCao.DataSource as DataTable;
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                XuatExcel(dt, "BaoCaoQuanLyNhaHang");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}