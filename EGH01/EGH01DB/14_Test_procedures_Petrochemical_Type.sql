------------- Проверка процедур Petrochemical Type ----------------------------------
-- create
declare @rc int = -1;
exec @rc = EGH.CreatePetrochemicalType	@КодТипаНефтепродукта= 17,  
										@НаименованиеТипаНефтепродукта = 'test',
										@ТемператураКипения =  130.2,
										@Плотность =  23.5,
										@КинематическаяВязкость =  56.7,
										@Растворимость =  24.3;
select @rc;
go
-- delete
declare @rc int = -1;
exec @rc = EGH.DeletePetrochemicalType @КодТипаНефтепродукта= 8;
select @rc;
go
-- by code
declare @rc int = -1;
declare @Name nvarchar(50) = '';
exec @rc = EGH.GetPetrochemicalTypeByCode @КодТипаНефтепродукта = 5;
select @rc;
print @Name;
go
-- list
exec EGH.GetPetrochemicalTypeList;
go
-- update
declare @rc int = -1;
exec @rc = EGH.UpdatePetrochemicalType	@КодТипаНефтепродукта = 9,  
										@НаименованиеТипаНефтепродукта = 'Керосин авиационный',
										@ТемператураКипения =  200,
										@Плотность =  0.89,
										@КинематическаяВязкость =  0.89,
										@Растворимость =  50;
select @rc;
go
-- next
declare @rc int = -1;
exec EGH.GetNextPetrochemicalTypeCode @КодТипаНефтепродукта = @rc output;
select @rc;
go
