CREATE TABLE IF NOT EXISTS `belepok` (
  `id` int NOT NULL  PRIMARY KEY auto_increment,
  `megnevezes` varchar(33) DEFAULT NULL,
  `ar` INT DEFAULT NULL,
  `ervenyes` INT DEFAULT NULL
);

CREATE TABLE IF NOT EXISTS `eladasok` (
  `tag_id` INT NOT NULL,
  `belepo_id` INT NOT NULL,
  `ido` DATETIME NOT NULL,
  PRIMARY KEY (`tag_id`,`belepo_id`,`ido`)
);

CREATE TABLE IF NOT EXISTS `tagok` (
  `id` int NOT NULL  PRIMARY KEY auto_increment,
  `nem` varchar(6) DEFAULT NULL,
  `vnev` varchar(30) DEFAULT NULL,
  `knev` varchar(30) DEFAULT NULL,
  `irsz` INT DEFAULT NULL,
  `telepules` varchar(30) DEFAULT NULL,
  `cim` varchar(30) DEFAULT NULL,
  `megye` varchar(30) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `telefon` varchar(20) DEFAULT NULL,
  `szuletett` date DEFAULT NULL,
  `kartya_tipusa` varchar(10) DEFAULT NULL
);




ALTER TABLE `eladasok`
 ADD CONSTRAINT `FK_eladasok_tag_id_1`
 FOREIGN KEY (`tag_id`)
 REFERENCES `tagok`(`id`)
 ON DELETE NO ACTION
 ON UPDATE NO ACTION;



ALTER TABLE `eladasok`
 ADD CONSTRAINT `FK_eladasok_belepo_id_1`
 FOREIGN KEY (`belepo_id`)
 REFERENCES `belepok`(`id`)
 ON DELETE NO ACTION
 ON UPDATE NO ACTION;