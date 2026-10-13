using Busztarsasag_VB_Lib;

namespace Busztarsasag_VB_UnitTest;

[TestFixture]
public class BuszFlottaTesztek
{
    private BuszFlotta _flotta = null!;

    [SetUp]
    public void Setup()
    {
        _flotta = new BuszFlotta([new Busz("ABC-123", 10), new Busz("DEF-456", 20)], ["A", "B"]);
    }

    [Test]
    [Description("Hiányzó hely esetén visszaadja a lent maradtakat")]
    public void MegallNincsElegHelyVisszaadjaLentMaradtakat()
    {
        Assert.That(_flotta.Megall("ABC-123", "A", 0, 14), Is.EqualTo(4), "A lent maradtak számát vissza kell adni");
        Assert.That(_flotta.Lentmaradt("A"), Is.EqualTo(4), "A megálló rögzítse a lent maradtakat");
    }

    [Test]
    [Description("A megálló statisztikája több busz adatát összegzi")]
    public void Megall_egalloStatisztikaOsszesitiBuszokat()
    {
        _flotta.Megall("ABC-123", "A", 0, 5);
        _flotta.Megall("DEF-456", "A", 0, 7);
        _flotta.Megall("ABC-123", "B", 2, 0);

        Assert.That(_flotta.Felszallt("A"), Is.EqualTo(12), "A megálló összegezze a felszállókat");
        Assert.That(_flotta.Leszallt("B"), Is.EqualTo(2), "A megálló összegezze a leszállókat");
    }

    [Test]
    [Description("Előbb leszállnak, utána szállnak fel a várakozók")]
    public void MegallLeszallokUtanFelszallnakVarakozok()
    {
        _flotta.Megall("ABC-123", "A", 0, 10);

        Assert.That(_flotta.Megall("ABC-123", "B", 10, 10), Is.Zero, "A leszállás után felszabadult helyekre mindenki felfér");
    }

    [Test]
    [Description("Az összes szállított buszonként számolódik")]
    public void OsszesSzallitottBuszonkentSzamol()
    {
        _flotta.Megall("ABC-123", "A", 0, 10);
        _flotta.Megall("ABC-123", "B", 10, 6);

        Assert.That(_flotta.OsszesSzallitott("ABC-123"), Is.EqualTo(16), "Az első busz szállított utasainak száma hibás");
        Assert.That(_flotta.OsszesSzallitott("DEF-456"), Is.Zero, "A másik busz nem szállított utast");
    }

    [Test]
    [Description("Nap végén a flotta adatai törlődnek")]
    public void NapVegeTorliAzAdatokat()
    {
        _flotta.Megall("ABC-123", "A", 0, 10);

        _flotta.NapVege();

        Assert.That(_flotta.Felszallt("A"), Is.Zero, "A felszállók száma nullázódjon nap végén");
        Assert.That(_flotta.OsszesSzallitott("ABC-123"), Is.Zero, "A szállított utasok száma nullázódjon nap végén");
    }

    [Test]
    [Description("Busz nélküli flotta: hiba")]
    public void KonstruktorNincsBusz()
    {
        Assert.Throws<ArgumentException>(() => new BuszFlotta([], ["A"]), "Busz nélküli flotta esetén kivételt kell dobni");
    }
}
