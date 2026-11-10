using LTTQ_BTL.Dal;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LTTQ_BTL.Dao
{
    public class MonAnDao
    {
        Database db = new Database();
        public DataTable DSMonAn()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = "SELECT MaMonAn, TenMonAn, TenCongDung, TenLoai, YeuCau, DonGia " +
                    "FROM MonAn JOIN CongDung ON MonAn.MaCongDung = CongDung.MaCongDung JOIN LoaiMon ON MonAn.MaLoai = LoaiMon.MaLoai;";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                adapter.Fill(dt);
            }
            return dt;
        }

        public DataTable TimKiem(string ten, string loai, string congdung)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = "SELECT MaMonAn, TenMonAn, TenCongDung, TenLoai, YeuCau, DonGia " +
                    "FROM MonAn JOIN CongDung ON MonAn.MaCongDung = CongDung.MaCongDung JOIN LoaiMon ON MonAn.MaLoai = LoaiMon.MaLoai " +
                    "WHERE TenMonAn LIKE @Ten AND MonAn.MaLoai LIKE @Loai AND MonAn.MaCongDung LIKE @CongDung;";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                adapter.SelectCommand.Parameters.AddWithValue("@Ten", "%" + ten + "%");
                adapter.SelectCommand.Parameters.AddWithValue("@Loai", "%" + loai + "%");
                adapter.SelectCommand.Parameters.AddWithValue("@CongDung", "%" + congdung + "%");

                adapter.Fill(dt);
            }
            return dt;
        }

        public DataTable DSLoai()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = "SELECT * FROM LoaiMon;";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                adapter.Fill(dt);
            }
            return dt;
        }

        public DataTable DSCongDung()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = "SELECT * FROM CongDung;";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                adapter.Fill(dt);
            }
            return dt;
        }

        public DataTable LayTheoMa(string ma)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = "SELECT MaMonAn, TenMonAn, TenCongDung, TenLoai, CachLam, YeuCau, DonGia , HinhAnh " +
                    "FROM MonAn JOIN CongDung ON MonAn.MaCongDung = CongDung.MaCongDung JOIN LoaiMon ON MonAn.MaLoai = LoaiMon.MaLoai " +
                    "WHERE MaMonAn = @Ma";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                adapter.SelectCommand.Parameters.AddWithValue("@Ma", ma);

                adapter.Fill(dt);
            }
            return dt;
        }

        public bool ThemMonAn(
                        string maMon,
                        string tenMon,
                        string maCongDung,
                        string maLoai,
                        string cachLam,
                        string yeuCau,
                        decimal donGia,
                        string hinhAnh)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = @"
            INSERT INTO MonAn
            (MaMonAn, TenMonAn, MaCongDung, MaLoai, CachLam, YeuCau, DonGia, HinhAnh)
            VALUES
            (@MaMon, @TenMon, @MaCongDung, @MaLoai, @CachLam, @YeuCau, @DonGia, @HinhAnh)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                
                cmd.Parameters.AddWithValue("@MaMon", maMon);
                cmd.Parameters.AddWithValue("@TenMon", tenMon);
                cmd.Parameters.AddWithValue("@MaCongDung", maCongDung);
                cmd.Parameters.AddWithValue("@MaLoai", maLoai);
                cmd.Parameters.AddWithValue("@CachLam", cachLam);
                cmd.Parameters.AddWithValue("@YeuCau", yeuCau);
                cmd.Parameters.AddWithValue("@DonGia", donGia);
                cmd.Parameters.AddWithValue("@HinhAnh",
                    string.IsNullOrWhiteSpace(hinhAnh) ? DBNull.Value : hinhAnh);

                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ThemNguyenLieuMonAn(
                                    string maMon,
                                    string maNguyenLieu,
                                    decimal soLuong)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = @"INSERT INTO NguyenLieu_MonAn(MaMonAn, MaNguyenLieu, SoLuong)"
                            + " VALUES (@MaMonAn, @MaNguyenLieu, @SoLuong)";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@MaMonAn", maMon);
                cmd.Parameters.AddWithValue("@MaNguyenLieu", maNguyenLieu);
                cmd.Parameters.AddWithValue("@SoLuong", soLuong);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        //bat dau dung stored procedure
    }
}
