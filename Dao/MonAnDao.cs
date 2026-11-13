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
        /*public DataTable DSMonAn()
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
        }*/
        // danh sach mon an
        public DataTable DSMonAn(string ten, string loai, string congdung)
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

        //lai theo ma
        public DataTable LayTheoMa(string ma)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = "SELECT MaMonAn, TenMonAn, TenCongDung, TenLoai, CachLam, YeuCau, DonGia , HinhAnh, MonAn.MaLoai " +
                    "FROM MonAn JOIN CongDung ON MonAn.MaCongDung = CongDung.MaCongDung JOIN LoaiMon ON MonAn.MaLoai = LoaiMon.MaLoai " +
                    "WHERE MaMonAn = @Ma";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                adapter.SelectCommand.Parameters.AddWithValue("@Ma", ma);

                adapter.Fill(dt);
            }
            return dt;
        }

        //create mon an
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

        public DataTable DSNguyenLieu_MonAn(string ma)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = "SELECT * FROM NguyenLieu_MonAn JOIN NguyenLieu ON NguyenLieu_MonAn.MaNguyenLieu = NguyenLieu.MaNguyenLieu" +
                    " WHERE MaMonAn LIKE @Ma";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                adapter.SelectCommand.Parameters.AddWithValue("@Ma", "%" + ma + "%");

                adapter.Fill(dt);
            }
            return dt;
        }

        //update mon an
        public bool SuaMonAn(
                        string maMon,
                        string tenMon,
                        string maCongDung,
                        string maLoai,
                        string cachLam,
                        string yeuCau,
                        decimal donGia,
                        string hinhAnh,
                        DataTable dtNguyenLieu)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Cập nhật thông tin món ăn
                        string sql = @"UPDATE MonAn SET TenMonAn = @TenMon, MaCongDung = @MaCongDung,
                        MaLoai = @MaLoai, CachLam = @CachLam, YeuCau = @YeuCau, DonGia = @DonGia, HinhAnh = @HinhAnh WHERE MaMonAn = @MaMon";

                        using (SqlCommand cmd = new SqlCommand(sql, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@MaMon", maMon);
                            cmd.Parameters.AddWithValue("@TenMon", tenMon);
                            cmd.Parameters.AddWithValue("@MaCongDung", maCongDung);
                            cmd.Parameters.AddWithValue("@MaLoai", maLoai);
                            cmd.Parameters.AddWithValue("@CachLam", cachLam);
                            cmd.Parameters.AddWithValue("@YeuCau", yeuCau);
                            cmd.Parameters.AddWithValue("@DonGia", donGia);

                            cmd.Parameters.AddWithValue("@HinhAnh",
                                string.IsNullOrWhiteSpace(hinhAnh)
                                ? (object)DBNull.Value : hinhAnh);

                            if (cmd.ExecuteNonQuery() == 0)
                                throw new Exception("Không tìm thấy món ăn cần sửa!");
                        }

                        // 2. Xóa danh sách nguyên liệu cũ
                        string sqlXoa = @"DELETE FROM NguyenLieu_MonAn WHERE MaMonAn = @MaMon";

                        using (SqlCommand cmd = new SqlCommand(sqlXoa, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@MaMon", maMon);
                            cmd.ExecuteNonQuery();
                        }

                        // 3. Thêm lại danh sách nguyên liệu mới
                        foreach (DataRow row in dtNguyenLieu.Rows)
                        {
                            string sqlThem = @"INSERT INTO NguyenLieu_MonAn (MaMonAn, MaNguyenLieu, SoLuong)
                        VALUES (@MaMon, @MaNguyenLieu, @SoLuong)";

                            using (SqlCommand cmd = new SqlCommand(sqlThem, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@MaMon", maMon);
                                cmd.Parameters.AddWithValue("@MaNguyenLieu", row["MaNguyenLieu"]);
                                cmd.Parameters.AddWithValue("@SoLuong", row["SoLuong"]);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();
                        return true;
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }
        //Xóa món ăn
        public bool XoaMonAn(string maMon)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Xóa nguyên liệu liên kết với món ăn
                        string sqlNguyenLieu = @"
                    DELETE FROM NguyenLieu_MonAn
                    WHERE MaMonAn = @MaMon";

                        using (SqlCommand cmd = new SqlCommand(sqlNguyenLieu, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@MaMon", maMon);
                            cmd.ExecuteNonQuery();
                        }

                        // 2. Xóa món ăn
                        string sqlMonAn = @"
                    DELETE FROM MonAn
                    WHERE MaMonAn = @MaMon";

                        int ketQua;

                        using (SqlCommand cmd = new SqlCommand(sqlMonAn, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@MaMon", maMon);
                            ketQua = cmd.ExecuteNonQuery();
                        }

                        tran.Commit();

                        return ketQua > 0;
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }
        //bat dau dung stored procedure
    }
}
