--=====================================================================================
--=== INSERT BASE RECORDS =============================================================
--=====================================================================================

IF NOT EXISTS (SELECT Username FROM Employees WHERE Username='admin')
INSERT INTO Employees VALUES ('admin','Administrador','','GaKFQUS2Oo92F6byJQGbEg==','',1)

INSERT INTO Aplications VALUES ('MDA','M�dulo de Descri��o Arquiv�stica','2.1.2')
INSERT INTO Aplications VALUES ('MGOD','M�dulo de Gest�o de Objectos Digitais','2.1.2')
INSERT INTO Aplications VALUES ('MPOD','M�dulo de Publica��o de Objectos Digitais','2.1.2')
INSERT INTO Aplications VALUES ('MGUP','M�dulo de Gest�o de Utilizadores','2')

-- MODULO DE DESCRICAO ARQUIVISTICA
INSERT INTO Functions VALUES ('0',NULL,'Login','MDA')
INSERT INTO Functions VALUES ('1',NULL,'AppendNode','MDA')
INSERT INTO Functions VALUES ('3',NULL,'RemoveNode','MDA')
INSERT INTO Functions VALUES ('4',NULL,'MoveNode','MDA')
INSERT INTO Functions VALUES ('5',NULL,'OpenFonds','MDA')
INSERT INTO Functions VALUES ('6',NULL,'ImportFonds','MDA')
INSERT INTO Functions VALUES ('7',NULL,'RemoveFonds','MDA')
INSERT INTO Functions VALUES ('8',NULL,'EditNode','MDA')
INSERT INTO Functions VALUES ('9',NULL,'CloseAplication','MDA')

-- MODULO DE GESTAO DE UTILIZADORES
INSERT INTO Functions VALUES ('gpu-1',NULL,'Administra��o','MGUP')
INSERT INTO Functions VALUES ('gpu-1.1','gpu-1','Gest�o funcion�rios','MGUP')
INSERT INTO Functions VALUES ('gpu-1.1.1','gpu-1.1','Listar','MGUP')
INSERT INTO Functions VALUES ('gpu-1.1.2','gpu-1.1','Novo','MGUP')
INSERT INTO Functions VALUES ('gpu-1.2','gpu-1','Gest�o perfis','MGUP')
INSERT INTO Functions VALUES ('gpu-1.2.1','gpu-1.2','Funcionalidades','MGUP')
INSERT INTO Functions VALUES ('gpu-1.2.2','gpu-1.2','Novo','MGUP')
INSERT INTO Functions VALUES ('gpu-2',NULL,'Administra��o Sistema','MGUP')
INSERT INTO Functions VALUES ('gpu-2.1','gpu-2','Gest�o aplica��es','MGUP')
INSERT INTO Functions VALUES ('gpu-2.1.1','gpu-2.1','Opera��es','MGUP')
INSERT INTO Functions VALUES ('gpu-2.1.2','gpu-2.1','Aplica��es','MGUP')
INSERT INTO Functions VALUES ('gpu-3',NULL,'Estat�sticas','MGUP')
INSERT INTO Functions VALUES ('gpu-3.1','gpu-3','Indicadores da BD','MGUP')
INSERT INTO Functions VALUES ('gpu-3.1.1','gpu-3.1','Indicadores da base dados','MGUP')
INSERT INTO Functions VALUES ('gpu-3.1.2','gpu-3.1','Relat�rios por n�veis de descri��o','MGUP')
INSERT INTO Functions VALUES ('gpu-3.2','gpu-3','Indicadores de produ��o','MGUP')
INSERT INTO Functions VALUES ('gpu-3.2.1','gpu-3.2','Produ��o do arquivo','MGUP')
INSERT INTO Functions VALUES ('gpu-3.2.2','gpu-3.2','Produ��o por funcion�rio','MGUP')
INSERT INTO Functions VALUES ('gpu-3.3','gpu-3','Indicadores de sistema','MGUP')
INSERT INTO Functions VALUES ('gpu-4',NULL,'Estat�sticas GOD','MGUP')
INSERT INTO Functions VALUES ('gpu-4.1','gpu-4','Dados globais imediatos','MGUP')
INSERT INTO Functions VALUES ('gpu-4.2','gpu-4','Produ��o global do arquivo','MGUP')


