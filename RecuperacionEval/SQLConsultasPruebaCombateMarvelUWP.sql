select * from SH_Luchadores
select * from SH_Combates
select * from SH_LuchadoresCombates

--insert into SH_Luchadores (nombreLuchador, fotoLuchador) values ('IronMan', null)
--insert into SH_Luchadores (nombreLuchador, fotoLuchador) values ('Thor Gordo', null)
--insert into SH_Luchadores (nombreLuchador, fotoLuchador) values ('Thor En Condiciones', null)
--insert into SH_Luchadores (nombreLuchador, fotoLuchador) values ('Spiderman', null)
--insert into SH_Luchadores (nombreLuchador, fotoLuchador) values ('Viuda negra', null)
--insert into SH_Luchadores (nombreLuchador, fotoLuchador) values ('AntMan', null)

--INSERT INTO SH_Combates VALUES (getdate())


--INSERT INTO SH_LuchadoresCombates (idCombate, idLuchador, puntuacionLuchador) VALUES (11, 2, 5)
--insert into SH_LuchadoresCombates (idCombate, idLuchador, puntuacionLuchador) values (11, 4, 2)

--UPDATE SH_LuchadoresCombates SET puntuacionLuchador = puntuacionLuchador + 5 WHERE idLuchador =  2 AND idCombate = 8


--select * from SH_Combates where fechaCombate = '2020-06-07' and idLuchador = (select idLuchador from SH_Luchadores where idLuchador = 2)

select  c.idCombate, c.fechaCombate from SH_Combates as c 
inner join SH_LuchadoresCombates as lc on c.idCombate = lc.idCombate
where c.fechaCombate = '2020-06-07' and lc.idLuchador = 2 or lc.idLuchador = 5


--Evita registros duplicados
SELECT DISTINCT  c.idCombate, c.fechaCombate, lc.idLuchador FROM SH_Combates AS c 
INNER JOIN SH_LuchadoresCombates AS lc ON c.idCombate = lc.idCombate
WHERE c.fechaCombate = '2020-06-08' AND lc.idLuchador IN (2,5)


--Todos los registros incluidos duplicados
select  c.idCombate, c.fechaCombate, lc.idLuchador from SH_Combates as c 
inner join SH_LuchadoresCombates as lc on c.idCombate = lc.idCombate
where c.fechaCombate = '2020-06-07' and lc.idLuchador in (2,4)


select distinct c.idCombate, c.fechaCombate, lc.idLuchador from SH_Combates as c 
inner join SH_LuchadoresCombates as lc on c.idCombate = lc.idCombate
where c.fechaCombate = '2020-06-08' and  lc.idLuchador =2


select distinct c.idCombate, c.fechaCombate, lc.idLuchador from SH_Combates as c 
inner join SH_LuchadoresCombates as lc on c.idCombate = lc.idCombate
where c.fechaCombate = getdate() and  lc.idLuchador =2

select * from SH_LuchadoresCombates where idLuchador in (select idLuchador from SH_LuchadoresCombates where idCombate = 8)


--Este parece que sí es el bueno

--Evita registros duplicados
select distinct c.idCombate, c.fechaCombate from SH_Combates as c 
inner join SH_LuchadoresCombates as lc on c.idCombate = lc.idCombate
where c.fechaCombate = '2020-06-08' and lc.idLuchador in (select idLuchador from SH_LuchadoresCombates where idCombate = 8)





																				
select  c.idCombate, c.fechaCombate, lc.idLuchador from SH_Combates as c 
inner join SH_LuchadoresCombates as lc on c.idCombate = lc.idCombate
where c.fechaCombate = '2020-06-08' and exists (select * from SH_LuchadoresCombates as lu where lu.idLuchador = 2)


			

select co.idCombate, fechaCombate from SH_Combates as co
inner join SH_LuchadoresCombates as lc
on co.idCombate = lc.idCombate
where idLuchador = 2



select co.idCombate, fechaCombate from SH_Combates as co
inner join SH_LuchadoresCombates as lc
on co.idCombate = lc.idCombate
where idLuchador = 5

select * from SH_LuchadoresCombates where idLuchador = 2

select * from SH_LuchadoresCombates where idLuchador = 5



SELECT DISTINCT  c.idCombate, c.fechaCombate FROM SH_Combates AS c 
INNER JOIN SH_LuchadoresCombates AS lc ON c.idCombate = lc.idCombate
WHERE c.fechaCombate = '2020-06-08' AND lc.idLuchador IN (2,5)

----------------



select co.idCombate, fechaCombate from SH_Combates as co
inner join SH_LuchadoresCombates as lc
on co.idCombate = lc.idCombate
where idLuchador = 2



select co.idCombate, fechaCombate from SH_Combates as co
inner join SH_LuchadoresCombates as lc
on co.idCombate = lc.idCombate
where idLuchador = 5
----

