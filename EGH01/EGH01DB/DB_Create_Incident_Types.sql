-- �������� �������� �� �������, �������� � ��������� �� ���� ���������
-- ���� ����������:
-- 1	�����������
-- 2	��������� ��������
-- 3	��������� ���������
-- 4	�������������
-- 5	��������������� ���������

-- ���������� ���� ���������
drop procedure EGH.CreateIncidentType
go


create procedure EGH.CreateIncidentType (@������� int ,  @������������ nvarchar(50))
as begin 
declare @rc int  = @�������;
	begin try
		insert into dbo.��������������(�������, ������������) values(@�������, @������������); 
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;
go

-- �������� ���� ���������
create procedure EGH.DeleteIncidentType (@������� int)
as begin 
    declare @rc int  = @�������;
    begin try 
	 delete �������������� where ������� = @�������;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end 
go;
-- ��������� ���� ��������� �� ID
drop  procedure EGH.GetIncidentTypeByID
go

create  procedure EGH.GetIncidentTypeByID(@������� int, @������������ nvarchar(50) output) 
as begin 
    declare @rc int = -1;
	select  @������������ = ������������ from dbo.�������������� where ������� = @�������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;

go

--
create procedure EGH.GetIncidentTypeList
 as begin
	declare @rc int = -1;
	select �������, ������������ from [dbo].[��������������];
	set @rc = @@ROWCOUNT;
	return @rc;    
end;


select * from [dbo].[��������������]
declare @ttt int = -1;
exec @ttt=EGH.GetIncidentTypeList
select @ttt;
