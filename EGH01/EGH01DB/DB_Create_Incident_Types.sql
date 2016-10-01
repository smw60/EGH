-- Создание процедур на вставку, удаление и получение ИД типа инцидента
-- Типа инцидентов:
-- 1	Нефтепровод
-- 2	Резервуар наземный
-- 3	Подземный резервуар
-- 4	Автотранспорт
-- 5	Жележнодорожный транспорт

-- Добавление типа инцидента
drop procedure EGH.CreateIncidentType
go


create procedure EGH.CreateIncidentType (@КодТипа int ,  @Наименование nvarchar(50))
as begin 
declare @rc int  = @КодТипа;
	begin try
		insert into dbo.ТипыИнцидентов(КодТипа, Наименование) values(@КодТипа, @Наименование); 
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;
go

-- Удаление типа инцидента
create procedure EGH.DeleteIncidentType (@КодТипа int)
as begin 
    declare @rc int  = @КодТипа;
    begin try 
	 delete ТипыИнцидентов where КодТипа = @КодТипа;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end 
go;
-- Получение типа инцидента по ID
drop  procedure EGH.GetIncidentTypeByID
go

create  procedure EGH.GetIncidentTypeByID(@КодТипа int, @Наименование nvarchar(50) output) 
as begin 
    declare @rc int = -1;
	select  @Наименование = Наименование from dbo.ТипыИнцидентов where КодТипа = @КодТипа;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;

go

--
create procedure EGH.GetIncidentTypeList
 as begin
	declare @rc int = -1;
	select КодТипа, Наименование from [dbo].[ТипыИнцидентов];
	set @rc = @@ROWCOUNT;
	return @rc;    
end;


select * from [dbo].[ТипыИнцидентов]
declare @ttt int = -1;
exec @ttt=EGH.GetIncidentTypeList
select @ttt;
