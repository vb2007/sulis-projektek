-- 3. feladat
SELECT *
FROM `teglalapok`;

-- 4. feladat
SELECT `szin`, `a`, `b`, (a * b) AS `terulet`
FROM `teglalapok`;

-- 5. feladat
SELECT
	(a * b) AS `terulet`,
    (2 * (a + b)) AS `kerulet`
FROM `teglalapok`
WHERE `szin` = "sárga";

-- 6. feladat
SELECT
	`szin`,
	(a * b) AS `terulet`,
    (2 * (a + b)) AS `kerulet`
FROM `teglalapok`
WHERE (a * b) >= 4;

-- 7. feladat
SELECT *
FROM `haromszogek`;

-- 8. feladat
SELECT
    `szin`,
    (a + b + c) as `kerulet`
FROM `haromszogek`;

-- 9. feladat
SELECT CONCAT((a + b + c), " cm") as `kerulet`
FROM `haromszogek`
WHERE `szin` = "sárga";

-- 10. feladat
SELECT ROUND((a + b + c), 1) as `kerulet`
FROM `haromszogek`
WHERE `szin` = "piros";

-- 11. feladat

-- 12. feladat

-- 13. feladat

-- 14. feladat

-- 15. feladat

-- 16. feladat

-- 17. feladat

-- 18. feladat

-- 19. feladat