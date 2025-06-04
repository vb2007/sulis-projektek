-- 3.-4. feladathoz a kód a star-trek-alap.sql fájlban található

-- 6. feladat
ALTER TABLE urhajok
ADD CONSTRAINT fk_urhajok_fajok
FOREIGN KEY (faj_id) REFERENCES fajok(faj_id)
ON DELETE CASCADE
ON UPDATE CASCADE;

-- 7. feladat
ALTER TABLE urhajok
ADD CONSTRAINT fk_urhajok_osztalyok
FOREIGN KEY (osztaly_id) REFERENCES hajo_osztalyok(osztaly_id)
ON DELETE RESTRICT
ON UPDATE RESTRICT;

-- 8. feladat
ALTER TABLE hajo_osztalyok
ADD CONSTRAINT fk_osztalyok_szerepek
FOREIGN KEY (szerep_id) REFERENCES hajo_szerepek(szerep_id)
ON DELETE RESTRICT
ON UPDATE CASCADE;

-- 9. feladat
SELECT urhajo_nev 
FROM urhajok
JOIN fajok ON urhajok.faj_id = fajok.faj_id
WHERE fajok.faj_nev = 'Egyesült Földi Csillagflotta';

-- 10. feladat
SELECT ho.osztaly_nev
FROM urhajok u
JOIN hajo_osztalyok ho ON u.osztaly_id = ho.osztaly_id
GROUP BY u.osztaly_id, ho.osztaly_nev
HAVING COUNT(DISTINCT u.faj_id) > 1;

-- 11. feladat
SELECT azonosito, urhajo_nev
FROM urhajok
ORDER BY urhajo_nev ASC;

-- 12. feladat
SELECT f.faj_nev, COUNT(u.urhajo_id) AS hajok_szama
FROM fajok f
LEFT JOIN urhajok u ON f.faj_id = u.faj_id
GROUP BY f.faj_id, f.faj_nev
ORDER BY hajok_szama ASC;

-- 13. feladat
ALTER TABLE urhajok
MODIFY COLUMN azonosito varchar(21) UNIQUE;

-- 14. feladat
SELECT u.azonosito
FROM urhajok u
JOIN hajo_osztalyok ho ON u.osztaly_id = ho.osztaly_id
WHERE u.urhajo_nev = 'U.S.S. Excalibur' 
    AND ho.osztaly_nev = 'Ambassador';

-- 15. feladat
SELECT urhajo_nev
FROM urhajok
WHERE azonosito IS NULL
ORDER BY urhajo_nev ASC;

-- 16. feladat
ALTER TABLE urhajok
ADD COLUMN datum DATE DEFAULT NULL;

-- 17. feladat
ALTER TABLE urhajok
CHANGE COLUMN datum kibocs_datuma DATE DEFAULT NULL;

-- 18. feladat
SELECT ho.osztaly_nev, hsz.szerep_nev
FROM hajo_osztalyok ho
JOIN hajo_szerepek hsz
    ON ho.szerep_id = hsz.szerep_id
JOIN urhajok u
    ON ho.osztaly_id = u.osztaly_id
GROUP BY ho.osztaly_id, ho.osztaly_nev, hsz.szerep_nev
ORDER BY COUNT(u.urhajo_id) DESC
LIMIT 1;

-- 19. feladat
SELECT COUNT(*) AS cardassiai_hajok_szama
FROM urhajok u
JOIN fajok f ON u.faj_id = f.faj_id
WHERE f.faj_nev = 'Cardassiai Unió' 
    AND u.azonosito IS NOT NULL;

-- 20. feladat
DELETE FROM urhajok
WHERE faj_id = (SELECT faj_id FROM fajok WHERE faj_nev = 'Ferengi') 
    AND azonosito = '16';