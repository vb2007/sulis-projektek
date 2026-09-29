-- 2. feladat
CREATE DATABASE kondibelepok
CHARACTER SET utf8mb4
COLLATE utf8mb4_hungarian_ci;

USE kondibelepok;

-- 4. feladat
SELECT DISTINCT COUNT(megnevezes) AS db
FROM belepok;

-- 5. feladat
SELECT COUNT(*) AS noi_letszam
FROM tagok
WHERE nem = "nő";

-- 6. feladat
SELECT COUNT(*) AS nyugdijas_db
FROM tagok
WHERE YEAR(NOW()) - YEAR(szuletett) >= 65;

-- 7. feladat
SELECT ROUND(AVG(YEAR(NOW()) - YEAR(szuletett)), 2) AS ferfi_atlag
FROM tagok
WHERE nem = "férfi";

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

-- 22. feladat

-- 23. feladat

-- 24. feladat