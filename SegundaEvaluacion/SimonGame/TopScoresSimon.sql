-----CREAR BBDD Y TABLAS----------
CREATE DATABASE JuegoSimon
Go
use JuegoSimon
go
CREATE TABLE TopScoresSimon
(idJugador INT IDENTITY CONSTRAINT PK_TopScoresSimon PRIMARY KEY,
nombreJugador VARCHAR(20) NOT NULL,
aciertos INT NOT NULL)
Go

----CONSULTAS PRUEBA---------

--INSERT INTO TopScoresSimon (nombreJugador, aciertos) VALUES ('Diana', 1)

--INSERT INTO TopScoresSimon (nombreJugador, aciertos) VALUES ('Diana', 0)

--select * from TopScoresSimon ORDER BY aciertos DESC

SELECT * FROM TopScoresSimon ORDER BY aciertos DESC