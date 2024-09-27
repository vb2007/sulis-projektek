-- 3. feladat
SELECT *
FROM `projektorok`

-- 4. feladat
SELECT DISTINCT `nev`
FROM `projektorok`
WHERE `projektor` = 1
ORDER BY `nev` ASC;

-- 5. feladat
SELECT `nev`, `elvitte`
FROM `projektorok`
WHERE `projektor` = 4
ORDER BY `elvitte` DESC;

-- 6. feladat
SELECT DISTINCT `nev`, `terem`
FROM `projektorok`
WHERE `atalakito` = "HDMI->VGA";

-- 7. feladat
SELECT DISTINCT `nev`, `terem`
FROM `projektorok`
WHERE `hangszoro` = "Logi 5.1";

-- 8. feladat
SELECT DISTINCT `nev`
FROM `projektorok`
WHERE `terem` IS NULL;

-- 9. feladat

-- 10. feladat

-- 11. feladat

-- 12. feladat

-- 13. feladat

-- 14. feladat

-- 15. feladat

-- 16. feladat

-- 17. feladat