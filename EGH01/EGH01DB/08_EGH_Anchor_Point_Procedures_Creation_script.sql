----------------- —оздание процедур --------- -------------------------------
---- √еологическа€ точка
-----------------------------------------------------------------------------
---- ƒобавление геологической точки
---- ”даление геологической точки
---- ѕолучение геологической точки  
---- ѕолучение геологической точки
---- ќбновление геологической точки
---- ѕолучение следующего ID геологической точки
-----------------------------------------------------------------------------
drop procedure EGH.CreatePoint;
drop procedure EGH.DeletePoint;
drop procedure EGH.GetPointByID;
drop procedure EGH.GetPointList;
drop procedure EGH.UpdatePoint;
drop procedure EGH.GetNextPointCode;
GO
------------------------------------

-- ƒобавление геологической точки 
create procedure EGH.CreatePoint(
		    @ од√еологической“очки int,  
			@Ўирота√рад float, 
			@ƒолгота√рад float,
			@“ип√рунта int,
			@√лубина√рунтовых¬од float,
			@¬ысота”ровнемћор€ float)
as begin 
declare @rc int  = @ од√еологической“очки;
	begin try
		insert into dbo.√еологическа€“очка(
					[ од√еологической“очки],
					[Ўирота√рад],
					[ƒолгота√рад],
					[“ип√рунта],
					[√лубина√рунтовых¬од],
					[¬ысота”ровнемћор€]) 
			values (@ од√еологической“очки,  
					@Ўирота√рад, 
					@ƒолгота√рад,
					@“ип√рунта,
					@√лубина√рунтовых¬од,
					@¬ысота”ровнемћор€); 
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;
go

-- ”даление геологической точки
create procedure EGH.DeletePoint (@ од√еологической“очки int)
as begin 
    declare @rc int  = @ од√еологической“очки;
    begin try 
	 delete [dbo].√еологическа€“очка where  од√еологической“очки = @ од√еологической“очки;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end;
go

-- ѕолучение геологической точки  по ID 
create  procedure EGH.GetPointByID(@ од√еологической“очки int, 
										@Ўирота√рад float output, 
										@ƒолгота√рад float output,  
										@“ип√рунта int output,
										@√лубина√рунтовых¬од float output,
										@¬ысота”ровнемћор€ float output) 
as begin 
    declare @rc int = -1;
	select	@Ўирота√рад = Ўирота√рад,  
			@ƒолгота√рад = ƒолгота√рад,
			@“ип√рунта = “ип√рунта,
			@√лубина√рунтовых¬од = √лубина√рунтовых¬од,
			@¬ысота”ровнемћор€ = ¬ысота”ровнемћор€
	from dbo.√еологическа€“очка where  од√еологической“очки = @ од√еологической“очки;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

-- ѕолучение списка геологических точек 
create procedure EGH.GetPointList
 as begin
	declare @rc int = -1;
	select	 од√еологической“очки, 
			Ўирота√рад,
			ƒолгота√рад,
			“ип√рунта,
			√лубина√рунтовых¬од,
			¬ысота”ровнемћор€
		from dbo.√еологическа€“очка;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- ќбновление геологической точки
create  procedure EGH.UpdatePoint(	@ од√еологической“очки int, 
									@Ўирота√рад float,  
									@ƒолгота√рад float,
									@“ип√рунта int,
									@√лубина√рунтовых¬од float,
									@¬ысота”ровнемћор€ float) 
as begin 
    declare @rc int = -1;
	update  dbo.√еологическа€“очка set 
	Ўирота√рад = @Ўирота√рад,
	ƒолгота√рад = @ƒолгота√рад,
	“ип√рунта = @“ип√рунта,
	√лубина√рунтовых¬од = @√лубина√рунтовых¬од,
	¬ысота”ровнемћор€ = @¬ысота”ровнемћор€  
	where  од√еологической“очки = @ од√еологической“очки;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- ѕолучение следующего ID геологической точки
create procedure  EGH.GetNextPointCode
 as begin
	declare @rc int = -1;
	select max( од√еологической“очки)+1 from dbo.√еологическа€“очка;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go