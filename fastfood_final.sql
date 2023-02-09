CREATE DATABASE FastFood
GO
USE FastFood
GO
SET DATEFORMAT MDY
GO

 CREATE TABLE STAFF
(
	ID NVARCHAR(50) PRIMARY KEY NOT NULL,
	Avatar nvarchar(100),
	AcessRight NVARCHAR(30) NOT NULL,
	Username nvarchar(100) NOT NULL,
	pass nvarchar(50) not null,
	FullName NVARCHAR(100) NOT NULL,
	Sex NVARCHAR(10) NOT NULL,
	DoB datetime NOT NULL,
	Phone nVARCHAR(20) NOT NULL,
	Email NVARCHAR(100) NOT NULL,
	Addr NVARCHAR(200),
	avail bit
)
GO
CREATE TABLE PRODUCTS
(
  ProductID nVARCHAR(50) NOT NULL PRIMARY KEY,
  ProductName NVARCHAR(50) NOT NULL,
  ProductType NVARCHAR(50) NOT NULL,
  ProductPrice INT NOT NULL,
  RemainingQuantity int NOT NULL,
  Descriptions NVARCHAR(300),
  Avatar nvarchar(100),
  avail bit
)
go

CREATE TABLE CUSTOMERS
(
 CustomerID nVARCHAR(50) PRIMARY KEY NOT NULL,
 Fullname NVARCHAR(100) NOT NULL,
 Sex nvarchar(10) NOT NULL,
 Phone NVARCHAR(25) NOT NULL,
 total int,
 CustomerRank nvarchar(30),
 CustomerAddress nvarchar(200),
 avail Bit
 )
 GO
CREATE TABLE BILL
(
	BillID nvarchar(50) PRIMARY KEY NOT NULL,
	StaffID nVARCHAR(50) NOT NULL,
	CustomerID nVARCHAR(50),
	BillDate datetime NOT NULL,
	Discount int,
	Total INT NOT NULL,
	constraint FK_StaffID foreign key (StaffID) references staff(ID),
	constraint FK_CustomerID foreign key (CustomerID) references Customers(CustomerID)
)
Go
CREATE TABLE ORDERS
(
  OrderID NVARCHAR(50) PRIMARY KEY NOT NULL,
  Bill_ID nvarchar(50) not null,
  ProductID nVARCHAR(50) NOT NULL,
  Sell_Quantity int NOT NULL,
  UnitPrice INT NOT NULL,
  Discount int NOT NULL,
  Total INT
  constraint FK_ProductID foreign key  (ProductID) references PRODUCTS(ProductID),
  constraint FK_Bill_ID foreign key (Bill_ID) references Bill(BillID)
)
GO
CREATE TABLE IMPORT
(
  ImportID nVARCHAR(50) primary key NOT NULL,
  AdminID NVARCHAR(50) NOT NULL,
  ImportDate datetime NOT NULL,
)
GO
create table ImportProduct
(
import_Product_ID nvarchar(50) primary key,
ImportProductName nvarchar(50),
ImportID nvarchar(50) not null,
Price int not null,
ProductType nvarchar(50) not null,
Quantity int,
Unit nvarchar(30),
constraint FK_ImportID foreign key (ImportID ) references Import(ImportID )
)



go




create trigger Trigger_check_ProductQuantity
on Orders
after insert, update
as
if(exists (select * from 
	inserted i join products p on i.ProductID = p.ProductID 
		where p.RemainingQuantity < i.Sell_Quantity))
	begin
		rollback transaction
	end
else
	begin
		Declare @quantity int
		Declare @ID nvarchar(50)
		select @ID=i.ProductID ,@quantity= i.Sell_Quantity  from 
						inserted i
		update PRODUCTS set RemainingQuantity = RemainingQuantity - @quantity where ProductID = @ID
	end
go


create trigger Trigger_update_CustomerTotal
on Bill
after insert
as
begin
	Declare @total int
	Declare @customerID nvarchar(50)
	select @total = total from inserted i
	select @customerID = customerID from inserted i
	update Customers set total = total + @total where customerID = @customerID

	update customers set customerRank = N'Bạc' where total between 1000000 and 2000000
	update customers set customerRank = N'Vàng' where total between 2000000 and 5000000
	update customers set customerRank = N'VIP' where total > 5000000
	end
go

