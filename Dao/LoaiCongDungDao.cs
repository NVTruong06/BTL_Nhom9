using LTTQ_BTL.Dal;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LTTQ_BTL.Dao
{
    public class LoaiCongDungDao
    {
        Database db = new Database();
        public DataTable DSLoai()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_DSLoai", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
            }
            return dt;
        }

        public DataTable DSCongDung()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_DSCongDung", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
            }
            return dt;
        }
    }
}
