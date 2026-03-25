using ByteFriend_Lib.Entities;
using ByteFriend_Lib.Entities.Animals;
using ByteFriend_Tests.Helpers;

namespace ByteFriend_Tests.Tests.ClassTests.AnimalTests;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class MonkeyTests
{
    private Monkey _monkey = null!;

    [SetUp]
    public void Setup()
    {
        ExcelReportGenerator.StartTest(TestContext.CurrentContext.Test.FullName);
        
        _monkey = new Monkey { Name = "George", Hunger = 50, Happiness = 50 };
    }

    [TearDown]
    public void TearDown()
    {
        ExcelReportGenerator.EndTest();
    }

    [Test]
    [Category("Animals")]
    [Description("Checks if the TypeName property returns 'Majom'.")]
    public void TypeName_ReturnsMajom()
    {
        Assert.That(_monkey.TypeName, Is.EqualTo("Majom"));
    }

    [Test]
    [Category("Animals")]
    [Description("Checks if the AsciiArt property is not empty.")]
    public void AsciiArt_IsNotEmpty()
    {
        Assert.That(_monkey.AsciiArt, Is.Not.Empty);
    }

    [Test]
    [Category("Interactions")]
    [Description("Checks if GetInteractions returns two interactions for Monkey.")]
    public void GetInteractions_ReturnsTwoInteractions()
    {
        List<(string name, Action<IAnimal> action)> interactions = _monkey.GetInteractions();
        Assert.That(interactions, Has.Count.EqualTo(2));
    }

    [Test]
    [Category("Interactions")]
    [Description("Checks if feeding decreases hunger by 25.")]
    public void Etetes_DecreasesHungerBy25()
    {
        List<(string name, Action<IAnimal> action)> interactions = _monkey.GetInteractions();
        int before = _monkey.Hunger;
        interactions[0].action(_monkey);
        Assert.That(_monkey.Hunger, Is.EqualTo(before - 25));
    }

    [Test]
    [Category("Interactions")]
    [Description("Checks if feeding increases happiness by 5.")]
    public void Etetes_IncreasesHappinessBy5()
    {
        List<(string name, Action<IAnimal> action)> interactions = _monkey.GetInteractions();
        int before = _monkey.Happiness;
        interactions[0].action(_monkey);
        Assert.That(_monkey.Happiness, Is.EqualTo(before + 5));
    }

    [Test]
    [Category("Interactions")]
    [Description("Checks if social interaction increases happiness by 20.")]
    public void Baratkozas_IncreasesHappinessBy20()
    {
        List<(string name, Action<IAnimal> action)> interactions = _monkey.GetInteractions();
        int before = _monkey.Happiness;
        interactions[1].action(_monkey);
        Assert.That(_monkey.Happiness, Is.EqualTo(before + 20));
    }

    [Test]
    [Category("Interactions")]
    [Description("Checks if social interaction increases hunger by 5.")]
    public void Baratkozas_IncreasesHungerBy5()
    {
        List<(string name, Action<IAnimal> action)> interactions = _monkey.GetInteractions();
        int before = _monkey.Hunger;
        interactions[1].action(_monkey);
        Assert.That(_monkey.Hunger, Is.EqualTo(before + 5));
    }

    [Test]
    [Category("Interactions")]
    [Description("Verifies that hunger does not fall below zero during feeding.")]
    public void Etetes_HungerDoesNotGoBelowZero()
    {
        _monkey.Hunger = 10;
        List<(string name, Action<IAnimal> action)> interactions = _monkey.GetInteractions();
        interactions[0].action(_monkey);
        Assert.That(_monkey.Hunger, Is.EqualTo(0));
    }
}
