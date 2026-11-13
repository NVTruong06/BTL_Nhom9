using LTTQ_BTL.Dal;
using OfficeOpenXml;
using QuanlyNhaHang.DAL;
using QuanLyNhaHang.DAL;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

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
                LoadDashboardOverview();
                LoadChartDoanhThu6Thang();
                LoadChartTopMonAn();

                DataTable dtNhanVien = NhanVienDAL.LayDanhSachNhanVien();
                DataRow dr = dtNhanVien.NewRow();
                dr["MaNV"] = "";
                dr["TenNV"] = "--- Tất cả nhân viên ---";
                dtNhanVien.Rows.InsertAt(dr, 0);

                cboNhanVien.DataSource = dtNhanVien;
                cboNhanVien.DisplayMember = "TenNV";
                cboNhanVien.ValueMember = "MaNV";
                cboNhanVien.SelectedIndex = 0;

                if (cboLoaiHoaDon.Items.Count == 0)
                {
                    cboLoaiHoaDon.Items.Add("Phiếu đặt bàn");
                    cboLoaiHoaDon.Items.Add("Hóa đơn nhập");

                    cboLoaiHoaDon.SelectedIndexChanged -= cboLoaiHoaDon_SelectedIndexChanged; 
                    cboLoaiHoaDon.SelectedIndexChanged += cboLoaiHoaDon_SelectedIndexChanged;
                }
                cboLoaiHoaDon.SelectedIndex = 0;

                dtpTuNgay.Value = DateTime.Now.AddMonths(-1);
                dtpDenNgay.Value = DateTime.Now;

                LoadDanhSachChiTiet();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo màn hình báo cáo: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                chartDoanhThu6Thang.Series.Clear();
                var series = chartDoanhThu6Thang.Series.Add("DoanhThu");
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                series.IsValueShownAsLabel = true; 

                if (chartDoanhThu6Thang.ChartAreas.Count > 0)
                {
                    var area = chartDoanhThu6Thang.ChartAreas[0];
                    area.AxisX.Interval = 1;
                }

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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải biểu đồ doanh thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadChartTopMonAn()
        {
            try
            {
                chartTopMonAn.Series.Clear();
                var series = chartTopMonAn.Series.Add("TopMonAn");
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                series.IsValueShownAsLabel = true; 

                string query = @"SELECT TOP 5 m.TenMonAn, SUM(ct.SoLuong) as TongSoLuong
                         FROM ChiTietPhieuDatBan ct -- Kiểm tra lại tên bảng chi tiết (ví dụ: ChiTietHoaDon, ChiTietPhieuDatBan...)
                         JOIN MonAn m ON ct.MaMonAn = m.MaMonAn
                         GROUP BY m.TenMonAn
                         ORDER BY TongSoLuong DESC";

                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string tenMon = row["TenMonAn"]?.ToString();
                        double soLuong = Convert.ToDouble(row["TongSoLuong"]);
                        series.Points.AddXY(tenMon, soLuong);
                    }
                }
                else
                {
                    series.Points.AddXY("Thịt bò xào rau cải", 1);
                    series.Points.AddXY("Súp rau củ giải nhiệt", 1);
                }
            }
            catch (Exception ex)
            {
                chartTopMonAn.Series.Clear();
                var series = chartTopMonAn.Series.Add("TopMonAn");
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                series.Points.AddXY("Thịt bò xào rau cải", 1);
                series.Points.AddXY("Súp rau củ giải nhiệt", 1);
            }
        }

        private void LoadDanhSachChiTiet()
        {
            try
            {
                DateTime tuNgay = dtpTuNgay != null ? dtpTuNgay.Value : DateTime.Now;
                DateTime denNgay = dtpDenNgay != null ? dtpDenNgay.Value : DateTime.Now;

                string maNV = null;
                if (cboNhanVien != null && cboNhanVien.SelectedValue != null)
                {
                    maNV = cboNhanVien.SelectedValue.ToString();
                }

                string loaiBaoCao = "";
                if (cboLoaiHoaDon != null)
                {
                    if (cboLoaiHoaDon.SelectedItem != null)
                        loaiBaoCao = cboLoaiHoaDon.SelectedItem.ToString().Trim();
                    else if (cboLoaiHoaDon.Text != null)
                        loaiBaoCao = cboLoaiHoaDon.Text.Trim();
                }

                DataTable dt = new DataTable();

                if (string.Equals(loaiBaoCao, "Phiếu đặt bàn", StringComparison.OrdinalIgnoreCase))
                {
                    dt = BaoCaoDAL.LayDanhSachPhieuDatBan();
                }
                else
                {
                    dt = BaoCaoDAL.LayDanhSachHoaDonChiTiet(tuNgay, denNgay, maNV);
                }

                dgvBaoCao.DataSource = null;
                if (dt != null)
                {
                    dgvBaoCao.DataSource = dt;
                }

                dgvBaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboLoaiHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDanhSachChiTiet();
        }

        private void cboNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDanhSachChiTiet();
        }

        private void btnTaoBaoCao_Click(object sender, EventArgs e)
        {
            LoadDashboardOverview();
            LoadChartDoanhThu6Thang();
            LoadChartTopMonAn();
            LoadDanhSachChiTiet();
            MessageBox.Show("Đã tạo báo cáo mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Now.AddMonths(-1);
            dtpDenNgay.Value = DateTime.Now;
            if (cboNhanVien.Items.Count > 0) cboNhanVien.SelectedIndex = 0;
            if (cboLoaiHoaDon.Items.Count > 0) cboLoaiHoaDon.SelectedIndex = 0;

            LoadDashboardOverview();
            LoadChartDoanhThu6Thang();
            LoadChartTopMonAn();
            LoadDanhSachChiTiet();
            MessageBox.Show("Đã làm mới dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void XuatExcel(DataTable dt, string fileName)
        {
            ExcelPackage.License.SetNonCommercialPersonal("Hoang Trong Giap");
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet ws = package.Workbook.Worksheets.Add("BaoCaoDoanhThu");
                ws.Cells["A1"].LoadFromDataTable(dt, true);

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