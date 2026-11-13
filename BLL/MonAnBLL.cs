using LTTQ_BTL.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LTTQ_BTL.BLL
{
    public class MonAnBLL
    {
        MonAnDao dao = new MonAnDao();
        //hien thi danh sach mon an
        public DataTable DSMonAn()
        {
            try
            {
                return dao.DSMonAn("", "", "");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách món ăn: " + ex.Message);
            }
        }
        //hien thi danh sach sau tim kiem
        public DataTable TimKiem(string ten, string loai, string congDung)
        {
            try
            {
                ten = string.IsNullOrWhiteSpace(ten) ? "" : ten.Trim();
                loai = string.IsNullOrWhiteSpace(loai) ? "" : loai.Trim();
                congDung = string.IsNullOrWhiteSpace(congDung) ? "" : congDung.Trim();
                return dao.DSMonAn(ten, loai, congDung);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tìm kiếm món ăn: " + ex.Message);
            }
        }

        public bool KiemTraMon(string ma)
        {
            if (string.IsNullOrWhiteSpace(ma))
                throw new Exception("Mã món ăn không được để trống.");

            try
            {
                return dao.LayTheoMa(ma).Rows.Count == 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kiểm tra món ăn: " + ex.Message);
            }
        }
        //them mon an
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
            // Kiểm tra dữ liệu bắt buộc
            if (string.IsNullOrWhiteSpace(maMon))
                throw new Exception("Mã món ăn không được để trống.");

            if (string.IsNullOrWhiteSpace(tenMon))
                throw new Exception("Tên món ăn không được để trống.");

            if (string.IsNullOrWhiteSpace(maCongDung))
                throw new Exception("Công dụng không được để trống.");

            if (string.IsNullOrWhiteSpace(maLoai))
                throw new Exception("Loại món không được để trống.");

            if (donGia < 0)
                throw new Exception("Đơn giá không được âm.");

            // Kiểm tra mã trùng
            if (!KiemTraMon(maMon))
                throw new Exception("Mã món ăn này đã tồn tại.");

            try
            {
            return dao.ThemMonAn(
                    maMon.Trim(), tenMon.Trim(), maCongDung.Trim(), maLoai.Trim(), 
                    cachLam ?? "", yeuCau ?? "", donGia, hinhAnh ?? "");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm món ăn: " + ex.Message);
            }
        }

        public void XoaMonAn(string maMon)
        {
            if (string.IsNullOrWhiteSpace(maMon))
                throw new Exception("Vui lòng chọn món ăn cần xóa.");

            maMon = maMon.Trim();

            try
            {
                if (dao.LayTheoMa(maMon).Rows.Count == 0)
                    throw new Exception("Món ăn không tồn tại.");

                bool ketQua = dao.XoaMonAn(maMon);

                if (!ketQua)
                    throw new Exception("Xóa món ăn thất bại.");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa món ăn: " + ex.Message);
            }
        }

        public bool ThemNguyenLieuMonAn(
                                    string maMon,
                                    string maNguyenLieu,
                                    decimal soLuong)
        {
            if (string.IsNullOrWhiteSpace(maMon))
                throw new Exception("Mã món ăn không được để trống.");

            if (string.IsNullOrWhiteSpace(maNguyenLieu))
                throw new Exception("Mã nguyên liệu không được để trống.");

            if (soLuong <= 0)
                throw new Exception("Số lượng phải lớn hơn 0.");

            try
            {
                return dao.ThemNguyenLieuMonAn(maMon.Trim(), maNguyenLieu.Trim(), soLuong);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm nguyên liệu cho món ăn: " + ex.Message);
            }
        }

        public DataTable LayTheoMa(string ma)
        {
            if (string.IsNullOrWhiteSpace(ma))
                throw new Exception("Mã món ăn không được để trống.");

            try
            {
                return dao.LayTheoMa(ma.Trim());
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy thông tin món ăn: " + ex.Message);
            }
        }

        public DataTable LayTheoMa_PhieuDatBan(string ma)
        {
            if (string.IsNullOrWhiteSpace(ma))
                throw new Exception("Mã món ăn không được để trống.");

            try
            {
                DataTable dt = dao.LayTheoMa(ma.Trim());
                if (dt.Rows.Count == 0)
                    throw new Exception("Không tìm thấy món ăn.");

                return dt.DefaultView.ToTable(false, "MaMonAn", "TenMonAn", "MaLoai", "DonGia");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy thông tin món ăn để đặt bàn: " + ex.Message);
            }
        }

        public DataTable LayNguyenLieu_MonAn(string ma)
        {
            if (string.IsNullOrWhiteSpace(ma))
                throw new Exception("Mã món ăn không được để trống.");

            try
            {
                DataTable dt = dao.DSNguyenLieu_MonAn(ma.Trim());
                if (dt.Rows.Count == 0)
                    return new DataTable(); // Trả về DataTable rỗng thay vì lỗi

                return dt.DefaultView.ToTable(false, "MaNguyenLieu", "TenNguyenLieu", "DonViTinh", "DonGiaBan", "SoLuong");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy nguyên liệu của món ăn: " + ex.Message);
            }
        }

        public bool SuaMonAn(
                        string maMon,
                        string tenMon,
                        string maCongDung,
                        string maLoai,
                        string cachLam,
                        string yeuCau,
                        decimal donGia,
                        string hinhAnh,
                        DataTable dtNguyenLieu)
        {
            if (string.IsNullOrWhiteSpace(maMon))
                throw new Exception("Mã món ăn không được để trống.");

            if (string.IsNullOrWhiteSpace(tenMon))
                throw new Exception("Tên món ăn không được để trống.");

            if (string.IsNullOrWhiteSpace(maCongDung))
                throw new Exception("Công dụng không được để trống.");

            if (string.IsNullOrWhiteSpace(maLoai))
                throw new Exception("Loại món không được để trống.");

            if (donGia < 0)
                throw new Exception("Đơn giá không được âm.");

            if (dtNguyenLieu == null || dtNguyenLieu.Rows.Count == 0)
                throw new Exception("Phải có ít nhất 1 nguyên liệu cho món ăn.");

            try
            {
                return dao.SuaMonAn(maMon.Trim(), tenMon.Trim(), maCongDung.Trim(), maLoai.Trim(), 
                    cachLam ?? "", yeuCau ?? "", donGia, hinhAnh ?? "", dtNguyenLieu);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi sửa món ăn: " + ex.Message);
            }
        }

        public DataTable DSMonAn_DatBan()
        {
            try
            {
                return dao.DSMonAn("", "", "").DefaultView.ToTable(false, "MaMonAn", "TenMonAn", "DonGia");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách món ăn: " + ex.Message);
            }
        }

        public DataTable TimKiemMonAn_PhieuDatBan(string ten, string loai, string congdung)
        {
            try
            {
                ten = string.IsNullOrWhiteSpace(ten) ? "" : ten.Trim();
                loai = string.IsNullOrWhiteSpace(loai) ? "" : loai.Trim();
                congdung = string.IsNullOrWhiteSpace(congdung) ? "" : congdung.Trim();

                return dao.DSMonAn(ten, loai, congdung).DefaultView.ToTable(false, "MaMonAn", "TenMonAn", "DonGia");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tìm kiếm món ăn: " + ex.Message);
            }
        }
    }
}
