Create Table GeneroTB (
	ID int IDENTITY(1,1) PRIMARY KEY not null ,
	NomeGenero varchar(10) not null
)
GO

Create Table FuncionarioTB (
	ID int IDENTITY(1,1) PRIMARY KEY not null,
	Nome varchar(100) not null,
	DataNascimento datetime not null,
	Salario float not null,
	GeneroID int null,
	FOREIGN KEY (GeneroID) REFERENCES GeneroTB(ID)
)
GO

Create Table DependentesTB (
	ID int IDENTITY(1,1) PRIMARY KEY not null,
	Nome varchar(100) not null,
	DataNascimento datetime not null,
	FuncionarioId int null,
	GeneroID int null,
	FOREIGN KEY (FuncionarioId) REFERENCES FuncionarioTB(ID),
	FOREIGN KEY (GeneroID) REFERENCES GeneroTB(ID)
)