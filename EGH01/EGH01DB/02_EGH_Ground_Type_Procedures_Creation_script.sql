----------------- Создание процедур --------- -------------------------------
---- Тип грунта
-----------------------------------------------------------------------------
---- Добавление типа грунта 
---- Удаление типа грунта 
---- Получение типа грунта по ID  
---- Получение списка типов грунта 
---- Обновление типа грунта
---- Получение следующего ID типа грунта 
-----------------------------------------------------------------------------
drop procedure EGH.CreateGroundType;
drop procedure EGH.DeleteGroundType;
drop procedure EGH.GetGroundTypeByID;
drop procedure EGH.GetGroundTypeList;
drop procedure EGH.UpdateGroundType;
drop procedure EGH.GetNextGroundTypeCode;
GO
------------------------------------

-- Добавление типа грунта  
create procedure EGH.CreateGroundType(
		    @КодТипаГрунта int,  
			@НаименованиеТипаГрунта nvarchar(50), 
			@КоэфПористости float,
			@КоэфЗадержкиМиграции float,
			@КоэфФильтрацииВоды float,
			@КоэфДиффузии float,
			@КоэфРаспределения float,
			@КоэфСорбции float)
as begin 
declare @rc int  = @КодТипаГрунта;
	begin try
		insert into dbo.ТипГрунта(
					[КодТипаГрунта],
					[НаименованиеТипаГрунта],
					[КоэфПористости],
					[КоэфЗадержкиМиграции],
					[КоэфФильтрацииВоды],
					[КоэфДиффузии],
					[КоэфРаспределения],
					[КоэфСорбции]) 
			values (@КодТипаГрунта,  
					@НаименованиеТипаГрунта, 
					@КоэфПористости,
					@КоэфЗадержкиМиграции,
					@КоэфФильтрацииВоды,
					@КоэфДиффузии,
					@КоэфРаспределения,
					@КоэфСорбции); 
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;
go

-- Удаление типа грунта 
create procedure EGH.DeleteGroundType (@КодТипаГрунта int)
as begin 
    declare @rc int  = @КодТипаГрунта;
    begin try 
	 delete ТипГрунта where КодТипаГрунта = @КодТипаГрунта;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end;
go

-- Получение типа грунта  по ID 
create  procedure EGH.GetGroundTypeByID(@КодТипаГрунта int, 
										@НаименованиеТипаГрунта nvarchar(30) output, 
										@КоэфПористости float output,  
										@КоэфЗадержкиМиграции float output,
										@КоэфФильтрацииВоды float output,
										@КоэфДиффузии float output,  
										@КоэфРаспределения float output,
										@КоэфСорбции float output) 
as begin 
    declare @rc int = -1;
	select	@НаименованиеТипаГрунта = НаименованиеТипаГрунта,  
			@КоэфПористости = КоэфПористости,
			@КоэфЗадержкиМиграции = КоэфПористости,
			@КоэфФильтрацииВоды = КоэфФильтрацииВоды,
			@КоэфДиффузии = КоэфДиффузии,
			@КоэфРаспределения = КоэфРаспределения,
			@КоэфСорбции = КоэфСорбции
	from dbo.ТипГрунта where КодТипаГрунта = @КодТипаГрунта;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

-- Получение списка типов грунта  
create procedure EGH.GetGroundTypeList
 as begin
	declare @rc int = -1;
	select	КодТипаГрунта, 
			НаименованиеТипаГрунта,
			КоэфПористости,
			КоэфЗадержкиМиграции,
			КоэфФильтрацииВоды,
			КоэфДиффузии,
			КоэфРаспределения,
			КоэфСорбции
		from dbo.ТипГрунта;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- Обновление типа грунта 
create  procedure EGH.UpdateGroundType(@КодТипаГрунта int, @НовоеНаименованиеТипаГрунта nvarchar(30)) 
as begin 
    declare @rc int = -1;
	update  dbo.ТипГрунта set НаименованиеТипаГрунта = @НовоеНаименованиеТипаГрунта where КодТипаГрунта = @КодТипаГрунта;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- Получение следующего ID типа грунта 
create procedure EGH.GetNextGroundTypeCode(@КодТипаГрунта int output)
 as begin
	declare @rc int = -1;
	set @КодТипаГрунта = (select max(КодТипаГрунта)+1 from [dbo].[ТипГрунта]);
	set @rc = @@ROWCOUNT;
	return @rc;    
end;