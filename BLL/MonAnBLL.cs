using LTTQ_BTL.Dao;
using System;
using System.Collections.Generic;
using System.Text;

namespace LTTQ_BTL.BLL
{
    public class MonAnBLL
    {
        MonAnDao dao = new MonAnDao();

        public bool KiemTraMon(string ma)
        {
            if(dao.LayTheoMa(ma).Rows.Count>0) return false;
            else return true;
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
            return dao.ThemMonAn(
                maMon, tenMon, maCongDung,maLoai, cachLam, yeuCau, donGia, hinhAnh);
        }

        public bool ThemNguyenLieuMonAn(
                                    string maMon,
                                    string maNguyenLieu,
                                    decimal soLuong)
        {
            return dao.ThemNguyenLieuMonAn(maMon, maNguyenLieu, soLuong);
        }
    }
}
