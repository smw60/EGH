----------------- �������� �������� --------- -------------------------------
---- ���� ����������
-----------------------------------------------------------------------------
---- ���������� ���� ���������
---- �������� ���� ���������
---- ��������� ID ���� ���������
---- ��������� ������ ����� ����������
---- ���������� ���� ���������
-----------------------------------------------------------------------------
use egh;

drop procedure EGH.CreateIncidentType;
drop procedure EGH.DeleteIncidentType; 
drop procedure EGH.GetIncidentTypeByID;
drop procedure EGH.GetIncidentTypeList;
drop procedure EGH.UpdateIncidentType;
go;
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
go;

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
go;

-- ��������� ���� ��������� �� ID
create  procedure EGH.GetIncidentTypeByID(@������� int, @������������ nvarchar(50) output) 
as begin 
    declare @rc int = -1;
	select  @������������ = ������������ from dbo.������������ where ������� = @�������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go;

-- ��������� ������ ����� ����������
create procedure EGH.GetIncidentTypeList
 as begin
	declare @rc int = -1;
	select �������, ������������ from [dbo].[������������];
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go;

---- ���������� ���� ���������

