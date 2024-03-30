CREATE OR ALTER VIEW VFuncionarios 
AS
	SELECT top (SELECT MAX(ID) fROM FuncionarioTB) 
		F.*
		, G.NomeGenero 
	FROM FuncionarioTB			F
		Inner Join GeneroTB		G On G.ID = F.GeneroID
	ORDER BY Nome
go

CREATE OR ALTER VIEW VFuncionariosFiltroGenero 
AS
	SELECT F.*, G.NomeGenero
	FROM FuncionarioTB			F
		Inner Join GeneroTB		G on G.ID = F.GeneroID
	Where (UPPER(TRIM(G.NomeGenero)) = 'MASCULINO' AND YEAR(F.DataNascimento) BetWeen 1990 And 2011)
		OR (UPPER(TRIM(G.NomeGenero)) = 'FEMININO' AND YEAR(F.DataNascimento) BetWeen 1980 And 2001)
GO

CREATE OR ALTER VIEW VFuncionariosEDependentes 
AS
	SELECT  F.*
		, GF.NomeGenero
		, D.Nome Nome_Dependente
		, D.DataNascimento Nascimento_Dependente
		, D.GeneroID GeneroID_Dependente
		, G.NomeGenero Genero_Dependente
	FROM FuncionarioTB				F
		Inner Join DependentesTB	D on D.FuncionarioId = F.ID
		Inner Join GeneroTB			G on G.ID = D.GeneroID
		Inner Join GeneroTB			GF on GF.ID = F.GeneroID
GO

CREATE OR ALTER VIEW VDependentesEFuncionarios 
AS
	SELECT  D.*
		, G.NomeGenero 
		, F.Nome Nome_Funcionario
		, F.DataNascimento Nascimento_Funcionario
		, F.GeneroID GeneroID_Funcionario
		, GF.NomeGenero Genero_Funcionario 
	FROM DependentesTB				D
		Left Join FuncionarioTB		F on D.FuncionarioId = F.ID
		Inner Join GeneroTB			G on G.ID = D.GeneroID
		Inner Join GeneroTB			GF on GF.ID = F.GeneroID
GO