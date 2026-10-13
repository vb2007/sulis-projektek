-- DROP DATABASE `kassza`;

CREATE DATABASE IF NOT EXISTS `kassza`
DEFAULT CHARACTER SET utf8
COLLATE utf8_hungarian_ci;

USE `kassza`;

CREATE TABLE `elado` (
  `id` int NOT NULL primary key auto_increment,
  `nev` varchar(40) COLLATE utf8_hungarian_ci NOT NULL
) ENGINE=InnoDB;

CREATE TABLE `blokk` (
  `id` int NOT NULL primary key auto_increment,
  `vasarlas_ideje` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `elado_id` int NOT NULL,
  `fizetesi_mod` varchar(25) NOT NULL
) ENGINE=InnoDB;

CREATE TABLE `cikk` (
  `id` int NOT NULL primary key auto_increment,
  `blokk_id` int NOT NULL,
  `nev` varchar(50) COLLATE utf8_hungarian_ci NOT NULL,
  `mennyiseg` double NOT NULL,
  `mertekegyseg` varchar(25) CHARACTER SET utf8 COLLATE utf8_hungarian_ci NOT NULL,
  `egysegar` int NOT NULL,
  `afa` double NOT NULL
) ENGINE=InnoDB;

-- manuális commit
SET AUTOCOMMIT = 0;

START TRANSACTION;

INSERT INTO `elado`( `id`, `nev`)
VALUES ( 1, 'Kováts Beáta');
INSERT INTO `elado`( `id`, `nev`)
VALUES ( 2, 'Németh Gizella');
INSERT INTO `elado`( `id`, `nev`)
VALUES ( 3, 'Nagy Péter');
INSERT INTO `elado`( `id`, `nev`)
VALUES ( 4, 'Tóth Erzsébet');

COMMIT;

SET AUTOCOMMIT = 0;

START TRANSACTION;

INSERT INTO `blokk`( `elado_id`, `fizetesi_mod`)
VALUES ( 1, 'kp');

SELECT MAX(id) into @blokk_id from blokk;

INSERT INTO `cikk` (`blokk_id`, `nev`, `mennyiseg`,`mertekegyseg`, `egysegar`, `afa`)
VALUES (@blokk_id, 'Tej', 1, 'liter', 266, 0.05);

COMMIT;





SET AUTOCOMMIT = 0;

START TRANSACTION;

INSERT INTO `blokk`( `elado_id`, `fizetesi_mod`,`vasarlas_ideje`)
VALUES ( 1, 'kártya','2026-08-30 12:51:38');

SELECT MAX(id) into @blokk_id from blokk;

INSERT INTO `cikk` (`blokk_id`, `nev`, `mennyiseg`,`mertekegyseg`, `egysegar`, `afa`)
VALUES (@blokk_id, 'Kenyér', 2, 'kilogramm', 500, 0.18);

COMMIT;

SET AUTOCOMMIT = 0;

START TRANSACTION;

INSERT INTO `blokk`( `elado_id`, `fizetesi_mod`,`vasarlas_ideje`)
VALUES ( 2, 'kártya','2026-08-30 13:21:50');

SELECT MAX(id) into @blokk_id from blokk;

INSERT INTO `cikk` (`blokk_id`, `nev`, `mennyiseg`,`mertekegyseg`, `egysegar`, `afa`)
VALUES (@blokk_id, 'Tej', 1, 'Liter', 350, 0.18);
INSERT INTO `cikk` (`blokk_id`, `nev`, `mennyiseg`,`mertekegyseg`, `egysegar`, `afa`)
VALUES (@blokk_id, 'Kenyér', 1, 'kilogramm', 500, 0.18);

COMMIT;



SET AUTOCOMMIT = 0;
START TRANSACTION;

INSERT INTO `blokk`( `elado_id`, `fizetesi_mod`)
VALUES ( 3, 'kp');

SELECT MAX(id) into @blokk_id from blokk;

INSERT INTO `cikk` (`blokk_id`, `nev`, `mennyiseg`,`mertekegyseg`, `egysegar`, `afa`)
VALUES (@blokk_id, 'SSD', 1, 'db', 18000, 0.27);

INSERT INTO `cikk` (`blokk_id`, `nev`, `mennyiseg`,`mertekegyseg`, `egysegar`, `afa`)
VALUES (@blokk_id, 'Egér és Billentyűzet', 1, 'db', 25000, 0.27);

INSERT INTO `cikk` (`blokk_id`, `nev`, `mennyiseg`,`mertekegyseg`, `egysegar`, `afa`)
VALUES (@blokk_id, 'Alaplap', 1, 'db', 26000, 0.27);

INSERT INTO `blokk`( `elado_id`, `fizetesi_mod`)
VALUES ( 4, 'kp');

SELECT MAX(id) into @blokk_id from blokk;

INSERT INTO `cikk` (`blokk_id`, `nev`, `mennyiseg`,`mertekegyseg`, `egysegar`, `afa`)
VALUES (@blokk_id, 'Paradicsom', 1, 'kg', 750, 0.18);

INSERT INTO `cikk` (`blokk_id`, `nev`, `mennyiseg`,`mertekegyseg`, `egysegar`, `afa`)
VALUES (@blokk_id, 'Kenyér', 1, 'kg', 500, 0.18);

INSERT INTO `cikk` (`blokk_id`, `nev`, `mennyiseg`,`mertekegyseg`, `egysegar`, `afa`)
VALUES (@blokk_id, 'Tej', 1, 'liter', 360, 0.18);
INSERT INTO `cikk` (`blokk_id`, `nev`, `mennyiseg`,`mertekegyseg`, `egysegar`, `afa`)
VALUES (@blokk_id, 'Kóla', 2, 'liter', 550, 0.18);

commit;

