using Urhajok_VB_Lib;

namespace Urhajok_VB_Tests;

[TestFixture]
public class CrewMemberTests
{
    private CrewMember _member;
    private List<Skill> _skills;
    private readonly DateTime _birthDate = new DateTime(1990, 5, 1);

    [SetUp]
    public void SetUp()
    {
        _skills = new List<Skill> { new Skill("Piloting", 3) };
        _member = new CrewMember("Anna", "Hungarian", _birthDate, "F", _skills);
    }

    [Test]
    [Description("A konstruktor beállítja az alapadatokat.")]
    public void CrewMemberConstructorShouldSetPropertiesWhenCreated()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_member.Name, Is.EqualTo("Anna"));
            Assert.That(_member.Nationality, Is.EqualTo("Hungarian"));
            Assert.That(_member.BirthDate, Is.EqualTo(_birthDate));
            Assert.That(_member.Gender, Is.EqualTo("F"));
        });
    }

    [Test]
    [Description("A megadott szakértelmek megmaradnak.")]
    public void CrewMemberConstructorShouldSetSkillsWhenSkillsAreGiven()
    {
        Assert.That(_member.Skills, Is.EqualTo(_skills));
    }

    [Test]
    [Description("Szakértelem nélkül üres lista jön létre.")]
    public void CrewMemberConstructorShouldCreateEmptyListWhenSkillsAreNotGiven()
    {
        CrewMember member = new CrewMember("Cid", "Spanish", _birthDate, "M");

        Assert.That(member.Skills, Is.Empty);
    }

    [Test]
    [Description("Null szakértelem esetén üres lista jön létre.")]
    public void CrewMemberConstructorShouldCreateEmptyListWhenSkillsAreNull()
    {
        CrewMember member = new CrewMember("Cid", "Spanish", _birthDate, "M", null);

        Assert.That(member.Skills, Is.Empty);
    }

    [Test]
    [Description("Új tag nincs hajóhoz rendelve.")]
    public void CrewMemberSpaceshipShouldBeNullWhenCreated()
    {
        Assert.That(_member.Spaceship, Is.Null);
    }

    [Test]
    [Description("A hajó beállítható.")]
    public void CrewMemberSpaceshipShouldChangeWhenSet()
    {
        Spaceship ship = new Spaceship("Voyager", new SpaceshipType("Explorer", "Leírás"), new SpaceshipClass("Alpha"), 2150, 2);

        _member.Spaceship = ship;

        Assert.That(_member.Spaceship, Is.SameAs(ship));
    }
}
