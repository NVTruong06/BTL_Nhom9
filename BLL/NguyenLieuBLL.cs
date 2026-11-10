using LTTQ_BTL.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LTTQ_BTL.BLL
{
    public class NguyenLieuBLL
    {
        NguyenLieuDAO dao = new NguyenLieuDAO();

        public DataTable DSNguyenLieuThemMonAn(string ten)
        {
            return dao.DSNguyenLieuThemMonAn(ten);
        }

        public DataTable LayNguyenLieuThemMonAn(string ma)
        {
            return dao.LayNguyenLieuMonAN(ma);
        }

        public decimal LaySoLuong(string ma)
        {
            return dao.LaySoLuong(ma);
        }
    }
}
