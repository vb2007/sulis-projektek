START TRANSACTION;

DROP DATABASE IF EXISTS `geometria`;

CREATE DATABASE IF NOT EXISTS `geometria`
DEFAULT CHARACTER SET utf8
COLLATE utf8_hungarian_ci;

USE `geometria`;

CREATE TABLE `haromszogek` (
  `id` int NOT NULL,
  `szin` varchar(20) NOT NULL,
  `a` double NOT NULL,
  `b` double NOT NULL,
  `c` double NOT NULL
);

INSERT INTO `haromszogek` (`id`, `szin`, `a`, `b`, `c`) VALUES
(1, 'kék', 3.22, 7.48, 4),
(2, 'piros', 2.2, 4.8, 4.3),
(3, 'zöld', 1, 1.12, 1),
(4, 'sárga', 1, 2, 3);

CREATE TABLE `korok` (
  `id` int NOT NULL,
  `szin` varchar(20) NOT NULL,
  `r` double NOT NULL
);

INSERT INTO `korok` (`id`, `szin`, `r`) VALUES
(1, 'kék', 3),
(2, 'piros', 4.5),
(3, 'zöld', 3),
(4, 'sárga', 7),
(5, 'lila', 2);

CREATE TABLE `teglalapok` (
  `id` int NOT NULL,
  `szin` varchar(20) NOT NULL,
  `a` double NOT NULL,
  `b` double NOT NULL
);


INSERT INTO `teglalapok` (`id`, `szin`, `a`, `b`) VALUES
(1, 'kék', 2, 4),
(2, 'piros', 1.5, 3.2),
(3, 'zöld', 7.4, 8),
(4, 'sárga', 3, 10);


ALTER TABLE `haromszogek`
  ADD PRIMARY KEY (`id`);

ALTER TABLE `korok`
  ADD PRIMARY KEY (`id`);

ALTER TABLE `teglalapok`
  ADD PRIMARY KEY (`id`);

ALTER TABLE `haromszogek`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

ALTER TABLE `korok`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

ALTER TABLE `teglalapok`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

COMMIT;