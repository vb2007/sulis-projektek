-- 3. feladat
CREATE DATABASE iskola
CHARACTER SET utf8mb4
COLLATE utf8mb4_hungarian_ci;

-- 4. feladat
SHOW DATABASES;

-- 5. feladat
USE iskola;

-- 6. feladat
CREATE TABLE tantargyak (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nev VARCHAR(25) NOT NULL
);

-- 7. feladat
SOURCE /sql/tantargyak-table.sql;

-- 8. feladat
CREATE TABLE jegyek (
    id INT AUTO_INCREMENT PRIMARY KEY,
    tantárgy_id INT NOT NULL,
    jegy INT NOT NULL,
    diak VARCHAR(20) NOT NULL,
    tanar VARCHAR(20) NOT NULL,
    beirva DATETIME NOT NULL,
    FOREIGN KEY (tantárgy_id)
        REFERENCES tantargyak(id)
);

-- 9. feladat
SOURCE /sql/jegyek-table.sql;

-- 10. feladat
CREATE VIEW jegyeim AS
SELECT *
FROM jegyek
WHERE diak = SUBSTRING_INDEX(USER(), "@", 1);

-- 11. feladat
SHOW TABLES;

-- 12. feladat

-- tanárok
CREATE USER "Ilona"@"%" IDENTIFIED BY "Ilona";
CREATE USER "Laci"@"%" IDENTIFIED BY "Laci";
GRANT SELECT, INSERT
    ON iskola.jegyek
    TO "Ilona"@"%", "Laci"@"%";

--- diákok
CREATE USER "Dani"@"%" IDENTIFIED BY "Dani";
CREATE USER "Juci"@"%" IDENTIFIED BY "Juci";
CREATE USER "Kati"@"%" IDENTIFIED BY "Kati";
CREATE USER "Marci"@"%" IDENTIFIED BY "Marci";
GRANT SELECT
    ON iskola.jegyeim
    TO "Dani"@"%", "Juci"@"%", "Kati"@"%", "Marci"@"%";

-- admin
CREATE USER "Admin"@"%" IDENTIFIED BY "Admin";
GRANT ALL PRIVILEGES
    ON iskola.*
    TO "Admin"@"%";

FLUSH PRIVILEGES;

-- 13. feladat
SOURCE /sql/felhasznalok.sql;

-- 14. feladat
-- belépés: mysql -u Admin -p iskola
INSERT INTO tantargyak (nev)
VALUES
    ("Matematika"),
    ("Backend programozás"),
    ("Történelem"),
    ("Fizika");

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

-- 16. feladat
-- belépés: mysql -u Dani -p iskola
SELECT *
FROM jegyeim;

-- 17. feladat
-- belépés: mysql -u Admin -p iskola
UPDATE jegyek
SET jegy = 4
WHERE id = 1; 