----------------- Создание процедур --------- -------------------------------
---- Типы инцидентов
-----------------------------------------------------------------------------
---- Добавление типа инцидента
---- Удаление типа инцидента
---- Получение ID типа инцидента
---- Получение списка типов инцидентов
---- Обновление типа инцидента
---- Получение следующего ID типа инцидента 
-----------------------------------------------------------------------------
use egh;
go

drop procedure EGH.CreateIncidentType;
drop procedure EGH.DeleteIncidentType; 
drop procedure EGH.GetIncidentTypeByID;
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


-- Получение типа инцидента по ID
create  procedure EGH.GetIncidentTypeByID(@КодТипа int, @Наименование nvarchar(50) output) 
as begin 
    declare @rc int = -1;
	select  @Наименование = Наименование from dbo.ТипИнцидента where КодТипа = @КодТипа;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;


-- Получение списка типов инцидентов
create procedure EGH.GetIncidentTypeList
 as begin
	declare @rc int = -1;
	select КодТипа, Наименование from [dbo].[ТипИнцидента];
	set @rc = @@ROWCOUNT;
	return @rc;    
end;


---- Обновление типа инцидента
create  procedure EGH.UpdateIncidentType(@КодТипа int, @НовоеНаименование nvarchar(50)) 
as begin 
    declare @rc int = -1;
	update  dbo.ТипИнцидента set Наименование = @НовоеНаименование where КодТипа = @КодТипа;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;

---- Получение следующего ID типа инцидента 
create procedure EGH.GetNextIncidentTypeCode
 as begin
	declare @rc int = -1;
	select max(КодТипа)+1 from [dbo].[ТипИнцидента];
	set @rc = @@ROWCOUNT;
	return @rc;    
end;