INSERT INTO Profiles values ('Administrador','MDA')
INSERT INTO Profiles values ('Administrador','MGOD')
INSERT INTO Profiles values ('Administrador','MPOD')
INSERT INTO Profiles values ('Administrador','MGUP')

DECLARE @ProfileID int
SELECT @ProfileID=ProfileID FROM Profiles WHERE Profile='Administrador' AND AplicationCode='MDA'
INSERT INTO AplicationEmployee VALUES('MDA','admin',@ProfileID)

INSERT INTO ProfileFunction VALUES (@ProfileID,0)
INSERT INTO ProfileFunction VALUES (@ProfileID,1)
INSERT INTO ProfileFunction VALUES (@ProfileID,3)
INSERT INTO ProfileFunction VALUES (@ProfileID,4)
INSERT INTO ProfileFunction VALUES (@ProfileID,5)
INSERT INTO ProfileFunction VALUES (@ProfileID,6)
INSERT INTO ProfileFunction VALUES (@ProfileID,7)
INSERT INTO ProfileFunction VALUES (@ProfileID,8)
INSERT INTO ProfileFunction VALUES (@ProfileID,9)

SELECT @ProfileID=ProfileID FROM Profiles WHERE Profile='Administrador' AND AplicationCode='MGOD'
INSERT INTO AplicationEmployee VALUES('MGOD','admin',@ProfileID)

SELECT @ProfileID=ProfileID FROM Profiles WHERE Profile='Administrador' AND AplicationCode='MPOD'
INSERT INTO aplicationEmployee values('MPOD','admin',@ProfileID)

SELECT @ProfileID=ProfileID FROM Profiles WHERE Profile='Administrador' AND AplicationCode='MGUP'
INSERT INTO aplicationEmployee values('MGUP','admin',@ProfileID)


INSERT INTO ProfileFunction VALUES (@ProfileID,'gpu-1')
INSERT INTO ProfileFunction VALUES (@ProfileID,'gpu-1.1')
INSERT INTO ProfileFunction VALUES (@ProfileID,'gpu-1.1.1')
INSERT INTO ProfileFunction VALUES (@ProfileID,'gpu-1.1.2')
INSERT INTO ProfileFunction VALUES (@ProfileID,'gpu-1.2')
INSERT INTO ProfileFunction VALUES (@ProfileID,'gpu-1.2.1')
INSERT INTO ProfileFunction VALUES (@ProfileID,'gpu-1.2.2')
INSERT INTO ProfileFunction VALUES (@ProfileID,'gpu-2')
INSERT INTO ProfileFunction VALUES (@ProfileID,'gpu-2.1')
INSERT INTO ProfileFunction VALUES (@ProfileID,'gpu-2.1.1')
INSERT INTO ProfileFunction VALUES (@ProfileID,'gpu-2.1.2')
INSERT INTO ProfileFunction VALUES (@ProfileID,'gpu-3')
INSERT INTO ProfileFunction VALUES (@ProfileID,'gpu-3.1')
INSERT INTO ProfileFunction VALUES (@ProfileID,'gpu-3.1.1')
INSERT INTO ProfileFunction VALUES (@ProfileID,'gpu-3.1.2')
INSERT INTO ProfileFunction VALUES (@ProfileID,'gpu-3.2')
INSERT INTO ProfileFunction VALUES (@ProfileID,'gpu-3.2.1')
INSERT INTO ProfileFunction VALUES (@ProfileID,'gpu-3.2.2')
INSERT INTO ProfileFunction VALUES (@ProfileID,'gpu-3.3')
INSERT INTO ProfileFunction VALUES (@ProfileID,'gpu-4')
INSERT INTO ProfileFunction VALUES (@ProfileID,'gpu-4.1')
INSERT INTO ProfileFunction VALUES (@ProfileID,'gpu-4.2')

SET IDENTITY_INSERT DigitalObjects ON
INSERT INTO DigitalObjects
(DigitalObjectID, ProjectID, Name, CaptureEntityCorporate, ResponsabilityEntity, Active)
VALUES (-1, NULL, '', '', '', 0)
SET IDENTITY_INSERT DigitalObjects OFF

SET IDENTITY_INSERT DOFiles ON
INSERT INTO DOFiles
(FileID, DigitalObjectID, Name)
VALUES (-1, -1, '')
SET IDENTITY_INSERT DOFiles OFF

INSERT INTO RevisionInterval
VALUES (5)
