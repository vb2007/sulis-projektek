-- 15. feladat
-- belépés: mysql -u Ilona -p iskola
INSERT INTO jegyek (tantárgy_id, jegy, diak, tanar, beirva)
VALUES (1, 5, "Dani", USER(), NOW());

INSERT INTO jegyek (tantárgy_id, jegy, diak, tanar, beirva)
VALUES (2, 4, "Juci", USER(), NOW());

INSERT INTO jegyek (tantárgy_id, jegy, diak, tanar, beirva)
VALUES (3, 3, "Kati", USER(), NOW());