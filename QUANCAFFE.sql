create database QuanLyQuanCaFe
go
use QuanLyQuanCaFe
go
create table TableFood
(
	  id int identity primary key,
	  name nvarchar(100) not null,
	  status nvarchar(100)  not null  --trống || có người
)
go
create table account
(    
	 DisplayName nvarchar(100) not null,
	 UserName nvarchar(100) primary key,
	 Password nvarchar(100) not null default 0,
	 type int not null default 0 --1:admin 0: staff
)
go
create table FoodCategory
(
	id int identity primary key,
	name nvarchar(100)not null,	
)
go
create table Food
(
  id int identity primary key,
  name nvarchar(100) not null default N' chưa đặt tên',
  idCategory int not null,
  price float not null
  foreign key(idCategory) references dbo.FoodCategory(id)
)
go
create table Bill
(
	id int identity primary key,
	DateCheckIn date not null default getdate(),
	DateCheckOut date,
	idTable int not null,
	status int not null  --1: đã thanh toán, 0;chưa thanh toán
	foreign key(idTable)  references dbo.TableFood(id)
)
go
create table BillInfo
(
    id int identity primary key,
	idBill int not null,
	idFood int not null,
	count int not null 
	foreign key(idBill) references dbo.Bill(id),
	foreign key(idFood) references dbo.Food(id)
)
go

--==================================== CHÈN DỮ LIỆU==================================--
insert account(UserName,DisplayName,Password, type) values (N'K9',N'RongK9',N'1',1)
insert account(UserName,DisplayName,Password, type) values (N'staff',N'staff',N'1',0)


insert TableFood(name, status) values(N'Bàn 1', N'trống')
insert TableFood(name, status) values(N'Bàn 2', N'trống')
insert TableFood(name, status) values(N'Bàn 3', N'trống')
insert TableFood(name, status) values(N'Bàn 4', N'trống')
insert TableFood(name, status) values(N'Bàn 5', N'trống')
insert TableFood(name, status) values(N'Bàn 6', N'trống')
insert TableFood(name, status) values(N'Bàn 7', N'trống')
insert TableFood(name, status) values(N'Bàn 8', N'trống')
insert TableFood(name, status) values(N'Bàn 9', N'trống')
insert TableFood(name, status) values(N'Bàn 10', N'trống')

insert FoodCategory(name) values(N'Hải sản' )
insert FoodCategory(name) values(N'Nông sản' )
insert FoodCategory(name) values(N'Lâm sản' )
insert FoodCategory(name) values(N'Nước' )

insert Food(name,idCategory,price) values(N'Mực một nắng nướng sa tế',1,120000)
insert Food(name,idCategory,price) values(N'Ngêu hấp sả',1,120000)
insert Food(name,idCategory,price) values(N'Dú dê nướng sữa',2,110000)
insert Food(name,idCategory,price) values(N'Sting',4,10000)
insert Food(name,idCategory,price) values(N'Lẩu cá bốp',1,120000)

insert Bill(DateCheckIn,DateCheckOut,idTable,status) values (GETDATE(),null,1,0)
insert Bill(DateCheckIn,DateCheckOut,idTable,status) values (GETDATE(),null,2,0)
insert Bill(DateCheckIn,DateCheckOut,idTable,status) values (GETDATE(),null,2,1)
update Bill set DateCheckOut =Getdate() where status =1


insert  BillInfo(idBill,idFood,count) values (1,1,2)
insert  BillInfo(idBill,idFood,count) values (1,2,3)
insert  BillInfo(idBill,idFood,count) values (1,3,4)
insert  BillInfo(idBill,idFood,count) values (2,1,2)
insert  BillInfo(idBill,idFood,count) values (2,2,2)

--========================================================================--
---TẠO CÁC PROC

go
drop proc FindAccount
create procedure FindAccount @username char(10)
As
select * from dbo.account where UserName = @username
exec FindAccount N'K9'
--------------------------------------

