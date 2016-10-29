------------- Проверка процедур Land Registry Type ----------------------------------
-- create
declare @rc int = -1;
exec @rc = EGH.CreateLandRegistryType 
					@КодНазначенияЗемель= 8,  
					@НаименованиеНазначенияЗемель = 'Морского фонда',
					@ПДК = 20;
select @rc;
go
-- delete
declare @rc int = -1;
exec @rc = EGH.DeleteLandRegistryType @КодНазначенияЗемель= 8;
select @rc;
go
-- by code
declare @rc int = -1;
declare @Name nvarchar(50) = '';
declare @p int = -1;
exec @rc = EGH.GetLandRegistryTypeByCode @КодНазначенияЗемель= 6,
										 @НаименованиеНазначенияЗемель = @Name output,
										 @ПДК = @p output;
select @rc;
print @Name;
print @p;
go
-- list
exec EGH.GetLandRegistryTypeList;
go
-- update
declare @rc int = -1;
exec @rc = EGH.UpdateLandRegistryType 
				@КодНазначенияЗемель = 6, 
				@НовоеНаименование = 'Резерва морских путей сообщения',
				@НовоеЗначениеПДК = 50;
select @rc;
go
-- next
declare @rc int = -1;
exec EGH.GetNextLandRegistryTypeCode @КодНазначенияЗемель = @rc output;
select @rc;
go
