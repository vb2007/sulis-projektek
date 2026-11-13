DROP DATABASE IF EXISTS telekom_tobbtablas;

CREATE DATABASE telekom_tobbtablas CHARACTER
SET
  utf8mb4 COLLATE utf8mb4_hungarian_ci;

USE telekom_tobbtablas;

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
    PRIMARY KEY (szerzodes_szam),
    FOREIGN KEY (ugyfel_azonosito) REFERENCES ugyfel (ugyfel_azonosito) ON UPDATE CASCADE ON DELETE RESTRICT
  );

CREATE TABLE
  mobil_szerzodes (
    szerzodes_szam VARCHAR(20) NOT NULL,
    mobilszam VARCHAR(20) NOT NULL,
    feltoltos BOOLEAN NOT NULL, -- 1 = feltöltős, 0 = előfizetéses
    husegido_vege DATE NULL, -- opcionális
    PRIMARY KEY (szerzodes_szam),
    UNIQUE (mobilszam),
    FOREIGN KEY (szerzodes_szam) REFERENCES szerzodes (szerzodes_szam) ON UPDATE CASCADE ON DELETE CASCADE
  );

CREATE TABLE
  kabeltv_szerzodes (
    szerzodes_szam VARCHAR(20) NOT NULL,
    csomag_nev VARCHAR(100) NOT NULL,
    extrak_osszkoltseg DECIMAL(10, 2) NOT NULL,
    PRIMARY KEY (szerzodes_szam),
    FOREIGN KEY (szerzodes_szam) REFERENCES szerzodes (szerzodes_szam) ON UPDATE CASCADE ON DELETE CASCADE
  );

CREATE TABLE
  internet_szerzodes (
    szerzodes_szam VARCHAR(20) NOT NULL,
    max_letoltes INT NOT NULL, -- Mbit/s
    max_feltoltes INT NOT NULL, -- Mbit/s
    sajat_router BOOLEAN NOT NULL, -- 1 = saját, 0 = bérelt
    PRIMARY KEY (szerzodes_szam),
    FOREIGN KEY (szerzodes_szam) REFERENCES szerzodes (szerzodes_szam) ON UPDATE CASCADE ON DELETE CASCADE
  );