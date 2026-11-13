CREATE DATABASE QuanLyNhaHang;
GO

USE QuanLyNhaHang;
GO

-- 1. Bảng Quê
CREATE TABLE Que (
    MaQue VARCHAR(20) PRIMARY KEY,
    TenQue NVARCHAR(100) NOT NULL
);
GO

-- 2. Bảng Nhân viên
CREATE TABLE NhanVien (
    MaNhanVien VARCHAR(20) PRIMARY KEY,
    TenNhanVien NVARCHAR(100) NOT NULL,
    GioiTinh NVARCHAR(10),
    NgaySinh DATE,
    DiaChi NVARCHAR(200),
    MaQue VARCHAR(20),
    DienThoai VARCHAR(15),
    FOREIGN KEY (MaQue) REFERENCES Que(MaQue)
);
GO

-- 3. Bảng Khách
CREATE TABLE Khach (
    MaKhach VARCHAR(20) PRIMARY KEY,
    TenKhach NVARCHAR(100) NOT NULL,
    DiaChi NVARCHAR(200),
    DienThoai VARCHAR(15)
);
GO

-- 4. Bảng Loại món
CREATE TABLE LoaiMon (
    MaLoai VARCHAR(20) PRIMARY KEY,
    TenLoai NVARCHAR(100) NOT NULL
);
GO

-- 5. Bảng Công dụng
CREATE TABLE CongDung (
    MaCongDung VARCHAR(20) PRIMARY KEY,
    TenCongDung NVARCHAR(100) NOT NULL
);
GO

-- 6. Bảng Món ăn
CREATE TABLE MonAn (
    MaMonAn VARCHAR(20) PRIMARY KEY,
    TenMonAn NVARCHAR(100) NOT NULL,
    MaCongDung VARCHAR(20),
    MaLoai VARCHAR(20),
    CachLam NVARCHAR(MAX),
    YeuCau NVARCHAR(MAX),
    DonGia DECIMAL(18, 2),
    FOREIGN KEY (MaCongDung) REFERENCES CongDung(MaCongDung),
    FOREIGN KEY (MaLoai) REFERENCES LoaiMon(MaLoai)
);
GO

-- 7. Bảng Nguyên liệu
CREATE TABLE NguyenLieu (
    MaNguyenLieu VARCHAR(20) PRIMARY KEY,
    TenNguyenLieu NVARCHAR(100) NOT NULL,
    DonViTinh NVARCHAR(20),
    SoLuong DECIMAL(18, 2),
    DonGiaNhap DECIMAL(18, 2),
    DonGiaBan DECIMAL(18, 2),
    CongDung NVARCHAR(200),
    YeuCau NVARCHAR(200),
    ChongChiDinh NVARCHAR(200)
);
GO

-- 8. Bảng Nguyên liệu_món ăn (Bảng trung gian)
CREATE TABLE NguyenLieu_MonAn (
    MaMonAn VARCHAR(20),
    MaNguyenLieu VARCHAR(20),
    SoLuong DECIMAL(18, 2),
    PRIMARY KEY (MaMonAn, MaNguyenLieu),
    FOREIGN KEY (MaMonAn) REFERENCES MonAn(MaMonAn),
    FOREIGN KEY (MaNguyenLieu) REFERENCES NguyenLieu(MaNguyenLieu)
);
GO

-- 9. Bảng Nhà cung cấp
CREATE TABLE NhaCungCap (
    MaNhaCungCap VARCHAR(20) PRIMARY KEY,
    TenNhaCungCap NVARCHAR(100) NOT NULL,
    DiaChi NVARCHAR(200),
    DienThoai VARCHAR(15)
);
GO

-- 10. Bảng Hóa đơn nhập
CREATE TABLE HoaDonNhap (
    MaHoaDonNhap VARCHAR(20) PRIMARY KEY,
    NgayNhap DATE NOT NULL,
    MaNhanVien VARCHAR(20),
    MaNhaCungCap VARCHAR(20),
    TongTien DECIMAL(18, 2),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaNhaCungCap) REFERENCES NhaCungCap(MaNhaCungCap)
);
GO

