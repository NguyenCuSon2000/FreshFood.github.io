CREATE DATABASE DA3_QuanLyFreshFood
GO
USE [DA3_QuanLyFreshFood]
GO
CREATE TABLE LoaiSanPham(
MaLoaiSP varchar(50) primary key clustered (MaLoaiSP asc),
TenLoai nvarchar(50) not null,
)

CREATE TABLE SanPham(
MaSP varchar(10) primary key clustered (MaSP asc),
TenSP nvarchar(50) not null,
MaLoaiSP varchar(10) constraint FK_MaLoaiSP_SanPham foreign key (MaLoaiSP) references LoaiSanPham(MaLoaiSP) on delete cascade on update cascade,
DonVi nvarchar(50),
MoTa nvarchar(500),
HinhAnh nvarchar(500),
SoLuongTon int,
LuotXem int,
LuotBinhLuan int,
SoLanMua int,
)

CREATE TABLE NhaCungCap(
MaNCC varchar(50) primary key clustered (MaNCC asc),
TenNCC nvarchar(50) not null,
DiaChi nvarchar(50),
SDT varchar(12),
Email nvarchar(50),
Fax nvarchar(50)
)


CREATE TABLE KhachHang(
MaKH varchar(50) primary key clustered (MaKH asc),
TenKH nvarchar(50) not null,
SDT varchar(12),
DiaChi nvarchar(50),
Email nvarchar(50),
)

CREATE TABLE UserGroup(
GroupID varchar(20) primary key,
Name nvarchar(50)
)

CREATE TABLE [User](
UserID bigint identity(1,1) primary key,
UserName varchar(50),
Password varchar(50),
GroupID varchar(20) constraint FK_GroupID_User foreign key (GroupID) references UserGroup(GroupID) on delete cascade on update cascade,
Name nvarchar(50),
DiaChi nvarchar(50),
Email nvarchar(50),
SDT varchar(12),
Active bit
)

CREATE TABLE HoaDonNhap(
MaHoaDonNhap varchar(50) primary key clustered (MaHoaDonNhap asc),
NgayNhap datetime,
MaNCC varchar(50) constraint FK_MaNCC_HoaDonNhap foreign key (MaNCC) references NhaCungCap(MaNCC) on delete cascade on update cascade,
TongTien float,
)

CREATE TABLE CTHoaDonNhap(
MaCTHDNhap bigint identity(1,1) primary key,
MaHoaDonNhap varchar(50) constraint FK_MaHDN_CTHDNhap foreign key (MaHoaDonNhap) references HoaDonNhap(MaHoaDonNhap) on delete cascade on update cascade,
MaSP varchar(10) constraint FK_MaSP_SanPham foreign key (MaSP) references SanPham(MaSP) on delete cascade on update cascade,
SoLuong float,
DonGia float,
HanSuDung datetime
)

CREATE TABLE DonDatHang(
MaDonHang nvarchar(50) primary key clustered (MaDonHang asc),
MaKH varchar(50) constraint FK_MaKH_KhachHang foreign key (MaKH) references KhachHang(MaKH) on delete cascade on update cascade,
DiaChiNhan nvarchar(200),
SDTNhan varchar(12),
TinhTrang bit,
ThanhTien float,
NgayDat datetime,
NgayGiao datetime
)

CREATE TABLE CTDonDatHang(
MaCTDonDatHang bigint identity(1,1) primary key,
MaDonHang nvarchar(50) constraint FK_MaDonHang_CTDonDatHang foreign key (MaDonHang) references DonDatHang(MaDonHang) on delete cascade on update cascade,
MaSP varchar(10) constraint FK_MaSP_CTDonDatHang foreign key (MaSP) references SanPham(MaSP) on delete cascade on update cascade,
SoLuong float,
DonGia float,
GiamGia float
)


CREATE TABLE BinhLuan(
ID bigint identity(1,1) primary key,
NoiDungBL nvarchar(500),
UserID bigint constraint FK_UserID_BinhLuan foreign key (UserID) references [User](UserID) on delete cascade on update cascade,
MaSP varchar(10) constraint FK_MaSP_BinhLuan foreign key (MaSP) references SanPham(MaSP) on delete cascade on update cascade,
)

