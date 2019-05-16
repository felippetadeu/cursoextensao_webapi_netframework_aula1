Create Table Usuario (
	UsuarioId Int Not Null Identity,
	Nome Varchar(50) Not Null,
	Email Varchar(50) Not Null,
	Senha Varchar(50) Not Null,
	Administrador Bit Not Null Constraint Df_Usuario_Administrador Default (0),
	Constraint Pk_Usuario Primary Key (UsuarioId)
)
Go

Insert Into Usuario (Nome, Email, Senha, Administrador) Values ('Admin', 'admin@site.com.br', '14e1b600b1fd579f47433b88e8d85291', 1)
Go

Create Table Controlador (
	ControladorId Int Not Null Identity,
	ControllerName Varchar(250) Not Null,
	Constraint Pk_Controlador Primary Key (ControladorId)
)
Go

Insert Into Controlador (ControllerName) Values ('Categoria')
Go

Insert Into Controlador (ControllerName) Values ('Produto')
Go

Create Table Acao (
	AcaoId Int Not Null Identity,
	ActionName Varchar(250) Not Null,
	ControladorId Int Not Null,
	Constraint Pk_Acao Primary Key (AcaoId),
	Constraint Fk_Acao_Controlador Foreign Key (ControladorId) References Controlador (ControladorId)
)
Go

Create Table AcaoUsuario (
	AcaoUsuarioId Int Not Null Identity,
	AcaoId Int Not Null,
	UsuarioId Int Not Null,
	Constraint Pk_AcaoUsuario Primary Key (AcaoUsuarioId),
	Constraint Fk_AcaoUsuario_Acao Foreign Key (AcaoId) References  Acao (AcaoId),
	Constraint Fk_AcaoUsuario_Usuario Foreign Key (UsuarioId) References Usuario (UsuarioId),
	Constraint Unq_AcaoUsuario_AcaoUsuario Unique (AcaoId, UsuarioId)
)
Go

Create Table Categoria (
	CategoriaId Int Not Null Identity,
	Nome Varchar(250) Not Null,
	Constraint Pk_Categoria Primary Key (CategoriaId)
)
Go

Create Table Produto (
	ProdutoId Int Not Null Identity,
	Nome Varchar(250) Not Null,
	CategoriaId Int Not Null,
	CodigoInterno Varchar(250) Not Null
	Constraint Pk_Produto Primary Key (ProdutoId),
	Constraint Fk_Produto_Categoria Foreign Key (CategoriaId) References Categoria (CategoriaId),
	Constraint Unq_Produto_CodigoInterno Unique (CodigoInterno)
)
Go