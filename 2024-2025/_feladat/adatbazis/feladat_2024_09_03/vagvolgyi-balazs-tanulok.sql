-- 3. feladat
SELECT * FROM `tanulok`;

-- 4. feladat
SELECT `vnev`, `knev`
FROM `tanulok`;

-- 5. feladat
SELECT *
FROM `tanulok`
WHERE `nem` = "N";

-- 6. feladat
SELECT `vnev`, `knev`
FROM `tanulok`
ORDER BY `vnev` ASC;

-- 7. feladat
SELECT `vnev`, `knev`, `magassag`
FROM `tanulok`;

-- 8. feladat
SELECT `vnev`, `knev`, `szul_ido`, `szul_hely`
FROM `tanulok`
WHERE `szul_hely` = "Miskolc";

-- 9. feladat
SELECT *
FROM `tanulok`
WHERE `nagycsalados` = 1;

-- 10. feladat
SELECT `vnev`, `knev`, `magassag`
FROM `tanulok`
WHERE `magassag` < 180;

-- 11. feladat

-- 12. feladat

-- 13. feladat

-- 14. feladat

-- 15. feladat

-- 16. feladat

-- 17. feladat

-- 18. feladat
