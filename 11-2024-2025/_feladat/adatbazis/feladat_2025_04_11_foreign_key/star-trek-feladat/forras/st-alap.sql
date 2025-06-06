create database if not exists `startrek`
character set utf8
collate utf8_hungarian_ci;

use `startrek`;

CREATE TABLE hajo_osztalyok (
  osztaly_id int NOT NULL auto_increment,
  osztaly_nev varchar(20) NOT NULL,
  szerep_id int NOT NULL,
  CONSTRAINT pk_osztaly PRIMARY KEY (osztaly_id)
);

CREATE TABLE urhajok (
  urhajo_id int NOT NULL auto_increment,
  azonosito varchar(20) UNIQUE,
  urhajo_nev varchar(50) NOT NULL,
  osztaly_id int NOT NULL,
  faj_id int NOT NULL,
  CONSTRAINT pk_urhajok PRIMARY KEY (urhajo_id)
);

INSERT INTO `hajo_osztalyok` (`osztaly_id`, `osztaly_nev`, `szerep_id`) VALUES
(1, 'Constitution', 1),
(2, 'Defiant', 2),
(3, 'Drexia', 3),
(4, 'B\'rel', 4),
(5, 'Sarcophagus', 5),
(6, 'Danube', 6),
(7, 'Intrepid', 7),
(8, 'Nebula', 8),
(9, 'Excelsior', 1),
(10, 'Galaxy', 1),
(11, 'Nova', 7),
(12, 'Olympic', 7),
(13, 'Sovereign', 1),
(14, 'Ambassador', 1),
(15, 'Yorktown', 1),
(16, 'Odyssey', 8),
(17, 'Guardian', 1),
(18, 'NX', 9),
(19, 'Miranda', 1),
(20, 'Centaur', 9),
(21, 'ShiKahr', 9),
(22, 'Jupiter', 8),
(23, 'Zilant', 10),
(24, 'Balaur', 8),
(25, 'Khales', 11),
(26, 'Bortasqu', 11),
(27, 'Tulwar', 8),
(28, 'Chimera', 15),
(29, 'Ha\'apax', 10),
(30, 'D\'deridex', 8),
(31, 'Scoprion', 12),
(32, 'Scimitar', 8),
(33, 'Valdor', 13),
(34, 'Mogai', 13),
(35, 'Vesta', 14),
(36, 'Type 8', 6),
(37, 'Cube', 17),
(38, 'Sphere', 17),
(39, 'Diamond', 18),
(40, 'Tactical Cube', 17),
(41, 'Cardenas', 1),
(42, 'Malachowski', 1),
(43, 'Hoover', 1),
(44, 'Walker', 1),
(45, 'Nimitz', 1),
(46, 'Suurok', 1),
(47, 'Apolllo', 7),
(48, 'Type F', 6),
(49, 'Hermes', 16),
(50, 'Barkano', 3),
(51, 'Galor', 1),
(52, 'Ravinok', 3),
(53, 'Keldon', 1),
(54, 'Peregrine', 15),
(55, 'Bok\'Nor', 3),
(56, 'Selek', 3),
(57, 'Hideki', 6),
(58, 'K\'vort', 4),
(59, 'D12', 4),
(60, 'Sh\'vhal', 1),
(61, 'California', 19),
(62, 'Type 6A', 6),
(63, 'Galileo', 6),
(64, 'Type 7', 6),
(65, 'Type 6', 6),
(66, 'Engle', 1),
(67, 'Renaissance', 16),
(68, 'Type 15', 6),
(69, 'Constellation', 1),
(70, 'Crossfield', 16),
(71, 'Magee', 16),
(72, 'Dauntless', 16),
(73, 'Venatic', 20),
(74, 'Kumari', 11),
(75, 'Khyzon', 2),
(76, 'Charal', 2),
(77, 'Antares', 3),
(78, 'Daedalus', 1),
(79, 'Saladin', 26),
(80, 'Freedom', 9),
(81, 'Oberth', 7),
(82, 'Kelvin', 14),
(83, 'Reliant', 1),
(84, 'Shepard', 11),
(85, 'Sydney', 24),
(86, 'New Orleans', 9),
(87, 'D\'Kora', 10),
(88, 'D7', 11),
(89, 'Raptor', 16),
(90, 'Type 10', 6),
(91, 'Type 9', 6),
(92, 'Aerowing', 6),
(93, 'Janeway', 7),
(94, 'Zhang Sui', 6),
(95, 'T\'varo', 4),
(96, 'OTV type K42', 6),
(97, 'Type 18', 6),
(98, 'Type 18H', 6),
(99, 'Jem\'Hadar', 11),
(100, 'Perikan', 22),
(101, 'Akira', 1),
(102, 'Curry', 23),
(103, 'D5', 11),
(104, 'D\'ama (D4)', 11),
(105, 'Koloth', 11),
(106, 'Luna', 7),
(107, 'Norway', 23),
(108, 'Inquery', 10),
(109, 'Sutherland', 7),
(110, 'Syracuse', 26),
(111, 'Courage', 7),
(112, 'D\'Kyr', 1),
(113, 'D\'Kyr', 7),
(114, 'Sh\'Ran', 1),
(115, 'Maymora', 10),
(116, 'Spinner', 1),
(117, 'Vor\'cha', 1),
(118, 'Ranger', 16),
(119, 'QeHpu\'', 27),
(120, 'Thris', 7),
(121, 'Sevaijen', 27),
(122, 'Yravas', 12),
(123, 'Taholsin', 26),
(124, 'Tanathooef', 9),
(125, 'Thofsin', 1),
(126, 'Thozyn', 2),
(127, 'Plen Zha', 3),
(128, 'Fek\'lhr', 28),
(129, 'Qang', 29),
(130, 'Deresus', 29),
(131, 'Chel Grett', 11),
(132, 'Rezreth', 26),
(133, 'Plesh Brek', 9),
(134, 'Brinok', 1),
(135, 'Groumall', 3),
(136, 'Negh\'Var', 8);

