-- 10. feladat
CREATE VIEW jegyeim AS
SELECT *
FROM jegyek
WHERE diak = SUBSTRING_INDEX(USER(), "@", 1);