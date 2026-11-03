DROP DATABASE IF EXISTS kek_osztriga;
CREATE DATABASE kek_osztriga
  CHARACTER SET utf8mb4
  COLLATE utf8mb4_hungarian_ci;
USE kek_osztriga;

CREATE TABLE nemzetiseg (
  nev VARCHAR(50) NOT NULL,
  PRIMARY KEY (nev)
) ENGINE=InnoDB;

CREATE TABLE mufaj (
  nev VARCHAR(50) NOT NULL,
  PRIMARY KEY (nev)
) ENGINE=InnoDB;

CREATE TABLE csoport (
  nev            VARCHAR(100) NOT NULL,
  nemzetiseg_nev VARCHAR(50)  NOT NULL,
  atlageletkor   DECIMAL(4,1) NOT NULL CHECK (atlageletkor > 0),
  pontszam       DECIMAL(6,2) NOT NULL DEFAULT 0 CHECK (pontszam >= 0),
  PRIMARY KEY (nev),
  FOREIGN KEY (nemzetiseg_nev) REFERENCES nemzetiseg (nev)
    ON UPDATE CASCADE ON DELETE RESTRICT
) ENGINE=InnoDB;

CREATE TABLE tanc (
  nev VARCHAR(100) NOT NULL,
  PRIMARY KEY (nev)
) ENGINE=InnoDB;

CREATE TABLE zene (
  cim       VARCHAR(200) NOT NULL,
  eloado    VARCHAR(200) NOT NULL,
  mufaj_nev VARCHAR(50)  NOT NULL,
  PRIMARY KEY (cim),
  FOREIGN KEY (mufaj_nev) REFERENCES mufaj (nev)
    ON UPDATE CASCADE ON DELETE RESTRICT
) ENGINE=InnoDB;

-- csoport M:N tanc
CREATE TABLE eloadja (
  csoport_nev VARCHAR(100) NOT NULL,
  tanc_nev    VARCHAR(100) NOT NULL,
  PRIMARY KEY (csoport_nev, tanc_nev),
  FOREIGN KEY (csoport_nev) REFERENCES csoport (nev)
    ON UPDATE CASCADE ON DELETE CASCADE,
  FOREIGN KEY (tanc_nev) REFERENCES tanc (nev)
    ON UPDATE CASCADE ON DELETE CASCADE
) ENGINE=InnoDB;

CREATE TABLE zeneje (
  tanc_nev VARCHAR(100) NOT NULL,
  zene_cim VARCHAR(200) NOT NULL,
  PRIMARY KEY (tanc_nev, zene_cim),
  FOREIGN KEY (tanc_nev) REFERENCES tanc (nev)
    ON UPDATE CASCADE ON DELETE CASCADE,
  FOREIGN KEY (zene_cim) REFERENCES zene (cim)
    ON UPDATE CASCADE ON DELETE CASCADE
) ENGINE=InnoDB;

INSERT INTO nemzetiseg (nev) VALUES ('magyar'), ('osztrák'), ('argentin');
INSERT INTO mufaj (nev) VALUES ('klasszikus'), ('tangó'), ('népzene');

INSERT INTO csoport (nev, nemzetiseg_nev, atlageletkor, pontszam) VALUES
  ('Tisza Táncegyüttes',   'magyar',   24.5, 87.50),
  ('Wiener Walzer Gruppe', 'osztrák',  31.2, 92.00),
  ('Compañía del Sur',     'argentin', 27.0, 79.25);

INSERT INTO tanc (nev) VALUES ('keringő'), ('tangó'), ('csárdás');

INSERT INTO zene (cim, eloado, mufaj_nev) VALUES
  ('A kék Duna',       'Johann Strauss II', 'klasszikus'),
  ('Por una cabeza',   'Carlos Gardel',     'tangó'),
  ('Szatmári csárdás', 'Muzsikás',          'népzene');

INSERT INTO eloadja (csoport_nev, tanc_nev) VALUES
  ('Tisza Táncegyüttes',   'csárdás'),
  ('Tisza Táncegyüttes',   'keringő'),
  ('Wiener Walzer Gruppe', 'keringő'),
  ('Compañía del Sur',     'tangó');

INSERT INTO zeneje (tanc_nev, zene_cim) VALUES
  ('keringő', 'A kék Duna'),
  ('tangó',   'Por una cabeza'),
  ('csárdás', 'Szatmári csárdás');
