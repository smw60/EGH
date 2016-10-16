----------------- Создание процедур --------- -------------------------------
---- Типы инцидентов
-----------------------------------------------------------------------------
---- Добавление типа инцидента
---- Удаление типа инцидента
---- Получение ID типа инцидента
---- Получение списка типов инцидентов
---- Обновление типа инцидента
-----------------------------------------------------------------------------
use egh;

drop procedure EGH.CreateIncidentType;
drop procedure EGH.DeleteIncidentType; 
drop procedure EGH.GetIncidentTypeByID;
drop procedure EGH.GetIncidentTypeList;
drop procedure EGH.UpdateIncidentType;
go;
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
go;

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
go;

-- Получение типа инцидента по ID
create  procedure EGH.GetIncidentTypeByID(@КодТипа int, @Наименование nvarchar(50) output) 
as begin 
    declare @rc int = -1;
	select  @Наименование = Наименование from dbo.ТипИнцидента where КодТипа = @КодТипа;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go;

-- Получение списка типов инцидентов
create procedure EGH.GetIncidentTypeList
 as begin
	declare @rc int = -1;
	select КодТипа, Наименование from [dbo].[ТипИнцидента];
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go;

---- Обновление типа инцидента

