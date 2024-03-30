CREATE OR ALTER PROCEDURE SelectFuncionarioTB
AS
	SELECT * FROM FuncionarioTB Order By Nome
GO

CREATE OR ALTER PROCEDURE BuscaFuncionarioTB (@Nome varchar(100))
AS
	SELECT  F.*
		, GF.NomeGenero
	FROM FuncionarioTB				F
		Inner Join GeneroTB			GF on GF.ID = F.GeneroID
	Where F.Nome like '%'+@Nome+'%' 
GO

CREATE OR ALTER PROCEDURE BuscaIDFuncionarioTB (@ID int)
AS
	SELECT TOP 1 * FROM FuncionarioTB F Where F.ID = @ID
GO

CREATE OR ALTER PROCEDURE AddFuncionarioTB (@Nome varchar(100), @DataNacimento datetime, @Salario float, @GeneroID int)
AS
	if(SELECT COUNT(1) FROM FuncionarioTB F Where F.Nome = @Nome AND F.DataNascimento = @DataNacimento And F.Salario = @Salario And F.GeneroID = @GeneroID) = 0
		INSERT INTO FuncionarioTB (Nome, DataNascimento,	Salario, GeneroID)
			VALUES (@Nome, @DataNacimento, @Salario, @GeneroID)
GO

CREATE OR ALTER PROCEDURE DeleteFuncionarioTB (@ID int = 0)
AS
	if(SELECT COUNT(1) FROM FuncionarioTB F Where F.ID = @ID) > 0
	BEGIN
		Update A Set A.GeneroID = null from FuncionarioTB A Where ID = @ID
		Delete from FuncionarioTB Where ID = @ID
	END
GO

CREATE OR ALTER PROCEDURE AtualizaFuncionarioTB (@ID int, @Nome varchar(100), @DataNacimento datetime, @Salario float, @GeneroID int)
AS
	if(SELECT COUNT(1) FROM FuncionarioTB F Where F.ID = @ID) > 0
		Update FuncionarioTB Set 
			Nome = @Nome, 
			DataNascimento = @DataNacimento, 
			Salario = @Salario, 
			GeneroID = @GeneroID
		Where ID = @ID
 
GO
