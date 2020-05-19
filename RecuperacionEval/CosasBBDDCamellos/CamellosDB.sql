CREATE DATABASE Camellos
go

use Camellos
go

------Creaci�n de Tablas-------------
CREATE TABLE Jugadores
(
	Contrase�a VARCHAR (8) NOT NULL,
	Nick VARCHAR (20) NOT NULL,
	---------------PK-------------------
	CONSTRAINT PK_Jugador PRIMARY KEY (Contrase�a, Nick)
)
go

CREATE TABLE Pruebas
(
	IdPrueba INT IDENTITY NOT NULL,
	CantidadPalabras INT NOT NULL,
	tiempoMax TIME NOT NULL,
	--------------------PK---------------------
	CONSTRAINT PK_Prueba PRIMARY KEY (IdPrueba)
)
go

CREATE TABLE Progresos
(
	Nick VARCHAR(20) NOT NULL,
	Contrase�a VARCHAR (8) NOT NULL,
	IdPrueba INT NOT NULL,
	TiempoJugador TIME NOT NULL,
	------------------------PK---------------------------------------
	CONSTRAINT PK_Progresos PRIMARY KEY (Contrase�a, Nick, IdPrueba),
	--------------------------FK---------------------------------------
	CONSTRAINT FK_Progresos_Jugadores FOREIGN KEY (Contrase�a, Nick) REFERENCES Jugadores(Contrase�a, Nick) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT FK_Progresos_Pruebas FOREIGN KEY (IdPrueba) REFERENCES Pruebas(IdPrueba) ON DELETE CASCADE ON UPDATE CASCADE,
)
go

CREATE TABLE Palabras
(
	IdPalabra INT IDENTITY NOT NULL,
	Palabra Varchar (50) NOT NULL, --Quiz�s m�s si incluimos frases
	Dificultad int NOT NULL,--Entero que evaldr�a a los segundos que se tarda en escribirla
	-------------------------PK-----------------------------
	CONSTRAINT PK_Palabras PRIMARY KEY (IdPalabra),
)
go

CREATE TABLE PruebasPalabras
(
	IdPrueba INT NOT NULL,
	IdPalabra INT NOT NULL,
	-----------------------------PK----------------------------------
	CONSTRAINT PK_PruebasPalabras PRIMARY KEY (IdPrueba, IdPalabra),
	-----------------------------FK---------------------------------------
	CONSTRAINT FK_PruebasPalabras_Pruebas FOREIGN KEY(IdPrueba) REFERENCES Pruebas(IdPrueba) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT FK_PruebasPalabras_Palabras FOREIGN KEY(IdPalabra) REFERENCES Palabras(IdPalabra) ON DELETE CASCADE ON UPDATE CASCADE
)
go

------Inserci�n de Datos----------
--INSERT INTO Jugadores VALUES ()

---------------Procedimientos, funciones y triggers-----------------

/*
	prototipo: create procedure pedidoEnReparto @CodigoPedido int
	comentarios: este procedimientos sirve para cambiar el estado de un pedido a 'En reparto'
	precondiciones: codigo del pedido correcto
	entradas: entero codigo del pedido
	salidas: no hay
	entr/sal: no hay
	postcondiciones: el pedido cuyo codigo se pasa por par�metro se le actualiza el estado a 'En reparto'
*/

/*Funci�n que establece la dificultad de la palabra en funnci�n de la longitud de la palabra, 
recibe como par�metro la palabra que se introduce
devuelve el entero que representa la dificultad*/
create function establecerDificultadPalabra(@palabra int)
returns int 
as
begin
declare @dificultadPalabra int,
		@longitudPalabra int

		set @longitudPalabra = len(@palabra) 
	
	if(@longitudPalabra>10 and @longitudPalabra<=15)
		set @dificultadPalabra = @longitudPalabra
	else if(@longitudPalabra>10 and @longitudPalabra<=15)	
		set @dificultadPalabra = @longitudPalabra
	

return(@dificultadPalabra)
end
go





/*Procedimiento que establece el tiempo de un prueba sumando el total de las 
dificultades(tiempo en segundos) de las palabras de esa prueba*/