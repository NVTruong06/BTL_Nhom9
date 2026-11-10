using LTTQ_BTL.Dal;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LTTQ_BTL.Dao
{
    public class HoaDonNhapDao
    {
        Database db = new Database();

        public bool ThemPhieuNhap(
            string maHoaDon,
            DateTime ngayNhap,
            string maNhanVien,
            string maNhaCungCap,
            decimal tongTien,
            string maNguyenLieu,
            decimal soLuong,
            decimal donGia,
            decimal khuyenMai)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    string sqlPhieuNhap = @"INSERT INTO HoaDonNhap (MaHoaDonNhap, NgayNhap, MaNhanVien, MaNhaCungCap, TongTien) 
                        VALUES (@MaHD, @Date, @MaNhanVien, @MaNCC, @TongTien);";

                    SqlCommand cmd1 = new SqlCommand(sqlPhieuNhap, conn, tran);

                    cmd1.Parameters.AddWithValue("@MaHD", maHoaDon);
                    cmd1.Parameters.AddWithValue("@Date", ngayNhap);
                    cmd1.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    cmd1.Parameters.AddWithValue("@MaNCC", maNhaCungCap);
                    cmd1.Parameters.AddWithValue("@TongTien", tongTien);

                    cmd1.ExecuteNonQuery();


                    string sqlChiTiet = @"INSERT INTO ChiTietHoaDonNhap(MaHoaDonNhap, MaNguyenLieu, SoLuong, DonGia, KhuyenMai, ThanhTien)
                        VALUES(@MaHD, @MaNguyenLieu, @SoLuong, @DonGia, @KhuyenMai, @ThanhTien)";

                    SqlCommand cmd2 = new SqlCommand(sqlChiTiet, conn, tran);

                    cmd2.Parameters.AddWithValue("@MaHD", maHoaDon);
                    cmd2.Parameters.AddWithValue("@MaNguyenLieu", maNguyenLieu);
                    cmd2.Parameters.AddWithValue("@SoLuong", soLuong);
                    cmd2.Parameters.AddWithValue("@DonGia", donGia);
                    cmd2.Parameters.AddWithValue("@KhuyenMai", khuyenMai);
                    cmd2.Parameters.AddWithValue("@ThanhTien", tongTien);

                    cmd2.ExecuteNonQuery();



                    string sqlCapNhat = @"UPDATE NguyenLieu SET SoLuong = SoLuong + @SoLuong
                        WHERE MaNguyenLieu = @MaNguyenLieu";

                    SqlCommand cmd3 = new SqlCommand(sqlCapNhat, conn, tran);

                    cmd3.Parameters.AddWithValue("@SoLuong", soLuong);
                    cmd3.Parameters.AddWithValue("@MaNguyenLieu", maNguyenLieu);

                    int ketQua = cmd3.ExecuteNonQuery();

                    if (ketQua == 0)
                        throw new Exception("Không tìm thấy nguyên liệu!");

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


        public DataTable LayTheoMa(string ma)
        {
            DataTable dt = new DataTable();

            using(SqlConnection conn = db.GetConnection())
            {
                string sql = "SELECT * FROM HoaDonNhap WHERE MaHoaDonNhap = @Ma;";

                SqlDataAdapter adapter = new SqlDataAdapter(sql,conn);

                adapter.SelectCommand.Parameters.AddWithValue("@Ma", ma);

                adapter.Fill(dt);
            }
            return dt;
        }
    }
}
