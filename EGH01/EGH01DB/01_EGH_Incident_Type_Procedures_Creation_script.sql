----------------- Создание процедур --------- -------------------------------
---- Типы инцидентов
-----------------------------------------------------------------------------
---- Добавление типа инцидента
---- Удаление типа инцидента
---- Получение кода типа инцидента
---- Получение списка типов инцидентов
---- Обновление типа инцидента
---- Получение следующего кода типа инцидента 
-----------------------------------------------------------------------------
use egh;
go

drop procedure EGH.CreateIncidentType;
drop procedure EGH.DeleteIncidentType; 
drop procedure EGH.GetIncidentTypeByCode;
drop procedure EGH.GetIncidentTypeList;
drop procedure EGH.UpdateIncidentType;
drop procedure EGH.GetNextIncidentTypeCode;
go
------------------------------------

-- Добавление типа инцидента
create procedure EGH.CreateIncidentType (@КодТипа int,  @Наименование nvarchar(50))
as begin 
declare @rc int  = @КодТипа;
	begin try
		insert into dbo.ТипИнцидента(КодТипа, Наименование) values(@КодТипа, @Наименование); 
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
	 delete ТипИнцидента where КодТипа = @КодТипа;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end; 
go


-- Получение типа инцидента по коду
create  procedure EGH.GetIncidentTypeByCode(@КодТипа int, @Наименование nvarchar(50) output) 
as begin 
    declare @rc int = -1;
	select  @Наименование = Наименование from dbo.ТипИнцидента where КодТипа = @КодТипа;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go


-- Получение списка типов инцидентов
create procedure EGH.GetIncidentTypeList
 as begin
	declare @rc int = -1;
	select КодТипа, Наименование from [dbo].[ТипИнцидента];
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

---- Обновление типа инцидента
create  procedure EGH.UpdateIncidentType(@КодТипа int, @НовоеНаименование nvarchar(50)) 
as begin 
    declare @rc int = -1;
	update  dbo.ТипИнцидента set Наименование = @НовоеНаименование where КодТипа = @КодТипа;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

---- Получение следующего ID типа инцидента 
create procedure EGH.GetNextIncidentTypeCode(@КодТипа int output)
 as begin
	declare @rc int = -1;
	set @КодТипа= (select max(КодТипа)+1 from [dbo].[ТипИнцидента]);
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go


