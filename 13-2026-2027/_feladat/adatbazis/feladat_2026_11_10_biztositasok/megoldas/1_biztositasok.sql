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
    -- lakasbiztositas
    helyrajzi_szam VARCHAR(30) NULL,
    ingatlan_meret DECIMAL(8, 2) NULL,
    ingosag_biztositasi_ertek DECIMAL(14, 2) NULL,
    -- gepjarmubiztositas
    alvazszam CHAR(17) NULL,
    rendszam VARCHAR(10) NULL,
    szin VARCHAR(30) NULL,
    teljesitmeny_kw DECIMAL(6, 1) NULL,
    CONSTRAINT pk_biztositas PRIMARY KEY (biztositas_azonosito),
    CONSTRAINT uq_biztositas_helyrajzi_szam UNIQUE (helyrajzi_szam),
    CONSTRAINT uq_biztositas_alvazszam UNIQUE (alvazszam),
    CONSTRAINT fk_biztositas_ugyfel FOREIGN KEY (ugyfel_azonosito) REFERENCES ugyfel (ugyfel_azonosito)
  );