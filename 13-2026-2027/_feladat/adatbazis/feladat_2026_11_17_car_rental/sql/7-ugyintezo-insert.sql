-- mysql -u peti -p
-- Enter password: peti

USE `autokolcsonzo`;

SELECT `id` FROM `autok` WHERE `rendszam` = 'AA-BB-111';

INSERT INTO `kolcsonzesek` (`auto_id`, `ugyfel`, `kolcsonzes_kezdete`, `kolcsonzes_vege`)
VALUES
    (1, 'Benjamin Netanyahu', '2024-12-11 12:35:00', NOW());