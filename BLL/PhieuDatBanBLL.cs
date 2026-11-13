using LTTQ_BTL.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LTTQ_BTL.BLL
{
    public class PhieuDatBanBLL
    {
        PhieuDatBanDao dao = new PhieuDatBanDao();

        //danh sach phieu dat ban
        public DataTable DSPhieuDatBan()
        {
            try
            {
                DataTable dt = dao.DSPhieuDatBan();
                if (dt.Rows.Count == 0)
                    return new DataTable();

                return dt.DefaultView.ToTable(
                    false, "MaPhieu", "TenKhach", "TenNhanVien", "NgayDat", "NgayDung", "TongTien");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách phiếu đặt bàn: " + ex.Message);
            }
        }

        //chi tiet phieu dat ban
        public DataTable LayPhieuDatBan(string ma)
        {
            if (string.IsNullOrWhiteSpace(ma))
                throw new Exception("Mã phiếu đặt bàn không được để trống.");

            DataTable dt = dao.LayPhieuDatBan(ma.Trim());
            return dt.DefaultView.ToTable(
                    false, "MaPhieu", "MaKhach", "MaNhanVien", "NgayDat", "NgayDung", "TongTien");
            /*try
            {
                DataTable dt = dao.LayPhieuDatBan(ma.Trim());
                if (dt.Rows.Count == 0)
                    throw new Exception("Không tìm thấy phiếu đặt bàn này.");

                return dt.DefaultView.ToTable(
                    false, "MaPhieu", "MaKhach", "MaNhanVien", "NgayDat", "NgayDung", "TongTien");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy thông tin phiếu đặt bàn: " + ex.Message);
            }*/
        }

        //danh sach mon trong phieu
        public DataTable DSChiTietPhieuDat(string ma)
        {
            if (string.IsNullOrWhiteSpace(ma))
                throw new Exception("Mã phiếu đặt bàn không được để trống.");

            try
            {
                DataTable dt = dao.DSChiTietPhieuDatBan(ma.Trim());
                if (dt.Rows.Count == 0)
                    return new DataTable();

                return dt.DefaultView.ToTable(false, "MaMonAN", "TenMonAn", "MaLoai", "SoLuong", "DonGia", "GiamGia", "ThanhTien");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy chi tiết phiếu đặt bàn: " + ex.Message);
            }
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
            // Kiểm tra dữ liệu bắt buộc
            if (string.IsNullOrWhiteSpace(maPhieu))
                throw new Exception("Mã phiếu không được để trống.");

            if (string.IsNullOrWhiteSpace(maKhach))
                throw new Exception("Khách hàng không được để trống.");

            if (string.IsNullOrWhiteSpace(maNhanVien))
                throw new Exception("Nhân viên không được để trống.");

            if (tongTien <= 0)
                throw new Exception("Tổng tiền phải lớn hơn 0.");

            if (dtChiTiet == null || dtChiTiet.Rows.Count == 0)
                throw new Exception("Phiếu đặt bàn phải có ít nhất một món ăn.");

            try
            {
                return dao.ThemPhieuDatBan(
                    maPhieu.Trim(),
                    maKhach.Trim(),
                    maNhanVien.Trim(),
                    ngayDat,
                    ngayDung,
                    tongTien,
                    dtChiTiet
                );
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm phiếu đặt bàn: " + ex.Message);
            }
        }

        public DataTable DSKhach()
        {
            try
            {
                return dao.DSKhach();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách khách hàng: " + ex.Message);
            }
        }

        public DataTable DSNhanVien()
        {
            try
            {
                return dao.DSNhanVien();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách nhân viên: " + ex.Message);
            }
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
            // Kiểm tra dữ liệu bắt buộc
            if (string.IsNullOrWhiteSpace(maPhieu))
                throw new Exception("Mã phiếu không được để trống.");

            if (string.IsNullOrWhiteSpace(maKhach))
                throw new Exception("Khách hàng không được để trống.");

            if (string.IsNullOrWhiteSpace(maNhanVien))
                throw new Exception("Nhân viên không được để trống.");

            if (ngayDat >= ngayDung)
                throw new Exception("Ngày đặt phải nhỏ hơn ngày dùng.");

            if (ngayDat < DateTime.Now.Date)
                throw new Exception("Ngày đặt không được nhỏ hơn hôm nay.");

            if (tongTien <= 0)
                throw new Exception("Tổng tiền phải lớn hơn 0.");

            if (dtChiTiet == null || dtChiTiet.Rows.Count == 0)
                throw new Exception("Phiếu đặt bàn phải có ít nhất một món ăn.");

            try
            {
                return dao.SuaPhieuDatBan(
                    maPhieu.Trim(),
                    maKhach.Trim(),
                    maNhanVien.Trim(),
                    ngayDat,
                    ngayDung,
                    tongTien,
                    dtChiTiet
                );
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi sửa phiếu đặt bàn: " + ex.Message);
            }
        }

        //xóa phiếu đặt bàn
        public void XoaPhieuDatBan(string maPhieu)
        {
            if (string.IsNullOrWhiteSpace(maPhieu))
                throw new Exception("Vui lòng chọn phiếu đặt bàn cần xóa.");

            bool ketQua = dao.XoaPhieuDatBan(maPhieu.Trim());

            if (!ketQua)
                throw new Exception("Phiếu đặt bàn không tồn tại.");
        }

    }
}
