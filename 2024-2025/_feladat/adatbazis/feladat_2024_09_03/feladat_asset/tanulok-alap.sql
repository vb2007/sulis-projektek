DROP database IF EXISTS `iskola`;

CREATE DATABASE IF NOT EXISTS `iskola`
DEFAULT CHARACTER SET utf8
COLLATE utf8_hungarian_ci;

USE `iskola`;


CREATE TABLE `tanulok` (
  `id` int NOT NULL PRIMARY KEY auto_increment,
  `vnev` varchar(20) DEFAULT NULL,
  `knev` varchar(20) DEFAULT NULL,
  `nem` char(1) DEFAULT NULL,
  `szul_hely` varchar(20)  DEFAULT NULL,
  `szul_ido` date DEFAULT NULL,
  `magassag` int DEFAULT NULL,
  `nagycsalados` tinyint(1) DEFAULT NULL,
  `atlag` float DEFAULT NULL
);

INSERT INTO `tanulok` (`id`, `vnev`, `knev`, `nem`, `szul_hely`, `szul_ido`, `magassag`, `nagycsalados`, `atlag`) VALUES
(1, 'Kurutz', 'Boldizsár Ádám', 'F', 'Budapest', '2003-03-16', 175, 1, 3.09),
(2, 'Vince', 'Armand', 'F', 'Budapest', '2003-04-27', 183, 0, 4.74),
(3, 'Vas', 'Eszter', 'N', 'Miskolc', '2003-12-15', 185, 1, 1.98),
(4, 'Sós', 'Péter', 'F', 'Budapest', '2006-08-29', 161, 0, 2.28),
(5, 'Budai', 'Beatrix', 'N', 'Szeged', '2002-02-21', 166, 1, 2.12),
(6, 'Borbély', 'Gergely László', 'F', 'Miskolc', '2003-10-11', 166, 0, 3.87),
(7, 'Budai', 'Franciska', 'N', 'Budapest', '2007-03-11', 182, 0, 3.08),
(8, 'Szakáll', 'Réka Petra', 'N', 'Miskolc', '2002-06-21', 165, 1, 3.66),
(9, 'Benke', 'Alexandra', 'N', 'Budapest', '2005-10-16', 158, 1, 2.96),
(10, 'Sághi', 'Bálint', 'F', 'Budapest', '2002-01-14', 188, 0, 4.93),
(11, 'Jósás', 'Laura', 'N', 'Győr', '2002-07-01', 164, 1, 2.12),
(12, 'Kecskés', 'Vince', 'F', 'Budapest', '2006-11-20', 186, 0, 3.21),
(13, 'Herceg', 'Andrea', 'N', 'Budapest', '2006-09-29', 173, 0, 2.04),
(14, 'Lendvai', 'Péter Zsolt', 'F', 'Budapest', '2007-12-05', 169, 0, 4.52),
(15, 'Budai', 'Bea', 'N', 'Budapest', '2003-10-21', 180, 0, 4.2);