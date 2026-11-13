-- 12. feladat

-- tanárok
CREATE USER "Ilona"@"%" IDENTIFIED BY "Ilona";
CREATE USER "Laci"@"%" IDENTIFIED BY "Laci";
GRANT SELECT, INSERT
    ON iskola.jegyek
    TO "Ilona"@"%", "Laci"@"%";

--- diákok
CREATE USER "Dani"@"%" IDENTIFIED BY "Dani";
CREATE USER "Juci"@"%" IDENTIFIED BY "Juci";
CREATE USER "Kati"@"%" IDENTIFIED BY "Kati";
CREATE USER "Marci"@"%" IDENTIFIED BY "Marci";
GRANT SELECT
    ON iskola.jegyeim
    TO "Dani"@"%", "Juci"@"%", "Kati"@"%", "Marci"@"%";

-- admin
CREATE USER "Admin"@"%" IDENTIFIED BY "Admin";
GRANT ALL PRIVILEGES
    ON iskola.*
    TO "Admin"@"%";

FLUSH PRIVILEGES;