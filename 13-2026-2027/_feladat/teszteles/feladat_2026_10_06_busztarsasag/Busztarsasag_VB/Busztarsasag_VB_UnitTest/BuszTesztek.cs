using Busztarsasag_VB_Lib;

namespace Busztarsasag_VB_UnitTest;

[TestFixture]
public class BuszTesztek
{
    [Test]
    public void FelszallTeliBuszCsakSzabadHelyekreSzallnakFel()
    {
        Busz busz = new Busz("ABC-123", 10);

        Assert.That(busz.Felszall(15), Is.EqualTo(10));
        Assert.That(busz.Utasok, Is.EqualTo(10));
    }

    [Test]
    public void LeszallTobbenMintAhanyanVannak()
    {
        Busz busz = new Busz("ABC-123", 10);
        busz.Felszall(3);

        Assert.Throws<ArgumentOutOfRangeException>(() => busz.Leszall(4));
    }

    [Test]
    public void OsszesSzallitottCsakFelszallokatSzamolja()
    {
        Busz busz = new Busz("ABC-123", 10);
        busz.Felszall(8);
        busz.Leszall(8);
        busz.Felszall(5);

        Assert.That(busz.OsszesSzallitott, Is.EqualTo(13));
    }

    [Test]
    public void NapVegeNullaz()
    {
        Busz busz = new Busz("ABC-123", 10);
        busz.Felszall(5);

        busz.NapVege();

        Assert.That(busz.Utasok, Is.Zero);
        Assert.That(busz.OsszesSzallitott, Is.Zero);
    }
}
