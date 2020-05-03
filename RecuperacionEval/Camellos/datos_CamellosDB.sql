--Datos CamellosDB Nzhdeh

insert into CJ_Jugadores values ('Jugador1', '111')
insert into CJ_Jugadores values ('Jugador2', '222')
insert into CJ_Jugadores values ('Jugador3', '333')



--Palabras
insert into CJ_Palabras values('Camellos', len('Camellos')/3)
insert into CJ_Palabras values('Picapiedras', len('Picapiedras')/3)
insert into CJ_Palabras values('May�scula', len('May�scula')/3)
insert into CJ_Palabras values('Ordenador', len('Ordenador')/3)
insert into CJ_Palabras values('Esternocleidomastoideo', len('Esternocleidomastoideo')/3)
---
insert into CJ_Palabras values('Otorrinolaring�logo', len('Otorrinolaring�logo')/3)
insert into CJ_Palabras values('Traumat�logo', len('Traumat�logo')/3)
insert into CJ_Palabras values('Ornitorrinco', len('Ornitorrinco')/3)
insert into CJ_Palabras values('Espiritualidad', len('Espiritualidad')/3)
insert into CJ_Palabras values('Infraestructura', len('Infraestructura')/3)
---
insert into CJ_Palabras values('Taxidermista', len('Taxidermista')/3)

--Frases
insert into CJ_Palabras values('El mundo es un pa�uelo', len('El mundo es un pa�uelo')/3)
insert into CJ_Palabras values('Tres tristes tigres tragaban trigo en un trigal', len('Tres tristes tigres tragaban trigo en un trigal')/3)
insert into CJ_Palabras values('No hay mal que por bien no venga', len('No hay mal que por bien no venga')/3)
insert into CJ_Palabras values('M�s sabe el diablo por viejo, que por diablo', len('M�s sabe el diablo por viejo, que por diablo')/3)

--Estas no las llegu� a insertar
--insert into CJ_Palabras values('El que calla otorga', len('El que calla otorga')/3)
--insert into CJ_Palabras values('El que r�e el �ltimo, r�e mejor', len('El que r�e el �ltimo, r�e mejor')/3)

--2
insert into CJ_Pruebas values (5, cast(dateadd(s, 18, '00:00:00') AS TIME(0)))
--3
insert into CJ_Pruebas values (10, cast(dateadd(s, 41, '00:00:00') AS TIME(0)))
--4
insert into CJ_Pruebas values (15, cast(dateadd(s, 91, '00:00:00') AS TIME(0)))

--Prueba 2
insert into CJ_PruebasPalabras values (1,2)
insert into CJ_PruebasPalabras values (2,2)
insert into CJ_PruebasPalabras values (3,2)
insert into CJ_PruebasPalabras values (4,2)
insert into CJ_PruebasPalabras values (5,2)
--Prueba 3
insert into CJ_PruebasPalabras values (1,3)
insert into CJ_PruebasPalabras values (2,3)
insert into CJ_PruebasPalabras values (3,3)
insert into CJ_PruebasPalabras values (4,3)
insert into CJ_PruebasPalabras values (5,3)

insert into CJ_PruebasPalabras values (6,3)
insert into CJ_PruebasPalabras values (7,3)
insert into CJ_PruebasPalabras values (8,3)
insert into CJ_PruebasPalabras values (9,3)
insert into CJ_PruebasPalabras values (10,3)

--Prueba 4
insert into CJ_PruebasPalabras values (1,4)
insert into CJ_PruebasPalabras values (2,4)
insert into CJ_PruebasPalabras values (3,4)
insert into CJ_PruebasPalabras values (4,4)
insert into CJ_PruebasPalabras values (5,4)

insert into CJ_PruebasPalabras values (6,4)
insert into CJ_PruebasPalabras values (7,4)
insert into CJ_PruebasPalabras values (8,4)
insert into CJ_PruebasPalabras values (9,4)
insert into CJ_PruebasPalabras values (10,4)

insert into CJ_PruebasPalabras values (11,4)
insert into CJ_PruebasPalabras values (12,4)
insert into CJ_PruebasPalabras values (13,4)
insert into CJ_PruebasPalabras values (14,4)
insert into CJ_PruebasPalabras values (15,4)


select * from CJ_PruebasPalabras
select * from CJ_Palabras
select * from CJ_Pruebas

select len('Traumat�logo')/3
select len('Tres tristes tigres tragaban trigo en un trigal')/3
select sum(Dificultad) from CJ_Palabras
select Dificultad from CJ_Palabras

select count(*) from CJ_Palabras

select * from CJ_Palabras where idPalabra>5

--Para elegir n�meros aleatorios para idPalabra
--select abs(checksum(newid()))%(@cantidadPalabras + 1) + 1)


--Para insertar tiempoMax en formato Time:
select cast(dateadd(s, 60, '00:00:00') AS TIME(0))



--select * from CJ_Jugadores