-- mysql -u tulajdonos -p
-- Enter password: tulajdonos

USE `autokolcsonzo`;

INSERT INTO `autok` (`rendszam`, `marka`, `modell`, `ar_naponta`)
VALUES
    ('AA-BB-111', 'Toyota', 'Corolla', 9500),
    ('GLX-132', 'Ford', 'Focus', 4500);