GO
create procedure USP_GetTableList
as
select * from TableFood
------------------------
go
create procedure sp_InsertAccount
@DisplayName nvarchar(20),
@UserName nvarchar(20),
@Password nvarchar(20),
@type int
as
insert into account(DisplayName,UserName,Password,type)
values (@DisplayName,@UserName,@Password,@type)
-----------------------------------------------
go
create procedure XoaAccount @Username nvarchar(20)
as
delete  from Account where UserName =@Username
-----------------------------------------------
go
create procedure sp_Login @UserName nvarchar(20), @Password nvarchar(20)
as
select * from account where  UserName =@UserName and Password=@Password

---------------------------------------------------------
go
alter procedure sp_Update @UserName nvarchar(20), 
						   @Password nvarchar(20),
						   @Displayname nvarchar(20), 
						   @type int
as
update account set   DisplayName =@Displayname, Password =@Password,type =@type
                where UserName =@UserName

------------------------------------------------------
go
create procedure usp_GetAccountByUserName
@UserName nvarchar(20)
as
select * from account where  UserName = @UserName
exec usp_GetAccountByUserName  N'1712833'

-------------------------------------------------
go
create procedure SP_GETTABLELIST
AS
select * from TableFood

exec SP_GETTABLELIST

------------------------------------------------------------
select f.name, bi.count, f.price,f.price*bi.count as totalPrice from BillInfo as bi, Bill as b,
Food as f where bi.idBill = b.id and bi.idFood = f.id and b.status = 0 and b.idTable =1;


-----------------------------thêm bill----------------
go
alter procedure USP_InsertBill
@idTable int
as
begin
insert into Bill(DateCheckIn, DateCheckOut, idTable, status, discount)
values(GETDATE(), null, @idTable, 0, 0)
end
go

--------------------------theem billInfo-----------------
go
alter procedure USP_InsertBillInfo
@idBill int, @idFood int, @count int
as
begin
	declare @isExitsBillInfo int
	declare @foodCount int =1
	select @isExitsBillInfo = id, @foodCount = count 
	from BillInfo 
	where idBill = @idBill and idFood=@idFood
	if (@isExitsBillInfo > 0)
		begin
			declare @newcount int = @foodCount +@count
			if(@newcount > 0)
				update BillInfo set count= @foodCount +@count where idFood = @idFood
			else
				delete BillInfo where idBill = @idBill and idFood = @idFood
		end
	else		
		insert into  BillInfo(idBill,idFood,count) values (@idBill, @idFood, @count)		
end
go
-------------------------------------------------------------------

create trigger UTG_UpdateBillInfo
on BillInfo for update, insert
as
begin
    Declare @idBill int
	select @idBill = idBill from inserted
	declare @idTable int
	select @idTable = idTable from Bill where id = @idBill and status = 0

	declare @count int
	select @count = count(*) from BillInfo where idBill = @idBill
	
	if(@count > 0)	
	update TableFood set status = N'Có người' where id = @idTable	
	else
	update TableFood set status = N'trống' where id = @idTable
end
go
---------------------------------------------------------------------
create trigger UTG_UpdateBill
on Bill for update
as
begin
	declare @idBill int
	select @idBill = id from inserted
	declare @idTable int
	select @idTable = idTable from Bill where id = @idBill 
	declare @count int = 0
	select @count = count(*) from Bill where idTable = @idTable and status = 0
	if(@count = 0)
	update TableFood set status = N'trống' where id = @idTable
end
go

------------------------update bảng Bill----------------------------
alter table Bill
add discount int
select * from Bill
update Bill set discount = 0


-----------------------------------------

