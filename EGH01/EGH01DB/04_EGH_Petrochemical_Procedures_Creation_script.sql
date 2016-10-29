----------------- Создание процедур --------- -------------------------------
---- Типы нефтепродуктов
-----------------------------------------------------------------------------
---- Добавление типа нефтепродукта
---- Удаление типа нефтепродукта
---- Получение типа нефтепродукта по ID
---- Получение списка типов нефтепродукта
---- Обновление типа нефтепродукта
---- Получение следующего ID типа нефтепродукта
-----------------------------------------------------------------------------
use egh;
drop procedure EGH.CreatePetrochemicalType;
drop procedure EGH.DeletePetrochemicalType;
drop procedure EGH.GetPetrochemicalTypeByCode;
drop procedure EGH.GetPetrochemicalTypeList;
drop procedure EGH.UpdatePetrochemicalType;
drop procedure EGH.GetNextPetrochemicalTypeCode;
go;
------------------------------------

-- Добавление типа нефтепродукта
create procedure EGH.CreatePetrochemicalType(
						@КодТипаНефтепродукта int,  
						@НаименованиеТипаНефтепродукта nvarchar(30),
						@ТемператураКипения float,
						@Плотность float,
						@КинематическаяВязкость float,
						@Растворимость float)
as begin 
declare @rc int  = @КодТипаНефтепродукта;
	begin try
		insert into dbo.ТипНефтепродукта(
							КодТипаНефтепродукта,
							НаименованиеТипаНефтепродукта,
							ТемператураКипения,
							Плотность,
							КинематическаяВязкость,
							Растворимость) 
				values(@КодТипаНефтепродукта,
					   @НаименованиеТипаНефтепродукта,
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
create procedure EGH.DeletePetrochemicalType (@КодТипаНефтепродукта int)
as begin 
    declare @rc int  = @КодТипаНефтепродукта;
    begin try 
	 delete dbo.ТипНефтепродукта where КодТипаНефтепродукта = @КодТипаНефтепродукта;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end; 
go

-- Получение типа нефтепродукта по ID
create  procedure EGH.GetPetrochemicalTypeByCode(@КодТипаНефтепродукта int) 
as begin 
    declare @rc int = -1;
	select  НаименованиеТипаНефтепродукта,
			ТемператураКипения,
			Плотность,
			КинематическаяВязкость,
			Растворимость
	from dbo.ТипНефтепродукта where КодТипаНефтепродукта = @КодТипаНефтепродукта;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go


exec EGH.GetPetrochemicalTypeByCode @КодТипаНефтепродукта = 2;
									


-- Получение списка типов нефтепродукта
create procedure EGH.GetPetrochemicalTypeList
 as begin
	declare @rc int = -1;
	select	КодТипаНефтепродукта,
			НаименованиеТипаНефтепродукта,
			ТемператураКипения,
			Плотность,
			КинематическаяВязкость,
			Растворимость
	from dbo.ТипНефтепродукта;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

-- Получение следующего значения типа нефтепродукта
create procedure EGH.GetNextPetrochemicalTypeCode(@КодТипаНефтепродукта int output)
 as begin
	declare @rc int = -1;
	set @КодТипаНефтепродукта = (select	max(КодТипаНефтепродукта)+1 from dbo.ТипНефтепродукта);
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
---- Обновление типа нефтепродукта
create  procedure EGH.UpdatePetrochemicalType(
						@КодТипаНефтепродукта int, 
						@НаименованиеТипаНефтепродукта nvarchar(50) output,
						@ТемператураКипения float output,
						@Плотность float output,
						@КинематическаяВязкость float output,
						@Растворимость float output) 
as begin 
    declare @rc int = -1;
	update  dbo.ТипНефтепродукта set
			НаименованиеТипаНефтепродукта = @НаименованиеТипаНефтепродукта,
			ТемператураКипения = @ТемператураКипения,
			Плотность = @Плотность,
			КинематическаяВязкость = @КинематическаяВязкость,
			Растворимость = @Растворимость
	from dbo.ТипНефтепродукта where КодТипаНефтепродукта = @КодТипаНефтепродукта;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go


