-----CREAR BBDD Y TABLAS----------
CREATE DATABASE JuegoParejas
Go
use JuegoParejas
go
CREATE TABLE TopScores
(idJugador INT IDENTITY CONSTRAINT PK_TopScores PRIMARY KEY,
nombreJugador VARCHAR(20) NOT NULL,
puntuacion DATETIME NOT NULL)
Go

----CONSULTAS PRUEBA---------

--INSERT INTO TopScores (nombreJugador, puntuacion) VALUES ('Diana', GETDATE())


--INSERT INTO TopScores (nombreJugador, puntuacion) VALUES ('Diana', '30-01-2020 18:40:48.640')

--select * from TopScores

