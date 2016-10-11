----------------- Создание процедур --------- -------------------------------
---- Типы нефтепродуктов
-----------------------------------------------------------------------------
---- Добавление типа нефтепродукта
---- Удаление типа нефтепродукта
---- Получение типа нефтепродукта по ID
---- Получение списка типов нефтепродукта
---- Обновление типа нефтепродукта
-----------------------------------------------------------------------------
drop procedure EGH.CreatePetrochemicalType;
drop procedure EGH.DeletePetrochemicalType;
drop procedure EGH.GetPetrochemicalTypeByID;
drop procedure EGH.GetPetrochemicalTypeList;
drop procedure EGH.UpdatePetrochemicalType;
go;
------------------------------------

-- Добавление типа нефтепродукта
create procedure EGH.CreatePetrochemicalType(
						@КодТипаНефтепродуктов int,  
						@НаименованиеТипаНефтепродуктов nvarchar(30),
						@ТемператураКипения float,
						@Плотность float,
						@КинематическаяВязкость float,
						@Растворимость float)
as begin 
declare @rc int  = @КодТипаНефтепродуктов;
	begin try
		insert into dbo.ТипыНефтепродуктов(
							КодТипаНефтепродуктов,
							НаименованиеТипаНефтепродуктов,
							ТемператураКипения,
							Плотность,
							КинематическаяВязкость,
							Растворимость) 
				values(@КодТипаНефтепродуктов,
					   @НаименованиеТипаНефтепродуктов,
					   @ТемператураКипения,
					   @Плотность,
					   @КинематическаяВязкость,
					   @Растворимость); 
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;
go

-- Удаление типа нефтепродукта
create procedure EGH.DeletePetrochemicalType (@КодТипаНефтепродуктов int)
as begin 
    declare @rc int  = @КодТипаНефтепродуктов;
    begin try 
	 delete dbo.ТипыНефтепродуктов where КодТипаНефтепродуктов = @КодТипаНефтепродуктов;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end; 
go;

-- Получение типа нефтепродукта по ID
create  procedure GetPetrochemicalTypeByID(
						@КодТипаНефтепродуктов int, 
						@НаименованиеТипаНефтепродуктов nvarchar(50) output,
						@ТемператураКипения float output,
						@Плотность float output,
						@КинематическаяВязкость float output,
						@Растворимость float output) 
as begin 
    declare @rc int = -1;
	select  @НаименованиеТипаНефтепродуктов = НаименованиеТипаНефтепродуктов,
			@ТемператураКипения = ТемператураКипения,
			@Плотность = Плотность,
			@КинематическаяВязкость = КинематическаяВязкость,
			@Растворимость = Растворимость
	from dbo.ТипыНефтепродуктов where КодТипаНефтепродуктов = @КодТипаНефтепродуктов;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go;

-- Получение списка типов нефтепродукта
create procedure EGH.GetPetrochemicalTypeList
 as begin
	declare @rc int = -1;
	select	КодТипаНефтепродуктов,
			НаименованиеТипаНефтепродуктов,
			ТемператураКипения,
			Плотность,
			КинематическаяВязкость,
			Растворимость
	from dbo.ТипыНефтепродуктов;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go;

---- Обновление типа нефтепродукта
