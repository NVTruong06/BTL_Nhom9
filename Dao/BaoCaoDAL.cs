using QuanlyNhaHang.DAL;
using QuanLyNhaHang.DAL;
using System;
using System.Data;
using System.Data.SqlClient;

namespace LTTQ_BTL.Dal
{
    public class BaoCaoDAL
    {
        public static int LayTongSoNhanVien()
        {
            string query = "SELECT COUNT(*) FROM NhanVien";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 0;
        }

        public static int LayTongSoKhachHang()
        {
            string query = "SELECT COUNT(*) FROM Khach";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 0;
        }

        public static decimal LayDoanhThuThangHienTai()
        {
            string query = "SELECT ISNULL(SUM(TongTien), 0) FROM HoaDonNhap WHERE MONTH(NgayNhap) = MONTH(GETDATE()) AND YEAR(NgayNhap) = YEAR(GETDATE())";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            return dt.Rows.Count > 0 ? Convert.ToDecimal(dt.Rows[0][0]) : 0;
        }

        public static DataTable LayDoanhThu6ThangGanNhat()
        {
            string query = "SELECT TOP 6 MONTH(NgayNhap) AS Thang, YEAR(NgayNhap) AS Nam, SUM(TongTien) AS DoanhThu " +
                           "FROM HoaDonNhap " +
                           "GROUP BY YEAR(NgayNhap), MONTH(NgayNhap) " +
                           "ORDER BY YEAR(NgayNhap) DESC, MONTH(NgayNhap) DESC";

            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataTable dtReversed = dt.Clone();
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    dtReversed.ImportRow(dt.Rows[i]);
                }
                return dtReversed;
            }
            return dt;
        }

        public static DataTable LayTyleGioiTinhKhach()
        {
            string query = "SELECT GioiTinh, COUNT(*) AS SoLuong FROM Khach GROUP BY GioiTinh";
            return DatabaseHelper.ExecuteQuery(query);
        }

        public static DataTable LayDanhSachHoaDonChiTiet(DateTime tuNgay, DateTime denNgay, string maNV)
        {
            string tu = tuNgay.ToString("yyyy-MM-dd 00:00:00");
            string den = denNgay.ToString("yyyy-MM-dd 23:59:59");

            string query = "SELECT HDN.MaHoaDonNhap AS MaHD, HDN.NgayNhap AS NgayLap, NV.MaNhanVien, NV.TenNhanVien, 'Khách lẻ' AS TenKhachHang, HDN.TongTien " +
                           "FROM HoaDonNhap HDN " +
                           "LEFT JOIN NhanVien NV ON HDN.MaNhanVien = NV.MaNhanVien " +
                           $"WHERE HDN.NgayNhap BETWEEN '{tu}' AND '{den}'";

            if (!string.IsNullOrEmpty(maNV))
            {
                query += $" AND HDN.MaNhanVien = '{maNV}'";
            }

    public static DataTable LayDanhSachNhanVien()
    {
        string query = "SELECT MaNhanVien, TenNhanVien FROM NhanVien";
            return DatabaseHelper.ExecuteQuery(query);
        }

        public static decimal LayDoanhThuTheoThang(int thang, int nam)
        {
            decimal doanhThu = 0;

            string query = $"SELECT ISNULL(SUM(TongTien), 0) FROM HoaDonNhap WHERE MONTH(NgayNhap) = {thang} AND YEAR(NgayNhap) = {nam}";

            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
                {
                    doanhThu = Convert.ToDecimal(dt.Rows[0][0]);
                }
            }
            catch
            {
                doanhThu = 0;
            }

            return doanhThu;
        }
    }
}