
use EGH;
go
-- create type [������������]
create table [��������������]
(
 [�������]  int, 
 [������������] varchar(50)
)
go
create table [��������]
(
 [�������������] int identity(10,10) primary key,
 [�������]       int,                   -- FK  ���� 
 [����]          datetime,              -- check              
 [�������������] datetime               -- check   [�������������]  >=  [����] 
) 
go
drop procedure EGH.���������������;
go
create procedure EGH.��������������� (@������� int ,  @���� datetime2, @������������� datetime2)
as begin 
   insert into ��������(�������,����,�������������) values(@�������, @����, @�������������);  
   end;
go

declare @d datetime2 =  getdate();
exec EGH.��������������� @�������= 1, @����=@d, @�������������=@d;

select * from [��������]







