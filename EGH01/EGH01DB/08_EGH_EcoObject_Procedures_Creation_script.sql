----------------- �������� �������� ���� ������ -----------------------------
----		����� ������� ��������� ���������
---- ����������������� ������    
-----------------------------------------------------------------------------
---- ���������� ������������������ �������
---- �������� ������������������ ������� 
---- ��������� ������������������ ������� �� ID 
---- ��������� ������ ����������������� �������� 
---- ���������� ������������������ �������
---- ��������� ���������� ID ������������������ �������
---- ��������� ������ ����������������� ��������, ����������� �� ����������� <D(������) �� ����� (X,Y)
---- ��������� ������ ����������������� ��������, ����������� �� ����������� >D1(������) � <D1(������) �� ����� (X,Y)
-----------------------------------------------------------------------------
USE EGH;
go

drop procedure EGH.CreateEcoObject;
drop procedure EGH.DeleteEcoObject;
drop procedure EGH.GetEcoObjectByID;
drop procedure EGH.GetEcoObjectList;
drop procedure EGH.UpdateEcoObject;
drop procedure EGH.GetNextEcoObjectId;
drop procedure EGH.GetListEcoObjectOnDistanceLessThanD;
drop procedure EGH.GetListEcoObjectOnDistanceLessThanD2MoreThanD1;
GO
------------------------------------

-- ���������� ���������������� ������� 
create procedure EGH.CreateEcoObject(
		    @Id����������������������� int,  
			@����������������������������������� nvarchar(MAX),
			@������������������������������ int,
			@����������������������� int,
			@���������� float,
			@����������� float,
			@��������� int,
			@������������������� float,
			@����������������� float)
as begin 
declare @rc int  = @Id�����������������������;
	begin try
		insert into dbo.���������������������(
					[Id�����������������������],
					[�����������������������������������],
					[������������������������������],
					[�����������������������],
					[����������],
					[�����������],
					[���������],
					[�������������������],
					[�����������������])
			values (@Id�����������������������,
					@�����������������������������������,  
					@������������������������������,
					@�����������������������,
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

-- �������� ���������������� �������
create procedure EGH.DeleteEcoObject(@Id����������������������� int)
as begin 
    declare @rc int  = @Id�����������������������;
    begin try 
	 delete dbo.��������������������� where Id����������������������� = @Id�����������������������;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end;
go
-- ��������� ���������������� �������  �� ID 
create  procedure EGH.GetEcoObjectByID(@Id����������������������� int)
as begin 
    declare @rc int = -1;
select [Id�����������������������],
		T.[������������������������������] ������������������������������,
		[���������������������������������������],
		[�����������������������],
		[����������������������������],
		[���],
		[�����������������������������������],
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
 from dbo.��������������������� O 
			inner join dbo.�������������������������� T on O.Id�����������������������=T.������������������������������
			inner join dbo.��������� G on O.��������� = G.�������������
			inner join dbo.���������������� Z on O.����������������������� = Z.�������������������
		 where Id����������������������� = @Id�����������������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- ��������� ������ ����������� ��������
create procedure EGH.GetEcoObjectList
 as begin
	declare @rc int = -1;
	select [Id�����������������������],
		T.[������������������������������] ������������������������������,
		[���������������������������������������],
		[�����������������������],
		[����������������������������],
		[���],
		[�����������������������������������],
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
 from dbo.��������������������� O 
			inner join dbo.�������������������������� T on O.Id�����������������������=T.������������������������������
			inner join dbo.��������� G on O.��������� = G.�������������
			inner join dbo.���������������� Z on O.����������������������� = Z.�������������������;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- ���������� ���������������� �������
create  procedure EGH.UpdateEcoObject(
					@Id����������������������� int, 
					@������������������������������ int,
					@����������������������� int,
					@����������������������������������� nvarchar(MAX),
					@���������� float,
					@����������� float,
					@��������� int,
					@������������������� float,
					@����������������� float) 
as begin 
    declare @rc int = -1;
	update  dbo.��������������������� 
	set 
	������������������������������ = @������������������������������,
	����������������������� = @�����������������������,
	����������������������������������� = @�����������������������������������,
	���������� = @����������,
	����������� = @�����������,
	��������� = @���������,
	������������������� = @�������������������,
	����������������� = @����������������� 
	where Id����������������������� = @Id�����������������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- ��������� ���������� ID ���������������� �������
create procedure EGH.GetNextEcoObjectId(@Id����������������������� int output)
 as begin
	declare @rc int = -1;
	set @Id����������������������� = (select max(Id�����������������������)+1 from dbo.���������������������);
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

---- ��������� ������ ��������������� ��������, ����������� �� ����������� <D(������) �� ����� (X,Y)
create procedure EGH.GetListEcoObjectOnDistanceLessThanD (
				@���������� float, 
				@����������� float, 
				@���������� float)
 as begin
	declare @rc int = -1;

	select [Id�����������������������],
		[����������],
		[�����������],
		SQRT(Power(([����������]-@����������), 2)+Power(([�����������]-@�����������), 2)) as [����������]
	from dbo.��������������������� where (SQRT(Power(([����������]-@����������), 2)+Power(([�����������]-@�����������), 2)) < @����������);
		set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
---- ��������� ������ ��������������� ��������, ����������� �� ����������� >D1(������) � <D1(������) �� ����� (X,Y)
create procedure EGH.GetListEcoObjectOnDistanceLessThanD2MoreThanD1(
					@���������� float, 
					@����������� float, 
					@����������1 float, 
					@����������2 float)
 as begin
	declare @rc int = -1;

	select [Id�����������������������],
		[����������],
		[�����������],
		SQRT(Power(([����������]-@����������), 2)+Power(([�����������]-@�����������), 2)) as [����������]
	from dbo.��������������������� where( (SQRT(Power(([����������]-@����������), 2)+Power(([�����������]-@�����������), 2)) > @����������1)
		and (SQRT(Power(([����������]-@����������), 2)+Power(([�����������]-@�����������), 2)) < @����������2));
		set @rc = @@ROWCOUNT;
	return @rc;    
end;
go











