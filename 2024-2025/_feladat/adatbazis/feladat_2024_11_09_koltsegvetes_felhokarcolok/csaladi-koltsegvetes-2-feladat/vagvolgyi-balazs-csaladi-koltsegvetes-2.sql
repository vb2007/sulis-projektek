-- 3. feladat
SELECT `kategoria`, SUM(`mennyiseg`) AS `db`
FROM `kiadasok`
GROUP BY `kategoria`
ORDER BY `db` ASC;

-- 4. feladat
SELECT `nev`, SUM(`egysegar`) AS `koltes`
FROM `kiadasok`
GROUP BY `kategoria`
ORDER BY `koltes` DESC;

-- 5. feladat

-- 6. feladat
SELECT `nev`, `kategoria`, SUM(`mennyiseg`) AS `db`
FROM `koltsegvetes`
GROUP BY `nev`, `kategoria`
ORDER BY `nev` DESC;

-- 7. feladat

-- 8. feladat

-- 9. feladat

-- 10. feladat

-- 11. feladat

-- 12. feladat

-- 13. feladat

-- 14. feladat

-- 15. feladat

