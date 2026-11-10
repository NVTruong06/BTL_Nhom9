using LTTQ_BTL.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LTTQ_BTL.BLL
{
    public class LoaiCongDungBLL
    {
        LoaiCongDungDao dao = new LoaiCongDungDao();

        public DataTable DSCongDung()
        {
            return dao.DSCongDung();
        }

        public DataTable DSLoai()
        {
            return dao.DSLoai();
        }
    }
}
