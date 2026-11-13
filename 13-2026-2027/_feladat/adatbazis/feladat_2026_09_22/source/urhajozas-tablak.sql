
CREATE TABLE `kuldetes` (
  `id` int NOT NULL,
  `megnevezes` varchar(25) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `kezdet` date DEFAULT NULL,
  `veg` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;


CREATE TABLE `repules` (
  `urhajos_id` int NOT NULL,
  `kuldetes_id` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;



CREATE TABLE `urhajos` (
  `id` int NOT NULL,
  `nev` varchar(45) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `orszag` varchar(3) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `nem` varchar(1) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `szulev` int NOT NULL,
  `urido` varchar(12) COLLATE utf8_hungarian_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;


ALTER TABLE `kuldetes`
  ADD PRIMARY KEY (`id`);

ALTER TABLE `repules`
  ADD PRIMARY KEY (`urhajos_id`,`kuldetes_id`),
  ADD KEY `kuldetes_id` (`kuldetes_id`);


ALTER TABLE `urhajos`
  ADD PRIMARY KEY (`id`),
  ADD KEY `szulev_index` (`szulev`);


ALTER TABLE `repules`
  ADD CONSTRAINT `repules_ibfk_1` FOREIGN KEY (`kuldetes_id`) REFERENCES `kuldetes` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `repules_ibfk_2` FOREIGN KEY (`urhajos_id`) REFERENCES `urhajos` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;