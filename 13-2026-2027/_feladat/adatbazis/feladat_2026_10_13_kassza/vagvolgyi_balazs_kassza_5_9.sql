USE `kassza`;

-- 4. havi összesítés nézet: év és hónap szerinti blokkértékek
CREATE OR REPLACE VIEW `havi_osszesites` AS
SELECT
  YEAR(`blokk`.`vasarlas_ideje`) AS `ev`,
  MONTH(`blokk`.`vasarlas_ideje`) AS `honap`,
  COUNT(DISTINCT `blokk`.`id`) AS `blokkok_szama`,
  SUM(`cikk`.`mennyiseg` * `cikk`.`egysegar`) AS `osszertek`
FROM `blokk`
JOIN `cikk` ON`cikk`.`blokk_id` = `blokk`.`id`
GROUP BY YEAR(`blokk`.`vasarlas_ideje`), MONTH(`blokk`.`vasarlas_ideje`);

-- 5. módosítások naplózása
CREATE TABLE `modositas` (
  `id` int NOT NULL PRIMARY KEY AUTO_INCREMENT,
  `blokk_id` int NOT NULL,
  `regi_osszeg` int NOT NULL,
  `uj_osszeg` int NOT NULL,
  `mod_ideje` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `mod_user` varchar(100) NOT NULL DEFAULT (CURRENT_USER()),
  FOREIGN KEY (`blokk_id`) REFERENCES `blokk`(`id`)
) ENGINE=InnoDB;

-- 7. storno mező (a 6., 8., 9. feladat előtt, hogy a jogosultságok a végleges táblára vonatkozzanak)
ALTER TABLE `blokk`
  ADD COLUMN `storno` BOOLEAN NOT NULL DEFAULT FALSE;

-- 6. NAV felhasználó: csak a havi_osszesites nézet olvasása
CREATE USER 'nav'@'192.168.1.11' IDENTIFIED BY 'navUser2026';
GRANT SELECT ON `kassza`.`havi_osszesites` TO 'nav'@'192.168.1.11';

-- 8. pénztárgép felhasználó
CREATE USER 'kasszaprogram'@'192.168.0.%' IDENTIFIED BY 'K4ssz4J3lsz0!';
GRANT INSERT, UPDATE ON `kassza`.`blokk` TO 'kasszaprogram'@'192.168.0.%';
GRANT INSERT ON `kassza`.`cikk` TO 'kasszaprogram'@'192.168.0.%';

-- 9. karbantartó felhasználó
CREATE USER 'kasszaadmin'@'192.168.%.%' IDENTIFIED BY 'adm1nPass++';
GRANT INSERT, UPDATE, DELETE ON `kassza`.`blokk` TO 'kasszaadmin'@'192.168.%.%';
GRANT INSERT, UPDATE, DELETE ON `kassza`.`cikk` TO 'kasszaadmin'@'192.168.%.%';

FLUSH PRIVILEGES;
