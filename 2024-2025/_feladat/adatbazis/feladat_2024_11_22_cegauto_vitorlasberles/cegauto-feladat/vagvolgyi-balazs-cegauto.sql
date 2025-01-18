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
SELECT
    `munkatars`.`vnev`,
    `munkatars`.`knev`,
    `auto`.`rendszam`
FROM `munkatars`
    INNER JOIN `auto`
        ON `munkatars`.`id` = `auto`.`munkatars_id`
WHERE `auto`.`kor` <= 6;

-- 9. feladat
SELECT `tipus`
FROM `auto`
WHERE `gyarto` = "Opel"
GROUP BY `tipus`
ORDER BY  `tipus` ASC;

-- 10. feladat
SELECT `vnev`, `knev`
FROM `munkatars`
    INNER JOIN `auto`
        ON `munkatars`.`id` = `auto`.`munkatars_id`
WHERE `munkatars`.`varos` = "Budapest"
    AND `munkatars`.`nem` = "Férfi"
    AND `auto`.`gyarto` = "Toyota";

-- 11. feladat
SELECT 
    `munkatars`.`vnev`, 
    `munkatars`.`knev`, 
    `auto`.`rendszam`
FROM  `munkatars`
    INNER JOIN `auto` 
        ON `munkatars`.`id` = `auto`.`munkatars_id`
WHERE `munkatars`.`varos` = "Budapest"
    AND (`auto`.`uzemanyag` = "dízel" OR `auto`.`kivitel` = "ferdehátú")
ORDER BY `auto`.`rendszam` DESC;

-- 12. feladat
SELECT 
    `auto`.`rendszam`, 
    `auto`.`gyarto`, 
    `auto`.`tipus`, 
    `munkatars`.`knev`
FROM `auto`
    INNER JOIN `munkatars` 
        ON `auto`.`munkatars_id` = `munkatars`.`id`
WHERE  `auto`.`kor` BETWEEN 3 AND 5
    AND (`auto`.`gyarto` = "Opel" OR `auto`.`gyarto` = "Skoda")
ORDER BY  `auto`.`rendszam` DESC;

-- 13. feladat
SELECT SUM(`auto`.`csomagter`) AS `osszliter`
FROM `auto`
    INNER JOIN `munkatars` 
        ON `auto`.`munkatars_id` = `munkatars`.`id`
WHERE `munkatars`.`nem` = 'férfi';

-- 14. feladat
SELECT 
    `auto`.`gyarto`, 
    COUNT(*) AS `db`
FROM `auto`
    INNER JOIN `munkatars` 
        ON `auto`.`munkatars_id` = `munkatars`.`id`
WHERE `munkatars`.`nem` = 'nő'
GROUP BY `auto`.`gyarto`;

-- 15. feladat
SELECT 
    `gyarto`, 
    AVG(`csomagter`) AS `csomagter_atlag`, 
    MAX(`csomagter`) AS `legnagyobb_csomagter`
FROM `auto`
GROUP BY `gyarto`
ORDER BY `legnagyobb_csomagter` ASC; --habár nem kérték, de kell, ha azt akarjuk, hogy úgy nézzen ki, mint a mintában
