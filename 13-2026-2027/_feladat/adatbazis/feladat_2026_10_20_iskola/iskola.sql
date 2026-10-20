DROP DATABASE IF EXISTS iskola;
CREATE DATABASE iskola
    CHARACTER SET utf8mb4
    COLLATE utf8mb4_hungarian_ci;
USE iskola;

SET NAMES utf8mb4 COLLATE utf8mb4_hungarian_ci;
SET lc_time_names = 'hu_HU';

CREATE TABLE tantargy (
    azonosito VARCHAR(20)  NOT NULL,
    nev       VARCHAR(100) NOT NULL,
    evfolyam  TINYINT      NOT NULL,
    tanterv   VARCHAR(50)  NOT NULL,
    PRIMARY KEY (azonosito)
) ENGINE=InnoDB;

CREATE TABLE tanar (
    email VARCHAR(100) NOT NULL,
    nev   VARCHAR(100) NOT NULL,
    PRIMARY KEY (email)
) ENGINE=InnoDB;

-- többértékű attribútum: egy tanárnak több végzettsége lehet
CREATE TABLE vegzettseg (
    email       VARCHAR(100) NOT NULL,
    vegzettseg  VARCHAR(100) NOT NULL,
    PRIMARY KEY (email, vegzettseg),
    FOREIGN KEY (email) REFERENCES tanar (email)
) ENGINE=InnoDB;

-- a kor származtatott attribútum, a születési időből számolható
CREATE TABLE diak (
    taj           CHAR(9)      NOT NULL,
    nev           VARCHAR(100) NOT NULL,
    szuletesi_ido DATE         NOT NULL,
    osztaly       VARCHAR(10)  NOT NULL,
    PRIMARY KEY (taj)
) ENGINE=InnoDB;

-- Tanítja (Tanár N:M Tantárgy)
CREATE TABLE tanitja (
    email     VARCHAR(100) NOT NULL,
    azonosito VARCHAR(20)  NOT NULL,
    PRIMARY KEY (email, azonosito),
    FOREIGN KEY (email)     REFERENCES tanar (email),
    FOREIGN KEY (azonosito) REFERENCES tantargy (azonosito)
) ENGINE=InnoDB;

-- Tanulja (Diák N:M Tantárgy), tanévenként
CREATE TABLE tanulja (
    taj       CHAR(9)     NOT NULL,
    azonosito VARCHAR(20) NOT NULL,
    tanev     VARCHAR(9)  NOT NULL,
    PRIMARY KEY (taj, azonosito, tanev),
    FOREIGN KEY (taj)       REFERENCES diak (taj),
    FOREIGN KEY (azonosito) REFERENCES tantargy (azonosito)
) ENGINE=InnoDB;
