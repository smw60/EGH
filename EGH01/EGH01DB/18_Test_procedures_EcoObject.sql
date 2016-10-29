------------- Проверка процедур EcoObject ----------------------------------
-- create
declare @rc int = -1;
exec @rc = EGH.CreateEcoObject
			@IdПриродоохранногоОбъекта = 2,  
			@НаименованиеПриродоохранногоОбъекта = 'Парк отдыха',
			@КодТипаПриродоохранногоОбъекта = 3,
			@КодТипаНазначенияЗемель = 5,
			@ШиротаГрад = 26.6,
			@ДолготаГрад = 56.8,
			@ТипГрунта = 1,
			@ГлубинаГрунтовыхВод = 42.3,
			@ВысотаУровнемМоря = 12.3;
select @rc;
go
-- delete
declare @rc int = -1;
exec @rc = EGH.DeleteEcoObject @IdПриродоохранногоОбъекта = 2;
select @rc;
go
-- by ID
declare @rc int = -1;
exec @rc = EGH.GetEcoObjectByID @IdПриродоохранногоОбъекта = 1;
select @rc;
go
-- list
exec EGH.GetEcoObjectList;
go
-- update
declare @rc int = -1;
exec @rc = EGH.UpdateEcoObject
			@IdПриродоохранногоОбъекта = 2,  
			@НаименованиеПриродоохранногоОбъекта = 'Озеро Нарочь',
			@КодТипаПриродоохранногоОбъекта = 3,
			@КодТипаНазначенияЗемель = 5,
			@ШиротаГрад = 26.6,
			@ДолготаГрад = 56.8,
			@ТипГрунта = 1,
			@ГлубинаГрунтовыхВод = 42.3,
			@ВысотаУровнемМоря = 12.3;
select @rc;
go

-- next
declare @rc int = -1;
exec EGH.GetNextEcoObjectId @IdПриродоохранногоОбъекта = @rc output;
select @rc;
go
-- less than d
exec EGH.GetListEcoObjectOnDistanceLessThanD
			@ШиротаГрад = 26.6, 
			@ДолготаГрад = 56.4, 
			@Расстояние = 1.1
go
-- between d1 and d2
exec EGH.GetListEcoObjectOnDistanceLessThanD2MoreThanD1
			 @ШиротаГрад = 26.6, 
			 @ДолготаГрад = 56.4, 
			 @Расстояние1 = 1.0, 
			 @Расстояние2 = 2.0;
go
