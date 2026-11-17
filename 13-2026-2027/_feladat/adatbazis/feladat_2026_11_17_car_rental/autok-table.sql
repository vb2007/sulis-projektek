DROP DATABASE IF EXISTS `autokolcsonzo`;

CREATE DATABASE `autokolcsonzo`
    CHARACTER SET utf8mb4
    COLLATE utf8mb4_hungarian_ci;

CREATE TABLE `autok` (
    `id` INT PRIMARY KEY AUTO_INCREMENT,
    `marka` VARCHAR(50),
    `modell` VARCHAR(50),
    `rendszam` VARCHAR(10),
    `ar_naponta` INT
);