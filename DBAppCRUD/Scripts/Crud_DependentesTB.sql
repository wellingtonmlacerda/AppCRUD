CREATE OR ALTER PROCEDURE SelectDependentesTB
AS
	SELECT * FROM DependentesTB
GO

CREATE OR ALTER PROCEDURE BuscaDependentesTB (@Nome varchar(100))
AS
	SELECT D.*
		, G.NomeGenero
	FROM DependentesTB		D
		Inner Join GeneroTB	G on G.ID = D.GeneroID
	Where Nome like '%'+@Nome+'%'
GO

CREATE OR ALTER PROCEDURE BuscaIDDependentesTB (@ID int)
AS
	SELECT TOP 1 * FROM DependentesTB Where ID = @ID
GO

CREATE OR ALTER PROCEDURE AddDependentesTB (@Nome varchar(100), @DataNacimento datetime, @FuncionarioId int, @GeneroID int)
AS
	if(SELECT COUNT(1) FROM DependentesTB Where Nome = @Nome AND DataNascimento = @DataNacimento And FuncionarioId = @FuncionarioId And GeneroID = @GeneroID) = 0
		INSERT INTO DependentesTB (Nome, DataNascimento,	FuncionarioId, GeneroID)
			VALUES (@Nome, @DataNacimento, @FuncionarioId, @GeneroID)
GO

CREATE OR ALTER PROCEDURE DeleteDependentesTB (@ID int = 0)
AS
	if(SELECT COUNT(1) FROM DependentesTB Where ID = @ID) > 0
		Delete from DependentesTB Where ID = @ID
GO

CREATE OR ALTER PROCEDURE AtualizaDependentesTB (@ID int, @Nome varchar(100), @DataNacimento datetime, @GeneroID int)
AS
	if(SELECT COUNT(1) FROM DependentesTB Where ID = @ID) > 0
		Update DependentesTB Set 
			Nome = @Nome,
			DataNascimento = @DataNacimento,
			GeneroID = @GeneroID
		Where ID = @ID
GO