using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace LTTQ_BTL.Dal
{
    public class Database
    {
        private string connStr =
            @"Data Source=localhost;
              Initial Catalog=QuanLyNhaHang;
              Integrated Security=True;
              TrustServerCertificate=True;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connStr);
        }
    }
}
