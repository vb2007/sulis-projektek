using Urhajok_VB_Lib;

namespace Urhajok_VB_Tests;

[TestFixture]
public class SpaceshipTests
{
    private SpaceshipType _type;
    private SpaceshipClass _class;
    private Spaceship _ship;

    [SetUp]
    public void SetUp()
    {
        _type = new SpaceshipType("Explorer", "Leírás");
        _class = new SpaceshipClass("Alpha");
        _ship = new Spaceship("Voyager", _type, _class, 2150, 2);
    }

    [Test]
    [Description("A konstruktor beállítja a nevet.")]
    public void SpaceshipConstructorShouldSetNameWhenCreated()
    {
        Assert.That(_ship.Name, Is.EqualTo("Voyager"));
    }

    [Test]
    [Description("A konstruktor beállítja a típust.")]
    public void SpaceshipConstructorShouldSetTypeWhenCreated()
    {
        Assert.That(_ship.Type, Is.SameAs(_type));
    }

    [Test]
    [Description("A konstruktor beállítja az osztályt.")]
    public void SpaceshipConstructorShouldSetClassWhenCreated()
    {
        Assert.That(_ship.Class, Is.SameAs(_class));
    }

    [Test]
    [Description("A konstruktor beállítja a gyártási évet.")]
    public void SpaceshipConstructorShouldSetManufacturedOnYearWhenCreated()
    {
        Assert.That(_ship.ManufacturedOnYear, Is.EqualTo(2150));
    }

    [Test]
    [Description("A konstruktor beállítja a férőhelyet.")]
    public void SpaceshipConstructorShouldSetCapacityWhenCreated()
    {
        Assert.That(_ship.Capacity, Is.EqualTo(2));
    }

    [Test]
    [Description("Új hajón nincs legénység.")]
    public void SpaceshipCrewShouldBeEmptyWhenCreated()
    {
        Assert.That(_ship.Crew, Is.Empty);
    }
}
