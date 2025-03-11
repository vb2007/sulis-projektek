
SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";

DROP DATABASE IF EXISTS `studio`;

CREATE DATABASE IF NOT EXISTS `studio`
DEFAULT CHARACTER SET utf8
COLLATE utf8_hungarian_ci;

USE `studio`;


CREATE TABLE `projektorok` (
  `id` int NOT NULL,
  `projektor` int DEFAULT NULL,
  `nev` varchar(25) DEFAULT NULL,
  `terem` int DEFAULT NULL,
  `elvitte` datetime NOT NULL,
  `visszahozta` datetime DEFAULT NULL,
  `kabel` varchar(10) NOT  NULL,
  `atalakito` varchar(25) DEFAULT NULL,
  `hangszoro` varchar(25) DEFAULT NULL
);


INSERT INTO `projektorok` (`id`, `projektor`, `nev`, `terem`, `elvitte`, `visszahozta`, `kabel`, `atalakito`, `hangszoro`) VALUES
(1, 1, 'Nagy Klára', 22, '2022-09-05 07:45:35', '2022-09-05 11:32:45', 'HDMI', NULL, 'Genius 2.0'),
(2, 3, 'Várszegi Nándor', 213, '2022-09-05 09:55:31', '2022-09-05 11:05:26', 'VGA', 'HDMI->VGA', NULL),
(3, 4, 'Tóth Géza', NULL, '2022-09-05 09:58:25', NULL, 'HDMI', 'Type C->HDMI', NULL),
(4, 1, 'Pécsi Eszter', NULL, '2022-09-05 10:55:20', '2022-09-05 12:14:25', 'HDMI', NULL, NULL),
(5, 1, 'Várszegi Nándor', 220, '2022-09-05 11:03:53', NULL, 'VGA', 'HDMI->VGA', NULL),
(6, NULL, 'Sándor Bertold', 132, '2022-09-06 14:20:54', '2022-09-06 16:07:38', 'HDMI', NULL, 'Genius 2.0'),
(7, 2, 'Pécsi Eszter', 141, '2022-09-06 14:41:43', '2022-09-06 19:27:52', 'HDMI', NULL, NULL),
(8, 1, 'Horváth Erzsébet', 200, '2022-09-07 12:01:29', '2022-09-07 13:07:55', NULL, NULL, 'Logi 5.1'),
(9, 4, 'Gál Nándor', 31, '2022-09-08 07:21:41', '2022-09-08 08:58:10', 'VGA', 'HDMI->VGA', NULL),
(10, 4, 'Gál Nándor', 8, '2022-09-09 07:18:33', '2022-09-09 08:55:37', 'VGA', NULL, 'Genius 2.0'),
(11, 1, 'Várszegi Nándor', 213, '2022-09-09 07:20:11', NULL, 'VGA', 'HDMI->VGA', NULL),
(12, 2, NULL, 202, '2022-09-09 09:50:33', NULL, 'HDMI', NULL, NULL),
(13, 2, NULL, 3, '2022-09-09 10:52:56', '2022-09-09 14:58:19', 'VGA', NULL, NULL);


ALTER TABLE `projektorok`
  ADD PRIMARY KEY (`id`);

ALTER TABLE `projektorok`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

COMMIT;