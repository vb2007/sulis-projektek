CREATE TABLE `kolcsonzesek` (
    `id` INT PRIMARY KEY AUTO_INCREMENT,
    `auto_id` INT,
    `ugyfel` VARCHAR(50),
    `kolcsonzes_kezdete` DATETIME,
    `kolcsonzes_vege` DATETIME,

    FOREIGN KEY (`auto_id`) REFERENCES `autok`(`id`)
);