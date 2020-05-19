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

------------------Triggers----------------------
/*
	prototipo: create trigger actualizarFechaRecepcionDelPedido on ERP_Pedidos
	comentarios: procedimiento que sirve para insertar la duración de una prueba en función del total de las dificultades 
				 de las palabras que contiene dicha prueba.

				 - Si no hay registros 
	precondiciones: no hay
	entradas: no hay
	salidas: no hay
	entr/sal: no hay
	postcondiciones: se actualizaria la fecha de un pedido si su estado es Recibido si no, no pasaria nada
*/

--create 
----or alter 
--procedure insertarPruebaPalabras(@cantidadPalabras int, @idPrueba int)
--as
--begin 
--	declare @idPalabra int 
--	declare @contador int
--	declare @totalPalabras int
--	declare @cantidadRegistrosPalabra int

--	set @contador = 0
--	--set @totalPalabras = (select count(*) from Palabras)
	

--	--while (@contador < @cantidadPalabras)

--	set @idPalabra = (select abs(checksum(newid()))%@cantidadPalabras + 1)
--	--set @cantidadRegistrosPalabra = (select count(*) from Palabras where IdPalabra = @idPalabra)
--	--set @idPalabra = 2
--	--set @cantidadRegistrosPalabra = 1

--	--begin 
--	--	if @cantidadRegistrosPalabra = 1
--	--	begin
--			insert into PruebasPalabras values (@idPrueba, @idPalabra)

--			--set @contador = @contador + 1
--	--	end
--	--end
--end
--go

--pasado a bonito

/*
Procedimiento que inserta valores en PruebaPalabras
Recibe la cantidad de palabras que se quiere insertar, para usarlo como rango para gener el random del idPalabra que se insertará
el idPrueba, de la prueba a la que pertenercerá*/

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
exec insertarPruebaPalabras 6, 2
--Para idPrueba = 3
exec insertarPruebaPalabras 8, 3
--Para idPrueba = 4
exec insertarPruebaPalabras 4, 4
--Para idPrueba = 5
exec insertarPruebaPalabras 4, 5
	

select abs(checksum(newid()))%5 +1

select count(*)  from Palabras where IdPalabra = 2

select count(*)  from PruebasPalabras where IdPrueba = 3

select *  from PruebasPalabras where IdPrueba = 3


	
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
insert into Pruebas values (4, '00:00:15')

--1
insert into PruebasPalabras values (1, 1)
insert into PruebasPalabras values (1, 2)
insert into PruebasPalabras values (1, 3)
insert into PruebasPalabras values (1, 4)

--2
insert into PruebasPalabras values (2,5)
insert into PruebasPalabras values (2,6)
insert into PruebasPalabras values (2,7)
insert into PruebasPalabras values (2,8)

select * from Pruebas 
select * from Palabras
select * from PruebasPalabras


----Consultas de prueba
select pru.IdPrueba, CantidadPalabras, tiempoMax from Pruebas pru
inner join PruebasPalabras pp
	on pru.IdPrueba = pp.IdPrueba
inner join Palabras pa
	on pp.IdPalabra = pa.IdPalabra
where pa.IdPalabra = 1

select * from Pruebas pru
inner join PruebasPalabras pp
	on pru.IdPrueba = pp.IdPrueba
inner join Palabras pa
	on pp.IdPalabra = pa.IdPalabra

select pru.IdPrueba, CantidadPalabras, tiempoMax from Pruebas pru
inner join PruebasPalabras pp
	on pru.IdPrueba = pp.IdPrueba
inner join Palabras pa
	on pp.IdPalabra = pa.IdPalabra
where pa.Palabra = 'Columna'


----
/*Consulta que escoge un regitro aleatorio de la tabla Pruebas que contenga la palabra especificada*/
select top 1 pru.IdPrueba, CantidadPalabras, tiempoMax from Pruebas pru
inner join PruebasPalabras pp
	on pru.IdPrueba = pp.IdPrueba
inner join Palabras pa
	on pp.IdPalabra = pa.IdPalabra
where pa.Palabra = 'Columna'
order by NEWID()

select top 5 Palabra, Dificultad 
from Palabras
order by NEWID()



select sum(Dificultad) , count(*)
from Palabras
order by NEWID()


select  sum(Dificultad) (select top 5 Dificultad
from Palabras
order by NEWID())


select count(*) from Palabras

select count(*) from Palabras where idPalabra = 9