INSERT INTO `urhajok` (`urhajo_id`,`azonosito`, `urhajo_nev`, `osztaly_id`, `faj_id`) VALUES
(1, 'NCC-1764', 'U.S.S. Defiant', 1, 1),
(2, 'NX-74205', 'U.S.S. Defiant', 2, 1),
(3, 'NCC-75633', 'U.S.S. Sao Paolo', 2, 1),
(4, NULL, 'Baxial', 3, 6),
(5, 'NCC-1701', 'U.S.S. Enterpsie', 1, 1),
(6, 'NCC-1717', 'U.S.S. Yorktown', 1, 1),
(7, NULL, 'I.K.S. Rotarran', 4, 2),
(8, NULL, 'Holtak hajója', 5, 2),
(9, NULL, 'U.S.S. Yangtzee King', 6, 1),
(10, 'NCC-74656', 'U.S.S. Voyager', 7, 1),
(11, 'NCC-62100', 'U.S.S. T\'Kumbra', 8, 1),
(12, 'NCC-42995', 'U.S.S. Al-Batani', 9, 1),
(13, 'NCC-71809', 'U.S.S. Musashi', 10, 1),
(14, 'NCC-38997', 'U.S.S. Malinche', 9, 1),
(15, 'NCC-71099', 'U.S.S. Challenger', 10, 1),
(16, 'NCC-72701', 'U.S.S. Rhode Island', 11, 1),
(17, 'NCC-58925', 'U.S.S. Pasteur', 12, 1),
(18, 'NCC-42768', 'U.S.S. Lakota', 9, 1),
(19, 'NCC-70637', 'U.S.S. Galaxy', 10, 1),
(20, 'NCC-1701-E', 'U.S.S. Enterprise-E', 13, 1),
(21, 'NCC-1701-D', 'U.S.S. Enterprise-D', 10, 1),
(22, 'NCC-1701-C', 'U.S.S. Enterprise-C', 14, 1),
(23, 'NCC-1701-A', 'U.S.S. Enterprise-A', 1, 1),
(24, 'NCC-1701-B', 'U.S.S. Enterprise-B', 9, 1),
(25, 'NCC-1701-F', 'U.S.S. Enterprise-F', 15, 1),
(26, 'NCC-97000', 'U.S.S. Odyssey', 16, 1),
(27, 'NCC-47503', 'U.S.S. Redoubt', 17, 1),
(28, 'NCC-97005', 'U.S.S. Verity', 16, 1),
(29, 'NCC-97284', 'U.S.S. Houston', 16, 1),
(30, 'NCC-71701-B', 'I.S.S. Odyssey', 16, 8),
(31, 'NX-01', 'Enterprise', 18, 9),
(32, 'NCC-31911', 'U.S.S. Saratoga', 19, 1),
(33, 'NCC-74559', 'U.S.S. Valor', 20, 1),
(34, 'NCC-91846', 'U.S.S. Warwick', 21, 1),
(35, 'NX-96100', 'U.S.S. Eridani', 22, 1),
(36, NULL, 'I.K.S. Skaut', 23, 10),
(37, NULL, 'G.H.S. S\'terras', 24, 10),
(38, NULL, 'I.K.S. Strazss', 23, 10),
(39, NULL, 'G.H.S. Hekallss', 24, 10),
(40, NULL, 'I.K.S. Batlh', 25, 2),
(41, NULL, 'I.K.S. Bortasqu\'', 26, 2),
(42, NULL, 'R.R.W. Lleiset', 27, 3),
(43, NULL, 'R.R.W. Deihu', 28, 3),
(44, NULL, 'R.R.W. Ar\'hael', 28, 3),
(45, NULL, 'R.R.W. Temanna', 29, 3),
(46, NULL, 'I.R.W. Scimitar', 32, 11),
(47, NULL, 'I.R.W. Valdore', 33, 3),
(48, NULL, 'I.R.W. Aethra', 34, 3),
(49, 'NCC-26253', 'U.S.S. Hotspur', 19, 1),
(50, 'NCC-82602', 'U.S.S. Aventine', 35, 1),
(51, 'NCC-75633-C', 'U.S.S. Belfast', 2, 1),
(52, 'NCC-97400', 'U.S.S. Chimera', 28, 1),
(53, 'NCC-66613', 'U.S.S. Khitomer', 13, 1),
(54, NULL, 'Tereshkova', 36, 1),
(55, NULL, 'Cube 461', 37, 5),
(56, NULL, 'Cube 630', 37, 5),
(57, NULL, 'Cube 1184', 37, 5),
(58, NULL, 'Sphere 634', 38, 5),
(59, NULL, 'Sphere 878', 38, 5),
(60, NULL, 'Tactical Cube 138', 40, 5),
(61, NULL, 'Borg királynő hajója', 39, 5),
(62, 'NCC-1422', 'U.S.S. Buran', 41, 1),
(63, 'NCC-1661', 'U.S.S. Clarke', 42, 1),
(64, 'NCC-1690', 'U.S.S. Dana', 43, 1),
(65, 'NCC-1227', 'U.S.S. Shenzhou', 44, 1),
(66, 'NCC-1274', 'U.S.S. Diwata', 44, 1),
(67, 'NCC-1226', 'U.S.S. Manaslu', 44, 1),
(68, 'NCC-1241', 'U.S.S. Tianzhou', 44, 1),
(69, 'NCC-1650', 'U.S.S. Ticonderoga', 45, 1),
(70, 'NCC-1647', 'U.S.S. Shinano', 45, 1),
(71, 'NCC-1508', 'U.S.S. Chew', 41, 1),
(72, 'NCC-1406', 'U.S.S. Ryan', 41, 1),
(73, 'NCC-1499', 'U.S.S. Supremacy', 10, 1),
(74, 'NCC-1437', 'U.S.S. Yeager', 41, 1),
(75, 'NCC-74600', 'U.S.S. Intrepid', 7, 1),
(76, NULL, 'Ni\'Var', 46, 7),
(77, NULL, 'Ti\'Mur', 46, 7),
(78, NULL, 'Sh\'Raan', 46, 7),
(79, 'NCC-11574', 'U.S.S. Ajax', 47, 1),
(80, 'NSP-17938', 'T\'Pau', 47, 7),
(81, 'NCC-1672', 'U.S.S. Exeter', 1, 1),
(82, 'NCC-26136', 'U.S.S. Zhukov', 14, 1),
(83, 'NCC-26510', 'U.S.S. Yamaguchi', 14, 1),
(84, 'NCC-26517', 'U.S.S. Excalibur', 14, 1),
(85, 'NCC-26531', 'U.S.S. Exeter', 14, 1),
(86, 'NCC-1648', 'U.S.S. Europa', 45, 1),
(87, 'NCC-1683', 'U.S.S. Edison', 43, 1),
(88, 'NCC-1701/02', 'Colombus', 48, 1),
(89, 'SB4-0314/02', 'da Vinci', 48, 1),
(90, 'SB11-1201/01', 'Picasso', 48, 1),
(91, 'NCC-1631/04', 'Setar', 48, 1),
(92, 'NCC-1631', 'U.S.S. Intrepid', 1, 1),
(93, 'NCC-1701/06', 'Einstein', 48, 1),
(94, 'NCC-1701/07', 'Galileo', 48, 1),
(95, 'NCC-595', 'U.S.S. Revere', 49, 1),
(96, 'NCC-621', 'U.S.S. Columbia', 49, 1),
(97, 'NCC-1837', 'U.S.S. Lantree', 19, 1),
(98, 'NCC-1877', 'U.S.S. McDuff', 19, 1),
(99, 'NCC-9844', 'U.S.S. Antares', 19, 1),
(100, 'NCC-21166', 'U.S.S. Brattain', 19, 1),
(101, 'NCC-31060', 'U.S.S. Majestic', 19, 1),
(102, 'NCC-31910', 'U.S.S. Nautilus', 19, 1),
(103, 'NCC-1864', 'U.S.S. Reliant', 19, 1),
(104, 'NCC-1887', 'U.S.S. Saratoga', 19, 1),
(105, 'NCC-31905', 'U.S.S. ShirKhar', 19, 1),
(106, 'NCC-32591', 'U.S.S. Sitak', 19, 1),
(107, 'NCC-21382', 'U.S.S. Tian An Men', 19, 1),
(108, 'NCC-1948', 'U.S.S. Trial', 19, 1),
(109, 'AS-502', 'AS-502', 92, 1),
(110, 'NCC-66808', 'U.S.S. Ulysses', 8, 1),
(111, 'NCC-61952', 'U.S.S. Proxima', 8, 1),
(112, 'NCC-62006', 'U.S.S. Hera', 8, 1),
(113, 'NCC-71805', 'U.S.S. Endeavour', 8, 1),
(114, 'NCC-72015', 'U.S.S. Sutherland', 8, 1),
(115, NULL, 'Barkano', 50, 12),
(116, NULL, 'Rabol', 50, 12),
(117, NULL, 'Aldara', 51, 12),
(118, NULL, 'Kraxon', 51, 12),
(119, NULL, 'Prakesh', 51, 12),
(120, NULL, 'Reklar', 51, 12),
(121, NULL, 'Trager', 51, 12),
(122, NULL, 'Vetar', 51, 12),
(123, NULL, 'Ravinok', 52, 12),
(124, NULL, 'Koranak', 53, 12),
(125, NULL, 'Bok\'Nor', 55, 12),
(126, 'CUF-2700', 'Groumall', 56, 12),
(127, NULL, 'C.D.S. Kornaire', 57, 12),
(128, NULL, 'I.K.S. Koraga', 58, 2),
(129, NULL, 'Che\'Ta\'', 59, 2),
(130, NULL, 'Sh\'vhal', 60, 7),
(131, 'NCC-75567', 'U.S.S. Cerritos', 61, 1),
(132, 'NCC-87075', 'U.S.S. Merced', 61, 1),
(133, 'NCC-12109', 'U.S.S. Rubidoux', 61, 1),
(134, NULL, 'Galileo', 62, 1),
(135, 'NCC-1701-D/15', 'Hawking', 62, 1),
(136, 'NCC-1701-A/03', 'Copernicus', 62, 1),
(137, 'NCC-72381', 'U.S.S. Equinox', 11, 1),
(138, 'NCC-1004', 'U.S.S. T\'Plana-Hath', 66, 1),
(139, NULL, 'U.S.S. Earhart', 66, 1),
(140, NULL, 'Onizuka', 68, 1),
(141, 'NCC-45167', 'U.S.S. Aries', 67, 1),
(142, 'NCC-45167/20', 'Cousteau', 68, 1),
(143, 'NCC-9754', 'U.S.S. Victory', 69, 1),
(144, 'NCC-2593', 'U.S.S. Hathaway', 69, 1),
(145, 'NCC-2893', 'U.S.S. Stargazer', 69, 1),
(146, 'NX-1974', 'U.S.S. Constellation', 69, 1),
(147, 'NCC-71201', 'U.S.S. Prometheus', 11, 1),
(148, 'NCC-1031', 'U.S.S. Discovery', 70, 1),
(149, 'NCC-1031-A', 'U.S.S. Discovery', 70, 1),
(150, 'NCC-1701-D/06', 'Ansel Adams', 64, 1),
(151, 'NCC-1413', 'U.S.S. Shran', 71, 1),
(152, NULL, 'U.S.S. Cabot', 71, 1),
(153, 'NCC-80816', 'U.S.S. Dauntless', 72, 1),
(154, 'NX-01-A', 'U.S.S. Dauntless', 72, 1),
(155, NULL, 'I.G.S. Kumari', 74, 16),
(156, NULL, 'I.G.S. Shashpar', 74, 16),
(157, 'AGC-7-19', 'U.S.S. Docana', 74, 1),
(158, 'AGC-7-48', 'U.S.S. Thelasa-vei', 74, 1),
(159, NULL, 'U.S.S. Vinakthen', 74, 1),
(160, 'AGC-7-10', 'U.S.S. Vol\'Rala', 74, 1),
(161, NULL, 'U.S.S. Khyzon', 75, 1),
(162, NULL, 'U.S.S. Charal', 76, 1),
(163, 'AGC-7-45', 'U.S.S. Atlirith', 74, 1),
(164, NULL, 'I.K.S. Ning\'tao', 4, 2),
(165, NULL, 'I.K.S. Orantho', 4, 2),
(166, NULL, 'I.K.C. Buruk', 58, 2),
(167, 'IKC-95295', 'I.K.S. Pagh', 58, 2),
(168, NULL, 'I.K.S. Lukara', 58, 2),
(169, 'NCC-173', 'U.S.S. Essex', 78, 1),
(170, 'NCC-176', 'U.S.S. Horizon', 78, 1),
(171, 'NCC-325', 'U.S.S. Woden', 77, 1),
(172, 'NCC-330', 'U.S.S. Yorkshire', 77, 1),
(173, 'NCC-1951', 'U.S.S. Senzig', 77, 1),
(174, 'NCC-44278', 'U.S.S. Archer', 9, 1),
(175, 'NX-326', 'U.S.S. Franklin', 80, 1),
(176, 'NCC-602', 'U.S.S. Oberth', 81, 1),
(177, 'NCC-638', 'U.S.S. Grissom', 81, 1),
(178, 'NCC-640', 'U.S.S. Copernicus', 81, 1),
(179, 'NCC-1657', 'U.S.S. Potemkin', 1, 1),
(180, 'NCC-0514', 'U.S.S. Kelvin', 82, 1),
(181, 'NCC-1017', 'U.S.S. Constellation', 1, 1),
(182, 'NCC-1030', 'U.S.S. Glenn', 70, 1),
(183, 'NCC-1664', 'U.S.S. Excalibur', 1, 1),
(184, 'NCC-1664-M', 'U.S.S. Excalibur', 1, 1),
(185, 'NCC-1703', 'U.S.S. Hood', 1, 1),
(186, 'NCC-1709', 'U.S.S. Lexington', 1, 1),
(187, 'NCC-1856', 'U.S.S. Emden', 1, 1),
(188, 'NCC-1895', 'U.S.S. Endeavour', 1, 1),
(189, 'NCC-2014', 'U.S.S. Korolev', 1, 1),
(190, 'NCC-2048', 'U.S.S. Ahwahnee', 1, 1),
(191, 'NCC-19002', 'U.S.S. Yosemite', 81, 1),
(192, 'NCC-29487', 'U.S.S. Raman', 81, 1),
(193, 'NCC-31600', 'U.S.S. Bonestell', 81, 1),
(194, 'NCC-45231', 'U.S.S. Hornet', 67, 1),
(195, 'NCC-53847', 'U.S.S. Pegasus', 81, 1),
(196, 'NCC-53911', 'SS Tsiolkovsky', 81, 1),
(197, 'NCC-59318', 'U.S.S. Cochrane', 81, 1),
(198, 'NCC-72452', 'U.S.S. Rio Grande', 6, 1),
(199, 'NCC-72454', 'U.S.S. Ganges', 6, 1),
(200, 'NCC-72936', 'U.S.S. Rubicon', 6, 1),
(201, 'NCC-73024', 'U.S.S. Shenandoah', 6, 1),
(202, 'NCC-317856', 'U.S.S. Armstrong', 1, 1),
(203, 'NCC-325002', 'U.S.S. Noble', 1, 1),
(204, 'NCC-90200', 'U.S.S. Reliant', 83, 1),
(205, 'NCC-90206', 'U.S.S. Clark', 83, 1),
(206, 'NCC-90214', 'U.S.S. Uhura', 83, 1),
(207, 'NCC-71807', 'U.S.S. Yamato', 10, 1),
(208, 'NCC-71832', 'U.S.S. Odyssey', 10, 1),
(209, 'NCC-71854', 'U.S.S. Venture', 10, 1),
(210, 'NCC-74210', 'U.S.S. Valiant', 2, 1),
(211, 'NCC-74107', 'U.S.S. Okuda', 13, 1),
(212, 'NCC-74181', 'U.S.S. Pachacuti', 13, 1),
(213, 'NCC-74669', 'U.S.S. Gilgamesh', 13, 1),
(214, 'NCC-74877', 'U.S.S. Valkyrie', 13, 1),
(215, 'NCC-74957', 'U.S.S. Hutchinson', 13, 1),
(216, 'NCC-74975', 'U.S.S. Hrothgar', 13, 1),
(217, 'NCC-75306', 'U.S.S. Venture', 13, 1),
(218, 'NCC-75307', 'U.S.S. Arsinoe', 13, 1),
(219, 'NCC-1255', 'U.S.S. Kerala', 84, 1),
(220, 'NCC-1309', 'U.S.S. Gagarin', 84, 1),
(221, 'NCC-2010', 'U.S.S. Jenolan', 85, 1),
(222, 'NCC-2010-5', 'U.S.S. Nash', 85, 1),
(223, 'NCC-2000', 'U.S.S. Excelsior', 9, 1),
(224, 'NCC-2544', 'U.S.S. Repulse', 9, 1),
(225, 'NCC-14232', 'U.S.S. Berlin', 9, 1),
(226, 'NCC-14598', 'U.S.S. Fearless', 9, 1),
(227, 'NCC-18253', 'U.S.S. Potemkin', 9, 1),
(228, 'NCC-42111', 'U.S.S. Fredrickson', 9, 1),
(229, 'NCC-42285', 'U.S.S. Charleston', 9, 1),
(230, 'NCC-42296', 'U.S.S. Hood', 9, 1),
(231, 'NCC-43305', 'U.S.S. Valley Forge', 9, 1),
(232, 'NCC-62043', 'U.S.S. Melbourne', 9, 1),
(233, 'NCC-74705', 'U.S.S. Bellerophon', 7, 1),
(234, 'NCC-65491', 'U.S.S. Kyushu', 86, 1),
(235, 'NCC-65530', 'U.S.S. Thomas Paine', 86, 1),
(236, 'NCC-60205', 'U.S.S. Honshu', 8, 1),
(237, 'NCC-60597', 'U.S.S. Farragut', 8, 1),
(238, 'NCC-61826', 'U.S.S. Monitor', 8, 1),
(239, 'NCC-61827', 'U.S.S. Merrimac', 8, 1),
(240, 'NCC-62048', 'U.S.S. Bellerophon', 8, 1),
(241, 'NCC-65420', 'U.S.S. Phoenix', 8, 1),
(242, 'NCC-70352', 'U.S.S. Leeds', 8, 1),
(243, 'NCC-70915', 'U.S.S. Bonchune', 8, 1),
(244, 'NCC-12101', 'U.S.S. Solvang', 61, 1),
(245, NULL, 'Krayton', 87, 16),
(246, NULL, 'Kreechta', 87, 16),
(247, NULL, 'I.K.S. Devisor', 88, 2),
(248, 'NCC-12537', 'U.S.S. Clement', 47, 1),
(249, 'IKC-4175', 'I.K.S. Gr\'oth', 88, 2),
(250, NULL, 'I.K.S. Klothos', 88, 2),
(251, ' IKS-173', 'I.K.S. Somraw', 89, 2),
(252, 'IKS-294', 'I.K.S. Veng', 89, 2),
(253, NULL, 'I.K.S. Ves Batlh', 89, 2),
(254, 'IKS-155', 'I.K.S. Rok\'lor', 89, 2),
(255, 'IKS-319', 'I.K.S. R\'mora', 89, 2),
(256, 'IKS-566', 'I.K.S. Patan', 89, 2),
(257, 'IKS-162', 'I.K.S. Nu\'Tal ', 89, 2),
(258, 'IKS-409', 'I.K.S. Nu\'paH', 89, 2),
(259, 'IKS-424', 'I.K.S. K\'eylat', 89, 2),
(260, 'NX-74205/01', 'Chaffee', 90, 1),
(261, 'NCC-1701-D/14', 'Goddard', 65, 1),
(262, 'NCC-74656/04', 'Cochrane', 91, 1),
(263, 'AS-501', 'AS-501', 92, 1),
(264, 'AS-503', 'AS-503', 92, 1),
(265, 'AS-506', 'AS-506', 92, 1),
(266, 'AS-508', 'AS-508', 92, 1),
(267, 'AS-509', 'AS-509', 92, 1),
(268, 'IKS-312', 'I.K.S. K\'araH', 89, 2),
(269, 'IKS-302', 'I.K.S. Gantin', 89, 2),
(270, 'AS-511', 'AS-511', 92, 1),
(271, 'IKS-453', 'I.K.S. Dit\'kra', 89, 2),
(272, 'IKS-284', 'I.K.S. Bokor', 89, 2),
(273, 'IKS-209', 'I.K.S. Barak', 89, 2),
(274, 'AS-514', 'AS-514', 92, 1),
(275, 'IKS-114', 'I.K.S. Balth', 89, 2),
(276, 'IKS-127', 'I.K.S. Amw\'I', 89, 2),
(277, 'AS-515', 'AS-515', 92, 1),
(278, 'NCC-74656-J', 'U.S.S. Voyager', 93, 1),
(279, 'NCC-1701/09', 'Zhang Sui', 93, 1),
(280, 'NCC-30405', 'U.S.S. Lexington', 8, 1),
(281, NULL, 'I.R.W. Eisn', 95, 3),
(282, NULL, 'I.R.W. Sharrdar', 95, 3),
(283, NULL, 'I.R.W. M\'sarr', 95, 3),
(284, NULL, 'R.F.V. Rerik', 95, 11),
(285, 'NC-05', 'NC-05', 96, 1),
(286, 'SC-04', 'SC-04', 98, 1),
(287, NULL, 'Tenak\'talar', 99, 4),
(288, NULL, 'Vessel 6474', 99, 4),
(289, NULL, 'Deneiros', 100, 18),
(290, NULL, 'Kitara', 100, 18),
(291, 'NCC-63284', 'U.S.S. Helios', 101, 1),
(292, 'NCC-63293', 'U.S.S. Rabin', 101, 1),
(293, 'NCC-63549', 'U.S.S. Thunderchild', 101, 1),
(294, 'NCC-63887', 'U.S.S. Avalon', 101, 1),
(295, 'NCC-63719', 'U.S.S. James T. Kirk', 101, 1),
(296, 'NCC-62497', 'U.S.S. Akira', 101, 1),
(297, 'NCC-62501', 'U.S.S. Geronimo', 101, 1),
(298, 'NCC-62743', 'U.S.S. Osceola', 101, 1),
(299, 'NCC-42254', 'U.S.S. Curry', 102, 1),
(300, 'NCC-42264', 'U.S.S. Raging Queen', 102, 1),
(301, NULL, 'I.K.S. Bortas', 103, 2),
(302, NULL, 'I.K.S. Che\'leth', 103, 2),
(303, NULL, 'I.K.S. Haj', 103, 2),
(304, NULL, 'I.K.S. Mirror', 103, 2),
(305, NULL, 'I.K.S. PeD NIHwI\'', 103, 2),
(306, NULL, 'I.K.S. Ash\'Nazg', 104, 2),
(307, NULL, 'I.K.S. Butlh', 104, 2),
(308, NULL, 'I.K.S. Daghaj\'a', 105, 2),
(309, NULL, 'I.K.S. DaHaghmoH', 105, 2),
(310, NULL, 'I.K.S. DaHa\'qu\'mo', 105, 2),
(311, NULL, 'I.K.S. Hab Quch', 105, 2),
(312, NULL, 'I.K.S. Ha\'ghach', 105, 2),
(313, NULL, 'I.K.S. JaghHeyvam', 105, 2),
(314, NULL, 'I.K.S. Lurghvetlh', 105, 2),
(315, NULL, 'I.K.S. Mu\'qaD', 105, 2),
(316, NULL, 'I.K.S. Nijbogh', 105, 2),
(317, NULL, 'I.K.S. Nodlljwo', 105, 2),
(318, NULL, 'I.K.S. Nuqjatlh', 105, 2),
(319, NULL, 'I.K.S. PuqloD', 105, 2),
(320, NULL, 'I.K.S. Qaghovchu', 105, 2),
(321, NULL, 'I.K.S. QaHeQnes', 105, 2),
(322, NULL, 'I.K.S. Qapla\'jImaw', 105, 2),
(323, NULL, 'I.K.S. QaSlahHbe', 105, 2),
(324, NULL, 'I.K.S. QuvDaq', 105, 2),
(325, NULL, 'I.K.S. RurmeH', 105, 2),
(326, NULL, 'I.K.S. SoHvad', 105, 2),
(327, NULL, 'I.K.S. SoQ Quaw\'Dl', 105, 2),
(328, NULL, 'I.K.S. Supawpu', 105, 2),
(329, NULL, 'I.K.S. Yaghna', 105, 2),
(330, 'NCC-80102', 'U.S.S. Titan', 106, 1),
(331, 'NCC-80103', 'U.S.S. Oberon', 106, 1),
(332, 'NCC-80104', 'U.S.S. Europa', 106, 1),
(333, 'NCC-80105', 'U.S.S. Io', 106, 1),
(334, 'NCC-80106', 'U.S.S. Triton', 106, 1),
(335, 'NCC-80107', 'U.S.S. Ganymede', 106, 1),
(336, 'NCC-80108', 'U.S.S. Amalthea', 106, 1),
(337, 'NCC-80109', 'U.S.S. Callisto', 106, 1),
(338, 'NCC-80110', 'U.S.S. Rhea', 106, 1),
(339, 'NCC-80111', 'U.S.S. Charon', 106, 1),
(340, 'NCC-80112', 'U.S.S. Galatea', 106, 1),
(341, 'NCC-64923', 'U.S.S. Budapest', 107, 1),
(342, NULL, 'U.S.S. Norway', 107, 1),
(343, NULL, 'U.S.S. Endeavour', 107, 1),
(344, NULL, 'U.S.S. Endeavour', 101, 1),
(346, 'NCC-86501', 'U.S.S. Nathan Hale', 108, 1),
(347, 'NCC-86503', 'U.S.S. Rustazh', 108, 1),
(348, 'NCC-86505', 'U.S.S. Zheng He', 108, 1),
(349, 'NCC-86509', 'U.S.S. Magellan', 108, 1),
(350, 'NCC-86517', 'U.S.S. Shackleton', 108, 1),
(351, 'NCC-91800', 'U.S.S. Sutherland', 109, 1),
(352, 'NCC-91814', 'U.S.S. Huygens', 109, 1),
(353, 'NCC-91870', 'U.S.S. Almagest', 109, 1),
(354, 'NCC-91965', 'U.S.S. Ibn al-Haytham', 109, 1),
(355, 'NCC-189', 'U.S.S. Archon', 78, 1),
(356, 'NCC-150', 'U.S.S. Zheng He', 78, 1),
(357, NULL, 'U.S.S. Freedom', 80, 1),
(358, 'NCC-68711', 'U.S.S. Concord', 80, 1),
(359, 'NCC-68723', 'U.S.S. Firebrand', 80, 1),
(360, 'NCC-63102', 'U.S.S. Renegade', 86, 1),
(361, 'NCC-57295', 'U.S.S. Rutledge', 86, 1),
(362, NULL, 'U.S.S. Santa Fe', 86, 1),
(363, NULL, 'U.S.S. Arnold', 86, 1),
(364, NULL, 'U.S.S. Herbert', 86, 1),
(365, NULL, 'U.S.S. Jefferson', 86, 1),
(366, NULL, 'U.S.S. Savannah', 86, 1),
(367, NULL, 'U.S.S. Tokyo', 86, 1),
(368, NULL, 'U.S.S. Yudhisthira', 86, 1),
(369, 'NCC-503', 'U.S.S. Alaric', 79, 1),
(370, 'NCC-505', 'U.S.S. Xerxes', 79, 1),
(371, 'NCC-510', 'U.S.S. Tamerlane', 79, 1),
(372, 'NCC-515', 'U.S.S. Adad', 79, 1),
(373, 'NCC-513', 'U.S.S. Ahriman', 79, 1),
(374, 'NCC-511', 'U.S.S. Alexander', 79, 1),
(375, 'NCC-517', 'U.S.S. Azrael', 79, 1),
(376, 'NCC-502', 'U.S.S. Darius', 79, 1),
(377, 'NCC-509', 'U.S.S. Etzel', 79, 1),
(378, 'NCC-518', 'U.S.S. Hamilcar', 79, 1),
(379, 'NCC-512', 'U.S.S. Hannibal', 79, 1),
(380, 'NCC-516', 'U.S.S. Hashinhiyun', 79, 1),
(381, 'NCC-501', 'U.S.S. Jenghiz', 79, 1),
(382, 'NCC-507', 'U.S.S. Kublai', 79, 1),
(383, 'NCC-424', 'U.S.S. Pompeii', 110, 1),
(384, 'NCC-506', 'U.S.S. Pompey', 79, 1),
(385, 'NCC-514', 'U.S.S. Rahman', 79, 1),
(386, 'NCC-500', 'U.S.S. Salain', 79, 1),
(387, 'NCC-420', 'U.S.S. Syracuse', 110, 1),
(388, 'NCC-504', 'U.S.S. Sargon', 79, 1),
(389, 'NCC-508', 'U.S.S. Suleman', 79, 1),
(390, 'NCC-585', 'U.S.S. Hermes', 49, 1),
(391, 'NCC-1265', 'U.S.S. Ride', 84, 1),
(392, 'NCC-1275', 'U.S.S. Antioch', 84, 1),
(393, 'NCC-1291', 'U.S.S. Stalwart', 84, 1),
(394, 'NCC-1303', 'U.S.S. Warspite', 84, 1),
(395, NULL, 'Wayfarer', 3, 6),
(396, 'NCC-325084', 'U.S.S. Song', 111, 1),
(397, 'NCC-325072', 'U.S.S. Hansondo', 111, 1),
(398, 'NCC-325068', 'U.S.S. Jubary', 111, 1),
(399, 'NCC-82617', 'U.S.S. Capitoline', 14, 1),
(401, 'NCC-14934', 'U.S.S. Tecumseh', 9, 1),
(402, NULL, 'G.H.S. Menakk', 24, 10),
(403, NULL, 'G.H.S. Yanss', 24, 10),
(404, NULL, 'G.H.S. Ythannak', 24, 10),
(405, 'CUW-8000', 'C.D.S. Kaldon', 51, 12),
(406, 'CUW-8132', 'C.D.S. Borano', 51, 12),
(407, 'CUW-80012', 'C.D.S. Sudanit', 51, 12),
(408, 'CUW-80009', 'C.D.S. Nammar', 51, 12),
(409, 'CUW-80004', 'C.D.S. Okara', 51, 12),
(410, NULL, 'D.F.C. D\'Kyr', 112, 7),
(411, NULL, 'D.F.C. Seleya', 112, 7),
(412, NULL, 'D.F.C. Sepok', 112, 7),
(413, NULL, 'D.F.C. Tal\'Kir', 112, 7),
(414, NULL, 'V.S.S. Soval', 113, 7),
(415, NULL, 'V.S.S. T\'Androma', 113, 7),
(416, NULL, 'V.S.S. T\'Pau', 113, 7),
(417, NULL, 'D.D.V. Toth', 114, 7),
(418, NULL, 'D.D.V. T\'Jal', 114, 7),
(419, NULL, 'Karik-tor', 113, 7),
(420, NULL, 'Yarahla', 113, 7),
(421, NULL, 'Narqal', 114, 18),
(422, NULL, 'Tholia One', 114, 18),
(423, 'IKC-11563', 'I.K.S. Drovana', 114, 2),
(424, 'IKC-11574', 'I.K.S. Maht-H\'a', 114, 2),
(425, 'IKC-11546', 'I.K.S. Bortas', 114, 2),
(426, 'IKC-11478', 'I.K.S. R\'kang', 114, 2),
(427, 'IKC-11678', 'I.K.S. Kohna', 114, 2),
(428, 'IKC-11274', 'I.K.S. T\'kora', 114, 2),
(429, 'IKC-11673', 'I.K.S. K\'elest', 114, 2),
(430, 'IKC-11233', 'I.K.S. Key\'vong', 114, 2),
(431, 'IKC-11452', 'I.K.S. Mahk\'tar', 114, 2),
(432, 'IKC-11515', 'I.K.S. Toh\'Kaht', 114, 2),
(433, 'IKC-11500', 'I.K.S. Vor\'cha', 114, 2),
(434, 'IKC-11544', 'I.K.S. Vor\'nak', 114, 2),
(435, 'IKC-11553', 'I.K.S. Ya\'Vang', 114, 2),
(436, 'NCC-42043', 'U.S.S. Centaur', 20, 1),
(437, 'NCC-42076', 'U.S.S. Boston', 20, 1),
(438, 'NCC-42050', 'U.S.S. Carolina', 20, 1),
(439, 'NCC-42059', 'U.S.S. Madrid', 20, 1),
(440, NULL, 'U.S.S. Arimathea', 20, 1),
(441, NULL, 'U.S.S. Constant', 101, 1),
(442, NULL, 'U.S.S. Ranger', 8, 1),
(443, 'NCC-315', 'U.S.S. Ranger', 118, 1),
(444, 'NCC-1404', 'U.S.S. Alka-Selsior', 9, 1),
(445, 'NCC-1656',	'U.S.S. Tokyo', 19, 1),
(446,	'NCC-1800',	'U.S.S. Miranda',	19, 1),
(447,	'NCC-1801',	'U.S.S. Prospero', 19, 1),
(448,	'NCC-1805-C', 'I.S.S. Miranda', 19, 8),
(449,	'NCC-1805-B', 'U.S.S. Miranda', 19, 1),
(450,	'NCC-26276', 'U.S.S. Circee', 19, 1),
(451, 'NCC-1893',	'I.S.S. Treacherus', 19, 8),
(452,	NULL,	'A.S.C. Shraa\'jath', 120, 15),
(453,	NULL,	'I.K.S. QeHpu\'', 119, 2),
(454,	NULL,	'A.S.C. Amdaroth', 120, 15),
(455,	NULL,	'A.S.C. Gilinar', 120, 15),
(456,	NUll,	'A.S.C. Thris', 120, 15),
(457,	NULL,	'I.K.S. Orantho',	119, 2),
(458,	'AGC-6-16',	'U.S.S. Flabbjellah', 121, 1),
(459,	'AGC-6-34', 'U.S.S. Kinaph', 121, 1),
(460, 'AGC-6-38', 'U.S.S. Thejat', 121, 1),
(461,	'AGC-6-49',	'U.S.S. Trenkanshent sh\'Lavan', 121, 1),
(462, NULL, 'U.S.S. Thozyn', 126, 1),
(463,	NULL,	'I.V.S. Daqtagh',	128, 2),
(464,	NULL,	'I.V.S. Fek\'lhr',	128, 2),
(465,	NULL,	'I.V.S. Ghanjaq',	128, 2),
(466,	'IKC-12007', 'I.K.S. Azetbur', 129,	2),
(467,	'IKC-12009', 'I.K.S. Ditagh', 129, 2),
(468, 'IKC-12001', 'I.K.S. Gorkon', 129, 2),
(469, 'IKC-12003', 'I.K.S. Gowron', 129, 2),
(470,	'IKC-12004', 'I.K.S. Kaarg', 129, 2),
(471, 'IKC-12005', 'I.K.S. Kesh', 129, 2),
(472,	'IKC-12006', 'I.K.S. K\'mpec', 129, 2),
(473, 'IKC-12002', 'I.K.S. Kravokh', 129, 2),
(474, 'IKC-12008', 'I.K.S. Sturka', 129, 2),
(475,	NULL,	'R.I.S. Averek', 130, 3),
(476,	NULL, 'R.I.S. D\'jarek',	130, 3),
(477,	NULL,	'R.I.S. Deretak', 130, 3),
(478,	NULL,	'R.I.S. Suterak',	130, 3),
(479,	NULL,	'R.I.S. T\'varian', 130,	3),
(480,	NULL,	'R.I.S. Torelan',	130, 3),
(481,	NULL,	'R.I.S. V\'tirex',	130, 3),
(482,	NULL,	'R.I.S. Vurin', 130, 3),
(483,	'FAM-288', 'F.M.S. Braktel', 87, 16),
(484,	'FAM-360', 'F.M.S. D\'Kora', 87, 16),
(485,	'FAM-634', 'F.M.S. Domu', 87,	16),
(486,	'Bravo 8', 'Gor Korus', 131, 13),
(487,	'FAM-725', 'F.M.S. Kraloor', 87, 16),
(488,	'FAM-682', 'F.M.S. Zedavaton', 87, 16),
(489,	'FAM-522', 'F.M.S. Qartum', 87, 16),
(490,	'FAM-645', 'F.M.S. Mroxor', 87, 16),
(491,	'Bravo 7', 'Braaktak Gaal', 131, 13),
(492,	'FAM-936', 'F.M.S. Kramora', 87, 16),
(493,	'Bravo 1', 'Megal Taan', 131, 13),
(494,	NULL, 'Istapp', 132, 13),
(495,	'Bravo 3', 'Gor Nivik',	131, 13),
(496,	'Bravo 9', 'Gor Tevik',	131, 13),
(497,	NULL,	'B.R.E. Onslaught', 132, 13),
(498,	'Bravo 6', 'Reel Gorvaal', 131, 13),
(499, 'Bravo 5', 'Reel Tivaan', 131, 13),
(500,	NULL,	'Torzat', 133, 13),
(501,	'CUF-2722',	'C.D.S. Ashell', 135, 12),
(502,	'CUF-2714',	'C.D.S. Dromell',	135, 12),
(503,	'CUF-2725',	'C.D.S. Enell', 135, 12),
(504,	'CUF-2710',	'C.D.S. Entara', 135, 12),
(505,	'CUW-8100',	'C.D.S. Galor', 51, 12),
(506,	'CUW-8130',	'C.D.S. Hanund', 53, 12),
(507,	'CUF-2702',	'C.D.S. Indra', 135, 12),
(508,	'CUF-2719',	'C.D.S. Ketlor', 135, 12),
(509,	'CUF-2731',	'C.D.S. Maldor', 135, 12),
(510,	'OOW-80013', 'C.D.S. Morag', 53, 12),
(511,	'OOW-80009', 'C.D.S. Nammar',	53, 12),
(512,	NULL,	'C.D.S.Nazirbakkhu', 134, 12),
(513,	NULL,	'C.D.S. Neri', 134, 12),
(514,	'OOW-80004', 'C.D.S. Okara', 53, 12),
(515,	NULL,	'C.D.S. Otheon', 57, 12),
(516,	NULL,	'C.D.S. Orkonil',	57, 12),
(517,	NULL,	'C.D.S. Okalay', 57, 12),
(518,	'CUW-8512',	'C.D.S. Rajan', 51, 12),
(519,	'OOX-90100', 'C.D.S. Rildon',	53, 12),
(520,	'CUW-8154',	'C.D.S. Reklar', 51, 12),
(521,	'OOW-80005', 'C.D.S. Sinalan', 53, 12),
(522,	'OOW-80012', 'C.D.S. Sudanit', 53, 12),
(523,	'CUF-2705',	'C.D.S. Tachiman', 135, 12),
(524,	'CUF-2706',	'C.D.S. Varan', 135, 12),
(525,	'CUW-8151',	'C.D.S. Zalkan', 53, 12),
(529,	'KL-1017', 'I.K.S. Hakkarl', 88, 2),
(530,	'KL-1018', 'I.K.S. Tazhat', 4, 2),
(531,	'IKC-4176',	'I.K.S. Klolode',	88, 2),
(532,	'IKC-5502',	'I.K.S. Korvat', 88, 2),
(533,	'IKC-7736',	'I.K.S. Amar', 88, 2),
(534,	'IKC-7739',	'I.K.S. B\'Moth', 88, 2),
(535,	'IKC-9200',	'I.K.S. B\'rel', 4, 2),
(536,	'IKC-9237',	'I.K.S. Ch\'Tang',	4, 2),
(537,	'IKC-7001',	'I.K.S. HaH\'vat',	88, 2),
(538,	'IKS-7503',	'I.K.S. Hegh\'mar', 136,	2),
(539,	'IKC-55342', 'I.K.S. Hegh\'ta', 58, 2),
(540, 'IKC-1167', 'I.K.S. K\'elric', 88, 2);