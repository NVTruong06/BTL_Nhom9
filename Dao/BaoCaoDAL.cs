using Microsoft.Data.SqlClient;
using QuanlyNhaHang.DAL;
using System;
using System.Data;

namespace LTTQ_BTL.Dal
{
    public class BaoCaoDAL
    {
        public static decimal LayDoanhThuThangHienTai()
        {
            decimal doanhThu = 0;
            string query = @"
                SELECT ISNULL(SUM(TongTien), 0) AS DoanhThu 
                FROM PhieuDatBan 
                WHERE MONTH(NgayDung) = MONTH(GETDATE()) 
                  AND YEAR(NgayDung) = YEAR(GETDATE())
                  AND NgayDung <= GETDATE()";

            Database db = new Database();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        doanhThu = Convert.ToDecimal(result);
                    }
                }
            }
            return doanhThu;
        }

        public static DataTable LayDoanhThu6Thang()
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT 
                    MONTH(NgayDung) AS Thang, 
                    YEAR(NgayDung) AS Nam, 
                    SUM(TongTien) AS DoanhThu
                FROM PhieuDatBan
                WHERE NgayDung <= GETDATE() 
                  AND NgayDung >= DATEADD(month, -6, GETDATE())
                GROUP BY YEAR(NgayDung), MONTH(NgayDung)
                ORDER BY Nam, Thang";

            Database db = new Database();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public static DataTable LayTyLeGioiTinhTheoDSKhach()
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT 
                    ISNULL(GioiTinh, N'Khác') AS GioiTinh, 
                    COUNT(*) AS SoLuong
                FROM Khach
                GROUP BY GioiTinh";

            Database db = new Database();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public static DataTable LayDanhSachHoaDonNhap()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM HoaDonNhap";

            Database db = new Database();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public static DataTable LayDanhSachPhieuDatBan()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = @"SELECT * FROM PhieuDatBan"; 
                dt = DatabaseHelper.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
            }
            return dt;
        }

        public static DataTable LayDanhSachHoaDonChiTiet(DateTime tuNgay, DateTime denNgay, string maNV)
        {
            string query = @"SELECT 
                        hd.MaHoaDonNhap, 
                        hd.NgayNhap, 
                        hd.MaNhanVien, 
                        nv.TenNhanVien, 
                        ncc.MaNhaCungCap AS TenKhachHang, 
                        hd.TongTien 
                     FROM HoaDonNhap hd
                     LEFT JOIN NhanVien nv ON hd.MaNhanVien = nv.MaNhanVien
                     LEFT JOIN NhaCungCap ncc ON hd.MaNhaCungCap = ncc.MaNhaCungCap
                     WHERE hd.NgayNhap >= @TuNgay AND hd.NgayNhap <= @DenNgay";

            if (!string.IsNullOrEmpty(maNV))
            {
                query += " AND hd.MaNhanVien = @MaNV";
            }

            List<SqlParameter> listParams = new List<SqlParameter>()
    {
        new SqlParameter("@TuNgay", tuNgay),
        new SqlParameter("@DenNgay", denNgay)
    };

            if (!string.IsNullOrEmpty(maNV))
            {
                listParams.Add(new SqlParameter("@MaNV", maNV));
            }

            DataTable dt = DatabaseHelper.ExecuteQuery(query, listParams.ToArray());

            return dt;
        }

        public static decimal LayDoanhThuTheoThang(int thang, int nam)
        {
            try
            {
                string sqlDatBan = @"SELECT ISNULL(SUM(TongTien), 0) 
                             FROM PhieuDatBan 
                             WHERE MONTH(NgayDung) = @Thang AND YEAR(NgayDung) = @Nam";

                string sqlNhapHang = @"SELECT ISNULL(SUM(TongTien), 0) 
                               FROM HoaDonNhap 
                               WHERE MONTH(NgayNhap) = @Thang AND YEAR(NgayNhap) = @Nam";

                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@Thang", thang),
            new SqlParameter("@Nam", nam)
                };

                DataTable dtDatBan = DatabaseHelper.ExecuteQuery(sqlDatBan, parameters);
                DataTable dtNhap = DatabaseHelper.ExecuteQuery(sqlNhapHang, parameters);

                decimal doanhThu = 0;
                decimal chiPhi = 0;

                if (dtDatBan != null && dtDatBan.Rows.Count > 0)
                {
                    decimal.TryParse(dtDatBan.Rows[0][0].ToString(), out doanhThu);
                }
                if (dtNhap != null && dtNhap.Rows.Count > 0)
                {
                    decimal.TryParse(dtNhap.Rows[0][0].ToString(), out chiPhi);
                }

                return doanhThu - chiPhi;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static int LayTongSoNhanVien()
        {
            int tong = 0;
            string query = "SELECT COUNT(*) FROM NhanVien";
            Database db = new Database();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        tong = Convert.ToInt32(result);
                    }
                }
            }
            return tong;
        }

        public static int LayTongSoKhachHang()
        {
            int tong = 0;
            string query = "SELECT COUNT(*) FROM Khach";
            Database db = new Database();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        tong = Convert.ToInt32(result);
                    }
                }
            }
            return tong;
        }
    }
}