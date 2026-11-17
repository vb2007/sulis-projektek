CREATE USER IF NOT EXISTS 'tulajdonos'@'%'
IDENTIFIED BY 'tulajdonos';

GRANT SELECT, INSERT, UPDATE, DELETE, ALTER ON `autokolcsonzo`.*
TO 'tulajdonos'@'%';

CREATE USER IF NOT EXISTS 'anna'@'%'
IDENTIFIED BY 'anna';

GRANT SELECT, INSERT, UPDATE, DELETE ON `autokolcsonzo`.`kolcsonzesek`
TO 'anna'@'%';

CREATE USER IF NOT EXISTS 'peti'@'%'
IDENTIFIED BY 'peti';

GRANT SELECT, INSERT, UPDATE, DELETE ON `autokolcsonzo`.`kolcsonzesek`
TO 'peti'@'%';

CREATE USER IF NOT EXISTS 'penzugyes'@'%'
IDENTIFIED BY 'penzugyes';

GRANT SELECT ON `autokolcsonzo`.`kolcsonzesek_nezet`
TO 'penzugyes'@'%';