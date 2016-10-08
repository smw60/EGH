----------------- Создание процедур --------- -------------------------------
---- Типы кадастрового назначения земель
-----------------------------------------------------------------------------
---- Добавление типа кадастрового назначения земель
---- Удаление типа кадастрового назначения земель
---- Получение типа кадастрового назначения земель по ID
---- Получение списка типов кадастрового назначения земель
---- Обновление типа кадастрового назначения земель
-----------------------------------------------------------------------------
drop procedure EGH.CreateLandRegistryType;
drop procedure EGH.DeleteLandRegistryType;
drop procedure EGH.GetLandRegistryTypeByID;
drop procedure EGH.GetLandRegistryTypeList;
drop procedure EGH.UpdateLandRegistryType;
go;
------------------------------------

-- Добавление типа кадастрового назначения земель
create procedure EGH.CreateLandRegistryType(
						@КодНазначенияЗемель int,  
						@НаименованиеНазначенияЗемель nvarchar(100),
						@ПДК int)
as begin 
declare @rc int  = @КодНазначенияЗемель;
	begin try
		insert into dbo.НазначениеЗемель(
							КодНазначенияЗемель,
							НаименованиеНазначенияЗемель,
							ПДК) 
				values (@КодНазначенияЗемель,  
						@НаименованиеНазначенияЗемель,
						@ПДК); 
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;
go

-- Удаление типа кадастрового назначения земель
create procedure EGH.DeleteLandRegistryType (@КодНазначенияЗемель int)
as begin 
    declare @rc int  = @КодНазначенияЗемель;
    begin try 
	 delete dbo.НазначениеЗемель where КодНазначенияЗемель = @КодНазначенияЗемель;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end; 
go;

-- Получение типа кадастрового назначения земель по ID
create  procedure EGH.GetLandRegistryTypeByID(
						@КодНазначенияЗемель int,  
						@НаименованиеНазначенияЗемель nvarchar(100) output,
						@ПДК int output)
as begin 
    declare @rc int = -1;
	select  @НаименованиеНазначенияЗемель = НаименованиеНазначенияЗемель,
			@ПДК = ПДК
		from  dbo.НазначениеЗемель where КодНазначенияЗемель = @КодНазначенияЗемель;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go;

-- Получение списка типов кадастрового назначения земель
create procedure EGH.GetLandRegistryTypeList
 as begin
	declare @rc int = -1;
	select	КодНазначенияЗемель,
			НаименованиеНазначенияЗемель,
			ПДК
	from dbo.НазначениеЗемель;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go;

---- Обновление типа кадастрового назначения земель
