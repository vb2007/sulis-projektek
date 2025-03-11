DROP DATABASE IF EXISTS `serulekenyseg`;

CREATE DATABASE IF NOT EXISTS `serulekenyseg`
DEFAULT CHARACTER SET utf8 
COLLATE utf8_hungarian_ci;

USE serulekenyseg;

DROP TABLE IF EXISTS `eszlelesek`;

CREATE TABLE `eszlelesek` (
  `eszleles_id` int(11) NOT NULL,
  `host_id` int(11),
  `vuln_id` int(11),
  `elso_eszleles` date,
  `utolso_eszleles` date,
  `javitva` tinyint(1) DEFAULT 0
);

INSERT INTO `eszlelesek` (`eszleles_id`, `host_id`, `vuln_id`, `elso_eszleles`, `utolso_eszleles`, `javitva`) VALUES
(1, 2, 1, '2022-12-08', '2022-12-11', 0),
(2, 1, 2, '2022-12-08', '2022-12-11', 0),
(3, 2, 2, '2022-12-08', '2022-12-09', 0),
(4, 2, 2, '2022-12-08', '2022-12-09', 0),
(5, 3, 2, '2022-12-08', '2022-12-09', 0),
(6, 6, 2, '2022-12-08', '2022-12-09', 0),
(7, 5, 2, '2022-12-08', '2022-12-09', 0),
(8, 4, 2, '2022-12-08', '2022-12-09', 0),
(9, 7, 2, '2022-12-08', '2022-12-09', 0),
(10, 8, 2, '2022-12-08', '2022-12-10', 0),
(11, 9, 2, '2022-12-08', '2022-12-09', 0),
(12, 14, 2, '2022-12-08', '2022-12-09', 0),
(13, 15, 2, '2022-12-08', '2022-12-10', 0),
(14, 17, 3, '2022-01-19', '2022-01-25', 0),
(15, 16, 2, '2022-12-08', '2022-12-09', 0),
(16, 18, 3, '2022-01-19', '2022-02-02', 0),
(17, 25, 2, '2022-12-08', '2022-12-09', 0),
(18, 24, 2, '2022-12-08', '2022-12-09', 0),
(19, 1, 4, '2022-12-10', '2022-12-11', 0),
(20, 2, 4, '2022-12-10', '2022-12-11', 0),
(21, 3, 4, '2022-12-10', '2022-12-11', 0),
(22, 4, 4, '2022-12-10', '2022-12-11', 0),
(23, 5, 4, '2022-12-10', '2022-12-11', 0),
(24, 6, 4, '2022-12-10', '2022-12-11', 0),
(25, 7, 4, '2022-12-10', '2022-12-11', 0),
(26, 8, 4, '2022-12-10', '2022-12-11', 0),
(27, 9, 4, '2022-12-10', '2022-12-11', 0),
(28, 10, 4, '2022-12-10', '2022-12-11', 0),
(29, 11, 4, '2022-12-10', '2022-12-11', 0),
(30, 12, 4, '2022-12-10', '2022-12-11', 0),
(31, 13, 4, '2022-12-12', '2022-12-11', 0),
(32, 14, 4, '2022-12-10', '2022-12-11', 0),
(33, 15, 4, '2022-12-10', '2022-12-11', 0),
(34, 16, 4, '2022-12-10', '2022-12-11', 0),
(35, 17, 4, '2022-12-10', '2022-12-11', 0),
(36, 18, 4, '2022-12-10', '2022-12-11', 0),
(37, 19, 4, '2022-12-10', '2022-12-11', 0),
(38, 20, 4, '2022-12-10', '2022-12-11', 0),
(39, 21, 4, '2022-12-10', '2022-12-11', 0),
(40, 24, 4, '2022-12-10', '2022-12-11', 0),
(41, 25, 4, '2022-12-10', '2022-12-21', 0),
(42, 22, 7, '2022-06-15', '2022-09-30', 0),
(43, 20, 10, '2022-02-15', '2022-03-10', 0),
(44, 18, 11, '2022-06-16', '2022-07-10', 0),
(45, 17, 11, '2022-06-16', '2022-06-20', 0),
(46, 19, 11, '2022-06-16', '2022-06-20', 0),
(47, 20, 11, '2022-06-16', '2022-06-20', 0),
(48, 21, 11, '2022-06-16', '2022-06-20', 0),
(49, 22, 11, '2022-06-16', '2022-07-10', 0),
(50, 18, 12, '2022-06-16', '2022-07-10', 0),
(51, 17, 12, '2022-06-16', '2022-06-20', 1),
(52, 19, 12, '2022-06-16', '2022-06-20', 1),
(53, 20, 12, '2022-06-16', '2022-06-20', 1),
(54, 21, 12, '2022-06-16', '2022-06-20', 1),
(55, 22, 12, '2022-06-16', '2022-07-10', 1),
(56, 18, 13, '2022-06-16', '2022-07-10', 1),
(57, 17, 13, '2022-06-16', '2022-06-20', 1),
(58, 19, 13, '2022-06-16', '2022-06-20', 1),
(59, 20, 13, '2022-06-16', '2022-06-20', 1),
(60, 21, 13, '2022-06-16', '2022-06-20', 1),
(61, 22, 13, '2022-06-16', '2022-07-10', 1),
(62, 14, 14, '2022-10-19', '2022-12-11', 0),
(63, 17, 15, '2022-07-01', '2022-07-05', 1);