CREATE TABLE GiaBan(
MaGia int identity(1,1) primary key,
MaSP varchar(10) constraint FK_MaSP_GiaBan foreign key (MaSP) references SanPham(MaSP) on delete cascade on update cascade,
NgayNhap datetime,
GiaBan float,
NgayApDung datetime,
NgayKetThuc datetime
)


CREATE TABLE GiamGia(
MaGiamGia int identity(1,1) primary key,
MaSP varchar(10) constraint FK_MaSP_GiamGia foreign key (MaSP) references SanPham(MaSP) on delete cascade on update cascade,
PhanTram float,
GiaGiam float,
Active bit,
NgayBatDau datetime,
NgayKetThuc datetime,
NgayNhap datetime,
)

CREATE TABLE TinTuc(
ID int identity(1,1) primary key,
TieuDe nvarchar(200),
HinhAnh nvarchar(200),
NoiDung nvarchar(max),
NgayDang Datetime,
TrangThai bit
)

Insert into LoaiSanPham values('Rau',N'Rau củ quả')
Insert into LoaiSanPham values('FreshFood',N'Thực phẩm tươi sống')
Insert into LoaiSanPham values('Thực phẩm khô',N'Thực phẩm khô')
Insert into LoaiSanPham values('Thực phẩm bổ dưỡng',N'Thực phẩm bổ dưỡng')

Insert into SanPham values('SP01',N'Bắp Bò Úc', N'FreshFood',N'1 cái', N'Bắp bò Úc giá tay do Vissan cung cấp có độ tươi ngon 100%','BapBoUc.jpg',10,20,30,10,73500)
Insert into SanPham values('SP02',N'Bắp Giò Heo', N'FreshFood',N'1 cái', N'Bắp giò heo Vissan được phân phối bởi VinMart - hệ thống siêu thị có uy tín trong việc cung ứng nguồn thực phẩm tươi sạch cho thị trường.','BapGioHeo.jpg',10,20,30,10,22400)
Insert into SanPham values('SP03',N'Cá Bạc Má', N'FreshFood',N'1 hộp', N'Cá bạc má có thân hình thuôn dài, hơi dẹt bên, thuộc nhóm cá biển có thịt thơm, ít xương dăm, rất ngon và bổ dưỡng. ','CaBacMa.jpg',10,20,30,10,62400)
Insert into SanPham values('SP04',N'Cá Ba Sa', N'FreshFood',N'1 con', N'Cá basa không đầu do VinMart cung cấp được chọn lọc từ cá basa tươi ngon, theo quy trình khép kín, an toàn cho sức khỏe người tiêu dùng.','CaBaSa.jpg',10,20,30,10,45000)
Insert into SanPham values('SP05',N'Cá Ba Sa Phi Lê', N'FreshFood',N'1 hộp', N'Cá basa phi lê do Vinmart cung cấp được sơ chế từ cá basa tươi ngon, theo quy trình khép kín, an toàn cho sức khỏe người tiêu dùng. ','CaBaSaPhiLe.jpg',10,20,30,10,19500)
Insert into SanPham values('SP06',N'Sườn Chặt Heo', N'FreshFood',N'1 hộp', N'Sản phẩm Sườn chặt heo Vissan do hệ thống siêu thị VinMart cung cấp luôn đảm bảo độ tươi ngon 100%, được sơ chế trước khi đóng gói nên đem đến sự an tâm tuyệt đối cho người tiêu dùng.','SuonChatHeo.jpg',10,20,30,10,48500)
Insert into SanPham values('SP07',N'Thịt Heo Xay', N'FreshFood',N'1 hộp', N'Thịt heo xay do Vissan cung cấp được sơ chế sạch, xay thành các sợi nhỏ và đóng gói kín mang lại sự tiện lợi cao cho người sử dụng. ','ThitHeoXay.jpg',10,20,30,10,26400)
Insert into SanPham values('SP08',N'Tôm Thẻ Tươi', N'FreshFood',N'1 hộp', N'Tôm thẻ tươi được chọn lọc từ nguồn nguyên liệu sạch, đã qua quá trình kiểm định độ an toàn, dưới sự giám sát và kiểm tra nghiêm ngặt.','TomTheTuoi.jpg',10,20,30,10,93500)
Insert into SanPham values('SP09',N'Cua Thịt Sống', N'FreshFood',N'1 con', N'Cua thịt có giá trị dinh dưỡng cao và rất quen thuộc trong ẩm thực của Việt Nam. Thịt cua giàu chất khoáng, axit béo omega 3, cung cấp cho cơ thể lượng vitamin B12 dồi dào... ','Cua.jpg',10,20,30,10,132700)
Insert into SanPham values('SP010',N'Cá Diêu Hồng Sống 0.4 - 0.8 Kg', N'FreshFood',N'1 con', N'Cá diêu hồng sống 0.4 - 0.8 kg là loại cá nước ngọt, giàu dinh dưỡng, thịt mềm, là nguồn thực phẩm rất tốt cho sức khỏe.','CaDieuHong.jpg',10,20,30,10,22400)
Insert into SanPham values('SP011',N'Ếch Thịt', N'FreshFood',N'1 hộp', N'Thịt ếch Vinmart được làm sạch và được bảo quản ở nhiệt độ thích hợp nên đảm bảo tươi ngon. Sản phẩm được kiểm tra chất lượng nghiêm ngặt, đảm bảo an toàn vệ sinh thực phẩm.','Ech.jpg',10,20,30,10,96400)
Insert into SanPham values('SP012',N'Tôm Thẻ Tươi', N'FreshFood',N'1 hộp', N'Thịt gà giàu hàm lượng protein giúp cơ thể luôn khỏe mạnh, phát triển cơ bắp, hỗ trợ giảm cân. Thịt gà giàu các loại axit amin có công dụng tốt cho não bộ. ','DuiGa.jpg',10,20,30,10,28200)

