DROP DATABASE IF EXISTS `tagdij`;

CREATE DATABASE `tagdij`
CHARACTER SET utf8
COLLATE utf8_hungarian_ci;

use `tagdij`;

CREATE TABLE ugyfel (
  azon INT UNSIGNED AUTO_INCREMENT NOT NULL,
  nev VARCHAR(30) NOT NULL,
  szulev SMALLINT UNSIGNED NOT NULL,
  irszam SMALLINT UNSIGNED NOT NULL,
  orsz VARCHAR(3) NOT NULL,
  CONSTRAINT pk_azon PRIMARY KEY (azon)
);


CREATE TABLE `befiz` (
  azon INT UNSIGNED NOT NULL,
  datum DATETIME NOT NULL,
  osszeg INT UNSIGNED NOT NULL,
  CONSTRAINT pk_azon PRIMARY KEY (azon, datum),
  CONSTRAINT fk_azon FOREIGN KEY (azon) REFERENCES ugyfel(azon)
);


INSERT INTO `ugyfel` VALUES 
(1001, 'Buda Jenő'     , 1982, 1026, 'H'  ),
(1002, 'Makkos Mária'  , 1970, 1128, 'H'  ),
(1003, 'Pilis Csaba'   , 1992, 2442, 'H'  ),
(1004, 'Török Bálint'  , 1988, 2128, 'H'  ),
(1005, 'Szent Endre'   , 1962, 2000, 'H'  ),
(1006, 'Kis Marton'    , 1991, 9999, 'A'  ),
(1007, 'Békés Csaba'   , 1989, 4400, 'H'  ),
(1009, 'Dráva Szabolcs', 1985, 7520, 'H'  ),
(1010, 'Nagy Károly'   , 1975, 9999, 'RO' ),
(1012, 'Boros Jenő'    , 1982, 9999, 'RO' ),
(1013, 'Száva Magdolna', 1987, 9999, 'HR' );

INSERT INTO `befiz` VALUES 
(1001, '2016-01-11 16:25:03', 60000),
(1002, '2016-01-17 11:01:19',  5000),
(1004, '2016-01-21 15:40:25', 18000),
(1005, '2016-02-02 09:26:54', 24000),
(1004, '2016-02-04 11:47:08', 30000),
(1006, '2016-02-20 16:36:12',  9000),
(1007, '2016-02-21 13:44:02', 12000),
(1005, '2016-03-01 10:49:41',  8000),
(1007, '2016-03-06 14:52:44', 15000),
(1009, '2016-04-12 20:21:57', 20000),
(1004, '2016-05-10 12:00:29',  8000),
(1006, '2016-06-08 11:10:26',  4000),
(1010, '2016-06-22 17:22:43',  7000),
(1010, '2016-07-14 03:35:02',  8500),
(1012, '2016-07-19 12:48:51', 41000),
(1004, '2016-09-02 16:51:25', 11000),
(1006, '2016-09-05 14:34:48', 15000),
(1007, '2016-09-25 21:16:38',  4000),
(1012, '2016-10-01 13:13:34', 10000),
(1010, '2016-10-01 14:29:37',  5000),
(1012, '2016-10-12 16:54:15',  6000),
(1007, '2016-11-24 11:02:52', 14000),
(1009, '2016-11-25 10:48:31', 19000),
(1007, '2016-11-25 16:01:24', 17000),
(1002, '2016-11-29 13:34:08', 10000),
(1010, '2016-11-30 08:27:50', 12000),
(1004, '2016-12-12 22:02:20', 20000),
(1009, '2016-12-15 12:28:44', 25000),
(1002, '2016-12-23 19:42:20',  3000),
(1005, '2016-12-23 20:33:28',  7500),
(1002, '2016-12-29 10:00:47', 18000);