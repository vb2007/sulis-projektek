CREATE USER IF NOT EXISTS 'tulajdonos'@'%'
IDENTIFIED BY 'tulajdonos';

GRANT ALL PRIVILEGES ON `autokolcsonzo`.*
TO 'tulajdonos'@'%';

CREATE USER IF NOT EXISTS 'anna'@'%'
IDENTIFIED BY 'anna';

GRANT CREATE ON `autokolcsonzo`.*
TO 'anna'@'%';

CREATE USER IF NOT EXISTS 'peti'@'%'
IDENTIFIED BY 'peti';

GRANT CREATE ON `autokolcsonzo`.*
TO 'peti'@'%';

CREATE USER IF NOT EXISTS 'penzugyes'@'%'
IDENTIFIED BY 'penzugyes';

GRANT READ ON `autokolcsonzo`.`kolcsonzesek_nezet`
TO 'penzugyes'@'%';