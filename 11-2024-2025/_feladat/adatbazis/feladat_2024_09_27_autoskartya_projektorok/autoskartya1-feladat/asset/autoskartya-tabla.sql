DROP DATABASE IF EXISTS `autoskartya`;

create database IF not exists `autoskartya` 
CHARACTER SET utf8
collate utf8_hungarian_ci;

use `autoskartya`;

CREATE TABLE IF NOT EXISTS `autoskartya` (
`id` int(11) NOT NULL,
  `gyartmany` varchar(30) DEFAULT NULL,
  `tipus` varchar(30) DEFAULT NULL,
  `orszagkod` varchar(5) DEFAULT NULL,
  `orszag` varchar(30) DEFAULT NULL,
  `hengerurtartalom` int(5) DEFAULT NULL,
  `loero` int(5) DEFAULT NULL,
  `kilowatt` int(5) DEFAULT NULL,
  `nyomatek` int(5) DEFAULT NULL,
  `vegsebesseg` int(5) DEFAULT NULL,
  `gyorsulas` double(7,2) DEFAULT NULL,
  `fogyasztas` double(7,2) DEFAULT NULL,
  `gyartasi_ev` int(5) DEFAULT NULL
);

ALTER TABLE `autoskartya`
 ADD PRIMARY KEY (`id`);