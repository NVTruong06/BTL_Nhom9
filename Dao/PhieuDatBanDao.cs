using LTTQ_BTL.Dal;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LTTQ_BTL.Dao
{
    public class PhieuDatBanDao
    {
        Database db = new Database();
        //lay danh sach phieu
        public DataTable DSPhieuDatBan()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = db.GetConnection())
            {
                string sql = @"SELECT * 
                FROM PhieuDatBan JOIN Khach ON PhieuDatBan.MaKhach = Khach.MaKhach 
                JOIN NhanVien ON PhieuDatBan.MaNhanVien = NhanVien.MaNhanVien";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.Fill(dt);
            }

            return dt;
        }
        //lay phieu theo ma
        public DataTable LayPhieuDatBan(string ma)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = db.GetConnection())
            {
                string sql = @"SELECT * 
                FROM PhieuDatBan JOIN Khach ON PhieuDatBan.MaKhach = Khach.MaKhach 
                JOIN NhanVien ON PhieuDatBan.MaNhanVien = NhanVien.MaNhanVien
                WHERE MaPhieu = @MaPhieu";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@MaPhieu", ma);
                adapter.Fill(dt);
            }

            return dt;
        }
        //lay chi tiet phieu(theo ma)

        public DataTable DSChiTietPhieuDatBan(string ma)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = db.GetConnection())
            {
                string sql = @"SELECT * 
                FROM ChiTietPhieuDatBan JOIN MonAn ON ChiTietPhieuDatBan.MaMonAn = MonAn.MaMonAn 
                WHERE MaPhieu = @MaPhieu";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@MaPhieu", ma);
                adapter.Fill(dt);
            }

            return dt;
        }

        //create phieu
        public bool ThemPhieuDatBan(
                            string maPhieu,
                            string maKhach,
                            string maNhanVien,
                            DateTime ngayDat,
                            DateTime ngayDung,
                            decimal tongTien,
                            DataTable dtChiTiet)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string sql = @"INSERT INTO PhieuDatBan (MaPhieu, MaKhach, MaNhanVien, NgayDat, NgayDung, TongTien)
                    VALUES (@MaPhieu, @MaKhach, @MaNhanVien, @NgayDat, @NgayDung, @TongTien)";

                        using (SqlCommand cmd = new SqlCommand(sql, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                            cmd.Parameters.AddWithValue("@MaKhach", maKhach);
                            cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                            cmd.Parameters.AddWithValue("@NgayDat", ngayDat);
                            cmd.Parameters.AddWithValue("@NgayDung", ngayDung);
                            cmd.Parameters.AddWithValue("@TongTien", tongTien);

                            cmd.ExecuteNonQuery();
                        }

                        string sqlCT = @"INSERT INTO ChiTietPhieuDatBan(MaPhieu, MaMonAn, MaLoai, SoLuong, DonGia, GiamGia, ThanhTien)
                    VALUES(@MaPhieuDatBan, @MaMonAn, @MaLoai, @SoLuong, @DonGia, @GiamGia, @ThanhTien)";

                        foreach (DataRow row in dtChiTiet.Rows)
                        {
                            using (SqlCommand cmd = new SqlCommand(sqlCT, conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@MaPhieuDatBan", row["MaPhieu"]);
                                cmd.Parameters.AddWithValue("@MaMonAn", row["MaMonAn"]);
                                cmd.Parameters.AddWithValue("@MaLoai", row["MaLoai"]);
                                cmd.Parameters.AddWithValue("@SoLuong", row["SoLuong"]);
                                cmd.Parameters.AddWithValue("@DonGia", row["DonGia"]);
                                cmd.Parameters.AddWithValue("@GiamGia", row["GiamGia"]);
                                cmd.Parameters.AddWithValue("@ThanhTien", row["ThanhTien"]);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        TruNguyenLieuDatBan(conn, trans, dtChiTiet);

                        trans.Commit();
                        return true;
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        private void TruNguyenLieuDatBan(
                                SqlConnection conn,
                                SqlTransaction tran,
                                DataTable dtChiTiet)
        {
            foreach (DataRow row in dtChiTiet.Rows)
            {
                string maMon = row["MaMonAn"].ToString();

                if (!int.TryParse(row["SoLuong"].ToString(), out int soLuongMon)
                    || soLuongMon <= 0)
                {
                    throw new Exception("Số lượng món ăn không hợp lệ.");
                }

                // Đếm số nguyên liệu cần dùng cho món ăn
                string sqlDem = @"SELECT COUNT(*) FROM NguyenLieu_MonAn WHERE MaMonAn = @MaMon";

                int soNguyenLieu;

                using (SqlCommand cmd = new SqlCommand(sqlDem, conn, tran))
                {
                    cmd.Parameters.Add("@MaMon", SqlDbType.VarChar, 20).Value = maMon;

                    soNguyenLieu = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // Trừ số lượng nguyên liệu trong kho
                string sqlTru = @"UPDATE NL SET NL.SoLuong = NL.SoLuong - NLM.SoLuong * @SoLuongMon
            FROM NguyenLieu NL INNER JOIN NguyenLieu_MonAn NLM ON NL.MaNguyenLieu = NLM.MaNguyenLieu
            WHERE NLM.MaMonAn = @MaMon AND NL.SoLuong >= NLM.SoLuong * @SoLuongMon";

                int soDongCapNhat;

                using (SqlCommand cmd = new SqlCommand(sqlTru, conn, tran))
                {
                    cmd.Parameters.Add("@MaMon", SqlDbType.VarChar, 20).Value = maMon;
                    cmd.Parameters.Add("@SoLuongMon", SqlDbType.Int).Value = soLuongMon;

                    soDongCapNhat = cmd.ExecuteNonQuery();
                }

                // Nếu có bất kỳ nguyên liệu nào không đủ thì báo lỗi
                if (soDongCapNhat != soNguyenLieu)
                {
                    throw new Exception(
                        "Không đủ nguyên liệu để thực hiện đặt món: " + maMon
                    );
                }
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

        public DataTable DSKhach()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = "SELECT * FROM Khach;";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                adapter.Fill(dt);
            }
            return dt;
        }
        //update phieu
        public bool SuaPhieuDatBan(
                        string maPhieu,
                        string maKhach,
                        string maNhanVien,
                        DateTime ngayDat,
                        DateTime ngayDung,
                        decimal tongTien,
                        DataTable dtChiTiet)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {

                        string sql = @"UPDATE PhieuDatBan SET MaKhach = @MaKhach, MaNhanVien = @MaNhanVien, NgayDat = @NgayDat,NgayDung = @NgayDung, TongTien = @TongTien
                    WHERE MaPhieu = @MaPhieu";

                        using (SqlCommand cmd = new SqlCommand(sql, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                            cmd.Parameters.AddWithValue("@MaKhach", maKhach);
                            cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                            cmd.Parameters.AddWithValue("@NgayDat", ngayDat);
                            cmd.Parameters.AddWithValue("@NgayDung", ngayDung);
                            cmd.Parameters.AddWithValue("@TongTien", tongTien);

                            cmd.ExecuteNonQuery();
                        }

                        string sqlXoa = @"DELETE FROM ChiTietPhieuDatBan
                    WHERE MaPhieu = @MaPhieu";

                        using (SqlCommand cmd = new SqlCommand(sqlXoa, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                            cmd.ExecuteNonQuery();
                        }

                        string sqlThem = @"INSERT INTO ChiTietPhieuDatBan(MaPhieu, MaMonAn, MaLoai, SoLuong, DonGia, GiamGia, ThanhTien)
                    VALUES(@MaPhieu, @MaMonAn, @MaLoai, @SoLuong, @DonGia, @GiamGia, @ThanhTien)";

                        foreach (DataRow row in dtChiTiet.Rows)
                        {
                            using (SqlCommand cmd = new SqlCommand(sqlThem, conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                                cmd.Parameters.AddWithValue("@MaMonAn", row["MaMonAn"]);
                                cmd.Parameters.AddWithValue("@MaLoai", row["MaLoai"]);
                                cmd.Parameters.AddWithValue("@SoLuong", row["SoLuong"]);
                                cmd.Parameters.AddWithValue("@DonGia", row["DonGia"]);
                                cmd.Parameters.AddWithValue("@GiamGia", row["GiamGia"]);
                                cmd.Parameters.AddWithValue("@ThanhTien", row["ThanhTien"]);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        trans.Commit();
                        return true;
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        //xóa phiếu đặt bàn 
        public bool XoaPhieuDatBan(string maPhieu)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Kiểm tra phiếu đặt bàn có tồn tại không
                        string sqlKiemTra = @"
                    SELECT COUNT(1)
                    FROM PhieuDatBan
                    WHERE MaPhieu = @MaPhieu";

                        using (SqlCommand cmd = new SqlCommand(sqlKiemTra, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);

                            int tonTai = Convert.ToInt32(cmd.ExecuteScalar());

                            if (tonTai == 0)
                            {
                                tran.Commit();
                                return false;
                            }
                        }

                        // 2. Hoàn lại nguyên liệu đã trừ
                        string sqlHoanNguyenLieu = @"
                    UPDATE NL
                    SET NL.SoLuong = ISNULL(NL.SoLuong, 0) + CT.SoLuongHoan
                    FROM NguyenLieu NL
                    INNER JOIN
                    (
                        SELECT
                            NLM.MaNguyenLieu,
                            SUM(NLM.SoLuong * CT.SoLuong) AS SoLuongHoan
                        FROM ChiTietPhieuDatBan CT
                        INNER JOIN NguyenLieu_MonAn NLM
                            ON CT.MaMonAn = NLM.MaMonAn
                        WHERE CT.MaPhieu = @MaPhieu
                        GROUP BY NLM.MaNguyenLieu
                    ) CT
                        ON NL.MaNguyenLieu = CT.MaNguyenLieu";

                        using (SqlCommand cmd = new SqlCommand(sqlHoanNguyenLieu, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                            cmd.ExecuteNonQuery();
                        }

                        // 3. Xóa chi tiết phiếu đặt bàn
                        string sqlXoaChiTiet = @"
                    DELETE FROM ChiTietPhieuDatBan
                    WHERE MaPhieu = @MaPhieu";

                        using (SqlCommand cmd = new SqlCommand(sqlXoaChiTiet, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                            cmd.ExecuteNonQuery();
                        }

                        // 4. Xóa phiếu đặt bàn
                        string sqlXoaPhieu = @"
                    DELETE FROM PhieuDatBan
                    WHERE MaPhieu = @MaPhieu";

                        using (SqlCommand cmd = new SqlCommand(sqlXoaPhieu, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                            cmd.ExecuteNonQuery();
                        }

                        // 5. Hoàn tất
                        tran.Commit();
                        return true;
                    }
                    catch (SqlException ex) when (ex.Number == 547)
                    {
                        tran.Rollback();

                        throw new Exception(
                            "Không thể xóa phiếu đặt bàn vì phiếu đang được liên kết với dữ liệu khác.", ex);
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
