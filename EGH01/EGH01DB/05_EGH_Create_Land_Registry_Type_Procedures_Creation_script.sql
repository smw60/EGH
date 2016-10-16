----------------- �������� �������� --------- -------------------------------
---- ���� ������������ ���������� ������
-----------------------------------------------------------------------------
---- ���������� ���� ������������ ���������� ������
---- �������� ���� ������������ ���������� ������
---- ��������� ���� ������������ ���������� ������ �� ID
---- ��������� ������ ����� ������������ ���������� ������
---- ���������� ���� ������������ ���������� ������
---- ��������� ���������� ID ���� ������������ ���������� ������
-----------------------------------------------------------------------------
drop procedure EGH.CreateLandRegistryType;
drop procedure EGH.DeleteLandRegistryType;
drop procedure EGH.GetLandRegistryTypeByID;
drop procedure EGH.GetLandRegistryTypeList;
drop procedure EGH.UpdateLandRegistryType;
drop procedure EGH.GetNextLandRegistryTypeCode;
go;

------------------------------------

-- ���������� ���� ������������ ���������� ������
create procedure EGH.CreateLandRegistryType(
						@������������������� int,  
						@���������������������������� nvarchar(100),
						@��� int)
as begin 
declare @rc int  = @�������������������;
	begin try
		insert into dbo.����������������(
							�������������������,
							����������������������������,
							���) 
				values (@�������������������,  
						@����������������������������,
						@���); 
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;

-- �������� ���� ������������ ���������� ������
create procedure EGH.DeleteLandRegistryType (@������������������� int)
as begin 
    declare @rc int  = @�������������������;
    begin try 
	 delete dbo.���������������� where ������������������� = @�������������������;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end; 

-- ��������� ���� ������������ ���������� ������ �� ID
create  procedure EGH.GetLandRegistryTypeByID(
						@������������������� int,  
						@���������������������������� nvarchar(100) output,
						@��� int output)
as begin 
    declare @rc int = -1;
	select  @���������������������������� = ����������������������������,
			@��� = ���
		from  dbo.���������������� where ������������������� = @�������������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;

-- ��������� ������ ����� ������������ ���������� ������
create procedure EGH.GetLandRegistryTypeList
 as begin
	declare @rc int = -1;
	select	�������������������,
			����������������������������,
			���
	from dbo.����������������;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;

-- ���������� ���� ������������ ���������� ������
create  procedure UpdateLandRegistryType(@������������������� int, @����������������� nvarchar(50), @���������������� int) 
as begin 
    declare @rc int = -1;
	update  dbo.���������������� set ���������������������������� = @�����������������, ��� = @���������������� where ������������������� = @�������������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;

-- ��������� ���������� ID ���� ������������ ���������� ������
create procedure EGH.GetNextLandRegistrytTypeCode
 as begin
	declare @rc int = -1;
	select (max(�������������������)+1) from [dbo].����������������;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;

