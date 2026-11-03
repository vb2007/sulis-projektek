1. Töltse be a kassza.sql állományt az adatbázisskezelőbe!
2. Jelölje ki aktívnak ezt az adatbázist!
3. Hozza létre a hiányzó idegenkulcsokat: a cikk (blokk_id) és a blokk(id) táblák között, valamint az blokk (elado_id) és az elado(id) táblák között!
4. Hozzon létre egy nézet táblát havi_osszesítés néven, ami megjeleníti év és havi bontásban a kiállított blokk összértékét!
5. Hozzon létre egy modositas nevű táblát, ami tartalmazza a módosított blokk azonosítóját, a régi és az új összeget (regi_osszeg, uj_osszeg néve), a módosítás idejét és a módosítást végző felhasználót (mod_user). A módosítást végző felhasználóhoz az aktuális felhasználót a CURRENT_USER() függvénnyel kérje le, automatikusan töltve a mező értékét!
6. A kasszát be kell kötni a NAV online rendszerébe. Ehhez hozzon létre egy nav nevu felhasználót, aki a 192.168.1.11 címről kell tudjon bejelentkezni a navUser2026 jelszóval! Csak a megtekinteni a havi_osszesites‘ adatainak lekérdezéséhez legyen joga.
7. Bővítse a blokk táblát egy storno nevű logikai mezővel! Alapértelmezetten hamis értéket vegyen fel a mező.
8. A pénztárgép normál működéséhez hozzon létre egy kasszaprogram nevű felhasználót, aki beszúrni és módosítani tud a blokk táblában, míg a cikk táblába csak beszúrni! Jelszava legyen K4ssz4J3lsz0! és a 192.168.0.* címekről legyen használható.
9. Az adatok karbantartására hozzon létre egy kasszaadmin felhasználót, aki tudjon beszúrni, módosítani, törölni adatokat a blokk és a cikk táblában is. Kezdeti jelszava legyen adm1nPass++ és a 192.168.*.* címről tudjon bejelentkezni.