USE `autoskartya`;

TRUNCATE TABLE `autoskartya`;

INSERT INTO `autoskartya` (`id`, `gyartmany`, `tipus`, `orszagkod`, `orszag`, `hengerurtartalom`, `loero`, `kilowatt`, `nyomatek`, `vegsebesseg`, `gyorsulas`, `fogyasztas`, `gyartasi_ev`) VALUES
(1, 'BMW', '120D', 'D', 'Németország', 1995, 177, 132, 350, 220, 7.60, 4.90, 2007),
(2, 'Peugeot', '207 SW 1.6 HDI', 'F', 'Franciaország', 1560, 109, 81, 240, 189, 21.10, 5.60, 2010),
(3, 'BMW', '530 XD', 'D', 'Németország', 2993, 235, 175, 500, 240, 18.00, 6.80, 2009),
(4, 'Mercedes', 'CLK DTM AMG', 'D', 'Németország', 5439, 582, 434, 800, 300, 4.00, 16.00, 2006),
(5, 'VW', 'Golf GTI', 'D', 'Németország', 1984, 200, 149, 280, 233, 6.90, 7.90, 2005),
(6, 'Honda', 'Jazz 1.4I CVT', 'J', 'Japán', 1340, 83, 61, 119, 160, 14.50, 5.90, 2007),
(7, 'Ford', 'Mondeo 2.5T', 'D', 'Németország', 1967, 220, 164, 320, 245, 7.50, 9.30, 2007),
(8, 'Land Rover', 'Range Rover Sport 3.6', 'GB', 'Egyesült Királyság', 3630, 272, 202, 640, 225, 9.20, 11.10, 2008),
(9, 'BMW', 'X3 3.0 SD', 'D', 'Németország', 2993, 286, 213, 580, 240, 6.60, 8.70, 2006),
(10, 'Bentley', 'Continental GT', 'GB', 'Egyesült Királyság', 5998, 560, 417, 650, 312, 4.90, 17.70, 2003),
(11, 'Jaguar', 'S-TYPE R', 'GB', 'Egyesült Királyság', 4196, 395, 294, 541, 250, 5.60, 12.40, 2002),
(12, 'Corvette', 'Z06', 'USA', 'Amerikai Egyesült Államok', 6997, 505, 376, 657, 320, 3.70, 11.60, 2005),
(13, 'Fiat', 'Panda 4x4', 'I', 'Olaszország', 1242, 60, 44, 102, 145, 20.00, 6.60, 2004),
(14, 'Honda', 'City', 'J', 'Japán', 1998, 201, 150, 193, 235, 6.60, 9.10, 2011),
(15, 'Opel', 'Astra', 'D', 'Németország', 1910, 150, 111, 320, 213, 10.20, 6.10, 2005),
(16, 'Skoda', 'Octavia RS', 'SK', 'Szlovákia', 1968, 170, 126, 350, 225, 8.50, 5.80, 2009),
(17, 'Volvo', 'S60R', 'S', 'Svédország', 2521, 300, 223, 400, 250, 5.70, 10.50, 2003),
(18, 'Volvo', 'S80 3.2', 'S', 'Svédország', 3192, 238, 177, 320, 240, 8.00, 9.80, 2006),
(19, 'Fiat', 'Grande Punto', 'I', 'Olaszország', 1248, 90, 67, 200, 175, 11.90, 4.60, 2005),
(20, 'Nissan', 'X-Trail 2.2', 'J', 'Japán', 2148, 136, 101, 314, 180, 11.50, 7.20, 2004);