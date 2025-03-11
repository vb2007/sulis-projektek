-- Könyvesbolt
-- Vágvölgyi Balázs

-- 3. feladat
SELECT *
FROM `konyvek`;

-- 4. feladat
SELECT `szerzo`, `cim`
FROM `konyvek`
WHERE `temakor` = "Történelem";

-- 5. feladat
SELECT 	`temakor`
FROM `konyvek`
WHERE `engedmeny` = 0;

-- 6. feladat
SELECT 	`cim`, `szerzo`, `eladasiar`
FROM `konyvek`
ORDER BY `eladasiar` DESC
LIMIT 3;

-- 7. feladat
-- Sorok megjelenítése 0-18 (összesen 19, A lekérdezés 0,0002 másodpercig tartott.) 

SELECT 	*
FROM `konyvek`
WHERE `engedmeny` = 20;

-- 8. feladat
SELECT 	`szerzo`, `cim`, `eladasiar`
FROM `konyvek`
WHERE `ar` > 1000
	AND `ar` < 2000 
    AND `temakor` = "Szépirodalom"
ORDER BY `ar` DESC;

-- 9. feladat
SELECT 	*
FROM `konyvek`
WHERE `szerzo` IS NULL;

-- 10. feladat
SELECT 	*
FROM `konyvek`
WHERE `szerzo` IN ("Robert Merle", "Joseph Heller", "Alexandre Dumas")
ORDER BY `szerzo` ASC;

-- 11. feladat
SELECT 	`szerzo`, `cim`
FROM `konyvek`
WHERE `datum` < 2015
	OR `datum` > 2018;

-- 12. feladat
-- A MySQL üres eredményhalmazt adott vissza (pl. nulla sorok). (A lekérdezés 0,0002 másodpercig tartott.) 

DROP DATABASE `konyvesbolt`