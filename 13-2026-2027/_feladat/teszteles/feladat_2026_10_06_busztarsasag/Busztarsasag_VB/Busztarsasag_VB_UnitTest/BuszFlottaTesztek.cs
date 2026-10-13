using Busztarsasag_VB_Lib;

namespace Busztarsasag_VB_UnitTest;

public class BuszFlottaTesztek
{
    private BuszFlotta _flotta = null!;

    [SetUp]
    public void Setup()
    {
        _flotta = new BuszFlotta([new Busz("ABC-123", 10), new Busz("DEF-456", 20)], ["A", "B"]);
    }

    [Test]
    public void Megall_NincsElegHely_VisszaadjaALentMaradtakat()
    {
        Assert.That(_flotta.Megall("ABC-123", "A", 0, 14), Is.EqualTo(4));
        Assert.That(_flotta.Lentmaradt("A"), Is.EqualTo(4));
    }

    [Test]
    public void Megall_MegalloStatisztikaOsszesitiABuszokat()
    {
        _flotta.Megall("ABC-123", "A", 0, 5);
        _flotta.Megall("DEF-456", "A", 0, 7);
        _flotta.Megall("ABC-123", "B", 2, 0);

        Assert.That(_flotta.Felszallt("A"), Is.EqualTo(12));
        Assert.That(_flotta.Leszallt("B"), Is.EqualTo(2));
    }

    [Test]
    public void Megall_LeszallokUtanFelszallnakAVarakozok()
    {
        _flotta.Megall("ABC-123", "A", 0, 10);

        Assert.That(_flotta.Megall("ABC-123", "B", 10, 10), Is.Zero);
    }

    [Test]
    public void OsszesSzallitott_BuszonkentSzamol()
    {
        _flotta.Megall("ABC-123", "A", 0, 10);
        _flotta.Megall("ABC-123", "B", 10, 6);

        Assert.That(_flotta.OsszesSzallitott("ABC-123"), Is.EqualTo(16));
        Assert.That(_flotta.OsszesSzallitott("DEF-456"), Is.Zero);
    }

    [Test]
    public void NapVege_TorliAzAdatokat()
    {
        _flotta.Megall("ABC-123", "A", 0, 10);

        _flotta.NapVege();

        Assert.That(_flotta.Felszallt("A"), Is.Zero);
        Assert.That(_flotta.OsszesSzallitott("ABC-123"), Is.Zero);
    }

    [Test]
    public void Konstruktor_NincsBusz_Kivetel()
    {
        Assert.Throws<ArgumentException>(() => new BuszFlotta([], ["A"]));
    }
}
