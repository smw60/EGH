----------------- �������� �������� --------- -------------------------------
---- ���� ����������� �������� 
-----------------------------------------------------------------------------
---- ���������� ���� ����������� �������� 
---- �������� ���� ����������� �������� 
---- ��������� ���� ����������� �������� �� ID 
---- ��������� ������ ����� ����������� �������� 
---- ���������� ���� ����������� ��������
---- ���������� ���� ����������� �������� 
---- ��������� ���������� ID ���� ����������� �������� �� ID 
-----------------------------------------------------------------------------
drop procedure EGH.CreateRiskObjectType;
drop procedure EGH.DeleteRiskObjectType; 
drop procedure EGH.GetRiskObjectTypeByID;
drop procedure EGH.GetRiskObjectTypeList;
drop procedure EGH.UpdateRiskObjectType;
drop procedure EGH.GetNextRiskObjectTypeCode;
go;
------------------------------------

-- ���������� ���� ����������� �������� 
create procedure EGH.CreateRiskoObjectType (@�������������������������� int,  @����������������������������������� nvarchar(30))
as begin 
declare @rc int  = @��������������������������;
	begin try
		insert into dbo.����������������������(��������������������������, �����������������������������������) values(@��������������������������, @�����������������������������������); 
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;
go
-- �������� ���� ����������� �������� 
create procedure EGH.DeleteRiskObjectType (@�������������������������� int)
as begin 
    declare @rc int  = @��������������������������;
    begin try 
	 delete dbo.���������������������� where �������������������������� = @��������������������������;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end; 
go
-- ��������� ���� ����������� �������� �� ID 
create  procedure EGH.GetRiskObjectTypeByID(@�������������������������� int, @����������������������������������� nvarchar(30) output) 
as begin 
    declare @rc int = -1;
	select  @����������������������������������� = ����������������������������������� from dbo.���������������������� where �������������������������� = @��������������������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- ��������� ������ ����� ����������� �������� 
create procedure EGH.GetRiskObjectTypeList
 as begin
	declare @rc int = -1;
	select ��������������������������, ����������������������������������� from dbo.����������������������;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- ���������� ���� ����������� �������� 
create  procedure EGH.UpdateRiskObjectType(@�������������������������� int, @����������������� nvarchar(30)) 
as begin 
    declare @rc int = -1;
	update  dbo.���������������������� set ����������������������������������� = @����������������� where �������������������������� = @��������������������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- ��������� ���������� ID ���� ����������� �������� 
create procedure EGH.GetNextRiskObjectTypeCode
 as begin
	declare @rc int = -1;
	select max(��������������������������)+1 from [dbo].[����������������������];
	set @rc = @@ROWCOUNT;
	return @rc;    
end;