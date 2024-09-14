DROP DATABASE IF EXISTS `pelda`;

CREATE DATABASE IF NOT EXISTS `pelda` 
CHARACTER SET utf8
COLLATE utf8_hungarian_ci;

USE `pelda`;


SET foreign_key_checks = 0; 



DROP TABLE IF EXISTS `autok`;
DROP TABLE IF EXISTS `termek`;



CREATE TABLE IF NOT EXISTS `autok` (
    `rendszam` CHAR(10),
    `gyarto` VARCHAR(20),
    `tipus` VARCHAR(20),
    `kategoria` VARCHAR(5),
    `uzemanyag` VARCHAR(10),
    `szin` VARCHAR(10)
);

CREATE TABLE IF NOT EXISTS `termek` (
    `id` INT NOT NULL PRIMARY KEY auto_increment,
    `nev` VARCHAR(20) not null,
    `kategoria` VARCHAR(20) not null,
    `netto` double,
    `penznem` char(3),
    `afa` float
);

SET foreign_key_checks = 1;

