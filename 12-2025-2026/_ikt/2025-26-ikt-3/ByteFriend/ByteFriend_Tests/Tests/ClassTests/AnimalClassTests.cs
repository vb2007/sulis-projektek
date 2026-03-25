using ByteFriend_Lib.Entities;
using ByteFriend_Lib.Entities.Animals;
using ByteFriend_Tests.Helpers;

namespace ByteFriend_Tests.Tests.ClassTests;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class AnimalBaseTests
{
    [SetUp]
    public void Setup()
    {
        ExcelReportGenerator.StartTest(TestContext.CurrentContext.Test.FullName);
    }

    [TearDown]
    public void TearDown()
    {
        ExcelReportGenerator.EndTest();
    }

    [Test]
    [Category("Animals")]
    [Description("Checks if the default happiness of a Cat is 50.")]
    public void DefaultHappiness_Is50()
    {
        Cat cat = new Cat();
        Assert.That(cat.Happiness, Is.EqualTo(50));
    }

    [Test]
    [Category("Animals")]
    [Description("Checks if the default health status of a Cat is true.")]
    public void DefaultIsHealthy_IsTrue()
    {
        Cat cat = new Cat();
        Assert.That(cat.IsHealthy, Is.True);
    }

    [Test]
    [Category("Animals")]
    [Description("Checks if the default state of a Monkey is Child.")]
    public void DefaultState_IsChild()
    {
        Monkey monkey = new Monkey();
        Assert.That(monkey.State, Is.EqualTo(LifeState.Child));
    }

    [Test]
    [Category("Animals")]
    [Description("Checks if the default name of a Goldfish is an empty string.")]
    public void DefaultName_IsEmptyString()
    {
        Goldfish goldfish = new Goldfish();
        Assert.That(goldfish.Name, Is.EqualTo(string.Empty));
    }

    [Test]
    [Category("Animals")]
    [Description("Verifies that hunger is clamped at 100 when modified.")]
    public void ModifyHunger_ClampsAt100()
    {
        Cat cat = new Cat { Name = "Cirmi", Hunger = 95 };
        List<(string name, Action<IAnimal> action)> interactions = cat.GetInteractions();
        //simogatás -> +3 hunger
        interactions[0].action(cat);
        Assert.That(cat.Hunger, Is.EqualTo(98));
        interactions[0].action(cat);
        Assert.That(cat.Hunger, Is.EqualTo(100)); // clamped
    }

    [Test]
    [Category("Animals")]
    [Description("Verifies that happiness is clamped at 100 when modified.")]
    public void ModifyHappiness_ClampsAt100()
    {
        Cat cat = new Cat { Name = "Cirmi", Happiness = 95 };
        List<(string name, Action<IAnimal> action)> interactions = cat.GetInteractions();
        //simogatás -> +20 happiness
        interactions[0].action(cat);
        Assert.That(cat.Happiness, Is.EqualTo(100)); // clamped at 100
    }

    [Test]
    [Category("Animals")]
    [Description("Verifies that happiness does not go below 0.")]
    public void ModifyHappiness_ClampsAt0()
    {
        Monkey monkey = new Monkey { Name = "George", Happiness = 0 };
        //boldogság 0, nem csökkenhet tovább
        Assert.That(monkey.Happiness, Is.EqualTo(0));
    }
}