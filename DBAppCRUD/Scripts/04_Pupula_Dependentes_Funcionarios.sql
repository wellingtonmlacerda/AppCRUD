DECLARE @ID int
  
PRINT '-------- Vendor Products Report --------';  
  
DECLARE DependenteCursor CURSOR FOR   
	Select A.ID
	From FuncionarioTB				A 
		Left Join DependentesTB		B On B.FuncionarioId = A.ID
	Where B.ID is null
  
OPEN DependenteCursor  
  
FETCH NEXT FROM DependenteCursor   
INTO @ID 
  
WHILE @@FETCH_STATUS = 0  
BEGIN  
	
    Update A Set A.FuncionarioId = @ID
	From DependentesTB A Where A.FuncionarioId is null 
		And A.ID IN (Select top 2 B.ID From DependentesTB B Where B.FuncionarioId is null )

        -- Get the next vendor.  
    FETCH NEXT FROM DependenteCursor   
    INTO @ID  
END   
CLOSE DependenteCursor;  
DEALLOCATE DependenteCursor;  
