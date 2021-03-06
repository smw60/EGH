----------------- �������� �������� ���� ������ -----------------------------
----		����� ������� ��������� ���������
---- ����������� ������    
-----------------------------------------------------------------------------
---- ���������� ������������ �������
---- �������� ������������ ������� 
---- ��������� ������������ ������� �� ID 
---- ��������� ������ ����������� �������� 
---- ���������� ������������ �������
---- ��������� ���������� ID ������������ �������
---- ��������� ������ ����������� ��������, ����������� �� ����������� <D(������) �� ����� (X,Y)
---- ��������� ������ ����������� ��������, ����������� �� ����������� >D1(������) � <D1(������) �� ����� (X,Y)
-----------------------------------------------------------------------------
USE EGH;
go

drop procedure EGH.CreateRiskObject;
drop procedure EGH.DeleteRiskObject;
drop procedure EGH.GetRiskObjectByID;
drop procedure EGH.GetRiskObjectList;
drop procedure EGH.UpdateRiskObject;
drop procedure EGH.GetNextRiskObjectId;
drop procedure EGH.GetListRiskObjectOnDistanceLessThanD;
drop procedure EGH.GetListRiskObjectOnDistanceLessThanD2MoreThanD1;
GO
------------------------------------

-- ���������� ������������ ������� 
create procedure EGH.CreateRiskObject(
		    @Id������������������� int,  
			@�������������������������� int,
			@����������������������� int,
			@������������������������������� nvarchar(MAX),
			@������������������������ nvarchar(MAX),
			@���������� float,
			@����������� float,
			@��������� int,
			@������������������� float,
			@����������������� float)
as begin 
declare @rc int  = @Id�������������������;
	begin try
		insert into dbo.�����������������(
					[Id�������������������],
					[��������������������������],
					[�����������������������],
					[�������������������������������],
					[������������������������],
					[����������],
					[�����������],
					[���������],
					[�������������������],
					[�����������������])
			values (@Id�������������������,  
					@��������������������������,
					@�����������������������,
					@�������������������������������,
					@������������������������,
					@����������,
					@�����������,
					@���������,
					@�������������������,
					@�����������������); 
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;
go

-- �������� ������������ �������
create procedure EGH.DeleteRiskObject(@Id������������������� int)
as begin 
    declare @rc int  = @Id�������������������;
    begin try 
	 delete dbo.����������������� where Id������������������� = @Id�������������������;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end;
go
-- ��������� ������������ �������  �� ID 
create  procedure EGH.GetRiskObjectByID(@Id������������������� int)
as begin 
    declare @rc int = -1;
select [Id�������������������],
		T.[��������������������������] ��������������������������,
		[�����������������������������������],
		[�����������������������],
		[����������������������������],
		[���],
		[�������������������������������],
		[������������������������],
		[����������],
		[�����������],
		[���������],
		[����������������������],
		[��������������],
		[��������������������],
		[������������������],
		[������������],
		[�����������������],
		[�����������],
		[�������������������],
		[�����������������]
 from dbo.����������������� O 
			inner join dbo.���������������������� T on O.��������������������������=T.��������������������������
			inner join dbo.��������� G on O.��������� = G.�������������
			inner join dbo.���������������� Z on O.����������������������� = Z.�������������������
		 where Id������������������� = @Id�������������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- ��������� ������ ����������� ��������
create procedure EGH.GetRiskObjectList
 as begin
	declare @rc int = -1;
	select [Id�������������������],
		T.[��������������������������] ��������������������������,
		[�����������������������������������],
		[�����������������������],
		[����������������������������],
		[���],
		[�������������������������������],
		[������������������������],
		[����������],
		[�����������],
		[���������],
		[����������������������],
		[��������������],
		[��������������������],
		[������������������],
		[������������],
		[�����������������],
		[�����������],
		[�������������������],
		[�����������������]
 from dbo.����������������� O 
			inner join dbo.���������������������� T on O.��������������������������=T.��������������������������
			inner join dbo.��������� G on O.��������� = G.�������������
			inner join dbo.���������������� Z on O.����������������������� = Z.�������������������;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- ���������� ������������ �������
create  procedure EGH.UpdateRiskObject(@Id������������������� int, 
										@�������������������������� int,
										@����������������������� int,
										@������������������������������� nvarchar(MAX),
										@������������������������ nvarchar(MAX),
										@���������� float,
										@����������� float,
										@��������� int,
										@������������������� float,
										@����������������� float) 
as begin 
    declare @rc int = -1;
	update  dbo.����������������� set 
	�������������������������� = @��������������������������,
	����������������������� = @�����������������������,
	������������������������������� = @�������������������������������,
	������������������������ = @������������������������,
	���������� = @����������,
	����������� = @�����������,
	��������� = @���������,
	������������������� = @�������������������,
	����������������� = @����������������� 
	where Id������������������� = @Id�������������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- ��������� ���������� ID ������������ �������
create procedure EGH.GetNextRiskObjectId(@Id������������������� int output)
 as begin
	declare @rc int = -1;
	set @Id������������������� = (select max(Id�������������������)+1 from dbo.�����������������);
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

---- ��������� ������ ����������� ��������, ����������� �� ����������� <D(������) �� ����� (X,Y)
create procedure EGH.GetListRiskObjectOnDistanceLessThanD (@���������� float, @����������� float, @���������� float)
 as begin
	declare @rc int = -1;

	select [Id�������������������],
		[����������],
		[�����������],
		SQRT(Power(([����������]-@����������), 2)+Power(([�����������]-@�����������), 2)) as [����������]
	from dbo.����������������� where (SQRT(Power(([����������]-@����������), 2)+Power(([�����������]-@�����������), 2)) < @����������);
		set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
---- ��������� ������ ����������� ��������, ����������� �� ����������� >D1(������) � <D1(������) �� ����� (X,Y)
create procedure EGH.GetListRiskObjectOnDistanceLessThanD2MoreThanD1(@���������� float, @����������� float, @����������1 float, @����������2 float)
 as begin
	declare @rc int = -1;

	select [Id�������������������],
		[����������],
		[�����������],
		SQRT(Power(([����������]-@����������), 2)+Power(([�����������]-@�����������), 2)) as [����������]
	from dbo.����������������� where( (SQRT(Power(([����������]-@����������), 2)+Power(([�����������]-@�����������), 2)) > @����������1)
		and (SQRT(Power(([����������]-@����������), 2)+Power(([�����������]-@�����������), 2)) < @����������2));
		set @rc = @@ROWCOUNT;
	return @rc;    
end;
go










