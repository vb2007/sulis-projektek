-- 3. Feladat
CREATE TABLE fajok (
  faj_id int NOT NULL auto_increment,
  faj_nev varchar(30) NOT NULL,
  CONSTRAINT pk_fajok PRIMARY KEY (faj_id)
);

-- 4. Feladat
CREATE TABLE hajo_szerepek (
  szerep_id int NOT NULL auto_increment,
  szerep_nev varchar(50) NOT NULL,
  CONSTRAINT pk_szerep PRIMARY KEY (szerep_id)
);