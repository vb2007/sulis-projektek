-- 2. feladat
DROP DATABASE IF EXISTS `allatmenhely`;

CREATE DATABASE `allatmenhely`
CHARACTER SET utf8
COLLATE utf8_hungarian_ci;

USE `allatmenhely`;

-- 3. feladat
CREATE TABLE `menhelyek` (
    `id` INT AUTO_INCREMENT NOT NULL,
    `nev` VARCHAR(50),
    `cim` VARCHAR(80),
    `web` VARCHAR(255),
    `adoszam` CHAR(13),
    `bankszamlaszam` CHAR(26),
    PRIMARY KEY (`id`)
);

-- 4. feladat
CREATE TABLE `allatok` (
    `id` INT AUTO_INCREMENT NOT NULL,
    `nev` VARCHAR(40) NOT NULL,
    `kor` INT,
    `tipus` VARCHAR(20),
    `fajta` VARCHAR(20),
    `ivartalanitott` BOOLEAN,
    `nem` VARCHAR(10),
    `behozva` DATE DEFAULT CURRENT_TIMESTAMP,
    `menhely_id` INT NOT NULL,
    PRIMARY KEY (`id`),
    FOREIGN KEY (`menhely_id`) REFERENCES `menhelyek`(`id`)
);

-- 5. feladat
INSERT INTO `menhelyek` (`nev`, `cim`, `web`, `adoszam`,  `bankszamlaszam`)
VALUES ("Rex Kutyaotthon", "1048 Budapest, Óceánárok u. 33.", "http://www.rex.hu", "18015676-1-41", "10402283-22802398-70140000");

-- 6. feladat
SELECT `id` FROM `menhelyek` WHERE nev = "Rex Kutyaotthon";

-- 7. feladat
INSERT INTO `allatok` (`nev`, `kor`, `tipus`, `fajta`, `ivartalanitott`, `nem`, `behozva`, `menhely_id`)
VALUES
("Csoki", 4, "kutya", "keverék", TRUE, "kan", "2016-04-01", (SELECT id FROM menhelyek WHERE nev = "Rex Kutyaotthon")),
("Picasso", 7, "kutya", "keverék", FALSE, "kan", "2018-01-12", (SELECT id FROM menhelyek WHERE nev = "Rex Kutyaotthon"));

-- 8. feladat

-- 9. feladat

-- 10. feladat

-- 11. feladat

-- 12. feladat

-- 13. feladat

-- 14. feladat

-- 15. feladat

-- 16. feladat

-- 17. feladat

-- 18. feladat
