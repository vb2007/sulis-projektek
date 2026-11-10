DROP DATABASE IF EXISTS telekom_egytablas;

CREATE DATABASE telekom_egytablas CHARACTER
SET
  utf8mb4 COLLATE utf8mb4_hungarian_ci;

USE telekom_egytablas;

CREATE TABLE
  ugyfel (
    ugyfel_azonosito VARCHAR(20) NOT NULL,
    nev VARCHAR(100) NOT NULL,
    szuletesi_ido DATE NOT NULL,
    anyja_neve VARCHAR(100) NOT NULL,
    email VARCHAR(255) NOT NULL,
    telefonszam VARCHAR(20) NOT NULL,
    PRIMARY KEY (ugyfel_azonosito)
  );

CREATE TABLE
  szerzodes (
    szerzodes_szam VARCHAR(20) NOT NULL,
    kezdes_datum DATE NOT NULL,
    fizetendo_osszeg DECIMAL(10, 2) NOT NULL,
    ugyfel_azonosito VARCHAR(20) NOT NULL,
    -- mobil
    mobilszam VARCHAR(20) NULL,
    feltoltos BOOLEAN NULL, -- 1 = feltöltős, 0 = előfizetéses
    husegido_vege DATE NULL,
    -- kábeltévé
    csomag_nev VARCHAR(100) NULL,
    extrak_osszkoltseg DECIMAL(10, 2) NULL,
    -- internet
    max_letoltes INT NULL, -- Mbit/s
    max_feltoltes INT NULL, -- Mbit/s
    sajat_router BOOLEAN NULL, -- 1 = saját, 0 = bérelt
    PRIMARY KEY (szerzodes_szam),
    UNIQUE (mobilszam),
    FOREIGN KEY (ugyfel_azonosito) REFERENCES ugyfel (ugyfel_azonosito) ON UPDATE CASCADE ON DELETE RESTRICT
  );