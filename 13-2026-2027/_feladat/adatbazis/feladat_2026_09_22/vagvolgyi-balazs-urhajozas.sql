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

-- 9. feladat

-- 10. feladat

-- 11. feladat

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