------------------------------------------------
use FastFood
GO
INSERT INTO PRODUCTS (ProductID,ProductName,ProductType,ProductPrice,RemainingQuantity, Descriptions, Avatar, avail) 
	VALUES ('SP001','Burger Bulgogi',N'Burger',46000,50, '','SP001.png', 1)
INSERT INTO PRODUCTS (ProductID,ProductName,ProductType,ProductPrice,RemainingQuantity, Descriptions, Avatar, avail) 
	VALUES ('SP002',N'Burger Tôm',N'Burger',48000,50,'','SP002.png', 1)
INSERT INTO PRODUCTS (ProductID,ProductName,ProductType,ProductPrice,RemainingQuantity, Descriptions, Avatar, avail) 
	VALUES ('SP003',N'Burger Gà',N'Burger',48000,50,'','SP003.png', 1)
INSERT INTO PRODUCTS (ProductID,ProductName,ProductType,ProductPrice,RemainingQuantity, Descriptions, Avatar, avail) 
	VALUES ('SP004',N'Burger Phô Mai',N'Burger',43000,50,'','SP004.png', 1)
INSERT INTO PRODUCTS (ProductID,ProductName,ProductType,ProductPrice,RemainingQuantity, Descriptions, Avatar, avail)  
	VALUES ('SP005',N'Burger Bò Teriyaki',N'Burger',43000,50,'','SP005.png', 1)
INSERT INTO PRODUCTS (ProductID,ProductName,ProductType,ProductPrice,RemainingQuantity, Descriptions, Avatar, avail) 
	VALUES ('SP006',N'Burger Cá',N'Burger',40000,50,'','SP006.png', 1)
INSERT INTO PRODUCTS (ProductID,ProductName,ProductType,ProductPrice,RemainingQuantity, Descriptions, Avatar, avail) 
	VALUES ('SP007',N'Burger Mozzrella',N'Burger',85000,50,'','SP007.png', 1)
INSERT INTO PRODUCTS (ProductID,ProductName,ProductType,ProductPrice,RemainingQuantity, Descriptions, Avatar, avail)  
	VALUES ('SP008',N'Gà Sốt Đậu',N'Gà',40000,50,'','SP008.png', 1)
INSERT INTO PRODUCTS (ProductID,ProductName,ProductType,ProductPrice,RemainingQuantity, Descriptions, Avatar, avail) 
	VALUES ('SP009',N'Gà Sốt Phô Mai',N'Gà',40000,50,'','SP009.png', 1)
INSERT INTO PRODUCTS (ProductID,ProductName,ProductType,ProductPrice,RemainingQuantity, Descriptions, Avatar, avail) 
	VALUES ('SP010',N'Gà Rán',N'Gà',35000,50,'','SP010.png', 1)
INSERT INTO PRODUCTS (ProductID,ProductName,ProductType,ProductPrice,RemainingQuantity, Descriptions, Avatar, avail) 
	VALUES ('SP011',N'Gà Sốt Cay',N'Gà',40000,50,'','SP011.png', 1)
INSERT INTO PRODUCTS (ProductID,ProductName,ProductType,ProductPrice,RemainingQuantity, Descriptions, Avatar, avail)  
	VALUES ('SP012',N'Cơm Gà Viên',N'Cơm - Mì Ý',45000,40,'','SP012.png', 1)
INSERT INTO PRODUCTS (ProductID,ProductName,ProductType,ProductPrice,RemainingQuantity, Descriptions, Avatar, avail) 
	VALUES ('SP013',N'Cơm Gà Sốt Cay',N'Cơm - Mì Ý',45000, 40,'','SP013.png', 1)
INSERT INTO PRODUCTS (ProductID,ProductName,ProductType,ProductPrice,RemainingQuantity, Descriptions, Avatar, avail) 
	VALUES ('SP014',N'Cơm Thịt Bò',N'Cơm - Mì Ý',45000,40,'','SP014.png', 1)
INSERT INTO PRODUCTS (ProductID,ProductName,ProductType,ProductPrice,RemainingQuantity, Descriptions, Avatar, avail) 
	VALUES ('SP015',N'Cơm Bò Trứng',N'Cơm - Mì Ý',45000,40,'','SP015.png', 1)
INSERT INTO PRODUCTS (ProductID,ProductName,ProductType,ProductPrice,RemainingQuantity, Descriptions, Avatar, avail) 
	VALUES ('SP016',N'Cơm Gà Sốt Phô Mai',N'Cơm - Mì Ý',45000, 40,'','SP016.png', 1)
