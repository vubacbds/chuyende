CREATE DATABASE QLQuanAn
GO

USE QLQuanAn
GO

CREATE TABLE BanAn
(
	id INT IDENTITY PRIMARY KEY,
	ten NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	trangthai NVARCHAR(100) NOT NULL DEFAULT N'Trống'
)
GO

CREATE TABLE TaiKhoan
(
	tendangnhap NVARCHAR(100) PRIMARY KEY,
	tenhienthi NVARCHAR(100) NOT NULL,
	matkhau NVARCHAR(500) NOT NULL DEFAULT 0,
	loai INT NOT NULL DEFAULT 0  --1 admin,
)
GO

CREATE TABLE DanhMuc
(
	id INT IDENTITY PRIMARY KEY,
	ten NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	trangthai tinyint NOT NULL DEFAULT 1,
)
GO

CREATE TABLE MonAn
(
	id INT IDENTITY PRIMARY KEY,
	ten NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	iddanhmuc INT NOT NULL,
	gia FLOAT NOT NULL DEFAULT 0,
	trangthai tinyint NOT NULL DEFAULT 1,
	
	FOREIGN KEY (iddanhmuc) REFERENCES dbo.DanhMuc(id)
)
GO

CREATE TABLE HoaDon
(
	id INT IDENTITY PRIMARY KEY,
	ngayvao DATE NOT NULL DEFAULT GETDATE(),
	ngayra DATE,
	idbanan INT NOT NULL,
	trangthai INT NOT NULL DEFAULT 0
	
	FOREIGN KEY (idbanan) REFERENCES dbo.BanAn(id)
)
GO

CREATE TABLE HoaDonChiTiet
(
	id INT IDENTITY PRIMARY KEY,
	idhoadon INT NOT NULL,
	idmonan INT NOT NULL,
	soluong INT NOT NULL DEFAULT 0
	
	FOREIGN KEY (idhoadon) REFERENCES dbo.HoaDon(id),
	FOREIGN KEY (idmonan) REFERENCES dbo.MonAn(id)
)
GO

--Thêm dữ liệu Tài khoản
INSERT INTO	dbo.TaiKhoan
(
	tendangnhap,
	tenhienthi,
	matkhau,
	loai 
)
VALUES
(
	N'bac',
	N'Vu Xuan Bac',
	N'888',
	1
)

INSERT INTO	dbo.TaiKhoan
(
	tendangnhap,
	tenhienthi,
	matkhau,
	loai 
)
VALUES
(
	N'admin',
	N'admin',
	N'888',
	0
)
--Thêm dữ liệu bàn ăn
DECLARE @i INT = 1
WHILE @i<=8
BEGIN
	INSERT INTO	dbo.BanAn(ten) VALUES (N'Bàn '+ CAST(@i AS nvarchar(100)))
	SET @i = @i + 1
END
--Thêm dữ liệu danh mục
INSERT INTO	dbo.DanhMuc(ten) VALUES (N'Thức ăn')
INSERT INTO	dbo.DanhMuc(ten) VALUES (N'Nước uống')

--Thêm dữ liệu món ăn
INSERT INTO	dbo.MonAn(ten, iddanhmuc, gia) VALUES (N'Giò heo muối xông khói', 1, 36000)
INSERT INTO	dbo.MonAn(ten, iddanhmuc, gia) VALUES (N'Lòng xào dưa chua', 1, 59000)
INSERT INTO	dbo.MonAn(ten, iddanhmuc, gia) VALUES (N'Cơm hến Huế', 1, 99000)
INSERT INTO	dbo.MonAn(ten, iddanhmuc, gia) VALUES (N'Gà ta muối xông khói', 1, 88000)
INSERT INTO	dbo.MonAn(ten, iddanhmuc, gia) VALUES (N'Gỏi bò bóp thấu', 1, 100000)
INSERT INTO	dbo.MonAn(ten, iddanhmuc, gia) VALUES (N'Tôm sốt bơ tỏi', 1, 39000)
INSERT INTO	dbo.MonAn(ten, iddanhmuc, gia) VALUES (N'Bò sốt me', 1, 120000)
INSERT INTO	dbo.MonAn(ten, iddanhmuc, gia) VALUES (N'Cá hấp bia', 1, 73000)
INSERT INTO	dbo.MonAn(ten, iddanhmuc, gia) VALUES (N'Đậu bắp xào tỏi', 1, 62000)
INSERT INTO	dbo.MonAn(ten, iddanhmuc, gia) VALUES (N'Cơm tấm Sài Gòn', 1, 68000)
INSERT INTO	dbo.MonAn(ten, iddanhmuc, gia) VALUES (N'Cá hấp bia', 1, 73000)
INSERT INTO	dbo.MonAn(ten, iddanhmuc, gia) VALUES (N'Đậu bắp xào tỏi', 1, 62000)

INSERT INTO	dbo.MonAn(ten, iddanhmuc, gia) VALUES (N'Bia 333', 2, 24000)
INSERT INTO	dbo.MonAn(ten, iddanhmuc, gia) VALUES (N'Bia Sài Gòn', 2, 30000)
INSERT INTO	dbo.MonAn(ten, iddanhmuc, gia) VALUES (N'Bia Tiger', 2, 28000)

INSERT INTO	dbo.MonAn(ten, iddanhmuc, gia) VALUES (N'Nước suối', 2, 5000)
INSERT INTO	dbo.MonAn(ten, iddanhmuc, gia) VALUES (N'Coca Cola', 2, 12000)
INSERT INTO	dbo.MonAn(ten, iddanhmuc, gia) VALUES (N'Nước 7UP', 2, 17000)

--Thêm dữ liệu Hóa đơn
INSERT INTO	dbo.HoaDon(ngayvao, ngayra, idbanan, trangthai) VALUES (GETDATE(), NULL, 1, 0)
INSERT INTO	dbo.HoaDon(ngayvao, ngayra, idbanan, trangthai) VALUES (GETDATE(), GETDATE(), 2, 1)
--Thêm dữ liệu Hóa đơn chi tiết
INSERT INTO	dbo.HoaDonChiTiet(idhoadon, idmonan, soluong) VALUES (2, 1, 2)
INSERT INTO	dbo.HoaDonChiTiet(idhoadon, idmonan, soluong) VALUES (2, 2, 1)
INSERT INTO	dbo.HoaDonChiTiet(idhoadon, idmonan, soluong) VALUES (2, 3, 3)
INSERT INTO	dbo.HoaDonChiTiet(idhoadon, idmonan, soluong) VALUES (1, 5, 1)
INSERT INTO	dbo.HoaDonChiTiet(idhoadon, idmonan, soluong) VALUES (1, 6, 2)
