using Urhajok_VB_Lib;

namespace Urhajok_VB_Tests;

[TestFixture]
public class SpaceshipTypeTests
{
    private List<Skill> _skills;

    [SetUp]
    public void SetUp()
    {
        _skills = new List<Skill> { new Skill("Piloting", 5) };
    }

    [Test]
    [Description("A konstruktor beállítja a nevet.")]
    public void SpaceshipTypeConstructorShouldSetNameWhenCreated()
    {
        SpaceshipType type = new SpaceshipType("Explorer", "Leírás", _skills);

        Assert.That(type.Name, Is.EqualTo("Explorer"));
    }

    [Test]
    [Description("A konstruktor beállítja a leírást.")]
    public void SpaceshipTypeConstructorShouldSetDescriptionWhenCreated()
    {
        SpaceshipType type = new SpaceshipType("Explorer", "Leírás", _skills);

        Assert.That(type.Description, Is.EqualTo("Leírás"));
    }

    [Test]
    [Description("A megadott szakértelmek megmaradnak.")]
    public void SpaceshipTypeConstructorShouldSetRequiredSkillsWhenSkillsAreGiven()
    {
        SpaceshipType type = new SpaceshipType("Explorer", "Leírás", _skills);

        Assert.That(type.RequiredSkills, Is.EqualTo(_skills));
    }

    [Test]
    [Description("Szakértelem nélkül üres lista jön létre.")]
    public void SpaceshipTypeConstructorShouldCreateEmptyListWhenSkillsAreNotGiven()
    {
        SpaceshipType type = new SpaceshipType("Explorer", "Leírás");

        Assert.That(type.RequiredSkills, Is.Not.Null.And.Empty);
    }

    [Test]
    [Description("Null szakértelem esetén üres lista jön létre.")]
    public void SpaceshipTypeConstructorShouldCreateEmptyListWhenSkillsAreNull()
    {
        SpaceshipType type = new SpaceshipType("Explorer", "Leírás", null);

        Assert.That(type.RequiredSkills, Is.Empty);
    }

    [Test]
    [Description("Az üres szakértelemlista megengedett.")]
    public void SpaceshipTypeConstructorShouldAcceptWhenSkillsListIsEmpty()
    {
        SpaceshipType type = new SpaceshipType("Explorer", "Leírás", new List<Skill>());

        Assert.That(type.RequiredSkills, Is.Empty);
    }
}
