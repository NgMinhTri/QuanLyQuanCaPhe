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


insert account(UserName,DisplayName,Password, type) values (N'K9',N'RongK9',N'1',1)
insert account(UserName,DisplayName,Password, type) values (N'staff',N'staff',N'1',0)

create procedure FindAccount @username char(10)
As
select * from dbo.account where UserName = @username

exec FindAccount N'K9'

create Procedure Login @username nvarchar(50), @password nvarchar(50)
As
select * from account where UserName = @username and Password = @password


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

update TableFood set status=N'Có người' where id=7


select * from TableFood

create procedure USP_GetTableList
as
select * from TableFood
go

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
select * from Bill


insert  BillInfo(idBill,idFood,count) values (1,1,2)
insert  BillInfo(idBill,idFood,count) values (1,2,3)
insert  BillInfo(idBill,idFood,count) values (1,3,4)
insert  BillInfo(idBill,idFood,count) values (2,1,2)
insert  BillInfo(idBill,idFood,count) values (2,2,2)

----------------------------------------------------------------
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


-----------------------------thêm bill
go
create procedure USP_InsertBill
@idTable int
as
insert into Bill(DateCheckIn, DateCheckOut, idTable, status, discount)
values(GETDATE(), null, @idTable, 0, 0)


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
-----------------------------------------

alter trigger UTG_UpdateBillInfo
on BillInfo for update, insert
as
begin
    Declare @idBill int
	select @idBill = idBill from inserted
	declare @idTable int
	select @idTable = idTable from Bill where id = @idBill and status = 0
	
	update TableFood set status = N'Có người' where id = @idTable		
end
go
---------------------------------------------------------------------
alter trigger UTG_UpdateBill
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

------------------------update bảng Bill
alter table Bill
add discount int
select * from Bill
update Bill set discount = 0


-----------------------------------------
go
create procedure USP_SwitchTable
@idTable1 int, @idTable2 int
as
begin
     declare  @idFirstBill int
	 declare  @idSecondBill int

	 select @idSecondBill = id from Bill where idTable = @idTable2 and status = 0
	 select @idFirstBill = id from Bill where idTable = @idTable1 and status = 0

	 if(@idFirstBill is NULL)
	 begin
		 insert into Bill(DateCheckIn, DateCheckOut, idTable, status)
		 values (getdate(), null, @idTable1, 0) 
		 select @idFirstBill = MAX(id) from Bill where idTable = @idTable1 and status = 0
	 end

	 if(@idSecondBill IS NULL)
	 begin
		 insert into Bill(DateCheckIn, DateCheckOut, idTable, status)
		 values (getdate(), null, @idTable2, 0) 
		 select @idSecondBill = MAX(id) from Bill where idTable = @idTable2 and status = 0
	 end

	 select id into IDBillInfoTable from BillInfo where idBill = @idSecondBill

	 update BillInfo set idBill = @idSecondBill where idBill = @idFirstBill

	 update BillInfo set idBill = @idFirstBill where id in	(select * from IDBillInfoTable)
	 drop table IDBillInfoTable
end

