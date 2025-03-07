-- 2. feladat
DROP DATABASE IF EXISTS `allatmenhely`;

CREATE DATABASE `alltmenhely`
CHARACTER SET utf8
COLLATE utf8_hungarian_ci;

USE `allatmenhely`;

-- 3. feladat
CREATE TABLE `menhelyek` (
    id INT AUTO_INCREMENT NOT NULL,
    nev VARCHAR(50),
    cim VARCHAR(80),
    web VARCHAR(255),
    adoszam CHAR(13),
    bankszamlaszam CHAR(26),
    PRIMARY KEY (id)
);

-- 4. feladat
CREATE TABLE `allatok` (
    id INT AUTO_INCREMENT NOT NULL,
    nev VARCHAR(40) NOT NULL,
    kor INT,
    tipus VARCHAR(20),
    fajta VARCHAR(20),
    ivartalanitott BOOLEAN,
    nem VARCHAR(10),
    behozva DATE DEFAULT CURRENT_TIMESTAMP,
    menhely_id INT NOT NULL,
    PRIMARY KEY id,
    FOREIGN KEY (menhely_id) REFERENCES menhelyek(id)
);

-- 5. feladat

-- 6. feladat

-- 7. feladat

-- 8. feladat

-- 9. feladat

-- 10. feladat

-- 11. feladat

-- 12. feladat

-- 13. feladat

-- 14. feladat

-- 15. feladat

-- 16. feladat

-- 17. feladat

-- 18. feladat
