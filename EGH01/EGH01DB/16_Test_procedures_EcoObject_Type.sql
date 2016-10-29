------------- Проверка процедур EcoObject Type ----------------------------------
-- create
declare @rc int = -1;
exec @rc = EGH.CreateEcoObjectType @КодТипаПриродоохранногоОбъекта = 4,  @НаименованиеТипаПриродоохранногоОбъекта = 'Заповедник';
select @rc;
go
-- delete
declare @rc int = -1;
exec @rc = EGH.DeleteEcoObjectType @КодТипаПриродоохранногоОбъекта= 4;
select @rc;
go
-- by code
declare @rc int = -1;
declare @Name nvarchar(50) = '';
exec @rc = EGH.GetEcoObjectTypeByCode
					@КодТипаПриродоохранногоОбъекта = 3, 
					@НаименованиеТипаПриродоохранногоОбъекта = @Name output;
select @rc;
print @Name;
go
-- list
exec EGH.GetEcoObjectTypeList;
go

-- update
declare @rc int = -1;
exec @rc = EGH.UpdateEcoObjectType @КодТипаПриродоохранногоОбъекта= 3,  @НовоеНаименование = 'Заповедник';
select @rc;
go

-- next
declare @rc int = -1;
exec EGH.GetNextEcoObjectTypeCode @КодТипаПриродоохранногоОбъекта = @rc output;
select @rc;
go