Insert into SanPham values('SP013',N'Bắp Cải Tím', 'Rau',N'1 cái', N'Bắp cải tím Đà Lạt PF là thực phẩm rất tốt cho sức khỏe con người. Bên cạnh thành phần chứa nhiều vitamin C và K, Bắp cải tím Đà Lạt rất giàu anthocyanin polyphenols - chất chống oxy hóa, các tính năng kháng viêm khác nhau. ','BapCaiTim.jpg',10,20,30,10,20500)
Insert into SanPham values('SP014',N'Bí Ngòi Xanh', 'Rau',N'1 quả', N'Bí ngòi xanh Đà Lạt được trồng tự nhiên tại các nông trại và được chăm sóc tỉ mỉ để thu được những sản phẩm chất lượng nhất.','BiNgoiXanh.jpg',10,20,30,10,12000)
Insert into SanPham values('SP015',N'Khoai Lang Nhật Đà Lại PF', 'Rau',N'1 hộp', N'Khoai lang là một loại củ được trồng rất nhiều ở Việt Nam. Nó có thể là nguồn thực phẩm thay thế cho gạo trắng, giúp cung cấp cho cơ thể một nguồn tinh bột rất lớn. ','KhoaiLang.jpg',10,20,30,10,36000)
Insert into SanPham values('SP016',N'Cà Rốt', 'Rau',N'1 hộp', N'Cà rốt Đà Lạt loại 1 được trồng tự nhiên tại các nông trại và chăm sóc tỉ mỉ để thu được những sản phẩm chất lượng nhất.','CaRot.jpg',10,20,30,10,20000)
Insert into SanPham values('SP017',N'Cải Thảo', 'Rau',N'1 hộp', N'Cải Thảo Đà Lạt PF là sản phẩm do VinMart cung cấp, được lựa chọn từ những cây cải tươi ngon, không sử dụng chất bảo quản nên tuyệt đối an toàn cho sức khỏe người tiêu dùng. ','CaiThao.jpg',10,20,30,10,29000)
Insert into SanPham values('SP018',N'Dưa Gang', 'Rau',N'1 quả', N'Dưa gang hay còn có tên gọi khác là dưa bở do VinMart phân phối, được lựa chọn từ những trái dưa chất lượng tại các trang trại sạch, đảm bảo vệ sinh an toàn thực phẩm.','DuaGang.jpg',10,20,30,10,17500)
Insert into SanPham values('SP019',N'Củ Cải Trắng', 'Rau',N'1 hộp', N'Được lấy từ những củ cải trồng theo phương pháp hữu cơ, thu hoạch tại những nông trường tươi xanh tại Đà Lạt, sản phẩm Củ cải trắng do VinMart cung cấp luôn tươi non, đảm bảo chất lượng nhất khi đến tay người tiêu dùng. ','CuCaiTrang.jpg',10,20,30,10,10000)
Insert into SanPham values('SP020',N'Cà Tím', 'Rau',N'1 hộp', N'Cà tím là một loài cây thuộc họ Cà với quả cùng tên gọi, nói chung được sử dụng làm một loại rau trong ẩm thực. ','CaTim.jpg',10,20,30,10,20000)
Insert into SanPham values('SP021',N'Ổi Lê Đài Loan', 'Rau',N'1 hộp', N'Ổi lê Đài Loan là giống ổi có hương vị thơm ngon và giòn, chứa nhiều chất xơ, vitamin C, A, kẽm, kali và mangan có tác dụng bồi dưỡng hệ tiêu hóa. ','OiLeDaLoan.jpg',10,20,30,10,29000)
Insert into SanPham values('SP022',N'Ớt Chuông Đà Lạt', 'Rau',N'1 hộp', N'Ớt chuông hay còn gọi là ớt tây, ớt ngọt. Đây là loại quả gia vị, có màu sắc rực rỡ (đỏ, vàng, xanh), quả to tròn hơn các loại ớt thông thường, vị giòn, ngọt nhẹ, ít cay, mùi vị đặc trưng.','OtChuongDaLat.jpg',10,20,30,10,51000)
Insert into SanPham values('SP023',N'Xoài Tứ Quý', 'Rau',N'1 hộp', N'Trong năm giống xoài đặc trưng của miền Tây nắng gió thì Xoài Cát Hoà Lộc và Xoài Tứ Quý là hai giống nổi tiếng nhất vì cho trái ngon, vị ngọt thanh, trái to và mang lại hiệu quả kinh tế cao.','XoaiTuQuy.jpg',10,20,30,10,39200)
Insert into SanPham values('SP024',N'Thanh Long Ruột Đỏ', 'Rau',N'1 quả', N'Thanh long là một loại trái cây mềm, có vị ngon ngọt, mát bổ, được nhiều người yêu thích. Thực phẩm thường được dùng làm món tráng miệng, mời khách hay làm sinh tố, nước giải khát uống hàng ngày. ','ThanhLongRuotDo.jpg.jpg',10,20,30,10,10000)
Insert into SanPham values('SP026',N'Ớt Sừng Đà Lạt', 'Rau',N'1 hộp', N'Ớt sừng đỏ Đà Lạt là loại quả làm gia vị cũng như loại quả được trồng phổ biến tại Đà Lạt do khí hậu thích hợp. Quả ớt sừng tròn dài, có màu sắc tươi và có vị cay đặc trưng. ','OtSungDaLat.jpg',10,20,30,10,50000)

