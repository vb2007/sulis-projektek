using Urhajok_VB_Lib;

namespace Urhajok_VB_Tests;

[TestFixture]
public class SpaceshipClassTests
{
    [Test]
    [Description("A konstruktor beállítja a nevet.")]
    public void SpaceshipClassConstructorShouldSetNameWhenNameIsValid()
    {
        SpaceshipClass spaceshipClass = new SpaceshipClass("Alpha");

        Assert.That(spaceshipClass.Name, Is.EqualTo("Alpha"));
    }

    [Test]
    [Description("Üres név kivételt dob.")]
    public void SpaceshipClassConstructorShouldThrowWhenNameIsEmpty()
    {
        Assert.Throws<ArgumentException>(() => new SpaceshipClass(""));
    }

    [Test]
    [Description("Szóközös név kivételt dob.")]
    public void SpaceshipClassConstructorShouldThrowWhenNameIsWhitespace()
    {
        Assert.Throws<ArgumentException>(() => new SpaceshipClass("   "));
    }

    [Test]
    [Description("Null név kivételt dob.")]
    public void SpaceshipClassConstructorShouldThrowWhenNameIsNull()
    {
        Assert.Throws<ArgumentException>(() => new SpaceshipClass(null!));
    }

    [Test]
    [Description("A kivétel üzenete magyar.")]
    public void SpaceshipClassConstructorShouldThrowHungarianMessageWhenNameIsEmpty()
    {
        ArgumentException ex = Assert.Throws<ArgumentException>(() => new SpaceshipClass(""));

        Assert.That(ex!.Message, Does.StartWith("Az osztály nevének megadása kötelező."));
    }

    [Test]
    [Description("Szabad szövegű név elfogadott.")]
    public void SpaceshipClassConstructorShouldAcceptWhenNameIsFreeText()
    {
        SpaceshipClass spaceshipClass = new SpaceshipClass("Ür-Hajó #1 (próba)!");

        Assert.That(spaceshipClass.Name, Is.EqualTo("Ür-Hajó #1 (próba)!"));
    }
}
