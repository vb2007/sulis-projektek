-- 2. feladat
CREATE DATABASE urhajozas
CHARACTER SET utf8mb4
COLLATE utf8mb4_hungarian_ci;

-- 3. feladat
USE urhajozas;

-- 5. feladat
SELECT nev, nem, szulev
FROM urhajos;

-- 6. feladat
SELECT megnevezes,
    DATEDIFF(veg, kezdet) AS napok
FROM kuldetes;

-- 7. feladat
SELECT nev,
    YEAR(NOW()) - szulev AS kor
FROM urhajos
ORDER BY kor DESC;

-- 8. feladat
SELECT kuldetes.megnevezes, urhajos.nev
FROM kuldetes
    JOIN repules
        ON repules.kuldetes_id = kuldetes.id
    JOIN urhajos ON
    urhajos.id = repules.urhajos_id
ORDER BY
    kuldetes.kezdet ASC,
    urhajos.nev DESC;

-- 9. feladat
SELECT nev, szulev
FROM urhajos
WHERE orszag = "CAN"
    AND szulev > 1960;

-- 10. feladat
SELECT nev
FROM urhajos
ORDER BY CHAR_LENGTH(nev) DESC
LIMIT 1;

-- 11. feladat
SELECT urhajos.nev, COUNT(*) AS repulesek_szama
FROM kuldetes
    JOIN repules
        ON repules.kuldetes_id = kuldetes.id
    JOIN urhajos
        ON urhajos.id = repules.urhajos_id
GROUP BY urhajos.nev
HAVING repulesek_szama >= 6;

-- 12. feladat

-- 13. feladat

-- 14. feladat

-- 15. feladat

-- 16. feladat

-- 17. feladat

-- 18. feladat

-- 19. feladat

-- 20. feladat

-- 21. feladat