INSERT INTO PRODUCTS (ProductID,ProductName,ProductType,ProductPrice,RemainingQuantity, Descriptions, Avatar, avail) 
	VALUES ('SP017',N'Cơm Gà Sốt Đậu',N'Cơm - Mì Ý',45000, 40,'','SP017.png', 1)
INSERT INTO PRODUCTS (ProductID,ProductName,ProductType,ProductPrice,RemainingQuantity, Descriptions, Avatar, avail) 
	VALUES ('SP018',N'Mì Ý',N'Cơm - Mì Ý',31000, 40,'','SP018.png', 1)
INSERT INTO PRODUCTS (ProductID,ProductName,ProductType,ProductPrice,RemainingQuantity, Descriptions, Avatar, avail) 
	VALUES ('SP019',N'Mì Ý Thịt Bò',N'Cơm - Mì Ý',41000,40,'','SP019.png', 1)
INSERT INTO PRODUCTS (ProductID,ProductName,ProductType,ProductPrice,RemainingQuantity, Descriptions, Avatar, avail)  
	VALUES ('SP020',N'Khoai Tây Lắc',N'Thức Ăn Nhẹ',39000,40,'','SP020.png', 1)
INSERT INTO PRODUCTS (ProductID,ProductName,ProductType,ProductPrice,RemainingQuantity, Descriptions, Avatar, avail)  
	VALUES ('SP021',N'Phô Mai Que',N'Thức Ăn Nhẹ',35000,40,'','SP021.png', 1)
INSERT INTO PRODUCTS (ProductID,ProductName,ProductType,ProductPrice,RemainingQuantity, Descriptions, Avatar, avail)  
	VALUES ('SP022',N'Gà Lắc',N'Thức Ăn Nhẹ',43000,40,'','SP022.png', 1)
INSERT INTO PRODUCTS (ProductID,ProductName,ProductType,ProductPrice,RemainingQuantity, Descriptions, Avatar, avail)  
	VALUES ('SP023',N'Khoai tây chiên',N'Thức Ăn Nhẹ',29000,40,'','SP023.png', 1)
INSERT INTO PRODUCTS (ProductID,ProductName,ProductType,ProductPrice,RemainingQuantity, Descriptions, Avatar, avail)  
	VALUES ('SP024',N'Bánh Táo',N'Thức Ăn Nhẹ',20000,40,'','SP024.png', 1)
INSERT INTO PRODUCTS (ProductID,ProductName,ProductType,ProductPrice,RemainingQuantity, Descriptions, Avatar, avail)  
	VALUES ('SP025',N'Gà Xiên Que',N'Thức Ăn Nhẹ',31000,40,'','SP025.png', 1)
INSERT INTO PRODUCTS (ProductID,ProductName,ProductType,ProductPrice,RemainingQuantity, Descriptions, Avatar, avail)  
	VALUES ('SP026',N'7 UP',N'Thức Uống',14000, 80,'','SP026.png', 1)
INSERT INTO PRODUCTS (ProductID,ProductName,ProductType,ProductPrice,RemainingQuantity, Descriptions, Avatar, avail) 
	VALUES ('SP027',N'Mirinda',N'Thức Uống',14000,80,'','SP027.png',1)
INSERT INTO PRODUCTS (ProductID,ProductName,ProductType,ProductPrice,RemainingQuantity, Descriptions, Avatar, avail)  
	VALUES ('SP028',N'Nước Cam',N'Thức Uống',23000,80,'','SP028.png', 1)
	-----------------------------------------------------------------------------------------------
INSERT INTO CUSTOMERS(CustomerID,Fullname,Sex,Phone,total,CustomerRank,CustomerAddress, avail)
	VALUES ('KH001',N'Nguyễn Thiện',N'Nam','0905321942',1200000,N'Bạc',N'Đông Hòa, Dĩ An, Bình Dương', 1)
INSERT INTO CUSTOMERS (CustomerID,Fullname,Sex,Phone,total,CustomerRank,CustomerAddress, avail)
	VALUES ('KH002',N'Trần Thanh Hiền',N'Nữ','0398285020',5000000,N'Vàng',N'Bến Tre', 1)
INSERT INTO CUSTOMERS (CustomerID,Fullname,Sex,Phone,total,CustomerRank,CustomerAddress, avail)
	VALUES ('KH003',N'Huỳnh Phước Tài',N'Nam','0123456789',1000000,N'Bạc',N'Quận 8, Thành phố Hồ Chí Minh', 1)
