DROP DATABASE IF EXISTS taxi;
CREATE DATABASE taxi
    CHARACTER SET utf8mb4
    COLLATE utf8mb4_hungarian_ci;
USE taxi;

SET NAMES utf8mb4 COLLATE utf8mb4_hungarian_ci;
SET lc_time_names = 'hu_HU';

CREATE TABLE sofor (
    engedely VARCHAR(20)  NOT NULL,
    nev      VARCHAR(100) NOT NULL,
    PRIMARY KEY (engedely)
) ENGINE=InnoDB;

-- többértékű attribútum: egy sofőrnek több telefonszáma lehet
CREATE TABLE telefon (
    engedely VARCHAR(20) NOT NULL,
    telefon  VARCHAR(20) NOT NULL,
    PRIMARY KEY (engedely, telefon),
    FOREIGN KEY (engedely) REFERENCES sofor (engedely)
) ENGINE=InnoDB;

-- Vezeti (Sofőr 1:1 Taxi)
CREATE TABLE taxi (
    rendszam VARCHAR(10) NOT NULL,
    tipus    VARCHAR(50) NOT NULL,
    ferohely TINYINT     NOT NULL,
    engedely VARCHAR(20) NOT NULL,
    PRIMARY KEY (rendszam),
    UNIQUE (engedely),
    FOREIGN KEY (engedely) REFERENCES sofor (engedely)
) ENGINE=InnoDB;

-- TaxiFuvar (Taxi 1:N Fuvar); az Indulás (idő + cím) összetett attribútum a kulcs
CREATE TABLE fuvar (
    indulasi_ido  DATETIME      NOT NULL,
    indulasi_cim  VARCHAR(150)  NOT NULL,
    nev           VARCHAR(100)  NOT NULL,
    cel           VARCHAR(150)  NOT NULL,
    km            DECIMAL(6,1)  NOT NULL,
    rendszam      VARCHAR(10)   NOT NULL,
    PRIMARY KEY (indulasi_ido, indulasi_cim),
    FOREIGN KEY (rendszam) REFERENCES taxi (rendszam)
) ENGINE=InnoDB;