Insert into KhachHang values('KH01',N'Nguyễn Thị Mai',N'Văn Lâm - Hưng Yên','0987675645','mainguyen@gmail.com')
Insert into KhachHang values('KH02',N'Nguyễn Văn Anh',N'Yên Mỹ - Hưng Yên','0986545674','anhnguyen@gmail.com')
Insert into KhachHang values('KH03',N'Trần Thế Thái',N'Kim Động - Hưng Yên','0987321456','thethai2k@gmail.com')
Insert into KhachHang values('KH04',N'Cao Văn Linh',N'Văn Lâm - Hưng Yên','0956456763','linhhy@gmail.com')
Insert into KhachHang values('KH05',N'Đinh Trọng Nghĩa',N'Ân Thi - Hưng Yên','0985453456','trongnghia@gmail.com')
Insert into KhachHang values('KH06',N'Trần Thị Yến Ninh',N'Văn Lâm - Hưng Yên','0876785465','yenninh@gmail.com')
Insert into KhachHang values('KH07',N'Ngô Văn Thịnh',N'Gia Lộc - Hải Dương','0987675432','ngothinh@gmail.com')
Insert into KhachHang values('KH08',N'Khúc Chí Thiện',N'Trâu Quỳ - Hà Nội','0987678546','chithien@gmail.com')
Insert into KhachHang values('KH09',N'Lý Cao Thượng',N'Thái Thụy - Thái Bình','0987867542','lythuong@gmail.com')
Insert into KhachHang values('KH010',N'Triệu Thái Sơn',N'Từ Sơn - Bắc Ninh','0978654321','thaison@gmail.com')

