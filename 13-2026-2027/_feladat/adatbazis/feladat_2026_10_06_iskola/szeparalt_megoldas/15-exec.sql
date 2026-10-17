-- 15. feladat
-- belépés: mysql -u Ilona -p iskola
INSERT INTO jegyek (tantárgy_id, jegy, diak, tanar, beirva)
VALUES (1, 5, "Dani", USER(), NOW());

INSERT INTO jegyek (tantárgy_id, jegy, diak, tanar, beirva)
VALUES (2, 4, "Juci", USER(), NOW());

INSERT INTO jegyek (tantárgy_id, jegy, diak, tanar, beirva)
VALUES (3, 3, "Kati", USER(), NOW());

-- ellenőrzés, hogy a tanár tud-e jegyet átírni
-- a tanár csak SELECT és INSERT jogot kapott, UPDATE-et nem, ezért ez hibát ad
UPDATE jegyek
SET jegy = 5
WHERE id = 3;
-- ERROR 1142 (42000): UPDATE command denied to user 'Ilona'@'%' for table 'jegyek'
