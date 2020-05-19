CREATE DATABASE Camellos
go

use Camellos
go

------Creación de Tablas-------------
CREATE TABLE Jugadores
(
	IdJugador INT IDENTITY NOT NULL,
	Nick VARCHAR (20) NOT NULL,
	Contraseña VARCHAR (8) NOT NULL,
	---------------PK----------------------------
	CONSTRAINT PK_Jugadores PRIMARY KEY (IdJugador),
	----------------UNQ--------------------------
	CONSTRAINT UNQ_Jugadores_Nick UNIQUE(Nick)
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
	IdJugador INT NOT NULL,
	IdPrueba INT NOT NULL,
	TiempoJugador TIME NOT NULL,
	------------------------PK---------------------------------------
	CONSTRAINT PK_Progresos PRIMARY KEY (IdJugador, IdPrueba),
	--------------------------FK---------------------------------------
	CONSTRAINT FK_Progresos_Jugadores FOREIGN KEY (IdJugador) REFERENCES Jugadores(IdJugador) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT FK_Progresos_Pruebas FOREIGN KEY (IdPrueba) REFERENCES Pruebas(IdPrueba) ON DELETE CASCADE ON UPDATE CASCADE,
)
go

CREATE TABLE Palabras
(
	IdPalabra INT IDENTITY NOT NULL,
	Palabra Varchar(150) NOT NULL,   --Quizás más si incluimos frases
	Dificultad INT NOT NULL,      --Entero que evaldría a los segundos que se tarda en escribirla
	-------------------------PK-----------------------------
	CONSTRAINT PK_Palabras PRIMARY KEY (IdPalabra),
	-------------------------UNQ-----------------------------
	CONSTRAINT UNQ_Palabras_Palabra UNIQUE(Palabra)
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

------------------Procedimientos----------------------
/*
	prototipo: create procedure insertarPruebaPalabras(@cantidadPalabras int, @idPrueba int)
	comentarios: Procedimiento que inserta valores en PruebaPalabras
			     Recibe la cantidad de palabras que se quiere insertar, para usarlo como rango para gener el random del idPalabra que se insertará
				 el idPrueba, de la prueba a la que pertenercerá
	precondiciones: no hay
	entradas: @cantidadPalabras int,
			  @idPrueba int
	salidas: no hay
	entr/sal: no hay
	postcondiciones: se insertaría un nuevo registro en PruebasPalabras
*/

create 
--or alter 
procedure insertarPruebaPalabras(@cantidadPalabras int, @idPrueba int)
as
begin 
	declare @idPalabra int 

	set @idPalabra = (select abs(checksum(newid()))%(@cantidadPalabras + 1) + 1)

	insert into PruebasPalabras values (@idPrueba, @idPalabra)

end
go

--Para idPrueba = 1
exec insertarPruebaPalabras 4, 1
--Para idPrueba = 2
exec insertarPruebaPalabras 8, 2
--Para idPrueba = 3
exec insertarPruebaPalabras 12, 3
--Para idPrueba = 4
exec insertarPruebaPalabras 16, 4
--Para idPrueba = 5
exec insertarPruebaPalabras 20, 5

/*
	prototipo: create procedure insertarPruebaPalabras(@cantidadPalabras int, @idPrueba int)
	comentarios: Procedimiento que actualiza el tiempo standar de la inserción incial de una prueba al timepoMax real del 
				la suma de las dificultades de las palabras que la componen
	precondiciones: no hay
	entradas:  @idPrueba int, de la prueba a actualizar
	salidas: no hay
	entr/sal: no hay
	postcondiciones: se insertaría un nuevo registro en PruebasPalabras
*/

create 
--or alter 
procedure actualizarPruebas(@idPrueba int)
as
begin 
	declare @sumaDificultadesPalabras int 
	declare @tiempoObtenido time

	set @sumaDificultadesPalabras = (select sum(Dificultad) from Palabras pa 
										inner join PruebasPalabras pp on
											pa.IdPalabra = pp.IdPalabra
									where IdPrueba = @idPrueba)

	set @tiempoObtenido = (select cast(dateadd(s, @sumaDificultadesPalabras, '00:00:00') AS TIME(0))) --Convierte un entero en su correspondiente tiempo

	update Pruebas set tiempoMax = @tiempoObtenido where IdPrueba = @idPrueba

end
go

exec actualizarPruebas 2

--DECLARE @MS INT = 40
--select cast(dateadd(s, @MS, '00:00:00') AS TIME(0))

--select sum(Dificultad) from Palabras pa 
--	inner join PruebasPalabras pp on
--		pa.IdPalabra = pp.IdPalabra
--where IdPrueba = 2
	

select abs(checksum(newid()))%5 +1

select count(*)  from Palabras where IdPalabra = 2

select count(*)  from PruebasPalabras where IdPrueba = 2

select *  from PruebasPalabras where IdPrueba = 2

select * from Palabras pa 
	inner join PruebasPalabras pp on
		pa.IdPalabra = pp.IdPalabra
where IdPrueba = 2


	
select * from Pruebas 
select * from Palabras
select * from PruebasPalabras


------Inserción de Datos, de prueba----------
insert into Jugadores values ('Alvaro','12345678')

---prueba 1
insert into Palabras values ('Columna', 3)
insert into Palabras values ('Espalda', 3)
insert into Palabras values ('Ridículo', 3)
insert into Palabras values ('Ornitorrinco', 4)

---prueba 2
--insert into Palabras values ('Columna', 3)
insert into Palabras values ('Pentagrama', 4)
insert into Palabras values ('Estropeado', 4)
insert into Palabras values ('Furioso', 4)

--1
insert into Pruebas values (4, '00:00:13')
--2
insert into Pruebas values (8, '00:00:15')
--3
insert into Pruebas values (12, '00:00:15')
--4
insert into Pruebas values (16, '00:00:15')
--5
insert into Pruebas values (20, '00:00:15')

--1
--insert into PruebasPalabras values (1, 1)
--insert into PruebasPalabras values (1, 2)
--insert into PruebasPalabras values (1, 3)
--insert into PruebasPalabras values (1, 4)

----2
--insert into PruebasPalabras values (2,5)
--insert into PruebasPalabras values (2,6)
--insert into PruebasPalabras values (2,7)
--insert into PruebasPalabras values (2,8)

select * from Pruebas 
select * from Palabras
select * from PruebasPalabras




insert into Palabras values('Picapiedras', len('Picapiedras')/3)

select len('Picapiedras')/3
select * from Palabras where palabra = 'Picapiedras'
