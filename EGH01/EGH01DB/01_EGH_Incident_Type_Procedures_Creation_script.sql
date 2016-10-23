----------------- �������� �������� --------- -------------------------------
---- ���� ����������
-----------------------------------------------------------------------------
---- ���������� ���� ���������
---- �������� ���� ���������
---- ��������� ID ���� ���������
---- ��������� ������ ����� ����������
---- ���������� ���� ���������
---- ��������� ���������� ID ���� ��������� 
-----------------------------------------------------------------------------
use egh;
go

drop procedure EGH.CreateIncidentType;
drop procedure EGH.DeleteIncidentType; 
drop procedure EGH.GetIncidentTypeByID;
drop procedure EGH.GetIncidentTypeList;
drop procedure EGH.UpdateIncidentType;
drop procedure EGH.GetNextIncidentTypeCode;
go
------------------------------------

-- ���������� ���� ���������
create procedure EGH.CreateIncidentType (@������� int,  @������������ nvarchar(50))
as begin 
declare @rc int  = @�������;
	begin try
		insert into dbo.������������(�������, ������������) values(@�������, @������������); 
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;


-- �������� ���� ���������
create procedure EGH.DeleteIncidentType (@������� int)
as begin 
    declare @rc int  = @�������;
    begin try 
	 delete ������������ where ������� = @�������;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end; 


-- ��������� ���� ��������� �� ID
create  procedure EGH.GetIncidentTypeByID(@������� int, @������������ nvarchar(50) output) 
as begin 
    declare @rc int = -1;
	select  @������������ = ������������ from dbo.������������ where ������� = @�������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;


-- ��������� ������ ����� ����������
create procedure EGH.GetIncidentTypeList
 as begin
	declare @rc int = -1;
	select �������, ������������ from [dbo].[������������];
	set @rc = @@ROWCOUNT;
	return @rc;    
end;


---- ���������� ���� ���������
create  procedure EGH.UpdateIncidentType(@������� int, @����������������� nvarchar(50)) 
as begin 
    declare @rc int = -1;
	update  dbo.������������ set ������������ = @����������������� where ������� = @�������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;

---- ��������� ���������� ID ���� ��������� 
create procedure EGH.GetNextIncidentTypeCode
 as begin
	declare @rc int = -1;
	select max(�������)+1 from [dbo].[������������];
	set @rc = @@ROWCOUNT;
	return @rc;    
end;

