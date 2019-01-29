-- Cria um banco de dados
CREATE DATABASE SENAI_SVIGUFU_TARDE;

--USA AS INSTRU��ES SQL NO BANCO INFORMADO
USE SENAI_SVIGUFU_TARDE;

/*
	Cria uma nova tabela
	identity - auto-incremento
	primary key - define que o campo ser� uma chave primaria
*/

CREATE TABLE TIPOS_EVENTOS(
	ID INT IDENTITY PRIMARY KEY
	,TITULO VARCHAR(255) NOT NULL UNIQUE
);

CREATE TABLE INSTITUICOES (
	ID INT IDENTITY PRIMARY KEY
	,RAZAO_SOCIAL VARCHAR(255) NOT NULL
	,NOME_FANTASIA VARCHAR(255) NULL
	,CNPJ CHAR(14) NOT NULL UNIQUE
	,LOGRADOURO VARCHAR(255) NOT NULL
	,CEP CHAR(8) NOT NULL
	,UF CHAR(2) NOT NULL
	,CIDADE VARCHAR(255) NOT NULL
);

CREATE TABLE EVENTOS(
	ID INT IDENTITY PRIMARY KEY
	,TITULO VARCHAR(255) NOT NULL
	,DESCRICAO TEXT -- para camps com grande quantidades de dados
	,DATA_EVENTO DATETIME NOT NULL -- campos do tipo data e hora
	,ACESSO_LIVRE BIT DEFAULT (1) --0 FALSE 1 TRUE
	,ID_TIPO_EVENTO INT
	,ID_INSTITUICAO INT
	--CRIA UMA CHAVE ESTRANGEIRA E DEFINE QUE O CAMPO ESTA RELACIONADO A TABELA(CAMPO)
	,FOREIGN KEY (ID_TIPO_EVENTO) REFERENCES TIPOS_EVENTOS(ID)
	,FOREIGN KEY (ID_INSTITUICAO) REFERENCES INSTITUICOES(ID)
);

CREATE TABLE USUARIOS (
	ID INT IDENTITY PRIMARY KEY
	,NOME VARCHAR(255) NOT NULL
	,EMAIL VARCHAR(250) NOT NULL UNIQUE
	,SENHA VARCHAR (100) NOT NULL
	,TIPO_USUARIO VARCHAR(100) NOT NULL
);

CREATE TABLE CONVITES(
	ID INT IDENTITY PRIMARY KEY
	,ID_USUARIO INT FOREIGN KEY REFERENCES USUARIOS(ID)
	,ID_EVENTOS INT FOREIGN KEY REFERENCES EVENTOS(ID)
	,SITUACAO CHAR(1)
);