-- 3. feladat
SELECT *
FROM `felhokarcolok`
ORDER BY `magassag` DESC;

-- 4. feladat
SELECT *
FROM `felhokarcolok`
WHERE `varos` = "Chicago";

-- 5. feladat
SELECT `nev`, `emeletek`
FROM `felhokarcolok`
WHERE `felhasznalas` LIKE "%lakóépület%";

-- 6. feladat
SELECT `nev`
FROM `felhokarcolok`
WHERE `nev` LIKE "_1%";

-- 7. feladat
SELECT COUNT(*) AS `db`
FROM `felhokarcolok`;

-- 8. feladat
SELECT COUNT(*) AS `db`
FROM `felhokarcolok`
WHERE `orszagkod` = "US";

-- 9. feladat
SELECT COUNT(*) AS `db`
FROM `felhokarcolok`
WHERE `befejezes_eve` BETWEEN 1997 AND 2005;

-- 10. feladat
SELECT ROUND(AVG(`emeletek`), 0) AS `atlagos_emelet`
FROM `felhokarcolok`
WHERE `nev` LIKE "%Tower%";

-- 11. feladat
SELECT `nev`, CONCAT(ROUND(`magassag`, 0), " m") AS `magassag_meterben`
FROM `felhokarcolok`
ORDER BY `magassag` DESC
LIMIT 3;

-- 12. feladat
SELECT
    `nev`,
    `orszagkod`,
    COALESCE(`varos`, "Ismeretlen") AS `varos_neve`,
    `befejezes_eve`,
    `anyag`
FROM `felhokarcolok`
WHERE (`anyag` = "acél"
    OR `anyag` = "kompozit")
    AND `orszagkod` IN ("CN", "RU", "MY")
    AND `befejezes_eve` BETWEEN 1990 AND 1999
ORDER BY `orszagkod`;

-- 13. feladat
SELECT MAX(`emeletek`) AS `legtobb_emelet`
FROM `felhokarcolok`;

-- 14. feladat
SELECT
    MIN(`befejezes_eve`) AS `elso`,
    MAX(`befejezes_eve`) AS `utolso`
FROM `felhokarcolok`;

-- 15. feladat

-- 16. feladat

-- 17. feladat

-- 18. feladat

-- 19. feladat

-- 20. feladat

-- 21. feladat

-- 22. feladat

-- 23. feladat
