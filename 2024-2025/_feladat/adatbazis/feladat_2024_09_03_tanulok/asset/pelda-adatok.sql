USE `pelda`;

SET foreign_key_checks = 0; 

INSERT INTO `autok` (`rendszam`,`gyarto`, `tipus`, `kategoria`, `uzemanyag`, `szin`)  VALUES
('XXX-111', 'Opel', 'Adam', 'M1','benzin', 'piros'),
('AAA-555', 'Honda', 'Jazz', 'M1','hibrid', 'kék'),
('ABC-123', 'Ford', 'Focus', 'M1','diesel', 'kék'),
('AA-AX-1234', 'Ford', 'Fiesta', 'M1','benzin', 'sárga')
;

INSERT INTO `termek` (`nev`,`kategoria`, `netto`, `penznem`, `afa`)  VALUES
('4K TV', 'tv', 499, 'EUR', 0.19 ),
('Mobil 32GB' , 'mobil', 299, 'EUR', 0.19 ),
('Mobil 128GB', 'mobil', 679, 'EUR', 0.19 ),
('Olcsó laptop', 'laptop', 269, 'EUR', 0.19 ),
('Drága laptop', 'laptop', 1729, 'EUR', 0.19 ),
('Könyv', 'könyv', null, null, null )
;

SET foreign_key_checks = 1;