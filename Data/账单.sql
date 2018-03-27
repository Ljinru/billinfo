use master 
go
create database BillDB
on
(
	name='BillDB',
	filename='H:\个人项目测试版\BillDB.dmf'
)
go
use BillDB
go
--用户表
create table Users 
(
	UserID int primary key identity(1,1),	--用户ID
	Uname varchar(10) not null ,			--用户名
	Uphone varchar(11)unique not null,			--用户电话
	Upwd varchar(20) not null,				--用户密码
)
go
select * from Users where Uphone='18166076500'

insert Users values(@UName,@UPhone,@UPwd)
insert Users Values('小哥哥','18166076500','123456')
--消费表
create table Consume
(
	Cid int primary key identity(1,1),		--消费ID
	Cincome int default(0),					--消费收入 0消费 1收入
	Cmoney money not null,					--消费金额
	Cmoneys money not null,					--总金额
	Ctime datetime not null,				--消费时间
	Cexplain varchar(255) not null,			--消费说明
	Ctype varchar(20) not null,				--消费类型
	Cimage varchar(100) not null ,			--图片
	Userid int references Users(UserID)		--用户ID
)
go
select *from Consume
--插入数据
insert Consume values(@Cincome,@Cmoney,@Cmoneys,@Ctime,@Cexplain,@Ctype,@Cimage,@Userid)
insert Consume values('0','20','-20',getdate(),'测试消费20元','微信','image/clothes/鞋子.jpg','1')
--修改数据
update Consume set Cincome=1,Cmoney=+500,Cmoneys=500,Ctime =getdate(),Ctype='微信',Cimage='image/taobao.jpg' where Userid=1
update Consume set Cexplain='第一次收入500元，激动٩(๑>◡<๑)۶' where Cid=1
select * from Consume
go
--触发器 
create trigger T_AddUsers
on Users
for insert 
as 
declare @Uid int
select @Uid =UserID from inserted
insert Consume values(0,0,0,getdate(),'','','',@Uid)
go
--查看个人信息
select u.Uname,u.Uphone,c.Cincome,c.Ctype,c.Cmoney,c.Cmoneys, c.Ctime ,c.Cimage from Users u ,Consume c where u.UserID =c.Userid
--
select * from Consume where Userid=1
go
/*
--存储过程分页
drop procedure proc_Users(@num2 int)
as
select top(5) * from Consume 
where Ctime not in(select top(@num2*5) Ctime from Consume where Userid=1 order by Ctime desc)
and Userid=1 order by Ctime desc
go
exec proc_Users 0
*/
go
alter procedure proc_Users
@pageIndex int,
@pageCount int=10,
@pageTotalCount int output
as
begin
  --计算出总页数
  declare @totalData int;
  set @totalData=(select count(*) from Consume)
  set @pageTotalCount=Ceiling(@totalData*1.0/@pageCount);
  --得到数据
  select * from
  (select *,num=row_number() over(order by Ctime desc) from Consume) as t
   where t.num between 
    @pageCount * (@pageIndex-1)+1 and @pageCount* @pageIndex;
end
go
DECLARE @Pages int
exec proc_Users 1,15,@Pages output
select @Pages
--------------
go
