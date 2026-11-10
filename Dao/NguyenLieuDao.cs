using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using LTTQ_BTL.Dal;
using Microsoft.Data.SqlClient;

namespace LTTQ_BTL.Dao
{
    public class NguyenLieuDAO
    {
        Database db = new Database();

        public DataTable DSNguyenLieu()
        {
            DataTable dt = new DataTable();
            using(SqlConnection conn = db.GetConnection())
            {
                string sql = "SELECT * FROM NguyenLieu;";

                SqlDataAdapter adapter = new SqlDataAdapter(sql,conn);

                adapter.Fill(dt);
            }
            return dt;
        }

        public DataTable TimKiem(string ten, string congdung,string ccd)
        {
            DataTable dt = new DataTable();
            using(SqlConnection conn = db.GetConnection())
            {
                string sql = "SELECT * FROM NguyenLieu " +
                    "WHERE TenNguyenLieu LIKE @Ten AND CongDung LIKE @Congdung AND ChongChiDinh LIKE @CCD";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                adapter.SelectCommand.Parameters.AddWithValue("@Ten", "%" +  ten + "%");
                adapter.SelectCommand.Parameters.AddWithValue("@Congdung", "%" + congdung + "%");
                adapter.SelectCommand.Parameters.AddWithValue("@CCD", "%" + ccd + "%");

                adapter.Fill(dt);
            }
            return dt;
        }

        public DataTable LayTheoMa(string ma)
        {
            DataTable dt = new DataTable();
            using(SqlConnection conn = db.GetConnection())
            {
                string sql = "SELECT * FROM NguyenLieu WHERE MaNguyenLieu = @Ma";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                adapter.SelectCommand.Parameters.AddWithValue("@Ma", ma);

                adapter.Fill(dt);
            }
            return dt;
        }

        public bool SuaNguyenLieu(string ma, string ten, string donvi, decimal soluong,
            decimal nhap, decimal ban, string congdung, string yeucau, string chidinh)
        {
            using(SqlConnection conn = db.GetConnection())
            {
                string sql = @"UPDATE NguyenLieu SET " + 
                    "TenNguyenLieu = @Ten, DonViTinh = @DonVi, SoLuong = @SL, DonGiaNhap = @Nhap, DonGiaBan = @Ban, CongDung = @CD, YeuCau = @YC, ChongChiDinh = @CCD " +
                    "WHERE MaNguyenLieu = @Ma;";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Ten", ten);
                cmd.Parameters.AddWithValue("@DonVi", donvi);
                cmd.Parameters.AddWithValue("@SL", soluong);
                cmd.Parameters.AddWithValue("@Nhap", nhap);
                cmd.Parameters.AddWithValue("@Ban", ban);
                cmd.Parameters.AddWithValue("@CD", congdung);
                cmd.Parameters.AddWithValue("@YC", yeucau);
                cmd.Parameters.AddWithValue("@CCD", chidinh);
                cmd.Parameters.AddWithValue("@Ma", ma);

                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public DataTable DSNhanVien()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = "SELECT * FROM NhanVien;";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                adapter.Fill(dt);
            }
            return dt;
        }

        public DataTable DSNhaCungCap()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = "SELECT * FROM NhaCungCap;";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                adapter.Fill(dt);
            }
            return dt;
        }
        //bat dau dung stored procedure
        public DataTable DSNguyenLieuThemMonAn(string ten)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_TimKiemNguyenLieu", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Ten", ten);
                cmd.Parameters.AddWithValue("CongDung", "");
                cmd.Parameters.AddWithValue("CCD", "");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
            }
            return dt.DefaultView.ToTable(
                false,
                "MaNguyenLieu",
                "TenNguyenLieu",
                "DonViTinh",
                "SoLuong",
                "DonGiaBan"
            );
        }

        public DataTable LayNguyenLieuMonAN(string ma)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_LayNguyenLieuTheoMa", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("MaNguyenLieu", ma);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
            }
            return dt.DefaultView.ToTable(
                false,
                "MaNguyenLieu",
                "TenNguyenLieu",
                "DonViTinh",
                "DonGiaBan"
            );
        }

        public decimal LaySoLuong(string ma)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_LayNguyenLieuTheoMa", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("MaNguyenLieu", ma);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
            }
            DataRow row = dt.Rows[0];
            decimal.TryParse(row["SoLuong"].ToString(), out decimal sl);
            return sl;
        }
    }
}
