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

INSERT INTO Medicos VALUES ('000AAA0000','Laura','Fern�ndez Gonz�lez')
INSERT INTO Medicos VALUES ('123ABC1234','Alberto','Rodr�guez G�mez')
INSERT INTO Medicos VALUES ('111AAA1111','Sara','�lvarez Guti�rrez')
INSERT INTO Medicos VALUES ('222AAA2222','David','Rodr�guez G�mez')
INSERT INTO Medicos VALUES ('333AAA3333','Mar�a','Ortega Castro')
INSERT INTO Medicos VALUES ('444AAA4444','Mario','Le�n Cabrera')
INSERT INTO Medicos VALUES ('555AAA4444','Mario','Le�n Cabrera')
INSERT INTO Medicos VALUES ('666AAA6666','Pedro','Le�n Cabrera')

--Insertar as�:
INSERT INTO ControlDiario VALUES ('333AAA3333', CONVERT(varchar,GETDATE(),3),'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
--Y hacer la consulta as�:
--SELECT * FROM ControlDiario WHERE fecha = CONVERT(varchar,GETDATE(),3)
SELECT * FROM ControlDiario WHERE codigoMedico = '000AAA0000' AND fecha = CONVERT(varchar,GETDATE(),3)

------------
--Insertar as�:
INSERT INTO ControlDiario VALUES ('000AAA0000', CONVERT(varchar,GETDATE(),3),'Limpiar heridas',NULL,'Revisar cantidad de suero de pacientes de primera planta', NULL)
INSERT INTO ControlDiario VALUES ('000AAA0000', CONVERT(datetime,'2020-03-14 14:20:37.963',101),'Limpiar heridas', NULL,'Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
INSERT INTO ControlDiario VALUES ('000AAA0000', CONVERT(datetime,'2020-04-14 14:20:37.963',101),'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')

INSERT INTO ControlDiario VALUES ('123ABC1234', CONVERT(varchar,GETDATE(),3),'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
INSERT INTO ControlDiario VALUES ('123ABC1234', CONVERT(datetime,'2020-03-14 14:20:37.963',101),'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')

INSERT INTO ControlDiario VALUES ('111AAA1111', CONVERT(varchar,GETDATE(),3),'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
INSERT INTO ControlDiario VALUES ('111AAA1111', CONVERT(datetime,'2020-03-14 14:20:37.963',101),'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')

INSERT INTO ControlDiario VALUES ('222AAA2222', CONVERT(varchar,GETDATE(),3),'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
INSERT INTO ControlDiario VALUES ('222AAA2222', CONVERT(datetime,'2020-03-14 14:20:37.963',101),'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')

INSERT INTO ControlDiario VALUES ('333AAA3333', CONVERT(varchar,GETDATE(),3),'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
INSERT INTO ControlDiario VALUES ('333AAA3333', CONVERT(datetime,'2020-03-14 14:20:37.963',101),'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')

INSERT INTO ControlDiario VALUES ('444AAA4444', CONVERT(varchar,GETDATE(),3),'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
INSERT INTO ControlDiario VALUES ('444AAA4444', CONVERT(datetime,GETDATE(),101),'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')

INSERT INTO ControlDiario VALUES ('555AAA4444', CONVERT(datetime,GETDATE(),101),'con 101','Funciona','para insertar fecha actual', 'Visitar pacientes tercera planta')
--INSERT INTO ControlDiario VALUES ('555AAA4444', CONVERT(datetime,GETDATE(),3),'con 3','Funciona','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
INSERT INTO ControlDiario VALUES ('555AAA4444', CONVERT(varchar,GETDATE(),3),'con 3','Funciona','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')

INSERT INTO ControlDiario VALUES ('666AAA6666', CONVERT(varchar,GETDATE(),3),null,null,null, null)
INSERT INTO ControlDiario VALUES ('666AAA6666', CONVERT(datetime,GETDATE(),3),null,'Visitar pacientes segunda planta',null, null)
INSERT INTO ControlDiario VALUES ('666AAA6666', CONVERT(datetime,GETDATE(),101),null,'Visitar pacientes segunda planta',null, null)

INSERT INTO ControlDiario VALUES ('666AAA6666', GETDATE(),null,'Visitar pacientes segunda planta',null, null)



---------------------
SELECT * FROM ControlDiario WHERE codigoMedico = '666AAA6666' order by fecha desc
select * from ControlDiario where fecha = CONVERT (varchar, GETDATE(), 3) and codigoMedico = '666AAA6666' --el bueno

select * from ControlDiario where fecha = FORMAT(GETDATE(), 'yyyy-MM-dd') and codigoMedico = '666AAA6666' --el bueno

select * from ControlDiario where fecha = FORMAT(GETDATE(), 'yyyy-MM-dd') and codigoMedico = '666AAA6666' --el bueno


select * from ControlDiario where codigoMedico = '666AAA6666' and fecha = (select FORMAT(GETDATE(), 'dd/MM/yyyy')) --funciona

select * from ControlDiario where codigoMedico = '666AAA6666' and fecha = FORMAT(GETDATE(), 'dd/MM/yyyy') --funciona

select * from ControlDiario where codigoMedico = '666AAA6666' and fecha = FORMAT(GETDATE(), 'dd-MM-yyyy') --funciona

select * from ControlDiario where codigoMedico = '666AAA6666' and fecha = FORMAT(GETDATE(), 'yyyy-dd-MM') --funciona


select * from ControlDiario where codigoMedico = '666AAA6666' and fecha = DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) --funciona

SELECT CONVERT(Date, GETDATE())
SELECT DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE()))  -- devuelve 2016-07-21 00: 00: 00.000
SELECT CAST(GETDATE() AS DATE)
SELECT CONVERT(CHAR(10),GETDATE(),111)
SELECT FORMAT(GETDATE(), 'yyyy-MM-dd')

select DATEADD(dd,0, DATEDIFF(dd, 0, GETDATE()))
select GETDATE()

select SYSDATETIME()
select GETDATE()
select GETDATE()





select * from ControlDiario where fecha = CONVERT (varchar, GETDATE(), 3) and codigoMedico = '555AAA4444' --el bueno

select * from ControlDiario where fecha = CONVERT (datetime, GETDATE(), 3) and codigoMedico = '555AAA4444' 

select * from ControlDiario where fecha = CONVERT (datetime, GETDATE(), 101) and codigoMedico = '555AAA4444'


-----------
--quiero esta    2020-04-19 17:33:01.147

--select * from ControlDiario where fecha = '2020-04-16 14:20:47.963'
--select * from ControlDiario where fecha = CONVERT(varchar,GETDATE(),3)
--select * from ControlDiario where fecha = CONVERT(datetime,'2020-04-16 14:20:47.963',13)

--select * from ControlDiario where fecha = CONVERT(varchar,'2020-04-16 14:20:47.963',3)
--select * from ControlDiario where fecha = CONVERT (datetime, GETDATE(), 103)


--select * from ControlDiario where fecha =  CONVERT (datetime, '2020-03-14 14:20:37.963', 101)

--select * from ControlDiario where fecha =  CONVERT (varchar, GETDATE(), 11)


--SELECT * FROM Medicos WHERE codigoMedico = '000AAA0000'

--SELECT * FROM ControlDiario WHERE codigoMedico = '555AAA4444' order by fecha desc
--SELECT * FROM ControlDiario WHERE  fecha = '2020-04-19 17:11:50.523'
--SELECT * FROM ControlDiario WHERE  fecha = CONVERT(varchar,GETDATE(),2) and codigoMedico = '555AAA4444'


--INSERT INTO ControlDiario VALUES ('555AAA4444', CONVERT(varchar,GETDATE(),8),null,'Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')






-----
--No insertar as�:
--INSERT INTO ControlDiario VALUES ('000AAA0000', CURRENT_TIMESTAMP,'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
--INSERT INTO ControlDiario VALUES ('000AAA0000', CURRENT_TIMESTAMP,'Limpiar heridas',NULL,'Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
--INSERT INTO ControlDiario VALUES ('000AAA0000', CURRENT_TIMESTAMP,'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
--INSERT INTO ControlDiario VALUES ('123ABC1234', CURRENT_TIMESTAMP,'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
--INSERT INTO ControlDiario VALUES ('123ABC1234', CURRENT_TIMESTAMP,'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
--INSERT INTO ControlDiario VALUES ('111AAA1111', CURRENT_TIMESTAMP,'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
--INSERT INTO ControlDiario VALUES ('111AAA1111', CURRENT_TIMESTAMP,'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
--INSERT INTO ControlDiario VALUES ('222AAA2222', CURRENT_TIMESTAMP,'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
--INSERT INTO ControlDiario VALUES ('222AAA2222', CURRENT_TIMESTAMP,'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
--INSERT INTO ControlDiario VALUES ('333AAA3333', GETDATE(),'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
--INSERT INTO ControlDiario VALUES ('333AAA3333', CURRENT_TIMESTAMP,'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
--INSERT INTO ControlDiario VALUES ('444AAA4444', CURRENT_TIMESTAMP,'Limpiar heridas','Visitar pacientes segunda planta','Revisar cantidad de suero de pacientes de primera planta', 'Visitar pacientes tercera planta')
------

