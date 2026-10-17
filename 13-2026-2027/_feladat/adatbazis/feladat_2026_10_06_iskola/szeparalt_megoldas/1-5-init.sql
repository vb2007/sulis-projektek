-- 1. feladat
-- mkdir iskola
-- cd iskola
-- mkdir sql

-- 2. feladat
-- docker run --name nigga -e MYSQL_ROOT_PASSWORD=nigger -d -v "$(pwd)/sql:/sql" -p 3306:3306 mysql:9.7.1
-- docker exec -it nigga bash

-- 3. feladat
CREATE DATABASE iskola
CHARACTER SET utf8mb4
COLLATE utf8mb4_hungarian_ci;

-- 4. feladat
SHOW DATABASES;

-- 5. feladat
USE iskola;