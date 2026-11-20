-- 8. feladat
CREATE TABLE jegyek (
    id INT AUTO_INCREMENT PRIMARY KEY,
    tantárgy_id INT NOT NULL,
    jegy INT NOT NULL,
    diak VARCHAR(20) NOT NULL,
    tanar VARCHAR(20) NOT NULL,
    beirva DATETIME NOT NULL,
    FOREIGN KEY (tantárgy_id)
        REFERENCES tantargyak(id)
);