alter PROC USP_SwitchTabel
@idTable1 INT, @idTable2 int
AS BEGIN

	DECLARE @idFirstBill int
	DECLARE @idSeconrdBill INT
	
	DECLARE @isFirstTablEmty INT = 1
	DECLARE @isSecondTablEmty INT = 1
	
	
	SELECT @idSeconrdBill = id FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
	SELECT @idFirstBill = id FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0
	
	IF (@idFirstBill IS NULL)
	BEGIN
		PRINT '0000001'
		INSERT dbo.Bill
		        ( DateCheckIn ,
		          DateCheckOut ,
		          idTable ,
		          status
		        )
		VALUES  ( GETDATE() , -- DateCheckIn - date
		          NULL , -- DateCheckOut - date
		          @idTable1 , -- idTable - int
		          0  -- status - int
		        )
		        
		SELECT @idFirstBill = MAX(id) FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0
		
	END
	
	SELECT @isFirstTablEmty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idFirstBill
		
	IF (@idSeconrdBill IS NULL)
	BEGIN
		PRINT '0000002'
		INSERT dbo.Bill
		        ( DateCheckIn ,
		          DateCheckOut ,
		          idTable ,
		          status
		        )
		VALUES  ( GETDATE() , -- DateCheckIn - date
		          NULL , -- DateCheckOut - date
		          @idTable2 , -- idTable - int
		          0  -- status - int
		        )
		SELECT @idSeconrdBill = MAX(id) FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
		
	END
	
	SELECT @isSecondTablEmty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idSeconrdBill
		
	SELECT id INTO IDBillInfoTable FROM dbo.BillInfo WHERE idBill = @idSeconrdBill
	
	UPDATE dbo.BillInfo SET idBill = @idSeconrdBill WHERE idBill = @idFirstBill
	
	UPDATE dbo.BillInfo SET idBill = @idFirstBill WHERE id IN (SELECT * FROM IDBillInfoTable)
	
	DROP TABLE IDBillInfoTable
	
	IF (@isFirstTablEmty = 0)
		UPDATE dbo.TableFood SET status = N'trống' WHERE id = @idTable2
		
	IF (@isSecondTablEmty= 0)
		UPDATE dbo.TableFood SET status = N'trống' WHERE id = @idTable1
END
GO

--LẤY DANH SÁCH BILL TỪ NGÀY NÀY TỚI NGÀY KIA---------------------
alter procedure USP_GetListBillByDate
@DateCheckIn date,
@DateCheckOut date
as
begin
	select t.name as [Tên bàn], b.totalPrice as [Tổng tiền], DateCheckIn as [Ngày vào], DateCheckOut as [Ngày ra], discount as [Giảm giá]
	from Bill b, TableFood t
	where DateCheckIn >= @DateCheckIn and DateCheckOut <= @DateCheckOut and b.status = 1 and t.id = b.idTable
end
go


-------------Bài 15 tạo proc đổi thông tin cá nhân---------------
create procedure  USP_UpdateAccount
@UserName nvarchar(100), @DisplayName nvarchar(100), @PassWord nvarchar(100), @NewPassWord nvarchar(100)
as
begin
	declare @isRightPass int = 0
	select @isRightPass = count(*) from Account where UserName = @UserName and Password = @PassWord
	if(@isRightPass = 1)
		begin
			if( @NewPassWord = null or @NewPassWord = '')
			update Account set DisplayName= @DisplayName where UserName = @UserName
			else
			update Account set DisplayName= @DisplayName, Password = @NewPassWord where UserName = @UserName
		end
end
go

-------------Bài 16 lấy danh sách thức ăn---------------------
create procedure USP_GetListFood
as
begin
select * from Food
end 

select * from BillInfo
----------------------------------------
go
create trigger UTG_DeleteBillInfo
On BillInfo for Delete
as
begin
     declare @idBillInfo int
	 declare @idBill int
	 select @idBillInfo = id , @idBill =Deleted.idBill from Deleted

	 declare @idTable  int
	 select @idTable = idTable from Bill where id = @idBill

	 declare @count int = 0
	 select @count =count(*) from BillInfo as bi, Bill As b where b.id = bi.idBill and b.id = @idBill and b.status = 0
	 if(@count = 0)
	 update TableFood set status = N'trống' where id = @idTable
end
go
