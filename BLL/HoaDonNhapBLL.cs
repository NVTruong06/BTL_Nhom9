using LTTQ_BTL.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LTTQ_BTL.BLL
{
    public class HoaDonNhapBLL
    {
        HoaDonNhapDao dao = new HoaDonNhapDao();

        public DataTable DSHoaDonNhap()
        {
            try
            {
                DataTable dt = dao.DSHoaDonNhap();
                if (dt.Rows.Count == 0)
                    return new DataTable(); // Trả về bảng rỗng thay vì lỗi

                return dt.DefaultView.ToTable(false, "MaHoaDonNhap", "NgayNhap", "TenNhanVien", "TenNhaCungCap", "TongTien");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách hóa đơn nhập: " + ex.Message);
            }
        }

        public DataTable ChiTietHoaDon(string ma)
        {
            if (string.IsNullOrWhiteSpace(ma))
                throw new Exception("Mã hóa đơn không được để trống.");

            try
            {
                DataTable dt = dao.ChiTietHoaDonNhap(ma.Trim());
                if (dt.Rows.Count == 0)
                    return new DataTable();

                return dt.DefaultView.ToTable(false, "MaHoaDonNhap", "MaNguyenLieu", "TenNguyenLieu", "SoLuong", "DonGia", "KhuyenMai", "ThanhTien");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy chi tiết hóa đơn: " + ex.Message);
            }
        }

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
            // Kiểm tra dữ liệu bắt buộc
            if (string.IsNullOrWhiteSpace(maHoaDon))
                throw new Exception("Mã hóa đơn không được để trống.");

            if (string.IsNullOrWhiteSpace(maNhanVien))
                throw new Exception("Nhân viên không được để trống.");

            if (string.IsNullOrWhiteSpace(maNhaCungCap))
                throw new Exception("Nhà cung cấp không được để trống.");

            if (string.IsNullOrWhiteSpace(maNguyenLieu))
                throw new Exception("Nguyên liệu không được để trống.");

            if (soLuong <= 0)
                throw new Exception("Số lượng phải lớn hơn 0.");

            if (donGia <= 0)
                throw new Exception("Đơn giá phải lớn hơn 0.");

            if (khuyenMai < 0)
                throw new Exception("Khuyến mại không được âm.");

            if (khuyenMai > 100)
                throw new Exception("Khuyến mại không được vượt quá 100%.");

            if (tongTien <= 0)
                throw new Exception("Tổng tiền phải lớn hơn 0.");

            try
            {
                return dao.ThemPhieuNhap(
                    maHoaDon.Trim(), ngayNhap, maNhanVien.Trim(), maNhaCungCap.Trim(), 
                    tongTien, maNguyenLieu.Trim(), soLuong, donGia, khuyenMai);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm phiếu nhập: " + ex.Message);
            }
        }

        public DataTable LayTheoMa(string ma)
        {
            if (string.IsNullOrWhiteSpace(ma))
                throw new Exception("Mã hóa đơn không được để trống.");

            try
            {
                DataTable dt = dao.LayTheoMa(ma.Trim());
                if (dt.Rows.Count == 0)
                    throw new Exception("Không tìm thấy hóa đơn này.");
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy thông tin hóa đơn: " + ex.Message);
            }
        }
    }
}