-- 11. Bảng Chi tiết hóa đơn nhập
CREATE TABLE ChiTietHoaDonNhap (
    MaHoaDonNhap VARCHAR(20),
    MaNguyenLieu VARCHAR(20),
    SoLuong DECIMAL(18, 2),
    DonGia DECIMAL(18, 2),
    KhuyenMai DECIMAL(18, 2),
    ThanhTien DECIMAL(18, 2),
    PRIMARY KEY (MaHoaDonNhap, MaNguyenLieu),
    FOREIGN KEY (MaHoaDonNhap) REFERENCES HoaDonNhap(MaHoaDonNhap),
    FOREIGN KEY (MaNguyenLieu) REFERENCES NguyenLieu(MaNguyenLieu)
);
GO

-- 12. Bảng Phiếu đặt bàn
CREATE TABLE PhieuDatBan (
    MaPhieu VARCHAR(20) PRIMARY KEY, -- Đổi tên từ MaPhiếu (bỏ dấu) để tránh lỗi cú pháp SQL
    MaKhach VARCHAR(20),
    MaNhanVien VARCHAR(20),
    NgayDat DATETIME,
    NgayDung DATETIME,
    TongTien DECIMAL(18, 2),
    FOREIGN KEY (MaKhach) REFERENCES Khach(MaKhach),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);
GO

-- 13. Bảng Chi tiết phiếu đặt bàn
CREATE TABLE ChiTietPhieuDatBan (
    MaPhieu VARCHAR(20),
    MaMonAn VARCHAR(20),
    MaLoai VARCHAR(20),
    SoLuong INT,
    GiamGia DECIMAL(5, 2),
    ThanhTien DECIMAL(18, 2),
    PRIMARY KEY (MaPhieu, MaMonAn),
    FOREIGN KEY (MaPhieu) REFERENCES PhieuDatBan(MaPhieu),
    FOREIGN KEY (MaMonAn) REFERENCES MonAn(MaMonAn),
    FOREIGN KEY (MaLoai) REFERENCES LoaiMon(MaLoai)
);
GO

-- =============================================
-- 1. THÊM DỮ LIỆU BẢNG QUÊ (Một số tỉnh thành Việt Nam)
-- =============================================
INSERT INTO Que (MaQue, TenQue) VALUES 
('01', N'Hà Nội'),
('02', N'Cao Bằng'),
('03', N'Tuyên Quang'),
('04', N'Điện Biên'),
('05', N'Lai Châu'),
('06', N'Sơn La'),
('07', N'Lào Cai'),
('08', N'Thái Nguyên'),
('09', N'Lạng Sơn'),
('10', N'Quảng Ninh'),
('11', N'Bắc Ninh'),
('12', N'Phú Thọ'),
('13', N'Hải Phòng'),
('14', N'Hưng Yên'),
('15', N'Ninh Bình'),
('16', N'Thanh Hóa'),
('17', N'Nghệ An'),
('18', N'Hà Tĩnh'),
('19', N'Quảng Trị'),
('20', N'Huế'),
('21', N'Đà Nẵng'),
('22', N'Quảng Ngãi'),
('23', N'Gia Lai'),
('24', N'Khánh Hòa'),
('25', N'Đắk Lắk'),
('26', N'Lâm Đồng'),
('27', N'Đồng Nai'),
('28', N'Hồ Chí Minh'),
('29', N'Tây Ninh'),
('30', N'Đồng Tháp'),
('31', N'Vĩnh Long'),
('32', N'An Giang'),
('33', N'Cần Thơ'),
('34', N'Cà Mau');

GO

-- =============================================
-- 2. THÊM DỮ LIỆU BẢNG NHÂN VIÊN
-- =============================================
INSERT INTO NhanVien (MaNhanVien, TenNhanVien, GioiTinh, NgaySinh, DiaChi, MaQue, DienThoai) VALUES 
('NV01', N'Nguyễn Văn Trường', N'Nam', '2006-05-21', N'Yên Sở, Hà Nội', '01', '0978351205'),
('NV02', N'Trần Thị B', N'Nữ', '2000-08-20', N'Tp. Thái Bình', '34', '0912345678');
GO

