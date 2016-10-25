----------------- Создание процедур --------- -------------------------------
---- Типы техногенных объектов 
-----------------------------------------------------------------------------
---- Добавление типа техногенных объектов 
---- Удаление типа техногенных объектов 
---- Получение типа техногенных объектов по ID 
---- Получение списка типов техногенных объектов 
---- Обновление типа техногенных объектов
---- Получение следующего ID типа техногенных объектов
-----------------------------------------------------------------------------
drop procedure EGH.CreateRiskObjectType;
drop procedure EGH.DeleteRiskObjectType; 
drop procedure EGH.GetRiskObjectTypeByCode;
drop procedure EGH.GetRiskObjectTypeList;
drop procedure EGH.UpdateRiskObjectType;
drop procedure EGH.GetNextRiskObjectTypeCode;
go;
------------------------------------

-- Добавление типа техногенных объектов 
create procedure EGH.CreateRiskObjectType (@КодТипаТехногенногоОбъекта int,  @НаименованиеТипаТехногенногоОбъекта nvarchar(30))
as begin 
declare @rc int  = @КодТипаТехногенногоОбъекта;
	begin try
		insert into dbo.ТипТехногенногоОбъекта(КодТипаТехногенногоОбъекта, НаименованиеТипаТехногенногоОбъекта) values(@КодТипаТехногенногоОбъекта, @НаименованиеТипаТехногенногоОбъекта); 
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;
go
-- Удаление типа техногенных объектов 
create procedure EGH.DeleteRiskObjectType (@КодТипаТехногенногоОбъекта int)
as begin 
    declare @rc int  = @КодТипаТехногенногоОбъекта;
    begin try 
	 delete dbo.ТипТехногенногоОбъекта where КодТипаТехногенногоОбъекта = @КодТипаТехногенногоОбъекта;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end; 
go
-- Получение типа техногенных объектов по ID 
create  procedure EGH.GetRiskObjectTypeByCode(@КодТипаТехногенногоОбъекта int, @НаименованиеТипаТехногенногоОбъекта nvarchar(30) output) 
as begin 
    declare @rc int = -1;
	select  @НаименованиеТипаТехногенногоОбъекта = НаименованиеТипаТехногенногоОбъекта from dbo.ТипТехногенногоОбъекта where КодТипаТехногенногоОбъекта = @КодТипаТехногенногоОбъекта;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- Получение списка типов техногенных объектов 
create procedure EGH.GetRiskObjectTypeList
 as begin
	declare @rc int = -1;
	select КодТипаТехногенногоОбъекта, НаименованиеТипаТехногенногоОбъекта from dbo.ТипТехногенногоОбъекта;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- Обновление типа техногенных объектов 
create  procedure EGH.UpdateRiskObjectType(@КодТипаТехногенногоОбъекта int, @НовоеНаименование nvarchar(30)) 
as begin 
    declare @rc int = -1;
	update  dbo.ТипТехногенногоОбъекта set НаименованиеТипаТехногенногоОбъекта = @НовоеНаименование where КодТипаТехногенногоОбъекта = @КодТипаТехногенногоОбъекта;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- Получение следующего ID типа техногенных объектов 
create procedure EGH.GetNextRiskObjectTypeCode(@КодТипаТехногенногоОбъекта int output)
 as begin
	declare @rc int = -1;
	set @КодТипаТехногенногоОбъекта = (select max(КодТипаТехногенногоОбъекта)+1 from [dbo].[ТипТехногенногоОбъекта]);
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
