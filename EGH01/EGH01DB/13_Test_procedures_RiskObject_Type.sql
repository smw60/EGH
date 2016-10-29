------------- Проверка процедур RiskObject Type ----------------------------------
-- create
declare @rc int = -1;
exec @rc = EGH.CreateRiskObjectType @КодТипаТехногенногоОбъекта= 3,  @НаименованиеТипаТехногенногоОбъекта = 'Нефтехранилище';
select @rc;
go
-- delete
declare @rc int = -1;
exec @rc = EGH.DeleteRiskObjectType  @КодТипаТехногенногоОбъекта = 2;
select @rc;
go
-- by code
declare @rc int = -1;
declare @Name nvarchar(50) = '';
exec @rc = EGH.GetRiskObjectTypeByCode @КодТипаТехногенногоОбъекта= 3, @НаименованиеТипаТехногенногоОбъекта = @Name output;
select @rc;
print @Name;
go
-- list
exec EGH.GetRiskObjectTypeList;
-- update
declare @rc int = -1;
exec @rc = EGH.UpdateRiskObjectType  @КодТипаТехногенногоОбъекта = 3,  @НовоеНаименование = 'Нефтевоз';
select @rc;
go
-- next
declare @rc int = -1;
exec EGH.GetNextRiskObjectTypeCode @КодТипаТехногенногоОбъекта=@rc output;
select @rc;
go
