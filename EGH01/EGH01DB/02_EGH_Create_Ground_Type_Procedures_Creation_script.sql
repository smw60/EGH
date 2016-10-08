----------------- Создание процедур --------- -------------------------------
---- Типы почв 
-----------------------------------------------------------------------------
---- Добавление типа почв 
---- Удаление типа почв 
---- Получение типа почв по ID  
---- Получение списка типов почв 
---- Обновление типа почв
-----------------------------------------------------------------------------
drop procedure EGH.CreateGroundType;
drop procedure EGH.DeleteGroundType;
drop procedure EGH.GetGroundTypeByID;
drop procedure EGH.GetGroundTypeList;
drop procedure EGH.UpdateGroundType;
GO;
------------------------------------

-- Добавление типа почв 
create procedure EGH.CreateGroundType(
		    @КодВидаПочвы int,  
			@НаименованиеВидаПочвы nvarchar(50), 
			@КоэфПористости float,
			@КоэфЗадержкиМиграции float,
			@КоэфФильтрацииВоды float,
			@КоэфДиффузии float,
			@КоэфРаспределения float,
			@КоэфСорбции float)
as begin 
declare @rc int  = @КодВидаПочвы;
	begin try
		insert into dbo.ТипыПочв(
					[КодВидаПочвы],
					[НаименованиеВидаПочвы],
					[КоэфПористости],
					[КоэфЗадержкиМиграции],
					[КоэфФильтрацииВоды],
					[КоэфДиффузии],
					[КоэфРаспределения],
					[КоэфСорбции]) 
			values (@КодВидаПочвы,  
					@НаименованиеВидаПочвы, 
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
go;

-- Удаление типа почв
create procedure EGH.DeleteGroundType (@КодВидаПочвы int)
as begin 
    declare @rc int  = @КодВидаПочвы;
    begin try 
	 delete ТипыПочв where КодВидаПочвы = @КодВидаПочвы;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end;
go;

-- Получение типа почв по ID 
create  procedure EGH.GetGroundTypeByID(@КодВидаПочвы int, @НаименованиеВидаПочвы nvarchar(30) output) 
as begin 
    declare @rc int = -1;
	select  @НаименованиеВидаПочвы = НаименованиеВидаПочвы from dbo.ТипыПочв where КодВидаПочвы = @КодВидаПочвы;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go;

-- Получение списка типов почв 
create procedure EGH.GetGroundTypeList
 as begin
	declare @rc int = -1;
	select	КодВидаПочвы, 
			НаименованиеВидаПочвы,
			КоэфПористости,
			КоэфЗадержкиМиграции,
			КоэфФильтрацииВоды,
			КоэфДиффузии,
			КоэфРаспределения,
			КоэфСорбции
		from dbo.ТипыПочв;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go;

---- Обновление типа почв
