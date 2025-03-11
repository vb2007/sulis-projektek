-- 3. feladat
SELECT DISTINCT telepules
FROM hely
WHERE utca LIKE 'Gőz u.%'
ORDER BY telepules ASC; --kell az order by, ha a minta alapján akarjuk rendezni

-- 4. feladat
SELECT nev
FROM szerelo
ORDER BY kezdev ASC
LIMIT 1;

-- 5. feladat
SELECT
    javdatum,
    COUNT(*) AS munkák_szama,
    SUM(anyagar) AS összes_anyagár
FROM munkalap
GROUP BY javdatum;

-- 6. feladat
SELECT bedatum, javdatum, telepules
FROM munkalap
    JOIN hely
        ON munkalap.helyaz = hely.helyaz
WHERE bedatum = javdatum
AND telepules IN ('Barackfalva', 'Kőváros');

-- 7. feladat
SELECT 
    munkaszam,
    javdatum, 
    (anyagar + (munkaora * 4500) + 3000) AS számla_összeg
FROM munkalap
WHERE YEAR(javdatum) = 2001;

-- 8. feladat
SELECT telepules, utca, javdatum
FROM munkalap
    JOIN hely
        ON munkalap.helyaz = hely.helyaz
    JOIN szerelo
        ON munkalap.szereloaz = szerelo.az
WHERE szerelo.nev = 'Erdei Imre'
AND telepules = 'Sárgahegy'
AND javdatum BETWEEN '2001-07-01' AND '2001-09-30';

-- 9. feladat
SELECT telepules, COUNT(*) AS javitasok_szama
FROM munkalap
    JOIN hely
        ON munkalap.helyaz = hely.helyaz
WHERE javdatum BETWEEN '2001-01-01' AND '2001-03-31'
GROUP BY telepules
ORDER BY javitasok_szama DESC;
