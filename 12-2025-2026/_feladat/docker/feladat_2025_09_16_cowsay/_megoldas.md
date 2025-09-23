# Cowsay

A következő feladatban a cowsay programhoz kell különböző Dockerfile-okat létrehoznia. A program egy tehénnel (vagy egyéb lénnyel/tárggyal) képes szöveget “mondatni”.

A feladatok megoldása után készítsen képernyőképet **Dockerfileokról**, valamint a működő konténerről, ahol mind a build és run parancsok, valamint a pontos dátum és idő is látható! A képernyőképeket mentse a forrásban kapott Word fájlba! A Word fájlt nevveze el az alábbiak szerint: vezeteknev_keresztnev_cowsay.docx!

1. Készítsen egy Dockerfile-t, ami a cowsay programot fogja lefuttatni!

a. Használja az ubuntu:latest imaget!

b. Frissítse a csomaglistát!

c. Telepítse fel a cowsay programot! Ügyeljen arra, hogy minden kérdésre igennel válaszoljon!

d. Indításkor futassa a /usr/games/cowsay programot!

e. Érje el, hogy a tehén által mondott szöveg mindig “Milyen csodás ez a nap!” legyen!

f. Buildelje a Dockerfile-t, melynek neve legyen monogram/cowsay:ubuntu , ahol a monogram az Ön mono-gramja!

g. Indítsa el a konténert és készítsen képernyőképet a sikeres működésről!


2. Az előző feladat alapján készítsen egy Dockerfile-t customcowsay.Dockerfile néven.

a. A felhasználó adhassa meg, mit mondjon a tehén! Amennyiben nem adja meg, úgy a szöveg maradjon az előző feladatban leírt!

b. Buildelje a Dockerfile-t, melynek neve legyen monogram/customcowsay:ubuntu , ahol a monogram az Ön monogramja!

c. Készítsen képernyőképet a konténer sikeres működésről!

3. Készítsen egy Dockerfile-t catsay.Dockerfile , ami a cowsay programot fogja lefuttatni úgy, hogy egy macska beszél!

a. Másolja be a forrásokból a cat.cow fájlt a konténer /usr/share/cowsay/cows mappájába.

b. Indításkor futassa a /usr/games/cowsay programot! Ha a felhasználó nem ad meg paramétert, úgy a “Mi-auu” szöveg jelenjen meg.

c. Állítsa be a ‑f kapcsoló segítségével, hogy a cat.cow fájlú állat jelnjen meg.

d. Buildelje a Dockerfile-t, melynek neve legyen monogram/catsay:ubuntu , ahol a monogram az Ön mono-gramja!

e. Készítsen képernyőképet a konténer sikeres működésről!



4. Az előző feladat alapján készítsen egy Dockerfile-t foxsay.Dockerfile néven, ami a cowsay programot fogja lefuttatni úgy, hogy egy róka beszél!

a. Másolja be a forrásokból a fox.cow fájlt a konténer /usr/share/cowsay/cows mappájába.

b. Indításkor futassa a /usr/games/cowsay programot! Ha a felhasználó nem ad meg paramétert, úgy a “…” szöveg jelenjen meg.

c. Állítsa be a ‑f kapcsoló
segítségével, hogy a fox.cow fájlú állat jelnjen meg.

d. Buildelje a Dockerfile-t, melynek neve legyen monogram/foxsay:ubuntu , ahol a monogram az Ön mono-gramja!

e. Készítsen képernyőképet a konténer sikeres működésről!

## Feladatleírást készítette: Kurityák Dániel
