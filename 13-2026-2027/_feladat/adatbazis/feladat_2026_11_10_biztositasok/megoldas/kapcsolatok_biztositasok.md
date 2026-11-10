[A]
ugyfel(_ugyfel_azonosito_, nev, szuletesi_ido, anyja_neve, email_cim, telefonszam)
biztositas(_biztositas_azonosito_, kezdeti_datum, veg_datum, ugyfel_azonosito, ~helyrajzi_szam~, ~ingatlan_meret~, ~ingosag_biztositasi_ertek~, _ _~alvazszam~_ _, _ _~rendszam~_ _, _ _~szin~_ _, _ _~teljesitmeny_kw~_ _)

[B]
ugyfel(_ugyfel_azonosito_, nev, szuletesi_ido, anyja_neve, email_cim, telefonszam)
biztositas(_biztositas_azonosito_, kezdeti_datum, veg_datum, ugyfel_azonosito)
lakasbiztositas(_biztositas_azonosito_, helyrajzi_szam, ingatlan_meret, ingosag_biztositasi_ertek)
gepjarmubiztositas(_biztositas_azonosito_, alvazszam, rendszam, szin, teljesitmeny_kw)

[C]
ugyfel(_ugyfel_azonosito_, nev, szuletesi_ido, anyja_neve, email_cim, telefonszam)
lakasbiztositas(_biztositas_azonosito_, kezdeti_datum, veg_datum, ugyfel_azonosito, helyrajzi_szam, ingatlan_meret, ingosag_biztositasi_ertek)
gepjarmubiztositas(_biztositas_azonosito_, kezdeti_datum, veg_datum, ugyfel_azonosito, alvazszam, rendszam, szin, teljesitmeny_kw)