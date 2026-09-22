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
SELECT kuldetes.megnevezes, COUNT(*) AS fo
FROM kuldetes
    JOIN repules
        ON repules.kuldetes_id = kuldetes.id
    JOIN urhajos
        ON urhajos.id = repules.urhajos_id
GROUP BY kuldetes.megnevezes;

-- 12. feladat
SELECT urhajos.nev, COUNT(*) AS db
FROM kuldetes
    JOIN repules
        ON repules.kuldetes_id = kuldetes.id
    JOIN urhajos
        ON urhajos.id = repules.urhajos_id
GROUP BY urhajos.nev
HAVING db >= 6;

-- 13. feladat
SELECT ROUND(AVG(DATEDIFF(veg, kezdet)), 2)
    AS "Gemini küldetések átlagos hosszúsága"
FROM kuldetes
WHERE megnevezes LIKE "Gemini%";

-- 14. feladat
SELECT orszag
FROM urhajos
    JOIN repules
        ON repules.urhajos_id = urhajos.id
    JOIN kuldetes
        ON repules.kuldetes_id = kuldetes.id
WHERE YEAR(kuldetes.kezdet) >= 1991
    AND YEAR(kuldetes.veg) <= 2000
GROUP BY orszag
ORDER BY COUNT(*) DESC
LIMIT 3;

-- 15. feladat
SELECT COUNT(*)
    AS "Robik száma"
FROM urhajos
WHERE nev LIKE "Robert%";

-- 16. feladat

-- 17. feladat

-- 18. feladat

-- 19. feladat

-- 20. feladat

-- 21. feladat