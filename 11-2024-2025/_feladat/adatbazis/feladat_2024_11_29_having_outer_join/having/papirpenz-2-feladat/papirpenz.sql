CREATE DATABASE IF NOT EXISTS `penznemek`
DEFAULT CHARACTER SET utf8
COLLATE utf8_hungarian_ci;


USE `penznemek`;


DROP TABLE IF EXISTS `papirpenz`;
CREATE TABLE `papirpenz` (
  `azon` char(6) NOT NULL,
  `penznem` char(3) DEFAULT NULL,
  `ertek` int(11) NOT NULL
);

TRUNCATE TABLE `papirpenz`;


INSERT INTO `papirpenz` (`azon`, `penznem`, `ertek`) VALUES
('BX4555', 'EUR', 20),
('CC2178', 'EUR', 10),
('CC4191', 'HUF', 1000),
('CG5108', 'EUR', 20),
('CI8516', 'RON', 500),
('CR4663', 'HUF', 2000),
('DK9523', 'EUR', 100),
('DY4097', 'HUF', 500),
('EI4299', 'RON', 500),
('FI3791', 'EUR', 20),
('FI9391', 'RON', 5),
('FN4701', 'HUF', 2000),
('FY7928', 'EUR', 50),
('GA8511', 'HUF', 500),
('HZ6323', 'RON', 200),
('IM9279', 'HUF', 20000),
('IN1004', 'RON', 50),
('JA1527', 'HUF', 10000),
('JK7551', 'HUF', 5000),
('JT2796', 'RON', 10),
('KC3438', 'HUF', 1000),
('LM2349', 'HUF', 2000),
('LV7284', 'EUR', 50),
('MJ8150', 'HUF', 1000),
('MU8643', 'EUR', 5),
('MX3911', 'HUF', 5000),
('NP2608', 'EUR', 100),
('NR6275', 'RON', 500),
('OF4213', 'EUR', 20),
('PG4405', 'EUR', 50),
('QN6777', 'EUR', 5),
('QP4560', 'RON', 500),
('RJ8561', 'EUR', 100),
('RN7429', 'EUR', 20),
('SE5079', 'HUF', 1000),
('SF2415', 'HUF', 2000),
('SJ7132', 'EUR', 10),
('SL2031', 'RON', 500),
('UD8863', 'HUF', 20000),
('US2956', 'RON', 5),
('VA5128', 'EUR', 50),
('VD2681', 'RON', 100),
('VI4153', 'EUR', 20),
('VO1344', 'RON', 200),
('VQ5897', 'RON', 50),
('WS7980', 'RON', 50),
('XJ8241', 'HUF', 5000),
('YK9351', 'HUF', 500),
('YP5324', 'HUF', 2000),
('ZZ2536', 'RON', 50);


ALTER TABLE `papirpenz`
  ADD PRIMARY KEY (`azon`),
  ADD KEY `ertek_index` (`ertek`);
