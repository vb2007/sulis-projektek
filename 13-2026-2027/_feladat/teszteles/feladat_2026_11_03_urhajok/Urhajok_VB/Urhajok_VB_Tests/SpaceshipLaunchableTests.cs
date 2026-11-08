using Urhajok_VB_Lib;

namespace Urhajok_VB_Tests;

[TestFixture]
public class SpaceshipLaunchableTests
{
    private Spaceship _ship;

    private static CrewMember Member(params Skill[] skills)
    {
        return new CrewMember("Tag", "Hungarian", new DateTime(1990, 1, 1), "F", skills.ToList());
    }

    [SetUp]
    public void SetUp()
    {
        SpaceshipType type = new SpaceshipType("Explorer", "Leírás", new List<Skill> { new Skill("Piloting", 5) });
        _ship = new Spaceship("Voyager", type, new SpaceshipClass("Alpha"), 2150, 3);
    }

    [Test]
    [Description("Üres legénységgel nem indítható.")]
    public void SpaceshipLaunchableShouldBeFalseWhenCrewIsEmpty()
    {
        Assert.That(_ship.Launchable, Is.False);
    }

    [Test]
    [Description("Kevés képzettségnél nem indítható.")]
    public void SpaceshipLaunchableShouldBeFalseWhenSkillSumIsBelowRequired()
    {
        _ship.Crew.Add(Member(new Skill("Piloting", 4)));

        Assert.That(_ship.Launchable, Is.False);
    }

    [Test]
    [Description("Pontosan elég képzettségnél indítható.")]
    public void SpaceshipLaunchableShouldBeTrueWhenSkillSumEqualsRequired()
    {
        _ship.Crew.Add(Member(new Skill("Piloting", 5)));

        Assert.That(_ship.Launchable, Is.True);
    }

    [Test]
    [Description("Több képzettségnél indítható.")]
    public void SpaceshipLaunchableShouldBeTrueWhenSkillSumExceedsRequired()
    {
        _ship.Crew.Add(Member(new Skill("Piloting", 9)));

        Assert.That(_ship.Launchable, Is.True);
    }

    [Test]
    [Description("Több tag szintjei összeadódnak.")]
    public void SpaceshipLaunchableShouldBeTrueWhenSkillsOfMoreMembersSumUp()
    {
        _ship.Crew.Add(Member(new Skill("Piloting", 3)));
        _ship.Crew.Add(Member(new Skill("Piloting", 2)));

        Assert.That(_ship.Launchable, Is.True);
    }

    [Test]
    [Description("Más nevű képzettség nem számít.")]
    public void SpaceshipLaunchableShouldBeFalseWhenOnlyOtherSkillsArePresent()
    {
        _ship.Crew.Add(Member(new Skill("Medicine", 10)));

        Assert.That(_ship.Launchable, Is.False);
    }

    [Test]
    [Description("Képzettség nélküli tag nem segít.")]
    public void SpaceshipLaunchableShouldBeFalseWhenMemberHasNoSkills()
    {
        _ship.Crew.Add(Member());

        Assert.That(_ship.Launchable, Is.False);
    }

    [Test]
    [Description("Elvárás nélküli típusnál üres legénységgel is indítható.")]
    public void SpaceshipLaunchableShouldBeTrueWhenTypeHasNoRequiredSkills()
    {
        Spaceship ship = new Spaceship("Simple", new SpaceshipType("Basic", "Leírás"), new SpaceshipClass("Beta"), 2100, 1);

        Assert.That(ship.Launchable, Is.True);
    }

    [Test]
    [Description("Minden elvárt képzettségnek teljesülnie kell.")]
    public void SpaceshipLaunchableShouldBeFalseWhenOneOfMoreRequiredSkillsIsMissing()
    {
        SpaceshipType type = new SpaceshipType("Explorer", "Leírás", new List<Skill> { new Skill("Piloting", 5), new Skill("Medicine", 2) });
        Spaceship ship = new Spaceship("Voyager", type, new SpaceshipClass("Alpha"), 2150, 3);
        ship.Crew.Add(Member(new Skill("Piloting", 5)));

        Assert.That(ship.Launchable, Is.False);
    }

    [Test]
    [Description("Minden elvárt képzettség teljesülésekor indítható.")]
    public void SpaceshipLaunchableShouldBeTrueWhenAllRequiredSkillsAreMet()
    {
        SpaceshipType type = new SpaceshipType("Explorer", "Leírás", new List<Skill> { new Skill("Piloting", 5), new Skill("Medicine", 2) });
        Spaceship ship = new Spaceship("Voyager", type, new SpaceshipClass("Alpha"), 2150, 3);
        ship.Crew.Add(Member(new Skill("Piloting", 5)));
        ship.Crew.Add(Member(new Skill("Medicine", 2)));

        Assert.That(ship.Launchable, Is.True);
    }

    [Test]
    [Description("Típus nélkül nem indítható.")]
    public void SpaceshipLaunchableShouldBeFalseWhenTypeIsNull()
    {
        _ship.Type = null;

        Assert.That(_ship.Launchable, Is.False);
    }
}