DROP TABLE IF EXISTS `rendszerek`;

CREATE TABLE `rendszerek` (
  `rendszer_id` int(11) NOT NULL,
  `host_nev` varchar(20),
  `os` varchar(100)
);

INSERT INTO `rendszerek` (`rendszer_id`, `host_nev`, `os`) VALUES
(1, 'mailgw', 'Windows SRV 2019'),
(2, 'pikachu', 'Windows SRV 2019'),
(3, 'bulbasaur', 'Windows SRV 2019'),
(4, 'venusaur', 'Windows SRV 2019'),
(5, 'charmander', 'Windows SRV 2019'),
(6, 'wartortle', 'Windows SRV 2019'),
(7, 'squirtle', 'Windows SRV 2022'),
(8, 'fs01', 'Windows SRV 2022'),
(9, 'fs02', 'Windows SRV 2022'),
(10, 'overwatch', 'Red Hat Enterpise Linux 8.6'),
(11, 'guardian', 'Red Hat Enterpise Linux 8.6'),
(12, 'observer', 'Red Hat Enterpise Linux 8.6'),
(13, 'oradb', 'Oracle Linux 9.1'),
(14, 'charizard', 'Windows SRV 2019'),
(15, 'charmeleon', 'Windows SRV 2019'),
(16, 'blastoise', 'Windows SRV 2016'),
(17, 'www-dev', 'Red Hat Enterpise Linux 8.6'),
(18, 'www-prod', 'Red Hat Enterpise Linux 8.6'),
(19, 'hermes', 'Red Hat Enterpise Linux 7.9'),
(20, 'jupiter', 'Red Hat Enterpise Linux 7.9'),
(21, 'atlas', 'Red Hat Enterpise Linux 7.9'),
(22, 'copernicus', 'AIX 7.2'),
(23, 'newton', 'AIX 7.2'),
(24, 'sqlsrv01', 'Windows SRV 2019'),
(25, 'sqlsrv02', 'Windows SRV 2019');

DROP TABLE IF EXISTS `serulekenysegek`;

CREATE TABLE `serulekenysegek` (
  `vuln_id` int(11) NOT NULL,
  `vuln_nev` varchar(200),
  `CVE` varchar(14),
  `CVSS` decimal(3,1)
);

INSERT INTO `serulekenysegek` (`vuln_id`, `vuln_nev`, `CVE`, `CVSS`) VALUES
(1, 'Apache Tomcat XSS vulnerability', 'CVE-2022-34305', '6.3'),
(2, 'Windows Kernel Elevation of Privilege', 'CVE-2022-37988', '7.8'),
(3, 'Oracle MySQL Denial of Service', 'CVE-2022-21368', '6.5'),
(4, 'Log4Shell', 'CVE-2021-44228', '10.0'),
(5, 'Spring4Shell', 'CVE-2022-22965', '9.8'),
(6, 'Text4Shell', 'CVE-2022-42889', '9.8'),
(7, 'AIX lpd Denial of Service', 'cve-2022-22444', '5.5'),
(8, 'Cisco Identity Services Engine Cross-Site Scripting Vulnerability', 'CVE-2022-20959', '5.4'),
(9, 'Cisco IP Telefophone Stack Overflow', 'CVE-2022-20968', '8.5'),
(10, 'Jira Cross -Site Request Forgery', 'CVE-2021-43953', '4.3'),
(11, 'Imagemagick outside the range of representable values of type unsigned char', 'CVE-2022-32545', '6.8'),
(12, 'Imagemagick  outside the range of representative value of type unsigned long', 'CVE-2022-32546', '6.8'),
(13, 'Imagemagick  load of misaligned address for types double and float', 'CVE-2022-32547', '6.8'),
(14, 'Jenkins Contrast Continuous Application Security Plugin XSS', 'CVE-2022-43420', '5.4'),
(15, 'Gitclone Command Injection', 'CVE-2022-25900', '10.0');

ALTER TABLE `eszlelesek`
  ADD PRIMARY KEY (`eszleles_id`),
  ADD KEY `FK_eszlelesek_rendszerek` (`host_id`),
  ADD KEY `FK_eszlelesek_serulekenysegek` (`vuln_id`);

ALTER TABLE `rendszerek`
  ADD PRIMARY KEY (`rendszer_id`);

ALTER TABLE `serulekenysegek`
  ADD PRIMARY KEY (`vuln_id`);

ALTER TABLE `eszlelesek`
  ADD CONSTRAINT `FK_eszlelesek_rendszerek` FOREIGN KEY (`host_id`) REFERENCES `rendszerek` (`rendszer_id`) ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_eszlelesek_serulekenysegek` FOREIGN KEY (`vuln_id`) REFERENCES `serulekenysegek` (`vuln_id`) ON UPDATE CASCADE;