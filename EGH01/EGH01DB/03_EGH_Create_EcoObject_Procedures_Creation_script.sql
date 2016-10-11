----------------- �������� �������� --------- -------------------------------
---- ���� ��������������� �������� 
-----------------------------------------------------------------------------
---- ���������� ���� ��������������� �������� 
---- �������� ���� ��������������� �������� 
---- ��������� ���� ��������������� �������� �� ID 
---- ��������� ������ ����� ��������������� �������� 
---- ���������� ���� ��������������� �������� 
-----------------------------------------------------------------------------
drop procedure EGH.CreateEcoObjectType;
drop procedure EGH.DeleteEcoObjectType; 
drop procedure EGH.GetEcoObjectTypeByID;
drop procedure EGH.GetEcoObjectTypeList;
drop procedure EGH.UpdateEcoObjectType;
go;
------------------------------------

-- ���������� ���� ��������������� �������� 
create procedure EGH.CreateEcoObjectType (@����������������� int,  @�������������������������� nvarchar(50))
as begin 
declare @rc int  = @�����������������;
	begin try
		insert into dbo.��������������(�����������������, ��������������������������) values(@�����������������, @��������������������������); 
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;
go;

-- �������� ���� ��������������� �������� 
create procedure EGH.DeleteEcoObjectType (@����������������� int)
as begin 
    declare @rc int  = @�����������������;
    begin try 
	 delete dbo.�������������� where ����������������� = @�����������������;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end; 
go;

-- ��������� ���� ��������������� �������� �� ID 
create  procedure EGH.GetEcoObjectTypeByID(@����������������� int, @�������������������������� nvarchar(30) output) 
as begin 
    declare @rc int = -1;
	select  @�������������������������� = �������������������������� from dbo.�������������� where ����������������� = @�����������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go;

-- ��������� ������ ����� ��������������� �������� 
create procedure EGH.GetEcoObjectTypeList
 as begin
	declare @rc int = -1;
	select �����������������, �������������������������� from dbo.��������������;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go;

---- ���������� ���� ��������������� �������� 