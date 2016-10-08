----------------- Создание процедур --------- -------------------------------
---- Типы природоохранных объектов 
-----------------------------------------------------------------------------
---- Добавление типа природоохранных объектов 
---- Удаление типа природоохранных объектов 
---- Получение типа природоохранных объектов по ID 
---- Получение списка типов природоохранных объектов 
---- Обновление типа природоохранных объектов 
-----------------------------------------------------------------------------
drop procedure EGH.CreateEcoObjectType;
drop procedure EGH.DeleteEcoObjectType; 
drop procedure EGH.GetEcoObjectTypeByID;
drop procedure EGH.GetEcoObjectTypeList;
drop procedure EGH.UpdateEcoObjectType;
go;
------------------------------------

-- Добавление типа природоохранных объектов 
create procedure EGH.CreateEcoObjectType (@КодТипаПООбъектов int,  @НаименованиеТипаПООбъектов nvarchar(50))
as begin 
declare @rc int  = @КодТипаПООбъектов;
	begin try
		insert into dbo.ТипыПООбъектов(КодТипаПООбъектов, НаименованиеТипаПООбъектов) values(@КодТипаПООбъектов, @НаименованиеТипаПООбъектов); 
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;
go;

-- Удаление типа природоохранных объектов 
create procedure EGH.DeleteEcoObjectType (@КодТипаПООбъектов int)
as begin 
    declare @rc int  = @КодТипаПООбъектов;
    begin try 
	 delete dbo.ТипыПООбъектов where КодТипаПООбъектов = @КодТипаПООбъектов;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end; 
go;

-- Получение типа природоохранных объектов по ID 
create  procedure EGH.GetEcoObjectTypeByID(@КодТипаПООбъектов int, @НаименованиеТипаПООбъектов nvarchar(30) output) 
as begin 
    declare @rc int = -1;
	select  @НаименованиеТипаПООбъектов = НаименованиеТипаПООбъектов from dbo.ТипыПООбъектов where КодТипаПООбъектов = @КодТипаПООбъектов;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go;

-- Получение списка типов природоохранных объектов 
create procedure EGH.GetEcoObjectTypeList
 as begin
	declare @rc int = -1;
	select КодТипаПООбъектов, НаименованиеТипаПООбъектов from dbo.ТипыПООбъектов;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go;

---- Обновление типа природоохранных объектов 