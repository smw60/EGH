declare @rc int = -1;
exec @rc = EGH.CreateRiskObject
		    @Id“ехногенногоќбъекта =4,  
			@ од“ипа“ехногенногоќбъекта =1,
			@ од“ипаЌазначени€«емель =1,
			@Ќаименование“ехногенногоќбъекта ='ttt',
			@јдрес“ехногенногоќбъекта ='111',
			@Ўирота√рад = 0.0,
			@ƒолгота√рад = 5.2,
			@“ип√рунта =1,
			@√лубина√рунтовых¬од = 6.7,
			@¬ысота”ровнемћор€ =7.4;
select @rc;


-- проверка рассто€ни€
exec EGH.GetListRiskObjectOnDistanceLessThanD @Ўирота√рад= 3.7, @ƒолгота√рад  = 5.6, @–ассто€ние = 145;

exec EGH.GetListRiskObjectOnDistanceLessThanD2MoreThanD1 @Ўирота√рад= 3.7, @ƒолгота√рад  = 5.6, @–ассто€ние1 = 53, @–ассто€ние2 = 55;

---- [EGH].[GetPetrochemicalTypeList]
exec EGH.GetPetrochemicalTypeList

exec EGH.GetGroundTypeByCode @ од“ипа√рунта = 1;