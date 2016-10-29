------------- Проверка процедур RiskObject ----------------------------------
-- create
declare @rc int = -1;
exec @rc = EGH.CreateRiskObject 
			@IdТехногенногоОбъекта = 5,  
			@КодТипаТехногенногоОбъекта = 3,
			@КодТипаНазначенияЗемель = 5,
			@НаименованиеТехногенногоОбъекта = 'АЗС-31',
			@АдресТехногенногоОбъекта = 'г.Минск, Свердлова, 16',
			@ШиротаГрад = 26.6,
			@ДолготаГрад = 56.7,
			@ТипГрунта = 1,
			@ГлубинаГрунтовыхВод = 8.5,
			@ВысотаУровнемМоря =12.6;
select @rc;
go
-- delete
declare @rc int = -1;
exec @rc = EGH.DeleteRiskObject  @IdТехногенногоОбъекта = 2;
select @rc;
go
-- by code
declare @rc int = -1;
exec @rc = EGH.GetRiskObjectByID 
		@IdТехногенногоОбъекта= 3;
select @rc;
go
-- list
exec EGH.GetRiskObjectList;
go
-- update
declare @rc int = -1;
exec @rc = EGH.UpdateRiskObject  
				@IdТехногенногоОбъекта = 3, 
				@КодТипаТехногенногоОбъекта = 1,
				@КодТипаНазначенияЗемель = 2,
				@НаименованиеТехногенногоОбъекта = 'АЗС-13',
				@АдресТехногенногоОбъекта = 'г.Минск, Свердлова, 16',
				@ШиротаГрад = 26.6,
				@ДолготаГрад = 56.4,
				@ТипГрунта = 1,
				@ГлубинаГрунтовыхВод = 23.7,
				@ВысотаУровнемМоря = 45.2;
select @rc;
go
-- next
declare @rc int = -1;
exec EGH.GetNextRiskObjectId @IdТехногенногоОбъекта = @rc output;
select @rc;
go
-- less than d
exec EGH.GetListRiskObjectOnDistanceLessThanD @ШиротаГрад = 26.6, @ДолготаГрад =56.4, @Расстояние = 2.2
go
-- between d1 and d2
exec EGH.GetListRiskObjectOnDistanceLessThanD2MoreThanD1
			 @ШиротаГрад = 26.6, 
			 @ДолготаГрад = 56.4, 
			 @Расстояние1 = 1.0, 
			 @Расстояние2 = 2.0;
go