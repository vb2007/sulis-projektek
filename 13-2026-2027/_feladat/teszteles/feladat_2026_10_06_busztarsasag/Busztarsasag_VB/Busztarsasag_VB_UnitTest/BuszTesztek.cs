using Busztarsasag_VB_Lib;

namespace Busztarsasag_VB_UnitTest;

[TestFixture]
public class BuszTesztek
{
    [Test]
    [Description("Teli busznál csak a szabad helyekre lehet felszállni")]
    public void FelszallTeliBuszCsakSzabadHelyekreSzallnakFel()
    {
        Busz busz = new Busz("ABC-123", 10);

        Assert.That(busz.Felszall(15), Is.EqualTo(10), "Csak a szabad helyek számának megfelelő utas szállhat fel");
        Assert.That(busz.Utasok, Is.EqualTo(10), "A teli busz utasszáma egyezzen a férőhellyel");
    }

    [Test]
    [Description("Több leszálló, mint utas: hiba")]
    public void LeszallTobbenMintAhanyanVannak()
    {
        Busz busz = new Busz("ABC-123", 10);
        busz.Felszall(3);

        Assert.Throws<ArgumentOutOfRangeException>(() => busz.Leszall(4), "Több leszálló, mint utas esetén kivételt kell dobni");
    }

    [Test]
    [Description("Az összes szállított csak a felszállókat számolja")]
    public void OsszesSzallitottCsakFelszallokatSzamolja()
    {
        Busz busz = new Busz("ABC-123", 10);
        busz.Felszall(8);
        busz.Leszall(8);
        busz.Felszall(5);

        Assert.That(busz.OsszesSzallitott, Is.EqualTo(13), "Csak a felszállók számítanak az összes szállítottba");
    }

    [Test]
    [Description("Nap végén a busz adatai nullázódnak")]
    public void NapVegeNullaz()
    {
        Busz busz = new Busz("ABC-123", 10);
        busz.Felszall(5);

        busz.NapVege();

        Assert.That(busz.Utasok, Is.Zero, "A busz üres kell legyen nap végén");
        Assert.That(busz.OsszesSzallitott, Is.Zero, "A szállított utasok száma nullázódjon nap végén");
    }
}
