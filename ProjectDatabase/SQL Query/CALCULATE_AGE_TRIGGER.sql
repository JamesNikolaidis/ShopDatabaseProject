CREATE TRIGGER Calculate_Age
ON PELATES
FOR INSERT,UPDATE

 AS 
 BEGIN 

 IF EXISTS (SELECT HM_GENNISIS FROM PELATES )

  
  UPDATE PELATES SET HLIKIA = year(GETDATE())-year(HM_GENNISIS);

 END





