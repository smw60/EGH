----------------- �������� �������� --------- -------------------------------
---- ���� ��������������
-----------------------------------------------------------------------------
---- ���������� ���� �������������
---- �������� ���� �������������
---- ��������� ���� ������������� �� ID
---- ��������� ������ ����� �������������
---- ���������� ���� �������������
---- ��������� ���������� ID ���� �������������
-----------------------------------------------------------------------------
use egh;
drop procedure EGH.CreatePetrochemicalType;
drop procedure EGH.DeletePetrochemicalType;
drop procedure EGH.GetPetrochemicalTypeByID;
drop procedure EGH.GetPetrochemicalTypeList;
drop procedure EGH.UpdatePetrochemicalType;
drop procedure EGH.GetNextPetrochemicalTypeCode;
go;
------------------------------------

-- ���������� ���� �������������
create procedure EGH.CreatePetrochemicalType(
						@�������������������� int,  
						@����������������������������� nvarchar(30),
						@������������������ float,
						@��������� float,
						@���������������������� float,
						@������������� float)
as begin 
declare @rc int  = @��������������������;
	begin try
		insert into dbo.����������������(
							��������������������,
							�����������������������������,
							������������������,
							���������,
							����������������������,
							�������������) 
				values(@��������������������,
					   @�����������������������������,
					   @������������������,
					   @���������,
					   @����������������������,
					   @�������������); 
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;
go

-- �������� ���� �������������
create procedure EGH.DeletePetrochemicalType (@�������������������� int)
as begin 
    declare @rc int  = @��������������������;
    begin try 
	 delete dbo.���������������� where �������������������� = @��������������������;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end; 
go

-- ��������� ���� ������������� �� ID
create  procedure EGH.GetPetrochemicalTypeByID(
						@�������������������� int, 
						@����������������������������� nvarchar(50) output,
						@������������������ float output,
						@��������� float output,
						@���������������������� float output,
						@������������� float output) 
as begin 
    declare @rc int = -1;
	select  @����������������������������� = �����������������������������,
			@������������������ = ������������������,
			@��������� = ���������,
			@���������������������� = ����������������������,
			@������������� = �������������
	from dbo.���������������� where �������������������� = @��������������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

-- ��������� ������ ����� �������������
create procedure EGH.GetPetrochemicalTypeList
 as begin
	declare @rc int = -1;
	select	��������������������,
			�����������������������������,
			������������������,
			���������,
			����������������������,
			�������������
	from dbo.����������������;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

-- ��������� ���������� �������� ���� �������������
create procedure EGH.GetNextPetrochemicalTypeCode(@�������������������� int output)
 as begin
	declare @rc int = -1;
	set @�������������������� = (select	max(��������������������)+1 from dbo.����������������);
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
---- ���������� ���� �������������
create  procedure EGH.UpdatePetrochemicalTypeByID(
						@�������������������� int, 
						@����������������������������� nvarchar(50) output,
						@������������������ float output,
						@��������� float output,
						@���������������������� float output,
						@������������� float output) 
as begin 
    declare @rc int = -1;
	update  dbo.���������������� set
			����������������������������� = @�����������������������������,
			������������������ = @������������������,
			��������� = @���������,
			���������������������� = @����������������������,
			������������� = @�������������
	from dbo.���������������� where �������������������� = @��������������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