-- =============================================
-- 3. THÊM DỮ LIỆU BẢNG KHÁCH HÀNG
-- =============================================
INSERT INTO Khach (MaKhach, TenKhach, DiaChi, DienThoai) VALUES 
('KH01', N'Lê Văn C', N'Đống Đa, Hà Nội', '0901122334'),
('KH02', N'Phạm Thị D', N'Nam Định', '0905566778');
GO

-- =============================================
-- 4. THÊM DỮ LIỆU BẢNG LOẠI MÓN
-- =============================================
INSERT INTO LoaiMon (MaLoai, TenLoai) VALUES 
('LM01', N'Tráng miệng'),
('LM02', N'Món rau'),
('LM03', N'Món súp'),
('LM04', N'Món thịt');
GO

-- =============================================
-- 5. THÊM DỮ LIỆU BẢNG CÔNG DỤNG
-- =============================================
INSERT INTO CongDung (MaCongDung, TenCongDung) VALUES 
('CD01', N'Giải nhiệt'),
('CD02', N'Bồi bổ sức khỏe'),
('CD03', N'Thanh lọc cơ thể');
GO

-- =============================================
-- 6. THÊM DỮ LIỆU BẢNG NHÀ CUNG CẤP
-- =============================================
INSERT INTO NhaCungCap (MaNhaCungCap, TenNhaCungCap, DiaChi, DienThoai) VALUES 
('NCC01', N'Công Ty TNHH Chế Biến Thực Phẩm Đông Đô', N'Hà Nội', '0974886925'),
('NCC02', N'Công Ty TNHH Phát Triển Nông Nghiệp Thịnh Vượng', N'Hà Nội', '0926066699');
GO

-- =============================================
-- 7. THÊM DỮ LIỆU BẢNG NGUYÊN LIỆU
-- =============================================
INSERT INTO NguyenLieu (MaNguyenLieu, TenNguyenLieu, DonViTinh, SoLuong, DonGiaNhap, DonGiaBan, CongDung, YeuCau, ChongChiDinh) VALUES 
('NL01', N'Thịt bò', N'kg', 50.0, 200000, 200000, N'Bồi bổ sức khỏe', N'Tươi sống, không ôi thiu', N'Người bị gout nặng'),
('NL02', N'Rau cải', N'kg', 100.0, 15000, 5000, N'Giải nhiệt', N'Xanh tươi, không sâu', N'Không có');
GO

-- =============================================
-- 8. THÊM DỮ LIỆU BẢNG MÓN ĂN
-- =============================================
INSERT INTO MonAn (MaMonAn, TenMonAn, MaCongDung, MaLoai, CachLam, YeuCau, DonGia) VALUES 
('MA01', N'Thịt bò xào rau cải', 'CD02', 'LM04', N'Xào thịt bò chín tái rồi cho rau cải vào đảo đều.', N'Chín vừa tới, đậm đà', 75000),
('MA02', N'Súp rau củ giải nhiệt', 'CD01', 'LM03', N'Nấu nhừ các loại rau củ với nước dùng.', N'Thanh ngọt tự nhiên', 45000);
GO

ALTER TABLE MonAn ADD hinhAnh VARCHAR(200);
Go


--nguyen lieu theo ma
CREATE PROCEDURE sp_LayNguyenLieuTheoMa
    @MaNguyenLieu VARCHAR(50)
AS
BEGIN
    SELECT *
    FROM NguyenLieu
    WHERE MaNguyenLieu = @MaNguyenLieu;
END
GO

--tim kiem nguyen lieu
CREATE PROCEDURE sp_TimKiemNguyenLieu
    @Ten NVARCHAR(100) = '',
    @CongDung NVARCHAR(200) = '',
    @CCD NVARCHAR(200) = ''
AS
BEGIN
    SELECT * 
    FROM NguyenLieu
    WHERE TenNguyenLieu LIKE '%' + @Ten + '%'
      AND CongDung LIKE '%' + @CongDung + '%'
      AND ChongChiDinh LIKE '%' + @CCD + '%';
END
GO

-- danh sach cac loai
CREATE PROCEDURE sp_DSCongDung
AS BEGIN
	SELECT * FROM CongDung;
END
GO

CREATE PROCEDURE sp_DSLoai
AS BEGIN
	SELECT * FROM LoaiMon;
END
GO

