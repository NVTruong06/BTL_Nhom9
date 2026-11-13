using System;
using System.Data;
using QuanLyNhaHang.DAL;

namespace QuanLyNhaHang.BLL
{
    public class NhanVienBLL
    {
        NhanVienDAL nvDAL = new NhanVienDAL();

        public DataTable LayDanhSachNhanVien()
        {
            return NhanVienDAL.LayDanhSachNhanVien();
        }

        public DataTable TimKiemNhanVien(string tuKhoa)
        {
            return NhanVienDAL.TimKiemNhanVien(tuKhoa);
        }

        public bool ThemNhanVien(string ma, string ten, string gt, DateTime ns, string dc, string maQue, string dt)
        {
            if (string.IsNullOrEmpty(ma) || string.IsNullOrEmpty(ten))
                return false;

            return NhanVienDAL.ThemNhanVien(ma, ten, gt, ns, dc, maQue, dt);
        }
    }
}