-- a) Adatbázis létrehozása
CREATE DATABASE IF NOT EXISTS jatekbolt
CHARACTER SET utf8
COLLATE utf8_hungarian_ci;

USE jatekbolt;

-- b) Táblák létrehozása
-- Kiadók tábla
CREATE TABLE kiadok (
    kiado_id INT AUTO_INCREMENT PRIMARY KEY,
    nev VARCHAR(100) NOT NULL,
    weboldal VARCHAR(255) NOT NULL,
    email VARCHAR(100) DEFAULT NULL,
    telefon VARCHAR(20) DEFAULT NULL
);

-- Kategóriák tábla
CREATE TABLE kategoriak (
    kategoria_id INT AUTO_INCREMENT PRIMARY KEY,
    nev VARCHAR(50) NOT NULL UNIQUE
);

-- Játékok tábla
CREATE TABLE jatekok (
    cikkszam VARCHAR(20) PRIMARY KEY,
    nev VARCHAR(255) NOT NULL,
    ar INT NOT NULL,
    kor_min INT NOT NULL,
    kor_max INT DEFAULT NULL,
    jatekosok_min INT NOT NULL,
    jatekosok_max INT DEFAULT NULL,
    nyelv VARCHAR(50) NOT NULL,
    kiado_id INT NOT NULL,
    FOREIGN KEY (kiado_id) REFERENCES kiadok(kiado_id)
);

-- Játék-kategória kapcsolótábla
CREATE TABLE jatek_kategoria (
    cikkszam VARCHAR(20),
    kategoria_id INT,
    PRIMARY KEY (cikkszam, kategoria_id),
    FOREIGN KEY (cikkszam) REFERENCES jatekok(cikkszam),
    FOREIGN KEY (kategoria_id) REFERENCES kategoriak(kategoria_id)
);

-- c) Adatok beszúrása a CSV-ből
-- Kiadók beszúrása
INSERT INTO kiadok (nev, weboldal) VALUES
('The Op', 'https://theop.games'),
('Mattel Inc.', 'https://mattel.com'),
('Gamewright', 'https://gamewright.com'),
('Winning Moves Games', 'https://www.winning-moves.com');

-- Kategóriák beszúrása
INSERT INTO kategoriak (nev) VALUES
('deck-buildig'),
('kooperatív'),
('kártyajáték'),
('kiegészítő'),
('kompetitív'),
('táblajáték'),
('puzzle');

-- Játékok beszúrása
INSERT INTO jatekok (cikkszam, nev, ar, kor_min, kor_max, jatekosok_min, jatekosok_max, nyelv, kiado_id) VALUES
('HPHOGW', 'Harry Potter Hogwarts Battle Monster box angol nyelvű kiegészítő', 10490, 11, NULL, 2, 4, 'magyar', (SELECT kiado_id FROM kiadok WHERE nev = 'The Op')),
('DB105', 'Harry Potter: Roxforti csata társasjáték', 19990, 11, NULL, 2, 4, 'magyar', (SELECT kiado_id FROM kiadok WHERE nev = 'The Op')),
('GDR44', 'Uno Flip kártyajáték', 2790, 7, NULL, 2, 10, 'magyar', (SELECT kiado_id FROM kiadok WHERE nev = 'Mattel Inc.')),
('GWDES', 'A Tiltott Sivatag társasjáték', 8490, 10, NULL, 2, 5, 'magyar', (SELECT kiado_id FROM kiadok WHERE nev = 'Gamewright')),
('WM00396-ML1-6', 'Rick and Morty 1000 db puzzle', 5490, 3, 100, 1, 6, 'francia', (SELECT kiado_id FROM kiadok WHERE nev = 'Winning Moves Games'));

