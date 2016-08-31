CREATE DATABASE CadeMeuMedicoBD
GO

USE CadeMeuMedicoBD
GO

CREATE TABLE Usuario
(
IDUsuario BIGINT IDENTITY(1,1) NOT NULL,
Nome VARCHAR(80) NOT NULL,
Login VARCHAR(30) NOT NULL,
Senha VARCHAR(100) NOT NULL,
Email VARCHAR(100) NOT NULL,
PRIMARY KEY(IDUsuario)
);
GO
CREATE TABLE Medico
(
IDMedico BIGINT IDENTITY(1,1) NOT NULL,
CRM VARCHAR(30) NOT NULL,
Nome VARCHAR(80) NOT NULL,
Endereco VARCHAR(100) NOT NULL,
Bairro VARCHAR(60) NOT NULL,
Email VARCHAR(100) NULL,
AtendePorConvenio BIT NOT NULL,
TemClinica BIT NOT NULL,
WebsiteBlog VARCHAR(80) NULL,
IDCidade INT NOT NULL,
IDEspecialidade INT NOT NULL,
PRIMARY KEY(IDMedico)
);
GO
CREATE TABLE Especialidade
(
IDEspecialidade INT IDENTITY(1,1) NOT NULL,
Nome VARCHAR(80) NOT NULL,
PRIMARY KEY(IDEspecialidade)
);
GO
CREATE TABLE Cidade
(IDCidade INT IDENTITY(1,1) NOT NULL,
Nome VARCHAR(100) NOT NULL,
PRIMARY KEY(IDCidade)
);
GO
ALTER TABLE Medico
ADD CONSTRAINT fk_medicos_cidades
FOREIGN KEY(IDCidade)
REFERENCES Cidade(IDCidade)
GO
ALTER TABLE Medico
ADD CONSTRAINT fk_medicos_especialidades
FOREIGN KEY(IDEspecialidade)
REFERENCES Especialidade(IDEspecialidade)
GO
INSERT INTO Cidade (Nome) VALUES ('Blumenau')
INSERT INTO Cidade (Nome) VALUES ('São José do Rio Preto')
GO
INSERT INTO Especialidade (Nome) VALUES ('Cardiologista')
INSERT INTO Especialidade (Nome) VALUES ('Neurologista')
GO
INSERT INTO Usuario (Nome, Login, Senha, Email)
VALUES ('Administrador',
'admin',
'40BD001563085FC35165329EA1FF5C5ECBDBBEEF',
'admin@cdmm.com')
GO
