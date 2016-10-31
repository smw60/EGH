------------- Проверка процедур Incident Type ----------------------------------
-- create
declare @rc int = -1;
exec @rc = EGH.CreateIncidentType @КодТипа= 7,  @Наименование = 'Нефтевоз';
select @rc;
go
-- delete
declare @rc int = -1;
exec @rc = EGH.DeleteIncidentType @КодТипа= 7;
select @rc;
go
-- by code
declare @rc int = -1;
declare @Name nvarchar(50) = '';
exec @rc = EGH.GetIncidentTypeByCode @КодТипа= 5, @Наименование = @Name output;
select @rc;
print @Name;
go
-- list
exec EGH.GetIncidentTypeList;
-- update
declare @rc int = -1;
exec @rc = EGH.UpdateIncidentType @КодТипа= 6,  @НовоеНаименование = 'Нефтевоз';
select @rc;
go
-- next
declare @rc int = -1;
exec EGH.GetNextIncidentTypeCode @КодТипа=@rc output;
select @rc;
go
