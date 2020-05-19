CREATE DATABASE Hospital
go

use Hospital
go

CREATE TABLE Medicos 
(
	codigoMedico VARCHAR(10) NOT NULL,
	nombreMedico VARCHAR(15) NOT NULL,
	apellidosMedico VARCHAR(30) NOT NULL,
	----------------PK-------------------
	CONSTRAINT PK_Medico PRIMARY KEY (codigoMedico)
)
go

CREATE TABLE ControlDiario 
(
	codigoMedico VARCHAR(10) NOT NULL,
	fecha DATETIME NOT NULL,
	primeraSesion VARCHAR(150) NULL,
	segundaSesion VARCHAR(150) NULL,
	terceraSesion VARCHAR(150) NULL,
	cuartaSesion VARCHAR(150) NULL,
	----------------PK--------------------------------
	CONSTRAINT PK_ControlDiarioMedicos PRIMARY KEY (codigoMedico, fecha),
	----------------FK--------------------------------
	CONSTRAINT FK_ControlDiario_Medicos FOREIGN KEY (codigoMedico) REFERENCES Medicos(codigoMedico) ON DELETE CASCADE ON UPDATE CASCADE
)
go

INSERT INTO Medicos VALUES ('000AAA0000','Laura','Fernández González')
INSERT INTO Medicos VALUES ('123ABC1234','Alberto','Rodríguez Gómez')
INSERT INTO Medicos VALUES ('111AAA1111','Sara','Álvarez Gutiérrez')
INSERT INTO Medicos VALUES ('222AAA2222','David','Rodríguez Gómez')
INSERT INTO Medicos VALUES ('333AAA3333','María','Ortega Castro')
INSERT INTO Medicos VALUES ('444AAA4444','Mario','León Cabrera')
INSERT INTO Medicos VALUES ('555AAA4444','Mario','León Cabrera')
INSERT INTO Medicos VALUES ('666AAA6666','Pedro','León Cabrera')

--Insertar así:
INSERT INTO ControlDiario VALUES ('333AAA3333', CONVERT(varchar,GETDATE(),3),'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
--Y hacer la consulta así:
--SELECT * FROM ControlDiario WHERE fecha = CONVERT(varchar,GETDATE(),3)
SELECT * FROM ControlDiario WHERE codigoMedico = '000AAA0000' AND fecha = CONVERT(varchar,GETDATE(),3)

------------
--Insertar así:
INSERT INTO ControlDiario VALUES ('000AAA0000', CONVERT(varchar,GETDATE(),3),'Limpiar heridas',NULL,'Revisar cantidad de suero de pacientes de primera planta', NULL)
INSERT INTO ControlDiario VALUES ('000AAA0000', CONVERT(varchar,GETDATE(),3),'Limpiar heridas', NULL,'Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
INSERT INTO ControlDiario VALUES ('000AAA0000', CONVERT(varchar,GETDATE(),3),'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
INSERT INTO ControlDiario VALUES ('123ABC1234', CONVERT(varchar,GETDATE(),3),'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
INSERT INTO ControlDiario VALUES ('123ABC1234', CONVERT(varchar,GETDATE(),3),'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
INSERT INTO ControlDiario VALUES ('111AAA1111', CONVERT(varchar,GETDATE(),3),'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
INSERT INTO ControlDiario VALUES ('111AAA1111', CONVERT(varchar,GETDATE(),3),'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
INSERT INTO ControlDiario VALUES ('222AAA2222', CONVERT(varchar,GETDATE(),3),'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
INSERT INTO ControlDiario VALUES ('222AAA2222', CONVERT(varchar,GETDATE(),3),'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
INSERT INTO ControlDiario VALUES ('333AAA3333', CONVERT(varchar,GETDATE(),3),'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
INSERT INTO ControlDiario VALUES ('333AAA3333', CONVERT(varchar,GETDATE(),3),'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
INSERT INTO ControlDiario VALUES ('444AAA4444', CONVERT(varchar,GETDATE(),3),'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
INSERT INTO ControlDiario VALUES ('555AAA4444', CONVERT(varchar,GETDATE(),3),null,'Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
INSERT INTO ControlDiario VALUES ('666AAA6666', CONVERT(varchar,GETDATE(),3),null,'Visitar pacientes segunda planta',null, null)
INSERT INTO ControlDiario VALUES ('666AAA6666', '2020-04-10 00:00:00.000',null,null,null, null)

-----------



SELECT * FROM Medicos WHERE codigoMedico = '000AAA0000'

-----
--No insertar así:
INSERT INTO ControlDiario VALUES ('000AAA0000', CURRENT_TIMESTAMP,'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
INSERT INTO ControlDiario VALUES ('000AAA0000', CURRENT_TIMESTAMP,'Limpiar heridas',NULL,'Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
INSERT INTO ControlDiario VALUES ('000AAA0000', CURRENT_TIMESTAMP,'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
INSERT INTO ControlDiario VALUES ('123ABC1234', CURRENT_TIMESTAMP,'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
INSERT INTO ControlDiario VALUES ('123ABC1234', CURRENT_TIMESTAMP,'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
INSERT INTO ControlDiario VALUES ('111AAA1111', CURRENT_TIMESTAMP,'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
INSERT INTO ControlDiario VALUES ('111AAA1111', CURRENT_TIMESTAMP,'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
INSERT INTO ControlDiario VALUES ('222AAA2222', CURRENT_TIMESTAMP,'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
INSERT INTO ControlDiario VALUES ('222AAA2222', CURRENT_TIMESTAMP,'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
INSERT INTO ControlDiario VALUES ('333AAA3333', GETDATE(),'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
INSERT INTO ControlDiario VALUES ('333AAA3333', CURRENT_TIMESTAMP,'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
INSERT INTO ControlDiario VALUES ('444AAA4444', CURRENT_TIMESTAMP,'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
------

