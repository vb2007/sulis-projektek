-- 3. feladat
SELECT *
FROM `magyarorszag`
ORDER BY `nepesseg` DESC;

-- 4. feladat
SELECT DISTINCT `tipus`
FROM `magyarorszag`
ORDER BY `tipus` ASC;

-- 5. feladat
SELECT COUNT(`id`) AS `varosok_szama`
FROM `magyarorszag`;

-- 6. feladat
SELECT COUNT(DISTINCT `tipus`) AS `tipus_db`
FROM `magyarorszag`;

-- 7. feladat
SELECT COUNT(`id`) AS `db`
FROM `magyarorszag`
WHERE `megye` = "Csongrád-Csanád";

-- 8. feladat
SELECT COUNT(`id`) AS `db`
FROM `magyarorszag`
WHERE LENGTH(`nev`) = 4;

-- 9. feladat
SELECT COUNT(`id`) AS `db`
FROM `magyarorszag`
WHERE `megye` = "Békés"
    OR `megye` = "Fejér";

-- 10. feladat
SELECT `megye`, COUNT(*) AS `db`
FROM `magyarorszag`
GROUP BY `megye`
ORDER BY `db` DESC;

-- 11. feladat
SELECT `varos_cim_elnyerese` AS `ev`
FROM `magyarorszag`
ORDER BY `ev` DESC
LIMIT 1;

-- 12. feladat
SELECT `megye`, MAX(`varos_cim_elnyerese`) AS `ev`
FROM `magyarorszag`
GROUP BY `megye`
ORDER BY `ev` DESC;

-- 13. feladat
SELECT `nepesseg` AS `minimum_lakossag`
FROM `magyarorszag`
-- WHERE `tipus` = "város"
ORDER BY `minimum_lakossag` ASC
LIMIT 1;

-- 14. feladat
SELECT `nepesseg` AS `maximum_lakossag`
FROM `magyarorszag`
-- WHERE `tipus` = "város" -- mivel: "Hányan laknak a legnagyobb népességű városban?"
ORDER BY `maximum_lakossag` DESC
LIMIT 1;

-- 15. feladat
SELECT `terulet` AS `maximum_terulet`
FROM `magyarorszag`
ORDER BY `maximum_terulet` DESC
LIMIT 1;

-- 16. feladat
SELECT `nev`, `terulet`
FROM `magyarorszag`
ORDER BY `terulet` DESC
LIMIT 3;

-- 17. feladat
SELECT `nev`, `terulet`
FROM `magyarorszag`
WHERE `megye` = "Somogy"
ORDER BY `terulet` DESC
LIMIT 3;

-- 18. feladat
SELECT `nev`, ROUND(`nepesseg` / `terulet`, 4) AS `nepsurusseg`
FROM `magyarorszag`
ORDER BY `nepsurusseg` DESC
LIMIT 1;

-- 19. feladat
SELECT SUM(`nepesseg`) AS `lakossag`
FROM `magyarorszag`
WHERE `tipus` = "járásszékhely város";

-- 20. feladat
SELECT ROUND(SUM(`terulet`), 2) AS `osszterulet`
FROM `magyarorszag`
WHERE `varos_cim_elnyerese` BETWEEN 2000 AND 2012;

-- 21. feladat

-- 22. feladat

-- 23. feladat

-- 24. feladat

-- 25. feladat
