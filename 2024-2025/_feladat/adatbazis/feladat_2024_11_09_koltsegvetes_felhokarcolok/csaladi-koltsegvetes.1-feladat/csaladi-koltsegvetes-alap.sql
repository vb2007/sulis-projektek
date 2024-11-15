DROP database IF EXISTS `koltsegvetes`;

CREATE DATABASE IF NOT EXISTS `koltsegvetes`
DEFAULT CHARACTER SET utf8
COLLATE utf8_hungarian_ci;

USE `koltsegvetes`;


CREATE TABLE IF NOT EXISTS `kiadasok` (
`id` int(11) NOT NULL,
  `nap` varchar(12) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `nev` varchar(12) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `kategoria` varchar(12) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `megnevezes` varchar(25) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `mennyiseg` double DEFAULT NULL,
  `egysegar` int(11) NOT NULL
);


INSERT INTO `kiadasok` (`id`, `nap`, `nev`, `kategoria`, `megnevezes`, `mennyiseg`, `egysegar`) VALUES
(1, 'hétfő', 'Mariann', 'élelmiszer', 'tej', 2, 280),
(2, 'hétfő', 'Mariann', 'élelmiszer', 'sajt', 1, 1250),
(3, 'hétfő', 'Mariann', 'élelmiszer', 'krumpli', 5, 120),
(4, 'hétfő', 'Lajos', 'élelmiszer', 'sonka', 0.5, 2400),
(5, 'hétfő', 'Lajos', 'élelmiszer', 'kolbász', 2, 800),
(6, 'hétfő', 'Bence', 'közlekedés', 'bérlet', 1, 3500),
(7, 'hétfő', 'Bence', 'higiénia', 'eldobható borotva', 1, 800),
(8, 'hétfő', 'Emese', 'higiénia', 'sampon', 1, 1200),
(9, 'hétfő', 'Emese', 'elektronika', 'telefon', 1, 120000),
(10, 'kedd', 'Lajos', 'élelmiszer', 'tej', 2, 280),
(11, 'kedd', 'Lajos', 'közlekedés', 'üzemanyag', 44.5, 390),
(12, 'szerda', 'Bence', 'élelmiszer', 'tej', 2, 280),
(13, 'szerda', 'Bence', 'élelmiszer', 'muzli', 1, 1320),
(14, 'szerda', 'Bence', 'élelmiszer', 'kifli', 12, 30),
(15, 'csütörtök', 'Emese', 'higiénia', 'tisztítószer', 1, 790),
(16, 'csütörtök', 'Emese', 'higiénia', 'rúzs', 1, 3800),
(17, 'csütörtök', 'Emese', 'higiénia', 'illat gyertya', 3, 570),
(18, 'csütörtök', 'Mariann', 'élelmiszer', 'kenyér', 1, 330),
(19, 'csütörtök', 'Mariann', 'élelmiszer', 'vaj', 1, 799),
(20, 'csütörtök', 'Mariann', 'élelmiszer', 'felvágott', 1, 3000),
(21, 'péntek', 'Lajos', 'közlekedés', 'üzemanyag', 39.8, 392),
(22, 'péntek', 'Mariann', 'elektronika', 'fejhallgató', 1, 8999),
(23, 'péntek', 'Mariann', 'elektronika', 'kijelzo védo fólia', 1, 3000);


ALTER TABLE `kiadasok`
 ADD PRIMARY KEY (`id`), ADD KEY `egysegar_index` (`egysegar`);
