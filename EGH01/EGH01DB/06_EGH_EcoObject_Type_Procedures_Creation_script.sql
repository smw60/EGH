----------------- —оздание процедур --------- -------------------------------
---- “ипы природоохранных объектов 
-----------------------------------------------------------------------------
---- ƒобавление типа природоохранных объектов 
---- ”даление типа природоохранных объектов 
---- ѕолучение типа природоохранных объектов по ID 
---- ѕолучение списка типов природоохранных объектов 
---- ќбновление типа природоохранных объектов
---- ќбновление типа природоохранных объектов 
---- ѕолучение следующего ID типа природоохранных объектов по ID 
-----------------------------------------------------------------------------
drop procedure EGH.CreateEcoObjectType;
drop procedure EGH.DeleteEcoObjectType; 
drop procedure EGH.GetEcoObjectTypeByCode;
drop procedure EGH.GetEcoObjectTypeList;
drop procedure EGH.UpdateEcoObjectType;
drop procedure EGH.GetNextEcoObjectTypeCode;
go;
------------------------------------

-- ƒобавление типа природоохранных объектов 
create procedure EGH.CreateEcoObjectType (@ од“ипаѕриродоохранногоќбъекта int,  @Ќаименование“ипаѕриродоохранногоќбъекта nvarchar(30))
as begin 
declare @rc int  = @ од“ипаѕриродоохранногоќбъекта;
	begin try
		insert into dbo.“ипѕриродоохранногоќбъекта( од“ипаѕриродоохранногоќбъекта, Ќаименование“ипаѕриродоохранногоќбъекта) values(@ од“ипаѕриродоохранногоќбъекта, @Ќаименование“ипаѕриродоохранногоќбъекта); 
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;
go
-- ”даление типа природоохранных объектов 
create procedure EGH.DeleteEcoObjectType (@ од“ипаѕриродоохранногоќбъекта int)
as begin 
    declare @rc int  = @ од“ипаѕриродоохранногоќбъекта;
    begin try 
	 delete dbo.“ипѕриродоохранногоќбъекта where  од“ипаѕриродоохранногоќбъекта = @ од“ипаѕриродоохранногоќбъекта;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end; 
go
-- ѕолучение типа природоохранных объектов по ID 
create  procedure EGH.GetEcoObjectTypeByCode(@ од“ипаѕриродоохранногоќбъекта int, @Ќаименование“ипаѕриродоохранногоќбъекта nvarchar(30) output) 
as begin 
    declare @rc int = -1;
	select  @Ќаименование“ипаѕриродоохранногоќбъекта = Ќаименование“ипаѕриродоохранногоќбъекта from dbo.“ипѕриродоохранногоќбъекта where  од“ипаѕриродоохранногоќбъекта = @ од“ипаѕриродоохранногоќбъекта;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- ѕолучение списка типов природоохранных объектов 
create procedure EGH.GetEcoObjectTypeList
 as begin
	declare @rc int = -1;
	select  од“ипаѕриродоохранногоќбъекта, Ќаименование“ипаѕриродоохранногоќбъекта from dbo.“ипѕриродоохранногоќбъекта;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- ќбновление типа природоохранных объектов 
create  procedure EGH.UpdateEcoObjectType(@ од“ипаѕриродоохранногоќбъекта int, @ЌовоеЌаименование nvarchar(30)) 
as begin 
    declare @rc int = -1;
	update  dbo.“ипѕриродоохранногоќбъекта set Ќаименование“ипаѕриродоохранногоќбъекта = @ЌовоеЌаименование where  од“ипаѕриродоохранногоќбъекта = @ од“ипаѕриродоохранногоќбъекта;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- ѕолучение следующего ID типа природоохранных объектов 
create procedure EGH.GetNextEcoObjectTypeCode(@ од“ипаѕриродоохранногоќбъекта int output)
 as begin
	declare @rc int = -1;
	set @ од“ипаѕриродоохранногоќбъекта = (select max( од“ипаѕриродоохранногоќбъекта)+1 from [dbo].[“ипѕриродоохранногоќбъекта]);
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
