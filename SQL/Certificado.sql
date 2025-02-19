
-----------------

/* --Caso necessario 
DROP SYMMETRIC KEY skFrench
DROP CERTIFICATE certFrench
DROP CERTIFICATE certFrench
ALTER MASTER KEY FORCE REGENERATE WITH ENCRYPTION BY PASSWORD = 'Frenchsenha@2018';
GO

--Para voltar backup, tem que voltar a masterkey

OPEN MASTER KEY DECRYPTION BY PASSWORD = 'humberfrench@1973'; --senha da criacao
go

BACKUP MASTER KEY TO FILE = 'd:\exportmasterkey' --esse já é o nome do arquivo
    ENCRYPTION BY PASSWORD = 'password@987';
go

-->>>>>>>>>>>>>>>>>>>>>>>>>>>>  BACKUP DA MASTER KEY
--OPEN MASTER KEY DECRYPTION BY PASSWORD = 'poe a senha de criação aqui';

--BACKUP MASTER KEY TO FILE = 'E:\exportmasterkey' 
--    ENCRYPTION BY PASSWORD = 'poe uma senha para o backup aqui';

--BACKUP CERTIFICATE CertRendCard TO FILE = 'E:\backupCertRendCard';

--GO


-->>>>>>>>>>>>>>>>>>>>rESTORE DO BANCO DE DADOS


--1 - DROPAR O BANCO DE DADOS NO SERVIDOR DE DESTINO
--2 - RESTAURAR O BACKUP DO DATABASE SEM A OPTION "REPLACE"
--3 - Abrir Masterkey com a chava usada na criação
--4 - RESTAURAR A MASTER KEY
--           ALTER MASTER KEY REGENERATE WITH ENCRYPTION BY PASSWORD = 'Frenchsenha@2018';
--           CLOSE MASTER KEY

*/

--Exemplo de uso
/*
Exec OpenKeys

select dbo.Encrypt('Teste') 'Valor Criptografado'

select dbo.Decrypt(dbo.Encrypt('Teste')) 'Valor Descriptografado'

SELECT TOP 1000 [UsuarioId]
      [Login]
      ,dbo.Decrypt([Senha])
  FROM [dbCorpLoginUnico].[dbo].[Usuario]

Exec CloseKeys

*/


-----------------
--DROP MASTER KEY 
--go

USE frenchDev
CREATE MASTER KEY ENCRYPTION BY PASSWORD = 'humberfrench@1973'
go

CREATE CERTIFICATE [certFrench]
	/* ENCRYPTION BY PASSWORD = */
	WITH SUBJECT = 'Certificado de Criptografia French',
	EXPIRY_DATE = '01/01/2050'
go

CREATE SYMMETRIC KEY [skFrench]
WITH 
	ALGORITHM = AES_256
ENCRYPTION BY  
CERTIFICATE [certFrench]
go

DROP FUNCTION Decrypt
go
CREATE FUNCTION Decrypt
(
    @ValueToDecrypt varbinary(264)
)
RETURNS varchar(200)
AS
BEGIN
    DECLARE @Result varchar(200)

    SET @Result = CONVERT(VARCHAR(200),DecryptByKey(@ValueToDecrypt))

    -- Return the result of the function
    RETURN @Result
END
go

DROP FUNCTION Encrypt
go
CREATE FUNCTION Encrypt
(
    @ValueToEncrypt varchar(200)
)
RETURNS varbinary(264)
AS
BEGIN
    DECLARE @Result varbinary(264)

    SET @Result = EncryptByKey(Key_GUID('skFrench'), @ValueToEncrypt)

    RETURN @Result
END
go



Exec OpenKeys

UPDATE Usuario Set Senha = dbo.Encrypt('goober00')

Exec	CloseKeys

Exec OpenKeys

SELECT UsuarioId, Login, senha,  dbo.Decrypt(Senha) FROM Usuario 

Exec	CloseKeys

Exec OpenKeys

SELECT  dbo.Encrypt('goober00')

Exec	CloseKeys
