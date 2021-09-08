use master 
go
create database DBSinhVien_15
use DBSinhVien_15
go

create table Tinh(
MaTinh int primary key not null,
TenTinh varchar(50) not null,
TelephoneCode int not null,
ZipCode int not null
)

create table LopHocPhan(
MaLop varchar(20) primary key not null,
TenHocPhan nvarchar(50) not null,
NgayBatDau date not null,
PhongHoc nvarchar(20)
)
create table SinhVien(
MaSV varchar(20) primary key not null,
HoTen nvarchar(50) not null,
NgaySinh date not null,
GioiTinh bit not null,
MaTinh int not null,
SoDT varchar(20)
constraint fk_SinhVien_Tinh foreign key (MaTinh) references Tinh(MaTinh)
)

create table SinhVien_Lop(
ID int primary key not null,
MaSV varchar(20) not null,
MaLop varchar(20) not null
constraint fk_Lophocphan_svLop foreign key (MaLop) references LopHocPhan(MaLop),
constraint fk_Lophocphan_sv foreign key (MaSV) references SinhVien(MaSV)
)

insert into Tinh values(29,N'Hà Nội',04253,123)
insert into Tinh values(17,N'Thái Bình',04253,123)
insert into Tinh values(99,N'Bắc Ninh',04253,123)
insert into Tinh values(20,N'Thái Nguyên',04253,123)
insert into Tinh values(88,N'Vĩnh Phúc',04253,123)

insert into LopHocPhan values('L001',N'Kỹ thuật lập trình','01/06/2021','PM4')
insert into LopHocPhan values('L002',N'Đồ họa máy tính','02/7/2021','PM7')
insert into LopHocPhan values('L003',N'Lập trinh window','03/8/2021','PM5')

insert into SinhVien values('SV001',N'Đỗ Tuấn Anh','11/11/2000','true',88,'0125646789')
insert into SinhVien values('SV002',N'Nguyễn Thanh Bình','2/5/2000','false',99,'432325')
insert into SinhVien values('SV003',N'Hoàng Thu Hằng','5/6/2000','false',20,'525646')
insert into SinhVien values('SV004',N'Vũ Kim Anh','02/11/2000','false',29,'0125646')

select *from SinhVien

insert into SinhVien_Lop values(1,'SV001','L002')
insert into SinhVien_Lop values(2,'SV002','L001')
insert into SinhVien_Lop values(3,'SV003','L003')

-----Hiển thị danh sách sinh viên
select SinhVien.MaSV,HoTen,NgaySinh,GioiTinh,Tinh.TenTinh from SinhVien
inner join Tinh on Tinh.MaTinh = SinhVien.MaTinh

CREATE PROC MaTinh(@matinh int)
as
	begin
		select SinhVien.MaSV,HoTen,NgaySinh,GioiTinh,Tinh.TenTinh from SinhVien
		inner join Tinh on Tinh.MaTinh = SinhVien.MaTinh
		where Tinh.MaTinh = @matinh

	end
exec MaTinh '88'

create proc MaLop(@malop varchar(20))
as
	begin
		select SinhVien.MaSV,HoTen,NgaySinh,GioiTinh,Tinh.TenTinh,SinhVien_Lop.MaLop from SinhVien
		inner join Tinh on Tinh.MaTinh = SinhVien.MaTinh
		inner join SinhVien_Lop on SinhVien_Lop.MaSV = SinhVien.MaSV
		where SinhVien_Lop.MaLop = @malop
	end
exec MaLop 'L001'

create proc Tinh_MA (@matinh int, @malop varchar(20))
as
	begin
		select SinhVien.MaSV,HoTen,NgaySinh,GioiTinh,Tinh.TenTinh,SinhVien_Lop.MaLop from SinhVien
		inner join Tinh on Tinh.MaTinh = SinhVien.MaTinh
		inner join SinhVien_Lop on SinhVien_Lop.MaSV = SinhVien.MaSV
		where SinhVien_Lop.MaLop = @malop and Tinh.MaTinh = @matinh
	end
exec Tinh_MA '88', 'L001'