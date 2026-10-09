-- phpMyAdmin SQL Dump
-- version 5.2.3
-- https://www.phpmyadmin.net/
--
-- Host: db:3306
-- Generation Time: Oct 09, 2026 at 01:35 AM
-- Server version: 9.7.1
-- PHP Version: 8.3.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `oebb`
--

-- --------------------------------------------------------

--
-- Table structure for table `hero_contents`
--

DROP TABLE IF EXISTS `hero_contents`;
CREATE TABLE `hero_contents` (
  `id` bigint UNSIGNED NOT NULL,
  `image_url` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `title` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `description` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `button_text` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `hero_contents`
--

INSERT INTO `hero_contents` (`id`, `image_url`, `title`, `description`, `button_text`) VALUES
(1, 'hero-1.webp', 'Sparschiene Nachtschwärmer', 'Später einsteigen günstiger aussteigen.', 'Jetzt informieren'),
(2, 'hero-2.webp', 'Die Nightjet-Tickets 2027 sind da!', 'Schnell sein lohnt sich.', 'Jetzt buchen'),
(3, 'hero-3.webp', 'Reisetipp: Budapest entdecken', 'Budapest fasziniert mit vielen Sehenswürdigkeiten, Thermalbädern und einzigartiger Architektur.', 'Ab nach Budapest'),
(4, 'hero-4.webp', 'Ab sofort das neue railaxed Reisemagazin lesen!', 'Reisen Sie mit uns im Herbst an viele inspirierende Orte.', 'Jetzt Reisetipps holen'),
(5, 'hero-5.webp', 'ÖBB Vorzugspunkte', 'Im ÖBB Konto buchen, Vorzugspunkte sammeln, exklusive Prämien genießen.', 'Jetzt informieren'),
(6, 'hero-6.webp', 'Vorteil auch fürs Hinterteil', 'Das kann nur die Vorteilscard Comfort: 50% Ermäßigung auf Tickets und Reservierungen.', 'Jetzt informieren');

-- --------------------------------------------------------

--
-- Table structure for table `teasers`
--

DROP TABLE IF EXISTS `teasers`;
CREATE TABLE `teasers` (
  `id` bigint UNSIGNED NOT NULL,
  `image_url` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `title` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `description` varchar(200) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `section` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `order` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `teasers`
--

INSERT INTO `teasers` (`id`, `image_url`, `title`, `description`, `section`, `order`) VALUES
(1, 'freizeitticket-2560.webp', 'Freizeitticket & Freizeitticket Plus', 'Das Ausflugsticket für Wien, Niederösterreich und das Burgenland ab € 19,90.', 'new_from_obb', 1),
(2, 'vorzugspunkte-billard.webp', 'ÖBB Vorzugspunkte', 'Buchen, Punkte sammeln, Prämien genießen.', 'new_from_obb', 3),
(3, 'erlebnisticket-sommer.webp', 'Die neuen ÖBB Erlebnistickets', 'Bahn + Freizeitangebot gemeinsam buchen und dabei sparen.', 'new_from_obb', 2),
(4, 'baustelleninfo.webp', 'Geplante Baustellen', 'Erneuerungs- und Instandhaltungsarbeiten.', 'new_from_obb', 4),
(5, 'verkehrsinfo-holding.webp', 'Aktuelle Verkehrsmeldungen', 'Streckeninformationen und Hinweise zu Baustellen.', 'new_from_obb', 5),
(6, 'cat.webp', 'City Airport Train', 'Günstig zum Flughafen mit ÖBB Vorteilscard.', 'current_offers', 3),
(7, 'businessabteil-mann-laessig-1422.webp', 'Businessreisen mit der Bahn', 'Durchatmen vor dem Meeting-Marathon.', 'current_offers', 4),
(8, 'railaxed-magazin.webp', 'Reisetipps für jede Jahreszeit', 'Lassen Sie sich inspirieren!', 'current_offers', 6),
(9, 'sharedmobility.webp', 'Shared Mobility', 'Smarte Mobilitätsservices', 'current_offers', 5),
(10, 'nj-new-schlafende-frau-1422.webp', 'ÖBB Nightjet', 'Bequem über Nacht verreisen.', 'current_offers', 2),
(11, 'strand-paar.webp', 'ÖBB Reisebüro', '...wenn es Zeit für Urlaub ist!', 'current_offers', 7),
(12, 'myrailtour.webp', 'MyRailTour - Bahn und Hotel', 'Zügig zum Bestpreis.', 'current_offers', 9),
(13, 'wien-riesenrad.webp', 'EasyCityPass & QueerCityPass', NULL, 'from_the_states', 6),
(14, 'oebb-plus.webp', 'ÖBB Plus', 'Bahnfahrt + Freizeitangebot.', 'current_offers', 7),
(15, 'ringstrasse-burgtheater.webp', 'Vienna City Card', NULL, 'from_the_states', 8),
(16, 'dzt-strandkorb-ostsee.webp', 'Mehr Zeit für Urlaub', NULL, 'from_the_states', 8),
(17, 'innsbruck-panorama.webp', 'Regio Ticket Werdenfels', NULL, 'from_the_states', 9),
(18, 'bruges.webp', 'Entdecken Sie Flandern', NULL, 'from_the_states', 1),
(19, 'bahn-zum-berg.webp', 'Bahn zum Berg', NULL, 'from_the_states', 2),
(20, 'woerthersee-pyramidenkogel.webp', 'Kultur und Events in Kärnten', NULL, 'from_the_states', 3),
(21, 'transfer-salzburg.webp', 'ÖBB Transfer Salzburg', NULL, 'from_the_states', 4),
(22, 'vc-vorteil-hinterteil.webp', 'ÖBB Vorteilscard', 'Für alle, die gerne flexibel Bahnfahren', 'current_offers', 1),
(23, 'graz-panorama.webp', 'Freizeit-Ticket Steiermark', NULL, 'from_the_states', 5);

-- --------------------------------------------------------

--
-- Table structure for table `trains`
--

DROP TABLE IF EXISTS `trains`;
CREATE TABLE `trains` (
  `id` bigint UNSIGNED NOT NULL,
  `train_number` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `origin` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `destination` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `departure_time` time NOT NULL,
  `arrival_time` time NOT NULL,
  `second_class_price` double NOT NULL,
  `first_class_price` double DEFAULT NULL,
  `business_class_price` double DEFAULT NULL,
  `is_overnight` tinyint(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `trains`
--

INSERT INTO `trains` (`id`, `train_number`, `origin`, `destination`, `departure_time`, `arrival_time`, `second_class_price`, `first_class_price`, `business_class_price`, `is_overnight`) VALUES
(1, 'EN 463', 'Wien Hbf', 'Budapest-Keleti', '06:40:00', '09:35:00', 22.9, NULL, NULL, 0),
(2, 'RJX 267', 'Wien Hbf', 'Budapest-Keleti', '07:40:00', '10:35:00', 24.9, 36.9, 46.9, 0),
(3, 'EC 141', 'Wien Hbf', 'Budapest-Keleti', '08:40:00', '11:35:00', 22.9, 33.9, NULL, 0),
(4, 'RJX 61', 'Wien Hbf', 'Budapest-Keleti', '11:40:00', '14:35:00', 21.9, 32.9, 41.9, 0),
(5, 'EC 145', 'Wien Hbf', 'Budapest-Keleti', '12:40:00', '15:35:00', 26.9, 39.9, NULL, 0),
(6, 'RJX 65', 'Wien Hbf', 'Budapest-Keleti', '15:40:00', '18:35:00', 21.9, 32.9, 41.9, 0),
(7, 'EC 149', 'Wien Hbf', 'Budapest-Keleti', '16:42:00', '19:35:00', 21.9, 32.9, NULL, 0),
(8, 'RJX 67', 'Wien Hbf', 'Budapest-Keleti', '17:40:00', '20:35:00', 23.9, 35.9, 44.9, 0),
(9, 'EC 341', 'Wien Hbf', 'Budapest-Keleti', '19:42:00', '22:35:00', 24.9, 36.9, NULL, 0),
(10, 'EC 343', 'Wien Hbf', 'Budapest-Keleti', '20:37:00', '23:35:00', 26.9, 39.9, NULL, 0),
(11, 'RJ 258', 'Wien Hbf', 'Praha hl.n.', '05:10:00', '09:23:00', 26.9, 39.9, 50.9, 0),
(12, 'RJ 256', 'Wien Hbf', 'Praha hl.n.', '07:10:00', '11:23:00', 28.9, 42.9, 54.9, 0),
(13, 'RJX 254', 'Wien Hbf', 'Praha hl.n.', '09:10:00', '13:23:00', 28.9, 42.9, 54.9, 0),
(14, 'RJ 252', 'Wien Hbf', 'Praha hl.n.', '11:10:00', '15:23:00', 29.9, 44.9, 56.9, 0),
(15, 'RJX 56', 'Wien Hbf', 'Praha hl.n.', '15:10:00', '19:23:00', 29.9, 44.9, 56.9, 0),
(16, 'RJ 54', 'Wien Hbf', 'Praha hl.n.', '17:10:00', '21:23:00', 31.9, 47.9, 60.9, 0),
(17, 'RJX 52', 'Wien Hbf', 'Praha hl.n.', '19:10:00', '23:32:00', 28.9, 42.9, 54.9, 0),
(18, 'NJ 456', 'Wien Hbf', 'Praha hl.n.', '22:10:00', '03:09:00', 33.9, NULL, NULL, 1),
(19, 'RJX 254', 'Villach Hbf', 'Praha hl.n.', '05:30:00', '13:23:00', 43.9, 65.9, 82.9, 0),
(20, 'RJX 56', 'Villach Hbf', 'Praha hl.n.', '11:33:00', '19:23:00', 46.9, 69.9, 88.9, 0),
(21, 'RJX 52', 'Villach Hbf', 'Praha hl.n.', '15:33:00', '23:32:00', 45.9, 68.9, 86.9, 0),
(22, 'NJ 13486', 'Wien Hbf', 'Zürich HB', '21:39:00', '10:36:00', 64.9, NULL, NULL, 1),
(23, 'EN 40462', 'Wien Hbf', 'Zürich HB', '23:28:00', '10:36:00', 57.9, NULL, NULL, 1),
(24, 'NJ 13486', 'Salzburg Hbf', 'Zürich HB', '02:30:00', '10:36:00', 46.9, NULL, NULL, 0),
(25, 'RJ 13478', 'Salzburg Hbf', 'Zürich HB', '06:56:00', '13:28:00', 36.9, 54.9, 69.9, 0),
(26, 'IC 407', 'Wien Hbf', 'München Hbf', '05:39:00', '10:39:00', 32.9, 48.9, NULL, 0),
(27, 'RJX 260', 'Wien Hbf', 'München Hbf', '06:28:00', '10:43:00', 28.9, 42.9, 54.9, 0),
(28, 'EC 1218', 'Wien Hbf', 'München Hbf', '07:13:00', '12:38:00', 32.9, 48.9, NULL, 0),
(29, 'RJX 262', 'Wien Hbf', 'München Hbf', '08:28:00', '12:43:00', 26.9, 39.9, 50.9, 0),
(30, 'EC 1216', 'Wien Hbf', 'München Hbf', '09:13:00', '14:37:00', 35.9, 53.9, NULL, 0),
(31, 'RJ 112', 'Wien Hbf', 'München Hbf', '11:24:00', '19:46:00', 48.9, 72.9, 92.9, 0),
(32, 'RJX 62', 'Wien Hbf', 'München Hbf', '12:28:00', '16:43:00', 32.9, 48.9, 62.9, 0),
(33, 'RJ 110', 'Wien Hbf', 'München Hbf', '13:24:00', '21:51:00', 47.9, 71.9, 90.9, 0),
(34, 'RJX 64', 'Wien Hbf', 'München Hbf', '14:28:00', '18:43:00', 27.9, 41.9, 52.9, 0),
(35, 'RJX 66', 'Wien Hbf', 'München Hbf', '16:28:00', '20:47:00', 31.9, 47.9, 60.9, 0),
(36, 'RJ 1296', 'Salzburg Hbf', 'München Hbf', '05:39:00', '07:30:00', 17.9, 26.9, 33.9, 0),
(37, 'RJ 1292', 'Salzburg Hbf', 'München Hbf', '06:31:00', '08:42:00', 23.9, 35.9, 44.9, 0),
(38, 'NJ 294', 'Salzburg Hbf', 'München Hbf', '07:01:00', '09:33:00', 24.9, NULL, NULL, 0),
(39, 'RJX 262', 'Salzburg Hbf', 'München Hbf', '11:00:00', '12:43:00', 17.9, 26.9, 33.9, 0),
(40, 'RJX 62', 'Salzburg Hbf', 'München Hbf', '15:00:00', '16:43:00', 20.9, 30.9, 39.9, 0),
(41, 'RJ 112', 'Salzburg Hbf', 'München Hbf', '18:00:00', '19:46:00', 18.9, 27.9, 35.9, 0),
(42, 'RJX 66', 'Salzburg Hbf', 'München Hbf', '19:00:00', '20:47:00', 19.9, 29.9, 37.9, 0),
(43, 'D 311', 'Villach Hbf', 'Ljubljana', '08:38:00', '10:17:00', 21.9, 32.9, NULL, 0),
(44, 'D 313', 'Villach Hbf', 'Ljubljana', '10:38:00', '12:27:00', 19.9, 29.9, NULL, 0),
(45, 'D 315', 'Villach Hbf', 'Ljubljana', '12:38:00', '14:14:00', 19.9, 29.9, NULL, 0),
(46, 'EC 115', 'Villach Hbf', 'Ljubljana', '14:45:00', '16:40:00', 20.9, 30.9, NULL, 0),
(47, 'D 317', 'Villach Hbf', 'Ljubljana', '16:38:00', '18:09:00', 18.9, 27.9, NULL, 0),
(48, 'D 319', 'Villach Hbf', 'Ljubljana', '18:38:00', '20:36:00', 22.9, 33.9, NULL, 0),
(49, 'D 39', 'Villach Hbf', 'Ljubljana', '21:38:00', '23:18:00', 19.9, 29.9, NULL, 0),
(50, 'RJ 1183', 'Innsbruck Hbf', 'Bologna Centrale', '11:30:00', '16:08:00', 30.9, 45.9, 58.9, 0),
(51, 'RJ 87', 'Innsbruck Hbf', 'Bologna Centrale', '15:30:00', '20:16:00', 31.9, 47.9, 60.9, 0),
(52, 'RJ 89', 'Innsbruck Hbf', 'Bologna Centrale', '17:30:00', '22:11:00', 29.9, 44.9, 56.9, 0),
(53, 'RJ 83', 'Innsbruck Hbf', 'Bologna Centrale', '11:30:00', '16:08:00', 30.9, 45.9, 58.9, 0),
(54, 'RJ 87', 'Innsbruck Hbf', 'Bologna Centrale', '15:30:00', '20:16:00', 33.9, 50.9, 63.9, 0),
(55, 'RJ 83', 'Innsbruck Hbf', 'Bologna Centrale', '11:30:00', '16:08:00', 29.9, 44.9, 56.9, 0),
(56, 'RJ 256', 'Linz/Donau Hbf', 'Praha hl.n.', '05:30:00', '11:23:00', 32.9, 48.9, 62.9, 0),
(57, 'EC 336', 'Linz/Donau Hbf', 'Praha hl.n.', '06:54:00', '10:39:00', 27.9, 41.9, NULL, 0),
(58, 'EC 334', 'Linz/Donau Hbf', 'Praha hl.n.', '11:54:00', '15:39:00', 26.9, 39.9, NULL, 0),
(59, 'EC 332', 'Linz/Donau Hbf', 'Praha hl.n.', '15:54:00', '19:39:00', 28.9, 42.9, NULL, 0),
(60, 'EC 330', 'Linz/Donau Hbf', 'Praha hl.n.', '19:54:00', '23:42:00', 26.9, 39.9, NULL, 0),
(61, 'EN 463', 'Linz/Donau Hbf', 'Budapest-Keleti', '05:10:00', '09:35:00', 28.9, NULL, NULL, 0),
(62, 'RJX 61', 'Linz/Donau Hbf', 'Budapest-Keleti', '10:17:00', '14:35:00', 32.9, 48.9, 62.9, 0),
(63, 'RJX 63', 'Linz/Donau Hbf', 'Budapest-Keleti', '12:17:00', '16:35:00', 27.9, 41.9, 52.9, 0),
(64, 'RJX 65', 'Linz/Donau Hbf', 'Budapest-Keleti', '14:17:00', '18:35:00', 28.9, 42.9, 54.9, 0),
(65, 'RJX 67', 'Linz/Donau Hbf', 'Budapest-Keleti', '16:17:00', '20:35:00', 28.9, 42.9, 54.9, 0),
(66, 'RJX 261', 'Linz/Donau Hbf', 'Budapest-Keleti', '20:17:00', '00:29:00', 30.9, 45.9, 58.9, 1),
(67, 'IC 407', 'Linz/Donau Hbf', 'München Hbf', '07:15:00', '10:39:00', 27.9, 41.9, NULL, 0),
(68, 'EN 40407', 'Linz/Donau Hbf', 'München Hbf', '07:15:00', '10:39:00', 27.9, NULL, NULL, 0),
(69, 'RJX 260', 'Linz/Donau Hbf', 'München Hbf', '07:45:00', '10:43:00', 21.9, 32.9, 41.9, 0),
(70, 'EC 1218', 'Linz/Donau Hbf', 'München Hbf', '08:34:00', '12:38:00', 25.9, 38.9, NULL, 0),
(71, 'RJX 262', 'Linz/Donau Hbf', 'München Hbf', '09:45:00', '12:43:00', 24.9, 36.9, 46.9, 0),
(72, 'ICE 1214', 'Linz/Donau Hbf', 'München Hbf', '12:34:00', '15:54:00', 28.9, 42.9, NULL, 0),
(73, 'RJX 62', 'Linz/Donau Hbf', 'München Hbf', '13:45:00', '16:43:00', 21.9, 32.9, 41.9, 0),
(74, 'RJX 64', 'Linz/Donau Hbf', 'München Hbf', '15:45:00', '18:43:00', 22.9, 33.9, 43.9, 0),
(75, 'ICE 1212', 'Linz/Donau Hbf', 'München Hbf', '16:34:00', '19:56:00', 26.9, 39.9, NULL, 0),
(76, 'RJX 66', 'Linz/Donau Hbf', 'München Hbf', '17:45:00', '20:47:00', 26.9, 39.9, 50.9, 0),
(77, 'EC 1210', 'Linz/Donau Hbf', 'München Hbf', '18:34:00', '22:15:00', 25.9, 38.9, NULL, 0),
(78, 'NJ 13486', 'Linz/Donau Hbf', 'Zürich HB', '23:10:00', '10:36:00', 60.9, 90.9, NULL, 1),
(79, 'EN 40462', 'Linz/Donau Hbf', 'Zürich HB', '00:51:00', '10:36:00', 52.9, NULL, NULL, 0),
(80, 'RJ 13478', 'Linz/Donau Hbf', 'Zürich HB', '05:30:00', '13:28:00', 41.9, 62.9, 79.9, 0),
(81, 'NJ 40490', 'Wien Hbf', 'Dortmund Hbf', '18:36:00', '06:50:00', 62.9, NULL, NULL, 1),
(82, 'ICE 1214', 'Wien Hbf', 'Stuttgart Hbf', '11:13:00', '19:27:00', 43.9, 65.9, NULL, 0),
(83, 'EN 50462', 'Wien Hbf', 'Stuttgart Hbf', '23:28:00', '08:38:00', 48.9, NULL, NULL, 1),
(84, 'RJX 133', 'Wien Hbf', 'Venezia Mestere', '08:53:00', '15:56:00', 43.9, 65.9, 82.9, 0),
(85, 'RJX 135', 'Wien Hbf', 'Venezia Mestere', '12:53:00', '19:52:00', 41.9, 62.9, 79.9, 0),
(86, 'NJ 40466', 'Wien Hbf', 'Venezia Mestere', '21:39:00', '08:23:00', 53.9, NULL, NULL, 1),
(87, 'NJ 40233', 'Wien Hbf', 'Roma Tiburtina', '20:05:00', '10:05:00', 66.9, NULL, NULL, 1),
(88, 'NJ 492', 'Wien Hbf', 'Hamburg Hbf', '18:36:00', '08:38:00', 67.9, NULL, NULL, 1),
(89, 'ICE 1206', 'Innsbruck Hbf', 'Hamburg Hbf', '08:20:00', '18:10:00', 51.9, 77.9, NULL, 0),
(90, 'NJ 40420', 'Innsbruck Hbf', 'Hamburg Hbf', '20:46:00', '08:38:00', 58.9, NULL, NULL, 1),
(91, 'NJ 40490', 'Wien Hbf', 'Amsterdam C.', '18:36:00', '09:59:00', 72.9, NULL, NULL, 1),
(92, 'NJ 420', 'Innsbruck Hbf', 'Amsterdam C.', '20:46:00', '09:59:00', 68.9, NULL, NULL, 1),
(93, 'REX 41', 'Wien Franz-Josefs-Bahnhof', 'Praha hl.n.', '09:00:00', '14:10:00', 19, NULL, NULL, 0),
(94, 'REX 1', 'Wien Hbf', 'Břeclav', '05:02:00', '06:29:00', 19, NULL, NULL, 0),
(95, 'REX 1', 'Wien Hbf', 'Břeclav', '06:04:00', '07:32:00', 19, NULL, NULL, 0),
(96, 'REX 1', 'Wien Hbf', 'Břeclav', '07:04:00', '08:32:00', 19, NULL, NULL, 0),
(97, 'REX 1', 'Wien Hbf', 'Břeclav', '08:04:00', '09:32:00', 19, NULL, NULL, 0),
(98, 'REX 1', 'Wien Hbf', 'Břeclav', '09:02:00', '10:29:00', 19, NULL, NULL, 0),
(99, 'REX 1', 'Wien Hbf', 'Břeclav', '10:04:00', '11:32:00', 19, NULL, NULL, 0),
(100, 'REX 1', 'Wien Hbf', 'Břeclav', '11:02:00', '12:29:00', 19, NULL, NULL, 0),
(101, 'REX 1', 'Wien Hbf', 'Břeclav', '12:02:00', '13:29:00', 19, NULL, NULL, 0),
(102, 'REX 1', 'Wien Hbf', 'Břeclav', '13:04:00', '14:32:00', 19, NULL, NULL, 0),
(103, 'REX 1', 'Wien Hbf', 'Břeclav', '14:02:00', '15:29:00', 19, NULL, NULL, 0),
(104, 'REX 1', 'Wien Hbf', 'Břeclav', '15:02:00', '16:29:00', 19, NULL, NULL, 0),
(105, 'REX 1', 'Wien Hbf', 'Břeclav', '16:02:00', '17:29:00', 19, NULL, NULL, 0),
(106, 'REX 1', 'Wien Hbf', 'Břeclav', '17:02:00', '18:29:00', 19, NULL, NULL, 0),
(107, 'REX 1', 'Wien Hbf', 'Břeclav', '18:02:00', '19:29:00', 19, NULL, NULL, 0),
(108, 'REX 1', 'Wien Hbf', 'Břeclav', '19:02:00', '20:29:00', 19, NULL, NULL, 0),
(109, 'REX 1', 'Wien Hbf', 'Břeclav', '20:02:00', '21:29:00', 19, NULL, NULL, 0),
(110, 'REX 1', 'Wien Hbf', 'Břeclav', '22:02:00', '23:29:00', 19, NULL, NULL, 0),
(111, 'RJ 258', 'Wien Hbf', 'Břeclav', '05:10:00', '06:04:00', 19, NULL, 31.9, 0),
(112, 'EC 106', 'Wien Hbf', 'Břeclav', '06:10:00', '07:04:00', 16.9, 24.9, NULL, 0),
(113, 'RJ 256', 'Wien Hbf', 'Břeclav', '07:10:00', '08:04:00', 13.9, 20.9, 25.9, 0),
(114, 'RJ 252', 'Wien Hbf', 'Břeclav', '11:10:00', '12:04:00', 15.9, 23.9, 29.9, 0),
(115, 'EC 204', 'Wien Hbf', 'Břeclav', '12:10:00', '13:04:00', 18.9, 27.9, NULL, 0),
(116, 'RJX 56', 'Wien Hbf', 'Břeclav', '15:10:00', '16:04:00', 17.9, 26.9, 33.9, 0),
(117, 'EC 202', 'Wien Hbf', 'Břeclav', '16:10:00', '17:04:00', 18.9, 27.9, NULL, 0),
(118, 'RJ 54', 'Wien Hbf', 'Břeclav', '17:10:00', '18:04:00', 13.9, 20.9, 25.9, 0),
(119, 'RJ 50', 'Wien Hbf', 'Břeclav', '21:10:00', '22:04:00', 18.9, 27.9, 35.9, 0),
(120, 'NJ 456', 'Wien Hbf', 'Břeclav', '22:10:00', '23:04:00', 15.9, 23.9, NULL, 0),
(121, 'IC 406', 'Wien Hbf', 'Břeclav', '23:19:00', '00:34:00', 16.9, 24.9, NULL, 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `hero_contents`
--
ALTER TABLE `hero_contents`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `teasers`
--
ALTER TABLE `teasers`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `trains`
--
ALTER TABLE `trains`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `hero_contents`
--
ALTER TABLE `hero_contents`
  MODIFY `id` bigint UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `teasers`
--
ALTER TABLE `teasers`
  MODIFY `id` bigint UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT for table `trains`
--
ALTER TABLE `trains`
  MODIFY `id` bigint UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=122;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
