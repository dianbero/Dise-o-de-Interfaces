CREATE DATABASE JuegoParejas
Go
CREATE TABLE TopScores
(idJugador INT IDENTITY CONSTRAINT PK_TopScores PRIMARY KEY,
nombreJugador VARCHAR(20) NOT NULL,
puntuacion DATETIME NOT NULL)
Go