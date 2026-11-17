CREATE VIEW `kolcsonzesek_nezet` AS
SELECT
    `kolcsonzesek`.`id`,
    `kolcsonzesek`.`auto_id`,
    `autok`.`marka`,
    `autok`.`modell`,
    `kolcsonzesek`.`ugyfel`,
    `kolcsonzesek`.`kolcsonzes_kezdete`,
    `kolcsonzesek`.`kolcsonzes_vege`
FROM `kolcsonzesek`
INNER JOIN `autok`
    ON `kolcsonzesek`.`auto_id` = `autok`.`id`;