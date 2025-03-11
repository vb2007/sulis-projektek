SET FOREIGN_KEY_CHECKS = 0;


CREATE DATABASE IF NOT EXISTS `vitorlasberles`
DEFAULT CHARACTER SET utf8
COLLATE utf8_hungarian_ci;


USE `vitorlasberles`;


DROP TABLE IF EXISTS `hajo`;

CREATE TABLE IF NOT EXISTS `hajo` (
  `regiszter` int PRIMARY KEY  NOT NULL auto_increment,
  `nev` varchar(12),
  `tipus` varchar(12),
  `utas` int NOT NULL,
  `dij` int NOT NULL
);


DROP TABLE IF EXISTS `tura`;

CREATE TABLE IF NOT EXISTS `tura` (
  `azon` int PRIMARY KEY  NOT NULL auto_increment,
  `hajoazon` int NOT NULL,
  `nap` int NOT NULL,
  `szemely` int NOT NULL
);

ALTER TABLE `tura`
ADD CONSTRAINT `FK_tura_hajoazon`
FOREIGN KEY (`hajoazon`)
REFERENCES `vitorlasberles`.`hajo`(`regiszter`)
ON DELETE CASCADE
ON UPDATE CASCADE;



INSERT INTO `hajo` (`regiszter`, `nev`, `tipus`, `utas`, `dij`) VALUES
(1, 'HUN-20 ', 'Kalóz', 2, 7500),
(2, 'Pille', 'B24', 6, 28000),
(3, 'Vihar', 'Cadet', 3, 15000),
(4, 'Hableány', 'B31', 8, 32000),
(5, 'HUN-17 ', 'Kalóz', 2, 7000),
(6, 'Kishamis', 'WIN-22', 5, 24000),
(7, 'Durbincs', 'WIN-22', 5, 24000),
(8, 'Fúria', 'Cadet', 3, 13000),
(9, 'Tikk-takk', 'Kalóz', 2, 7500),
(10, 'Sérv', 'WIN-22', 5, 24000),
(11, 'Fortuna', 'Kalóz', 2, 7500),
(12, 'Bíbic', 'Cadet', 3, 13000),
(13, 'Szello', 'B16', 4, 24000),
(14, 'Tünde', 'B31', 8, 41000),
(15, 'HUN-163 ', 'Kalóz', 2, 7500),
(16, 'Adria', 'B24', 6, 28000),
(17, 'Óriás', 'Enter 36', 11, 56000),
(18, 'Szamuráj', 'Enter 36', 11, 56000),
(19, 'Zeusz', 'Cadet', 3, 13000),
(20, 'HUN-115 ', 'Kalóz', 2, 7500),
(21, 'Neptun', 'Malu 30', 7, 39000),
(22, 'Sello', 'B16', 4, 24000),
(23, 'Nemo', 'B16', 4, 24000),
(24, 'Gyöngyhalász', 'WIN-22', 5, 24000),
(25, 'Dörgicse', 'B24', 6, 28000),
(26, 'Willy', 'Cadet', 3, 13000),
(27, 'Vöcsök II', 'Neptun', 4, 25000),
(28, 'Hullám', 'Malu 30', 7, 41000),
(29, 'HUN-328 ', 'Kalóz', 2, 7500),
(30, 'Széltoló', 'B16', 4, 24000),
(31, 'HUN-181 ', 'Kalóz', 2, 7500),
(32, 'Nana', 'B32', 6, 28000),
(33, 'HUN-113 ', 'Kalóz', 2, 7500),
(34, 'HUN-14 ', 'Kalóz', 2, 6800),
(35, 'Szaturnusz', 'B31', 8, 41000),
(36, 'Karcos', 'B16', 4, 24000),
(37, 'Esthajnal', 'B16', 4, 24000),
(38, 'HUN-11 ', 'Kalóz', 2, 7000),
(39, 'HUN-110 ', 'Kalóz', 2, 7500),
(40, 'Avar', 'Cadet', 3, 13000);




INSERT INTO `tura` (`azon`, `hajoazon`, `nap`, `szemely`) VALUES
(1, 15, 3, 2),
(2, 37, 7, 3),
(3, 14, 3, 6),
(4, 24, 3, 4),
(5, 20, 3, 2),
(6, 23, 2, 4),
(7, 36, 3, 3),
(8, 38, 3, 2),
(9, 32, 4, 5),
(10, 17, 3, 10),
(11, 18, 2, 9),
(12, 8, 3, 3),
(13, 22, 4, 3),
(14, 26, 3, 2),
(15, 21, 2, 5),
(16, 11, 3, 2),
(17, 25, 4, 4),
(18, 5, 2, 2),
(19, 33, 3, 1),
(20, 10, 4, 3),
(21, 39, 2, 2),
(22, 40, 7, 3),
(23, 7, 3, 4),
(24, 9, 4, 2),
(25, 6, 8, 4),
(26, 13, 3, 4),
(27, 27, 2, 3),
(28, 30, 3, 4),
(29, 16, 4, 4),
(30, 31, 3, 1),
(31, 35, 2, 6),
(32, 5, 3, 2),
(33, 26, 4, 2),
(34, 22, 2, 2),
(35, 39, 7, 1),
(36, 27, 7, 4),
(37, 19, 7, 3),
(38, 37, 6, 3),
(39, 9, 5, 2),
(40, 27, 4, 4),
(41, 31, 3, 2),
(42, 32, 4, 5),
(43, 20, 5, 2),
(44, 27, 4, 4),
(45, 8, 3, 3),
(46, 15, 4, 1),
(47, 14, 5, 6),
(48, 9, 4, 2),
(49, 25, 3, 6),
(50, 18, 4, 10),
(51, 32, 5, 5),
(52, 8, 6, 3),
(53, 1, 5, 2),
(54, 19, 4, 3),
(55, 1, 3, 2),
(56, 19, 4, 2),
(57, 22, 4, 4),
(58, 35, 3, 8),
(59, 29, 3, 1),
(60, 37, 4, 3),
(61, 16, 4, 6),
(62, 11, 5, 2),
(63, 28, 6, 7),
(64, 24, 5, 5),
(65, 32, 4, 6),
(66, 10, 3, 4),
(67, 37, 4, 3),
(68, 27, 5, 4),
(69, 23, 4, 3),
(70, 12, 3, 3),
(71, 25, 4, 4),
(72, 6, 5, 5),
(73, 1, 6, 2),
(74, 17, 5, 11),
(75, 35, 4, 7),
(76, 15, 3, 2),
(77, 11, 4, 2),
(78, 16, 5, 5),
(79, 39, 6, 1),
(80, 29, 4, 2),
(81, 31, 3, 2),
(82, 18, 4, 10),
(83, 33, 5, 1),
(84, 34, 6, 2),
(85, 14, 4, 8),
(86, 5, 4, 2),
(87, 26, 5, 3),
(88, 28, 6, 6),
(89, 33, 3, 1),
(90, 24, 2, 4),
(91, 38, 3, 2),
(92, 36, 2, 4),
(93, 30, 3, 4),
(94, 7, 4, 5),
(95, 20, 3, 1),
(96, 3, 4, 2),
(97, 4, 5, 6),
(98, 9, 4, 2),
(99, 3, 3, 3);

SET FOREIGN_KEY_CHECKS = 1;