START TRANSACTION;

DROP DATABASE IF EXISTS `valogatott`;

CREATE DATABASE IF NOT EXISTS `valogatott`
DEFAULT CHARACTER SET utf8
COLLATE utf8_hungarian_ci;

USE `valogatott`;

CREATE TABLE IF NOT EXISTS `foci` (
  `sorszam` int(11) NOT NULL,
  `nev` varchar(50) DEFAULT NULL,
  `poszt` varchar(25) DEFAULT NULL,
  `szuletes` date DEFAULT NULL,
  `klub` varchar(30),
  `magassag` double DEFAULT NULL,
  `lab`  varchar(25) DEFAULT NULL,
  `merkozes_szam` int(11),
  `gol`int(11) DEFAULT NULL,
  `bemzutatkozas` date DEFAULT NULL,
  `ertek` double NOT NULL
);

INSERT INTO `foci` (`sorszam`,`nev`,`poszt`,`szuletes`,`klub`,`magassag`,`lab`,`merkozes_szam`,`gol`,`bemzutatkozas`,`ertek`) VALUES
( 1 ,'Péter Gulácsi','Kapus','1990-05-06','RB Leipzig', 1.90 ,'jobb', 49 , 0 ,'2014-05-22', 8.00 ),
( 2 ,'Dénes Dibusz','Kapus','1990-11-16','Ferencvárosi TC', 1.88 ,'jobb', 22 , 0 ,'2014-10-14', 2.80 ),
( 3 ,'Péter Szappanos','Kapus','1990-11-14','Budapest Honvéd FC', 1.94 ,'jobb', 0 , 0 , NULL, 0.55 ),
( 4 ,'Attila Szalai','Középhátvéd','1998-01-20','Fenerbahce SK', 1.92 ,'bal', 27 , 0 ,'2019-11-15', 12.00 ),
( 5 ,'Willi Orbán','Középhátvéd','1992-11-03','RB Leipzig', 1.86 ,'jobb', 33 , 5 ,'2018-10-12', 10.00 ),
( 6 ,'Ádám Lang','Középhátvéd','1993-01-17','Omonia Nicosia', 1.86 ,'jobb', 51 , 1 ,'2014-05-22', 0.80 ),
( 7 ,'Ákos Kecskés','Középhátvéd','1996-01-04','FC Pari Nyizsnyij Novgorod', 1.90 ,'jobb', 6 , 0 ,'2020-11-15', 0.80 ),
( 8 ,'Milos Kerkez','Balhátvéd','2003-11-07','AZ Alkmaar', 1.80 ,'bal', 0 , 0 , NULL, 0.70 ),
( 9 ,'Csaba Spandler','Középhátvéd','1996-03-07','Puskás Akadémia FC', 1.83 ,'bal', 0 , 0 ,NULL, 0.50 ),
( 10 ,'Zsolt Nagy','Balhátvéd','1993-05-25','Puskás Akadémia FC', 1.88 ,'mindkét', 11 , 2 ,'2019-11-15', 0.60 ),
( 11 ,'Bendegúz Bolla','Jobbhátvéd','1999-11-22','Grasshopper Club Zürich', 1.79 ,'jobb', 7 , 0 ,'2021-06-04', 3.00 ),
( 12 ,'Loic Nego','Jobbhátvéd','1991-01-15','MOL Fehérvár FC', 1.81 ,'jobb', 24 , 2 ,'2020-10-08', 2.00 ),
( 13 ,'Attila Fiola','Jobbhátvéd','1990-02-17','MOL Fehérvár FC', 1.83 ,'jobb', 48 , 2 ,'2014-10-14', 3.00 ),
( 14 ,'Ádám Nagy','Védekező középpályás','1995-06-17','Pisa Sporting Club', 1.78 ,'jobb', 63 , 1 ,'2015-09-07', 2.00 ),
( 15 ,'Péter Baráth','Védekező középpályás','2002-02-21','Debreceni VSC', 1.85 ,'jobb', 0 , 0 ,NULL, 0.80 ),
( 16 ,'Callum Styles','Középső középpályás','2000-03-27','Barnsley FC', 1.67 ,'bal', 6 , 0 ,'2022-03-24', 3.50 ),
( 17 ,'András Schäfer','Középső középpályás','1999-04-13','1.FC Union Berlin', 1.80 ,'mindkét', 20 , 3 ,'2020-09-03', 2.00 ),
( 18 ,'Bálint Vécsei','Középső középpályás','1993-07-13','Ferencvárosi TC', 1.85 ,'bal', 10 , 1 ,'2014-06-04', 1.00 ),
( 19 ,'Dániel Gazdag','Támadó középpályás','1996-03-02','Philadelphiai Unió', 1.78 ,'jobb', 15 , 3 ,'2019-09-05', 2.00 ),
( 20 ,'Dominik Szoboszlai','Balszélső','2000-10-25','RB Leipzig', 1.87 ,'jobb', 24 , 6 ,'2019-03-21', 28.00 ),
( 21 ,'Dániel Sallói','Balszélső','1996-07-19','Sporting Kansas City', 1.85 ,'mindkét', 4 , 0 ,'2021-09-02', 7.50 ),
( 22 ,'Szabolcs Schön','Balszélső','2000-09-27','FC Dallas', 1.73 ,'bal', 8 , 0 ,'2021-06-08', 1.50 ),
( 23 ,'Zalán Vancsa','Balszélső','2004-10-27','Lommel SK', 1.75 ,'jobb', 1 , 0 ,'2022-06-07', 1.00 ),
( 24 ,'Roland Sallai','Jobbszélső','1997-05-22','SC Freiburg', 1.82 ,'mindkét', 36 , 8 ,'2016-05-20', 12.00 ),
( 25 ,'Martin Ádám','Középcsatár','1994-11-06','Paksi FC', 1.91 ,'bal', 6 , 0 ,'2022-03-24', 0.90 ),
( 26 ,'Ádám Szalai','Középcsatár','1987-12-09','FC Basel 1893', 1.93 ,'jobb', 84 , 25 ,'2009-02-11', 0.50 );

ALTER TABLE `foci`
  ADD PRIMARY KEY (`sorszam`);
