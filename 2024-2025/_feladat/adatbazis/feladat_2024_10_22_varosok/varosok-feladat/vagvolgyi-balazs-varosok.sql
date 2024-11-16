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
WHERE `tipus` = "város"
GROUP BY `nev`
ORDER BY `minimum_lakossag` ASC
LIMIT 1;

-- 14. feladat

-- 15. feladat

-- 16. feladat

-- 17. feladat

-- 18. feladat

-- 19. feladat

-- 20. feladat

-- 21. feladat

-- 22. feladat

-- 23. feladat

-- 24. feladat

-- 25. feladat
