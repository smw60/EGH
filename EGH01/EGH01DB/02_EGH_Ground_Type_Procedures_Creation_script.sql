----------------- Создание процедур --------- -------------------------------
---- Тип грунта
-----------------------------------------------------------------------------
---- Добавление типа грунта 
---- Удаление типа грунта 
---- Получение типа грунта по коду  
---- Получение списка типов грунта 
---- Обновление типа грунта
---- Получение следующего кода типа грунта 
-----------------------------------------------------------------------------
drop procedure EGH.CreateGroundType;
drop procedure EGH.DeleteGroundType;
drop procedure EGH.GetGroundTypeByCode;
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

-- Получение типа грунта  по коду 
create  procedure EGH.GetGroundTypeByCode(@КодТипаГрунта int) 
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
alter  procedure EGH.UpdateGroundType(
					@КодТипаГрунта int, 
					@НовоеНаименованиеТипаГрунта nvarchar(30),
					@НовыйКоэфПористости float,
					@НовыйКоэфЗадержкиМиграции float,
					@НовыйКоэфФильтрацииВоды float,
					@НовыйКоэфДиффузии float,
					@НовыйКоэфРаспределения float,
					@НовыйКоэфСорбции float) 
as begin 
    declare @rc int = -1;
	update  dbo.ТипГрунта 
	set 
	НаименованиеТипаГрунта = @НовоеНаименованиеТипаГрунта,
	@НовыйКоэфПористости = КоэфПористости,
	@НовыйКоэфЗадержкиМиграции= КоэфЗадержкиМиграции,
	@НовыйКоэфФильтрацииВоды = КоэфФильтрацииВоды,
	@НовыйКоэфДиффузии= КоэфДиффузии,
	@НовыйКоэфРаспределения = КоэфРаспределения,
	@НовыйКоэфСорбции = КоэфСорбции
	where КодТипаГрунта = @КодТипаГрунта;  
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