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
        public DataTable DSNguyenLieu()
        {
            try
            {
                return dao.DSNguyenLieu("", "", "");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách nguyên liệu: " + ex.Message);
            }
        }

        public DataTable TimKiem(string ten, string congDung, string CCD)
        {
            try
            {
                ten = string.IsNullOrWhiteSpace(ten) ? "" : ten.Trim();
                congDung = string.IsNullOrWhiteSpace(congDung) ? "" : congDung.Trim();
                CCD = string.IsNullOrWhiteSpace(CCD) ? "" : CCD.Trim();
                return dao.DSNguyenLieu(ten, congDung, CCD);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tìm kiếm nguyên liệu: " + ex.Message);
            }
        }

        public DataTable LayTheoMa(string ma)
        {
            if (string.IsNullOrWhiteSpace(ma))
                throw new Exception("Mã nguyên liệu không được để trống.");

            return dao.LayTheoMa(ma.Trim());
            /*try
            {
                DataTable dt = dao.LayTheoMa(ma.Trim());
                if (dt.Rows.Count == 0)
                    throw new Exception("Không tìm thấy nguyên liệu này.");
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy thông tin nguyên liệu: " + ex.Message);
            }*/
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

        public DataTable DSNhaCungCap()
        {
            try
            {
                return dao.DSNhaCungCap();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách nhà cung cấp: " + ex.Message);
            }
        }

        public bool ThemNguyenLieu(
                                string ma,
                                string ten,
                                string donViTinh,
                                decimal donGiaNhap,
                                string congDung,
                                string yeuCau,
                                string CCD)
        {
            // Kiểm tra dữ liệu bắt buộc
            if (string.IsNullOrWhiteSpace(ma))
                throw new Exception("Mã nguyên liệu không được để trống.");

            if (string.IsNullOrWhiteSpace(ten))
                throw new Exception("Tên nguyên liệu không được để trống.");

            if (string.IsNullOrWhiteSpace(donViTinh))
                throw new Exception("Đơn vị tính không được để trống.");

            if (donGiaNhap < 0)
                throw new Exception("Đơn giá nhập không được âm.");

            if (string.IsNullOrWhiteSpace(congDung))
                throw new Exception("Công dụng không được để trống.");

            try
            {
                // Kiểm tra mã trùng
                if (dao.LayTheoMa(ma.Trim()).Rows.Count > 0)
                    throw new Exception("Mã nguyên liệu này đã tồn tại.");

                return dao.ThemNguyenLieu(ma.Trim(), ten.Trim(), donViTinh.Trim(), 
                    donGiaNhap, congDung.Trim(), yeuCau ?? "", CCD.Trim());
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm nguyên liệu: " + ex.Message);
            }
        }

        public bool SuaNguyenLieu(string ma, string ten, string donvi, decimal soluong,
            decimal nhap, decimal ban, string congdung, string yeucau, string chidinh)
        {
            if (string.IsNullOrWhiteSpace(ma))
                throw new Exception("Mã nguyên liệu không được để trống.");

            if (string.IsNullOrWhiteSpace(ten))
                throw new Exception("Tên nguyên liệu không được để trống.");

            if (string.IsNullOrWhiteSpace(donvi))
                throw new Exception("Đơn vị tính không được để trống.");

            if (soluong < 0)
                throw new Exception("Số lượng không được âm.");

            if (nhap < 0)
                throw new Exception("Đơn giá nhập không được âm.");

            if (ban < 0)
                throw new Exception("Đơn giá bán không được âm.");

            if (nhap > ban)
                throw new Exception("Đơn giá nhập không được lớn hơn đơn giá bán.");

            try
            {
                if (dao.LayTheoMa(ma.Trim()).Rows.Count == 0)
                    throw new Exception("Nguyên liệu không tồn tại.");

                return dao.SuaNguyenLieu(ma.Trim(), ten.Trim(), donvi.Trim(), soluong, 
                    nhap, ban, congdung.Trim(), yeucau ?? "", chidinh ?? "");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi sửa nguyên liệu: " + ex.Message);
            }
        }

        public void XoaNguyenLieu(string maNguyenLieu)
        {
            if (string.IsNullOrWhiteSpace(maNguyenLieu))
                throw new Exception("Vui lòng chọn nguyên liệu cần xóa.");

            maNguyenLieu = maNguyenLieu.Trim();

            try
            {
                if (dao.LayTheoMa(maNguyenLieu).Rows.Count == 0)
                    throw new Exception("Nguyên liệu không tồn tại.");

                bool ketQua = dao.XoaNguyenLieu(maNguyenLieu);

                if (!ketQua)
                    throw new Exception("Xóa nguyên liệu thất bại.");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa nguyên liệu: " + ex.Message);
            }
        }

        //lay danh sach nguyen lieu dung trong trang them/sua mon an
        public DataTable DSNguyenLieuThemMonAn(string ten)
        {
            try
            {
                ten = string.IsNullOrWhiteSpace(ten) ? "" : ten.Trim();
                DataTable dt = dao.DSNguyenLieu(ten, "", "");
                return dt.DefaultView.ToTable(
                    false,
                    "MaNguyenLieu",
                    "TenNguyenLieu",
                    "DonViTinh",
                    "SoLuong",
                    "DonGiaBan"
                );
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách nguyên liệu: " + ex.Message);
            }
        }

        //lay nguyen lieu de cho vao bang nguyen lieu che bien mon an
        public DataTable LayNguyenLieuThemMonAn(string ma)
        {
            if (string.IsNullOrWhiteSpace(ma))
                throw new Exception("Mã nguyên liệu không được để trống.");

            try
            {
                DataTable dt = dao.LayTheoMa(ma.Trim());
                if (dt.Rows.Count == 0)
                    throw new Exception("Không tìm thấy nguyên liệu.");

                return dt.DefaultView.ToTable(
                    false,
                    "MaNguyenLieu",
                    "TenNguyenLieu",
                    "DonViTinh",
                    "DonGiaBan"
                );
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy thông tin nguyên liệu: " + ex.Message);
            }
        }

        public decimal LaySoLuong(string ma)
        {
            if (string.IsNullOrWhiteSpace(ma))
                throw new Exception("Mã nguyên liệu không được để trống.");

            try
            {
                DataTable dt = dao.LayTheoMa(ma.Trim());
                if (dt.Rows.Count == 0)
                    throw new Exception("Không tìm thấy nguyên liệu.");

                DataRow row = dt.Rows[0];
                if (row["SoLuong"] == DBNull.Value)
                    return 0;

                if (decimal.TryParse(row["SoLuong"].ToString(), out decimal sl))
                    return sl;
                else
                    throw new Exception("Số lượng không phải là số hợp lệ.");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy số lượng nguyên liệu: " + ex.Message);
            }
        }
    }
}
