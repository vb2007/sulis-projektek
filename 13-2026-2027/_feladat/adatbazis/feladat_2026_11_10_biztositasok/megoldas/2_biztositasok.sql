CREATE TABLE
  ugyfel (
    ugyfel_azonosito VARCHAR(20) NOT NULL,
    nev VARCHAR(100) NOT NULL,
    szuletesi_ido DATE NOT NULL,
    anyja_neve VARCHAR(100) NOT NULL,
    email_cim VARCHAR(255) NOT NULL,
    telefonszam VARCHAR(20) NOT NULL,
    CONSTRAINT pk_ugyfel PRIMARY KEY (ugyfel_azonosito)
  );

CREATE TABLE
  biztositas (
    biztositas_azonosito VARCHAR(20) NOT NULL,
    kezdeti_datum DATE NOT NULL,
    veg_datum DATE NULL,
    ugyfel_azonosito VARCHAR(20) NOT NULL,
    CONSTRAINT pk_biztositas PRIMARY KEY (biztositas_azonosito),
    CONSTRAINT fk_biztositas_ugyfel FOREIGN KEY (ugyfel_azonosito) REFERENCES ugyfel (ugyfel_azonosito)
  );

CREATE TABLE
  lakasbiztositas (
    biztositas_azonosito VARCHAR(20) NOT NULL,
    helyrajzi_szam VARCHAR(30) NOT NULL,
    ingatlan_meret DECIMAL(8, 2) NOT NULL,
    ingosag_biztositasi_ertek DECIMAL(14, 2) NOT NULL,
    CONSTRAINT pk_lakasbiztositas PRIMARY KEY (biztositas_azonosito),
    CONSTRAINT uq_lakasbiztositas_helyrajzi_szam UNIQUE (helyrajzi_szam),
    CONSTRAINT fk_lakasbiztositas_biztositas FOREIGN KEY (biztositas_azonosito) REFERENCES biztositas (biztositas_azonosito)
  );

CREATE TABLE
  gepjarmubiztositas (
    biztositas_azonosito VARCHAR(20) NOT NULL,
    alvazszam CHAR(17) NOT NULL,
    rendszam VARCHAR(10) NOT NULL,
    szin VARCHAR(30) NOT NULL,
    teljesitmeny_kw DECIMAL(6, 1) NOT NULL,
    CONSTRAINT pk_gepjarmubiztositas PRIMARY KEY (biztositas_azonosito),
    CONSTRAINT uq_gepjarmubiztositas_alvazszam UNIQUE (alvazszam),
    CONSTRAINT fk_gepjarmubiztositas_biztositas FOREIGN KEY (biztositas_azonosito) REFERENCES biztositas (biztositas_azonosito)
  );