INSERT INTO CUSTOMERS (CustomerID,Fullname,Sex,Phone,total,CustomerRank,CustomerAddress, avail)
	VALUES ('KH004',N'Nguyễn Phạm Thanh Phong',N'Nam','0987654321',7200000,N'Vip',N'Thành phố Hồ Chí Minh', 1)
INSERT INTO CUSTOMERS (CustomerID,Fullname,Sex,Phone,total,CustomerRank,CustomerAddress, avail)
	VALUES ('KH005',N'Nguyễn Văn A',N'Nam','0897463521',200000,N'',N'Bình Phước', 1)
INSERT INTO CUSTOMERS (CustomerID,Fullname,Sex,Phone,total,CustomerRank,CustomerAddress, avail)
	VALUES ('KH006',N'Phạm Thị N',N'Nữ','0685792431',8000000,N'Vip',N'Quảng Nam', 1)
INSERT INTO CUSTOMERS (CustomerID,Fullname,Sex,Phone,total,CustomerRank,CustomerAddress, avail)
	VALUES ('KH007',N'Huỳnh D',N'Nam','0325174869',1200000,N'Bạc',N'Vũng Tàu', 1)
INSERT INTO CUSTOMERS (CustomerID,Fullname,Sex,Phone,total,CustomerRank,CustomerAddress, avail)
	VALUES ('KH008',N'Lê Thị K',N'Nữ','0192783546',4500000,N'Vàng',N'Đà Nẵng', 1)
	--------------------------------------------------------------------------------------------------
INSERT INTO STAFF (ID,Avatar,AcessRight,Username,pass,FullName,Sex,DoB,Phone,Email,Addr,avail)
	VALUES ('QL001','QL001.png',N'Quản lý','thien','1',N'Ng Thiện','Nam','08/26/2003','0905321942','thientknt1@gmail.com',N'Quảng Nam',1)
INSERT INTO STAFF (ID,Avatar,AcessRight,Username,pass,FullName,Sex,DoB,Phone,Email,Addr,avail)
	VALUES ('NV001','NV001.png',N'Nhân viên','tai','1',N'Huỳnh Tài','Nam','03/01/2003','096243543','nous033@gmail.com',N'Sóc Trăng',1)
INSERT INTO STAFF (ID,Avatar,AcessRight,Username,pass,FullName,Sex,DoB,Phone,Email,Addr,avail)
	VALUES ('QL002','QL002.png',N'Quản lý','hien','1',N'Thanh Hiền','Nữ','03/01/2003','096243543','chipp267@gmail.com',N'Bến Tre',1)
	--------------------------------------------------------------------------------------------------
INSERT INTO BILL (BillID,StaffID,CustomerID,BillDate,Discount,Total)
	VALUES ('HD001','NV001','KH002','02/05/2023','',200000)
INSERT INTO BILL (BillID,StaffID,CustomerID,BillDate,Discount,Total)
	VALUES ('HD002','NV001','KH001','02/06/2023','',322000)
INSERT INTO BILL (BillID,StaffID,CustomerID,BillDate,Discount,Total)
	VALUES ('HD003','NV001','KH008','02/05/2023','',88000)
INSERT INTO BILL (BillID,StaffID,CustomerID,BillDate,Discount,Total)
	VALUES ('HD004','QL001','KH004','02/05/2023','',597000)
INSERT INTO BILL (BillID,StaffID,CustomerID,BillDate,Discount,Total)
	VALUES ('HD005','QL001','KH002','02/06/2023','',48000)
	------------------------------------------------------------------------------------------------------
INSERT INTO ORDERS (OrderID,Bill_ID,ProductID,UnitPrice,Sell_Quantity,Discount,Total)
	VALUES ('HD001_DH001','HD001','SP002',48000,1,0,48000)
INSERT INTO ORDERS (OrderID,Bill_ID,ProductID,UnitPrice,Sell_Quantity,Discount,Total)
	VALUES ('HD001_DH002','HD001','SP004',40000,1,0,40000)
INSERT INTO ORDERS (OrderID,Bill_ID,ProductID,UnitPrice,Sell_Quantity,Discount,Total)
	VALUES ('HD001_DH003','HD001','SP003',45000,1,0,45000)
INSERT INTO ORDERS (OrderID,Bill_ID,ProductID,UnitPrice,Sell_Quantity,Discount,Total)
	VALUES ('HD001_DH004','HD001','SP007',31000,1,0,31000)
