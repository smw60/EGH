------------- Проверка процедур Ground Type ----------------------------------
-- create
declare @rc int = -1;
exec @rc = EGH.CreateGroundType 
				@КодТипаГрунта= 2, 
				@НаименованиеТипаГрунта = 'Супесчаный',
				@КоэфПористости = 0.7,
				@КоэфЗадержкиМиграции = 5.2,
				@КоэфФильтрацииВоды =7.5,
				@КоэфДиффузии = 3.6,
				@КоэфРаспределения = 8.6,
				@КоэфСорбции = 2.0;
select @rc;
go
-- delete
declare @rc int = -1;
exec @rc = EGH.DeleteGroundType @КодТипаГрунта = 2;
select @rc;
go
-- by code
declare @rc int = -1;
exec @rc = EGH.GetGroundTypeByCode @КодТипаГрунта= 1;
select @rc;
go
-- list
exec EGH.GetGroundTypeList;
-- update
declare @rc int = -1;
exec @rc = EGH.UpdateGroundType 
				@КодТипаГрунта= 2, 
				@НовоеНаименованиеТипаГрунта = 'Глинистый',
				@НовыйКоэфПористости = 0.7,
				@НовыйКоэфЗадержкиМиграции = 5.2,
				@НовыйКоэфФильтрацииВоды =7.5,
				@НовыйКоэфДиффузии = 3.6,
				@НовыйКоэфРаспределения = 8.6,
				@НовыйКоэфСорбции = 2.0;
select @rc;
go
-- next
declare @rc int = -1;
exec EGH.GetNextGroundTypeCode @КодТипаГрунта=@rc output;
select @rc;
go
