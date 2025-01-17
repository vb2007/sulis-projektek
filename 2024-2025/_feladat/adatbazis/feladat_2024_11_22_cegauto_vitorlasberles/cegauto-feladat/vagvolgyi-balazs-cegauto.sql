-- 3. feladat
SELECT COUNT(DISTINCT `tipus`) AS `toyotadb`
FROM `auto`
WHERE `gyarto` = "Toyota";

-- 4. feladat
SELECT `szin`
FROM `auto`
GROUP BY `szin`
ORDER BY COUNT(*) DESC
LIMIT 1;

-- 5. feladat
SELECT
    `munkatars`.`nem`,
    COUNT(*) AS `db`
FROM `munkatars`
    INNER JOIN `auto`
        ON `munkatars`.`id` = `auto`.`munkatars_id`
WHERE
    `auto`.`automata` = 1
GROUP BY
    `munkatars`.`nem`;

-- 6. feladat
SELECT `gyarto`, `tipus`, COUNT(*) AS `db`
FROM `auto`
GROUP BY `gyarto`, `tipus`;

-- 7. feladat
SELECT
    `munkatars`.`vnev`,
    `munkatars`.`knev`,
    `auto`.`rendszam`
FROM `munkatars`
    INNER JOIN `auto`
        ON `munkatars`.`id` = `auto`.`munkatars_id`
ORDER BY `munkatars`.`vnev`, `munkatars`.`knev`;

-- 8. feladat

-- 9. feladat

-- 10. feladat

-- 11. feladat

-- 12. feladat

-- 13. feladat

-- 14. feladat

-- 15. feladat

