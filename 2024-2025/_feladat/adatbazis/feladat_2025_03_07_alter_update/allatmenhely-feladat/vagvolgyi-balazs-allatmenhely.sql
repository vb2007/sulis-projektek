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
("Csoki", 4, "kutya", "keverék", TRUE, "kan", "2016-04-01", (SELECT `id` FROM `menhelyek` WHERE `nev` = "Rex Kutyaotthon")),
("Picasso", 7, "kutya", "keverék", FALSE, "kan", "2018-01-12", (SELECT `id` FROM `menhelyek` WHERE `nev` = "Rex Kutyaotthon"));

-- 8. feladat
INSERT INTO `menhelyek` (`nev`, `cim`, `web`, `adoszam`, `bankszamlaszam`)
VALUES
("Noé állatotthon", "Budapest XVII.ker. Csordakút utca", "http://www.noeallatotthon.hu/", "18169696-1-42", "11710002-20083777");

-- 9. feladat
INSERT INTO `allatok` (`nev`, `kor`, `tipus`, `fajta`, `ivartalanitott`, `nem`, `behozva`, `menhely_id`)
VALUES
("Bíbor", 2, "cica", "perzsai", TRUE, "nőstény", "2017-05-17", (SELECT `id` FROM `menhelyek` WHERE `nev` = "Noé állatotthon")),
("Bubbly", 0.5, "cica", NULL, FALSE, "nőstény", "2018-01-02", (SELECT `id` FROM `menhelyek` WHERE `nev` = "Noé állatotthon")),
("Csoki", 2, "kutya", "keverék", FALSE, "nőstény", "2020-01-12", (SELECT `id` FROM `menhelyek` WHERE `nev` = "Noé állatotthon")),
("Nixxxon", 2.5, "kutya", "golden retviver", TRUE, "kan", NOW(), (SELECT `id` FROM `menhelyek` WHERE `nev` = "Noé állatotthon"));

-- 10. feladat
DELETE FROM `allatok`
WHERE `nev` = "Bubbly";

-- 11. feladat
UPDATE `allatok`
SET `nev` = "Nixon"
WHERE `nev` = "Nixxxon";

-- 12. feladat
UPDATE `allatok`
SET `nem` = "nőstény"
WHERE `nev` = "Picasso";

-- 13. feladat
UPDATE `allatok`
SET `kor` = 3
WHERE `nev` = "Csoki";

-- 14. feladat
SELECT AVG(`kor`) AS `atlag_eletkor`
FROM `allatok`
WHERE `tipus` = 'kutya';

-- 15. feladat
SELECT `menhelyek`.`nev` AS `menhely_nev`, COUNT(`allatok`.`id`) AS `allatok_szama`
FROM `menhelyek`
    JOIN `allatok`
        ON `menhelyek`.`id` = `allatok`.`menhely_id`
GROUP BY `menhelyek`.`nev`;

-- 16. feladat
SELECT
    `menhelyek`.`nev` AS `menhely_nev`,
    `allatok`.`tipus` AS `allat_tipus`,
    COUNT(`allatok`.`id`) AS `allatok_szama`
FROM `menhelyek`
    JOIN `allatok`
        ON `menhelyek`.`id` = `allatok`.`menhely_id`
GROUP BY `menhelyek`.`nev`, `allatok`.`tipus`;

-- 17. feladat
SELECT COUNT(`allatok`.`id`) AS `kutyak_szama`
FROM `allatok`
    JOIN `menhelyek`
        ON `allatok`.`menhely_id` = `menhelyek`.`id`
WHERE
    `menhelyek`.`nev` = "Noé állatotthon"
    AND `allatok`.`tipus` = "kutya";

-- 18. feladat
DELETE FROM `allatok`;
