create database pexinxa;

use pexinxa;

create table tb_Pessoa (
	Pessoa_Id int identity primary key,
	Nome varchar(20),
	Sobrenome varchar (40),
	CPF char(11),
	CNPJ CHAR(14)

);



INSERT INTO tb_Pessoa(Nome, Sobrenome, CPF, CNPJ)
	VALUES
	('administrador', 'silva', '43255634801', '89765547209871');
	
	INSERT INTO tb_Usuario(Pessoa_Id, Email, Senha, Nivel)
	VALUES
	(1, 'admin@gmail.com', '12345678', 0);

create table tb_Usuario(
	Usuario_Id int identity primary key,
	Pessoa_Id int not null,
	Email varchar(50) not null,
	Senha varchar(100) not null,
	Nivel int not null,
	constraint fk_pessoa_id foreign key (Pessoa_Id) references tb_Pessoa(Pessoa_Id)
);


SELECT P.Pessoa_Id, P.Nome, P.Sobrenome, P.CPF, P.CNPJ, U.Email, U.Senha, U.Nivel FROM tb_Pessoa AS P
LEFT JOIN tb_Usuario AS U
ON(U.Pessoa_Id = P.Pessoa_Id)
where P.Pessoa_Id = 1;


DECLARE @idPessoa TABLE(id int);
INSERT INTO tb_Pessoa(Nome, Sobrenome, CPF, CNPJ)
OUTPUT inserted.Pessoa_Id INTO @idPessoa
values ('Ryan', 'Carvalho', '66666655514', '14526378091825');
DECLARE @newidPessoa INT;
SELECT @newidPessoa = id FROM @idPessoa
INSERT INTO tb_Usuario(Pessoa_Id, Email, Senha, Nivel)
values(@newidPessoa, 'ryan@gmail.com', '12345678', 1);

DECLARE @idPessoa TABLE(id int);
INSERT INTO tb_Pessoa(Nome, Sobrenome, CPF, CNPJ)
OUTPUT inserted.Pessoa_Id INTO @idPessoa
values ('Pedro', 'Carvalho', '66656655514', '14526378091822');
DECLARE @newidPessoa INT;
SELECT @newidPessoa = id FROM @idPessoa
INSERT INTO tb_Usuario(Pessoa_Id, Email, Senha, Nivel)
values(@newidPessoa, 'pedro@gmail.com', '12345678', 1);


DECLARE @idPessoa TABLE(id int);
INSERT INTO tb_Pessoa(Nome, Sobrenome, CPF, CNPJ)
OUTPUT inserted.Pessoa_Id INTO @idPessoa
values ('Pedrin', 'Carval', '66656655514', '14526378091822');
DECLARE @newidPessoa INT;
SELECT @newidPessoa = id FROM @idPessoa
INSERT INTO tb_Usuario(Pessoa_Id, Email, Senha, Nivel)
values(@newidPessoa, 'pedro@gmail.com', '12345678999999999999999999999999999999999999999999000000000000000aaaad', 1);

select * from tb_Pessoa
select * from tb_Usuario


UPDATE tb_Usuario SET Senha = 'ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f' where Pessoa_Id = 1;