--tim kiem mon an
CREATE PROCEDURE sp_TimKiemMonAn
    @Ten NVARCHAR(100) = '',
    @Loai VARCHAR(50) = '',
    @CongDung VARCHAR(50) = ''
AS
BEGIN
    SELECT MaMonAn, TenMonAn, TenCongDung, TenLoai, YeuCau, DonGia 
    FROM MonAn 
    JOIN CongDung ON MonAn.MaCongDung = CongDung.MaCongDung 
    JOIN LoaiMon ON MonAn.MaLoai = LoaiMon.MaLoai 
    WHERE TenMonAn LIKE '%' + @Ten + '%'
      AND MonAn.MaLoai LIKE '%' + @Loai + '%'
      AND MonAn.MaCongDung LIKE '%' + @CongDung + '%';
END
GO

--lay theo ma mon an
--hien khong hoat dong
CREATE PROCEDURE sp_LayMonAnTheoMa
    @Ma VARCHAR(50) -- Kiểu dữ liệu tùy thuộc vào cột MaMonAn thực tế trong bảng của bạn (ví dụ: INT, VARCHAR, CHAR...)
AS
BEGIN
    SELECT MaMonAn, TenMonAn, TenCongDung, TenLoai, CachLam, YeuCau, DonGia 
    FROM MonAn 
    JOIN CongDung ON MonAn.MaCongDung = CongDung.MaCongDung 
    JOIN LoaiMon ON MonAn.MaLoai = LoaiMon.MaLoai 
    WHERE MaMonAn = @Ma;
END
GO

-- 1.1 Lấy danh sách nhân viên
CREATE PROC sp_DSNhanVien
AS
BEGIN
    SELECT MaNV, TenNV, ChucVu, Luong, SoDienThoai, NgayVaoLam 
    FROM NhanVien;
END
GO

-- 1.2 Tìm kiếm nhân viên theo tên hoặc chức vụ
CREATE PROC sp_TimKiemNhanVien
    @TuKhoa NVARCHAR(100)
AS
BEGIN
    SELECT MaNV, TenNV, ChucVu, Luong, SoDienThoai, NgayVaoLam 
    FROM NhanVien
    WHERE TenNV LIKE N'%' + @TuKhoa + N'%' 
       OR ChucVu LIKE N'%' + @TuKhoa + N'%';
END
GO

-- 1.3 Thêm nhân viên mới
CREATE PROC sp_ThemNhanVien
    @MaNV VARCHAR(20),
    @TenNV NVARCHAR(100),
    @ChucVu NVARCHAR(50),
    @Luong DECIMAL(18,2),
    @SoDienThoai VARCHAR(15),
    @NgayVaoLam DATETIME
AS
BEGIN
    INSERT INTO NhanVien(MaNV, TenNV, ChucVu, Luong, SoDienThoai, NgayVaoLam)
    VALUES(@MaNV, @TenNV, @ChucVu, @Luong, @SoDienThoai, @NgayVaoLam);
END
GO

-- 2.1 Lấy danh sách khách hàng
CREATE PROC sp_DSKhachHang
AS
BEGIN
    SELECT MaKH, TenKH, SoDienThoai, DiaChi, DiemTichLuy 
    FROM KhachHang;
END
GO

-- 2.2 Tìm kiếm khách hàng theo tên hoặc số điện thoại
CREATE PROC sp_TimKiemKhachHang
    @TuKhoa NVARCHAR(100)
AS
BEGIN
    SELECT MaKH, TenKH, SoDienThoai, DiaChi, DiemTichLuy 
    FROM KhachHang
    WHERE TenKH LIKE N'%' + @TuKhoa + N'%' 
       OR SoDienThoai LIKE '%' + @TuKhoa + '%';
END
GO

-- 2.3 Thêm khách hàng mới
CREATE PROC sp_ThemKhachHang
    @MaKH VARCHAR(20),
    @TenKH NVARCHAR(100),
    @SoDienThoai VARCHAR(15),
    @DiaChi NVARCHAR(200)
AS
BEGIN
    INSERT INTO KhachHang(MaKH, TenKH, SoDienThoai, DiaChi, DiemTichLuy)
    VALUES(@MaKH, @TenKH, @SoDienThoai, @DiaChi, 0); -- Mặc định điểm tích lũy = 0
END
GO