Insert into NhaCungCap values('NCC01',N'Nguyễn Thị Mai',N'Văn Lâm - Hưng Yên','0943243546','mainguyen@gmail.com','+84 (8) 3823 3318')
Insert into NhaCungCap values('NCC02',N'Nguyễn Văn Anh',N'Yên Mỹ - Hưng Yên','0986678674','anhnguyen@gmail.com','+84 (8) 4745 3320')
Insert into NhaCungCap values('NCC03',N'Trần Thế Thái',N'Kim Động - Hưng Yên','0956221456','thethai2k@gmail.com','+84 (4) 3213 4018')
Insert into NhaCungCap values('NCC04',N'Cao Văn Linh',N'Văn Lâm - Hưng Yên','0989256763','linhhy@gmail.com','+84 (2) 3123 8318')
Insert into NhaCungCap values('NCC05',N'Đinh Trọng Nghĩa',N'Ân Thi - Hưng Yên','0945853456','trongnghia@gmail.com','+84 (2) 3833 3328')
Insert into NhaCungCap values('NCC06',N'Trần Thị Yến Ninh',N'Văn Lâm - Hưng Yên','0876788905','yenninh@gmail.com','+84 (8) 3123 3318')
Insert into NhaCungCap values('NCC07',N'Ngô Văn Thịnh',N'Gia Lộc - Hải Dương','0981235432','ngothinh@gmail.com','0981235432')
Insert into NhaCungCap values('NCC08',N'Khúc Chí Thiện',N'Trâu Quỳ - Hà Nội','0984578546','chithien@gmail.com','+84 (8) 1825 3318')
Insert into NhaCungCap values('NCC09',N'Lý Cao Thượng',N'Thái Thụy - Thái Bình','0987477542','lythuong@gmail.com','+84 (8) 3824 3918')
Insert into NhaCungCap values('NCC010',N'Triệu Thái Sơn',N'Từ Sơn - Bắc Ninh','0974554321','thaison@gmail.com','+84 (8) 3424 3318')
exec GetSanPhams 'FreshFood', 1, 5 , ''

USE [DA3_QuanLyFreshFood]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE GetSanPhams(
@maloai varchar(20), @pageIndex int, @pageSize int, @productName nvarchar(100)
)
as
Begin
--if(@maloai = '')
--  begin
    Declare @RecordCount int;
	select * into #Result from SanPham
	where (TenSP='') or (TenSP like '%' + @productName + '%')

	select * from #Result order by MaSP offset @pageSize*(@pageIndex-1)
	Rows Fetch Next @pageSize Rows Only;

	select COUNT(*) as totalCount from SanPham;
	Drop table #Result
  end
----else
----   begin
----    select * into #Result from SanPham
----	where (MaLoaiSP = @maloai) and (TenSP='') or (TenSP like '%' + @productName + '%')

----	select * from #Result order by MaSP offset @pageSize*(@pageIndex-1)
----	Rows Fetch Next @pageSize Rows Only;

----	select COUNT(*) as totalCount from SanPham;
----	Drop table #Result
----  end
----end

--Alter proc Sp_get_data
--@Pageindex int,
--@Pagesize int
--as 
--begin
--select * from KhachHang order by MaKH desc Offset @Pagesize*(@Pageindex-1) rows fetch next @Pagesize rows only

--select COUNT(KhachHang.TenKH) as totalcount from KhachHang
--end

SELECT * FROM Users u WHERE u.UserName = 'son@gmail.com' AND u.Pass = '1'

Exec GetSanPhams 'Rau', 3, 5, ''

select * from SanPham where TenSP like N'%Thịt%'