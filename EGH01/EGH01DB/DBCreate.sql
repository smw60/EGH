
use EGH;
go
-- create type [Наименования]
create table [ТипыИнцидентов]
(
 [КодТипа]  int, 
 [Наименование] varchar(50)
)
go
create table [Инцидент]
(
 [Идентификатор] int identity(10,10) primary key,
 [КодТипа]       int,                   -- FK  типы 
 [Дата]          datetime,              -- check              
 [ДатаСообщения] datetime               -- check   [ДатаСообщения]  >=  [Дата] 
) 
go
drop procedure EGH.СоздатьИнцидент;
go
create procedure EGH.СоздатьИнцидент (@КодТипа int ,  @Дата datetime2, @ДатаСообщения datetime2)
as begin 
   insert into Инцидент(КодТипа,Дата,ДатаСообщения) values(@КодТипа, @Дата, @ДатаСообщения);  
   end;
go

declare @d datetime2 =  getdate();
exec EGH.СоздатьИнцидент @КодТипа= 1, @Дата=@d, @ДатаСообщения=@d;

select * from [Инцидент]







