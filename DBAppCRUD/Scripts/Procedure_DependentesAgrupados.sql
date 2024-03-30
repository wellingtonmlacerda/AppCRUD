CREATE OR ALTER PROCEDURE DependentesAgrupados
AS
	SELECT COUNT(*) QTD
		, V.Genero_Dependente
		, YEAR(V.Nascimento_Dependente) Ano_Nascimento
	FROM VFuncionariosEDependentes V
	Group By
		V.Genero_Dependente
		, YEAR(V.Nascimento_Dependente)
GO