--Este es el que necesito para obtener un combate segun fecha, idluchador1 e idluchador2
select co.idCombate, fechaCombate from SH_Combates as co
inner join SH_LuchadoresCombates as lc
on co.idCombate = lc.idCombate
where idLuchador = 2

intersect

select co.idCombate, fechaCombate from SH_Combates as co
inner join SH_LuchadoresCombates as lc
on co.idCombate = lc.idCombate
where idLuchador = 4
------
select * from SH_Luchadores
select * from SH_Combates
select * from SH_LuchadoresCombates

----

-------


select co.idCombate, fechaCombate from SH_Combates as co
inner join SH_LuchadoresCombates as lc
on co.idCombate = lc.idCombate
where co.fechaCombate='2020-06-08' and idLuchador = 2

intersect

select co.idCombate, fechaCombate from SH_Combates as co
inner join SH_LuchadoresCombates as lc
on co.idCombate = lc.idCombate
where co.fechaCombate='2020-06-08' and  idLuchador = 4
---

select co.idCombate from SH_Combates as co
inner join SH_LuchadoresCombates as lc
on co.idCombate = lc.idCombate
where co.fechaCombate='2020-06-08' and idLuchador = 2

intersect

select co.idCombate from SH_Combates as co
inner join SH_LuchadoresCombates as lc
on co.idCombate = lc.idCombate
where co.fechaCombate='2020-06-08' and  idLuchador = 5

---------
select co.idCombate, fechaCombate from SH_Combates as co
inner join SH_LuchadoresCombates as lc
on co.idCombate = lc.idCombate
where co.fechaCombate='2020-06-09' and idLuchador = 2

intersect

select co.idCombate, fechaCombate from SH_Combates as co
inner join SH_LuchadoresCombates as lc
on co.idCombate = lc.idCombate
where co.fechaCombate='2020-06-09' and  idLuchador = 4



----
---Para comprobar si existe y obtener el numero de filas afectadas para usarlo con executeScalar
select count(*) from
(
select co.idCombate, fechaCombate from SH_Combates as co
inner join SH_LuchadoresCombates as lc
on co.idCombate = lc.idCombate
where co.fechaCombate='2020-06-08' and idLuchador = 4

intersect

select co.idCombate, fechaCombate from SH_Combates as co
inner join SH_LuchadoresCombates as lc
on co.idCombate = lc.idCombate
where co.fechaCombate='2020-06-8' and  idLuchador = 5
) I


----
select co.idCombate, fechaCombate from SH_Combates as co
inner join SH_LuchadoresCombates as lc
on co.idCombate = lc.idCombate
where co.fechaCombate='2020-06-08' and idLuchador = 4

intersect

select co.idCombate, fechaCombate from SH_Combates as co
inner join SH_LuchadoresCombates as lc
on co.idCombate = lc.idCombate
where co.fechaCombate='2020-06-8' and  idLuchador = 5

select * from SH_LuchadoresCombates
SELECT * FROM SH_Luchadores 
select * from SH_Combates --where idLuchador = 2 

--Listado luchadores ordenador por ratings
select sum(puntuacionLuchador) from SH_LuchadoresCombates where idLuchador = 2 




-----
select sum(puntuacionLuchador), idLuchador from SH_LuchadoresCombates
group by idLuchador
order by sum(puntuacionLuchador) desc


select sum(puntuacionLuchador), idLuchador from SH_LuchadoresCombates
group by idLuchador
having idLuchador = 2
order by sum(puntuacionLuchador) desc





select sum(puntuacionLuchador) as sumaPuntosLuchador, lc.idLuchador from SH_LuchadoresCombates as lc, SH_Luchadores as lu
where lc.idLuchador = lu.idLuchador
group by lc.idLuchador 
order by sum(puntuacionLuchador) desc


select  lc.idLuchador from SH_LuchadoresCombates as lc, SH_Luchadores as lu
where lc.idLuchador = lu.idLuchador
group by lc.idLuchador
order by sum(lc.puntuacionLuchador) desc




 --Obtiene listado de luchadores ordenadors por su ratings en todos los combates que han participado
 SELECT lu.idLuchador, lu.nombreLuchador, lu.fotoLuchador, SUM(lc.puntuacionLuchador) AS totalPuntuacionLuchador
 FROM SH_LuchadoresCombates AS lc, SH_Luchadores AS lu
 WHERE lu.idLuchador=lc.idLuchador
 GROUP BY lu.idLuchador, lu.nombreLuchador, lu.fotoLuchador
 ORDER BY SUM(lc.puntuacionLuchador) DESC




 select sum(puntuacionLuchador) as IronMan from SH_LuchadoresCombates where idLuchador = 2
 
 select sum(puntuacionLuchador) as Hulk from SH_LuchadoresCombates where idLuchador = 4
 
 select sum(puntuacionLuchador) as PuñoArmenio from SH_LuchadoresCombates where idLuchador = 5

 select * from SH_Luchadores
select * from SH_Combates
select * from SH_LuchadoresCombates