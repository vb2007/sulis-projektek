using Urhajok_VB_Lib;

namespace Urhajok_VB_Tests;

[TestFixture]
public class SkillTests
{
    private Skill _skill;

    [SetUp]
    public void SetUp()
    {
        _skill = new Skill("Piloting", 3);
    }

    [Test]
    [Description("A konstruktor beállítja a nevet.")]
    public void SkillConstructorShouldSetNameWhenCreated()
    {
        Assert.That(_skill.Name, Is.EqualTo("Piloting"));
    }

    [Test]
    [Description("A konstruktor beállítja a szintet.")]
    public void SkillConstructorShouldSetLevelWhenCreated()
    {
        Assert.That(_skill.Level, Is.EqualTo(3));
    }

    [Test]
    [Description("A név módosítható.")]
    public void SkillNameShouldChangeWhenSet()
    {
        _skill.Name = "Medicine";

        Assert.That(_skill.Name, Is.EqualTo("Medicine"));
    }

    [Test]
    [Description("A szint módosítható.")]
    public void SkillLevelShouldChangeWhenSet()
    {
        _skill.Level = 7;

        Assert.That(_skill.Level, Is.EqualTo(7));
    }
}
