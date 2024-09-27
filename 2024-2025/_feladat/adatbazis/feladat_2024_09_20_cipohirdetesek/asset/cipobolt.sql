DROP DATABASE IF EXISTS `cipobolt2024`;

CREATE DATABASE IF NOT EXISTS `cipobolt2024`
DEFAULT CHARACTER SET utf8
COLLATE utf8_hungarian_ci;

USE `cipobolt2024`;

CREATE TABLE `hirdetesek` (
  `azon` int NOT NULL,
  `gyarto` varchar(12) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `nev` varchar(12) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `szin` varchar(12) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `nem` varchar(5) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `meret` int NOT NULL,
  `ar` int NOT NULL,
  `lejarat` datetime DEFAULT NULL,
  `aktiv` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8_hungarian_ci;

INSERT INTO `hirdetesek` (`azon`, `gyarto`, `nev`, `szin`, `nem`, `meret`, `ar`, `lejarat`, `aktiv`) VALUES
(1, 'Nipie', 'RunnAir', 'fekete', 'u', 42, 15990, '2025-08-31 00:00:00', 0),
(2, 'Nipie', 'RunnAir', 'piros', 'u', 39, 15990, '2025-01-10 00:00:00', 0),
(3, 'Para', 'Comfort', 'fekete', 'f', 44, 32990, '2025-08-31 00:00:00', 1),
(4, 'Para', 'High', 'piros', 'n', 36, 32990, '2024-01-01 00:00:00', 1),
(5, 'Matchers', 'Run', 'sötétkék', 'f', 46, 16800, '2024-09-10 00:00:00', 1),
(6, 'Matchers', 'Walk', 'fehér', 'u', 40, 18900, '2025-01-10 00:00:00', 0),
(7, 'Matchers', 'Flexy', 'rózsaszín', 'n', 39, 20000, '2024-09-10 00:00:00', 1),
(8, 'Gabika', 'Balett', 'rózsaszín', 'n', 36, 29999, '2025-01-01 00:00:00', 1),
(9, 'Gabika', 'Balett', 'rózsaszín', 'n', 36, 29999, '2025-01-01 00:00:00', 1),
(10, 'Gabika', 'Balett', 'rózsaszín', 'n', 38, 29999, '2025-01-01 00:00:00', 1),
(11, 'Nipie', 'RunnAir', 'fekete', 'f', 36, 18990, '2099-01-10 00:00:00', 1);

ALTER TABLE `hirdetesek`
  ADD PRIMARY KEY (`azon`),
  ADD KEY `meret_index` (`meret`),
  ADD KEY `ar_index` (`ar`);

ALTER TABLE `hirdetesek`
  MODIFY `azon` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;