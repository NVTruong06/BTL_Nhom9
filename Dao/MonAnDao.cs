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
                string sql = "SELECT MaMonAn, TenMonAn, TenCongDung, TenLoai, CachLam, YeuCau, DonGia " +
                    "FROM MonAn JOIN CongDung ON MonAn.MaCongDung = CongDung.MaCongDung JOIN LoaiMon ON MonAn.MaLoai = LoaiMon.MaLoai " +
                    "WHERE MaMonAn = @Ma";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                adapter.SelectCommand.Parameters.AddWithValue("@Ma", ma);

                adapter.Fill(dt);
            }
            return dt;
        }
    }
}