INSERT INTO ORDERS (OrderID,Bill_ID,ProductID,UnitPrice,Sell_Quantity,Discount,Total)
	VALUES ('HD001_DH005','HD001','SP005',18000,2,0,36000)
INSERT INTO ORDERS (OrderID,Bill_ID,ProductID,UnitPrice,Sell_Quantity,Discount,Total)
	VALUES ('HD002_DH001','HD002','SP008',115000,1,0,115000)
INSERT INTO ORDERS (OrderID,Bill_ID,ProductID,UnitPrice,Sell_Quantity,Discount,Total)
	VALUES ('HD002_DH002','HD002','SP001',14000,4,0,56000)
INSERT INTO ORDERS (OrderID,Bill_ID,ProductID,UnitPrice,Sell_Quantity,Discount,Total)
	VALUES ('HD002_DH003','HD002','SP007',18000,2,0,36000)
INSERT INTO ORDERS (OrderID,Bill_ID,ProductID,UnitPrice,Sell_Quantity,Discount,Total)
	VALUES ('HD002_DH004','HD002','SP005',115000,1,0,115000)
INSERT INTO ORDERS (OrderID,Bill_ID,ProductID,UnitPrice,Sell_Quantity,Discount,Total)
	VALUES ('HD003_DH001','HD003','SP010',48000,1,0,48000)
INSERT INTO ORDERS (OrderID,Bill_ID,ProductID,UnitPrice,Sell_Quantity,Discount,Total)
	VALUES ('HD003_DH002','HD003','SP006',40000,1,0,40000)
	----------------------------------------------------------------------------------
INSERT INTO IMPORT (ImportID,AdminID,ImportDate)
	VALUES ('NH001','NV001','02/09/2023')
INSERT INTO IMPORT (ImportID,AdminID,ImportDate)
	VALUES ('NH002','QL001','02/09/2023')
	-----------------------------------------------------------------------------------
INSERT INTO ImportProduct (import_Product_ID,ImportProductName,ImportID,Price,ProductType,Quantity, Unit)
	VALUES ('NH001_MH001',N'Burger Bò Teriyaki','NH001',10000,'Burger',50,N'Cái')
INSERT INTO ImportProduct (import_Product_ID,ImportProductName,ImportID,Price,ProductType,Quantity, Unit)
	VALUES ('NH001_MH002',N'Burger Cá','NH001',12500,'Burger',50,N'Cái')
INSERT INTO ImportProduct (import_Product_ID,ImportProductName,ImportID,Price,ProductType,Quantity, Unit)
	VALUES ('NH001_MH003',N'Burger Mozzrella','NH001',15000,'Burger',50,N'Cái')
INSERT INTO ImportProduct (import_Product_ID,ImportProductName,ImportID,Price,ProductType,Quantity, Unit)
	VALUES ('NH001_MH004',N'Gà Sốt Đậu','NH001',20000,N'Gà',50,N'Cái')
INSERT INTO ImportProduct (import_Product_ID,ImportProductName,ImportID,Price,ProductType,Quantity, Unit)
	VALUES ('NH001_MH005',N'Gà Sốt Phô Mai','NH001',21000,'Gà',50,N'Cái')
INSERT INTO ImportProduct (import_Product_ID,ImportProductName,ImportID,Price,ProductType,Quantity, Unit)
	VALUES ('NH001_MH006',N'Gà Rán','NH001',22500,'Gà',50,N'Cái')
INSERT INTO ImportProduct (import_Product_ID,ImportProductName,ImportID,Price,ProductType,Quantity, Unit)
	VALUES ('NH002_MH001',N'Mì Ý Thịt Bò','NH002',15000,'Cơm - Mì Ý',50,N'Phần')
INSERT INTO ImportProduct (import_Product_ID,ImportProductName,ImportID,Price,ProductType,Quantity, Unit)
	VALUES ('NH002_MH002',N'Mì Ý','NH002',16500,'Cơm - Mì Ý',50,N'Phần')
INSERT INTO ImportProduct (import_Product_ID,ImportProductName,ImportID,Price,ProductType,Quantity, Unit)
	VALUES ('NH002_MH003',N'Phô Mai Que','NH002',170000,'Thức Ăn Nhẹ',50,N'Cái')
INSERT INTO ImportProduct (import_Product_ID,ImportProductName,ImportID,Price,ProductType,Quantity, Unit)
	VALUES ('NH002_MH004',N'Gà Xiên Que','NH002',18000,'Thức Ăn Nhẹ',50,N'Cái')