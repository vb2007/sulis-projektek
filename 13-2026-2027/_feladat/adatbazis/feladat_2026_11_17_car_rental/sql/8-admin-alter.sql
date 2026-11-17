-- mysql -u tulajdonos -p
-- Enter password: tulajdonos

USE `autokolcsonzo`;

UPDATE `kolcsonzesek`
SET `kolcsonzes_kezdete` = '2024-12-31 16:55:00'
WHERE `id` = 1;