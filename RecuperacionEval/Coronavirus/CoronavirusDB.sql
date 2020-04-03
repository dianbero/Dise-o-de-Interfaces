--Creación Base Datos--

CREATE DATABASE Coronavirus
go
use Coronavirus
go
--Creación de Tablas--

--drop table Preguntas
CREATE TABLE Preguntas
(
	idPregunta INT IDENTITY NOT NULL,
	pregunta VARCHAR(40),
	-------------PK------------------
	CONSTRAINT PK_PREGUNTAS PRIMARY KEY(idPregunta),
)
go

--drop table Respuestas
CREATE TABLE Respuestas
(
	idRespuesta INT IDENTITY NOT NULL,
	idPregunta INT NOT NULL,
	respuesta VARCHAR(15),
	posibleCaso BIT NOT NULL,
	----------------PK---------------------
	CONSTRAINT PK_Respuestas PRIMARY KEY (idRespuesta),
	----------------FK----------------------
	CONSTRAINT FK_Respuestas_Preguntas FOREIGN KEY(idPregunta) REFERENCES Preguntas(idPregunta)
)
go

CREATE TABLE Personas
(
dniPersona VARCHAR(9) NOT NULL,
nombrePersona VARCHAR(15) NOT NULL,
apellidosPersona VARCHAR(30) NOT NULL,
telefono VARCHAR(15) NOT NULL,
direccion VARCHAR(60) NOT NULL,
diagnostico BIT NOT NULL
---------------PK--------------
CONSTRAINT PK_Persona PRIMARY KEY (dniPersona)
)
go

----Inserción de Datos-------

---Preguntas---
INSERT INTO Preguntas VALUES ('¿Tiene usted tos?')
INSERT INTO Preguntas VALUES ('¿Tiene usted fiebre?')
INSERT INTO Preguntas VALUES ('¿Tiene usted dolor de garganta?')
INSERT INTO Preguntas VALUES ('¿Dificultad para respirar?')
INSERT INTO Preguntas VALUES ('¿Escalofríos y malestar general?')
INSERT INTO Preguntas VALUES ('¿Secreción y goteo nasal?')
INSERT INTO Preguntas VALUES ('¿Tiene usted dolor de cabeza?')

---Respuestas---
INSERT INTO Respuestas (idPregunta,respuesta,posibleCaso) VALUES (1,'Si', 1)
INSERT INTO Respuestas (idPregunta,respuesta,posibleCaso) VALUES (1,'No', 0)

INSERT INTO Respuestas (idPregunta,respuesta,posibleCaso) VALUES (2,'No', 0)
INSERT INTO Respuestas (idPregunta,respuesta,posibleCaso) VALUES (2,'Entre 37º y 38º', 0)
INSERT INTO Respuestas (idPregunta,respuesta,posibleCaso) VALUES (2,'>38º', 1)

INSERT INTO Respuestas (idPregunta,respuesta,posibleCaso) VALUES (3,'Si', 1)
INSERT INTO Respuestas (idPregunta,respuesta,posibleCaso) VALUES (3,'No', 0)

INSERT INTO Respuestas (idPregunta,respuesta,posibleCaso) VALUES (4,'Si', 1)
INSERT INTO Respuestas (idPregunta,respuesta,posibleCaso) VALUES (4,'No', 0)

INSERT INTO Respuestas (idPregunta,respuesta,posibleCaso) VALUES (5,'Si', 1)
INSERT INTO Respuestas (idPregunta,respuesta,posibleCaso) VALUES (5,'No', 0)

INSERT INTO Respuestas (idPregunta,respuesta,posibleCaso) VALUES (6,'Si', 1)
INSERT INTO Respuestas (idPregunta,respuesta,posibleCaso) VALUES (6,'No', 0)

INSERT INTO Respuestas (idPregunta,respuesta,posibleCaso) VALUES (7,'Si', 1)
INSERT INTO Respuestas (idPregunta,respuesta,posibleCaso) VALUES (7,'No', 0)

----Consultas y pruebas------
SELECT * FROM Preguntas

SELECT * FROM Respuestas WHERE idPregunta=2

INSERT INTO Personas (dniPersona, nombrePersona, apellidosPersona, telefono, direccion, diagnostico) 
VALUES ('53931762M', 'Diana', 'Bejarano Rodríguez', '634700800', 'Cerro de las 40 chicas, 52', 0)
