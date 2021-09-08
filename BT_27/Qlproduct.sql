use master
go
create database BT1_27
go
use BT1_27
go
create table Category(
		CategoryID nvarchar(50) primary key not null,
		CategoryName nvarchar(50)
)
create table Product(
	ProductCode nvarchar(50) primary key not null,
	DescriptionPro nvarchar(50),
	UnitPrice int,
	OnhandQuantity int,
	CategoryID nvarchar(50)
	constraint pk_pro foreign key(CategoryID) references Category(CategoryID)
)
insert into Category values('01','Programming')
insert into Category values('02','Database')
insert into Category values('03','Web Design')
insert into Category values('04','Graphics')
insert into Category values('05','Chilren')
select *from Category

insert into Product values('S01','Sach lap trinh',5400,10,'01')
insert into Product values('S02','Sach do hoa',6400,10,'02')

select *from Product

select Product.ProductCode,Product.DescriptionPro,Product.UnitPrice,Product.OnhandQuantity,Category.CategoryName from Product inner join Category
on Product.CategoryID=Category.CategoryID
--insert into Product(ProductCode,Product.DescriptionPro,UnitPrice,OnhandQuantity) values('S03','Sach thư',6400,10)
select Product.ProductCode from Product