-- Játék-kategória kapcsolatok beszúrása
-- HPHOGW: deck-buildig, kooperatív, kártyajáték
INSERT INTO jatek_kategoria (cikkszam, kategoria_id) VALUES
('HPHOGW', (SELECT kategoria_id FROM kategoriak WHERE nev = 'deck-buildig')),
('HPHOGW', (SELECT kategoria_id FROM kategoriak WHERE nev = 'kooperatív')),
('HPHOGW', (SELECT kategoria_id FROM kategoriak WHERE nev = 'kártyajáték'));

-- DB105: deck-buildig, kooperatív, kártyajáték, kiegészítő
INSERT INTO jatek_kategoria (cikkszam, kategoria_id) VALUES
('DB105', (SELECT kategoria_id FROM kategoriak WHERE nev = 'deck-buildig')),
('DB105', (SELECT kategoria_id FROM kategoriak WHERE nev = 'kooperatív')),
('DB105', (SELECT kategoria_id FROM kategoriak WHERE nev = 'kártyajáték')),
('DB105', (SELECT kategoria_id FROM kategoriak WHERE nev = 'kiegészítő'));

-- GDR44: kártyajáték, kompetitív
INSERT INTO jatek_kategoria (cikkszam, kategoria_id) VALUES
('GDR44', (SELECT kategoria_id FROM kategoriak WHERE nev = 'kártyajáték')),
('GDR44', (SELECT kategoria_id FROM kategoriak WHERE nev = 'kompetitív'));

-- GWDES: kooperatív, táblajáték
INSERT INTO jatek_kategoria (cikkszam, kategoria_id) VALUES
('GWDES', (SELECT kategoria_id FROM kategoriak WHERE nev = 'kooperatív')),
('GWDES', (SELECT kategoria_id FROM kategoriak WHERE nev = 'táblajáték'));

-- WM00396-ML1-6: puzzle
INSERT INTO jatek_kategoria (cikkszam, kategoria_id) VALUES
('WM00396-ML1-6', (SELECT kategoria_id FROM kategoriak WHERE nev = 'puzzle'));

-- d) Készlet oszlop hozzáadása a játékok táblához
ALTER TABLE jatekok
ADD COLUMN keszlet INT DEFAULT 0;

-- e) Email és telefon oszlopok már létre lettek hozva a kiadok táblában

-- f) Rick and Morty játék nyelvének javítása
UPDATE jatekok
SET nyelv = 'magyar'
WHERE cikkszam = 'WM00396-ML1-6';

-- g) 4 fős társaságnak való kooperatív társasjátékok
SELECT j.nev AS 'Négy fős társaságnak való kooperatív játékok'
FROM jatekok j
JOIN jatek_kategoria jk ON j.cikkszam = jk.cikkszam
JOIN kategoriak k ON jk.kategoria_id = k.kategoria_id
WHERE k.nev = 'kooperatív'
AND j.jatekosok_min <= 4
AND (j.jatekosok_max IS NULL OR j.jatekosok_max >= 4);

-- h) 8 éveseknek való játékok
SELECT j.nev AS '8 éveseknek való játékok'
FROM jatekok j
WHERE j.kor_min <= 8
AND (j.kor_max IS NULL OR j.kor_max >= 8);

-- i) Összes játék adatai a gyártó adataival együtt
SELECT 
    j.cikkszam,
    j.nev AS jatek_nev,
    j.ar,
    j.kor_min,
    j.kor_max,
    j.jatekosok_min,
    j.jatekosok_max,
    j.nyelv,
    j.keszlet,
    k.nev AS kiado_nev,
    k.weboldal AS kiado_weboldal,
    k.email AS kiado_email,
    k.telefon AS kiado_telefon
FROM jatekok j
JOIN kiadok k ON j.kiado_id = k.kiado_id;

-- j) Játékok száma gyártónként
SELECT 
    k.nev AS kiado_nev, 
    COUNT(j.cikkszam) AS jatekok_szama
FROM kiadok k
LEFT JOIN jatekok j ON k.kiado_id = j.kiado_id
GROUP BY k.kiado_id, k.nev;