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
    public void MegallNincsElegHelyVisszaadjaLentMaradtakat()
    {
        Assert.That(_flotta.Megall("ABC-123", "A", 0, 14), Is.EqualTo(4));
        Assert.That(_flotta.Lentmaradt("A"), Is.EqualTo(4));
    }

    [Test]
    public void Megall_egalloStatisztikaOsszesitiBuszokat()
    {
        _flotta.Megall("ABC-123", "A", 0, 5);
        _flotta.Megall("DEF-456", "A", 0, 7);
        _flotta.Megall("ABC-123", "B", 2, 0);

        Assert.That(_flotta.Felszallt("A"), Is.EqualTo(12));
        Assert.That(_flotta.Leszallt("B"), Is.EqualTo(2));
    }

    [Test]
    public void MegallLeszallokUtanFelszallnakVarakozok()
    {
        _flotta.Megall("ABC-123", "A", 0, 10);

        Assert.That(_flotta.Megall("ABC-123", "B", 10, 10), Is.Zero);
    }

    [Test]
    public void OsszesSzallitottBuszonkentSzamol()
    {
        _flotta.Megall("ABC-123", "A", 0, 10);
        _flotta.Megall("ABC-123", "B", 10, 6);

        Assert.That(_flotta.OsszesSzallitott("ABC-123"), Is.EqualTo(16));
        Assert.That(_flotta.OsszesSzallitott("DEF-456"), Is.Zero);
    }

    [Test]
    public void NapVegeTorliAzAdatokat()
    {
        _flotta.Megall("ABC-123", "A", 0, 10);

        _flotta.NapVege();

        Assert.That(_flotta.Felszallt("A"), Is.Zero);
        Assert.That(_flotta.OsszesSzallitott("ABC-123"), Is.Zero);
    }

    [Test]
    public void KonstruktorNincsBusz()
    {
        Assert.Throws<ArgumentException>(() => new BuszFlotta([], ["A"]));
    }
}
