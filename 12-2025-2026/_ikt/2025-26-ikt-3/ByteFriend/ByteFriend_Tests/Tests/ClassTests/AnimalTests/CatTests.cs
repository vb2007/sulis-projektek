using ByteFriend_Lib.Entities;
using ByteFriend_Lib.Entities.Animals;
using ByteFriend_Tests.Helpers;

namespace ByteFriend_Tests.Tests.ClassTests.AnimalTests;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CatTests
{
    private Cat _cat = null!;

    [SetUp]
    public void Setup()
    {
        ExcelReportGenerator.StartTest(TestContext.CurrentContext.Test.FullName);
        
        _cat = new Cat { Name = "Cirmi", Hunger = 30, Happiness = 50 };
    }
    
    [TearDown]
    public void TearDown()
    {
        ExcelReportGenerator.EndTest();
    }

    [Test]
    [Category("Animals")]
    [Description("Checks if the TypeName property returns 'Macska'.")]
    public void TypeName_ReturnsMacska()
    {
        Assert.That(_cat.TypeName, Is.EqualTo("Macska"));
    }

    [Test]
    [Category("Animals")]
    [Description("Checks if the AsciiArt property is not empty.")]
    public void AsciiArt_IsNotEmpty()
    {
        Assert.That(_cat.AsciiArt, Is.Not.Empty);
    }

    [Test]
    [Category("Interactions")]
    [Description("Checks if GetInteractions returns two interactions for Cat.")]
    public void GetInteractions_ReturnsTwoInteractions()
    {
        List<(string name, Action<IAnimal> action)> interactions = _cat.GetInteractions();
        Assert.That(interactions, Has.Count.EqualTo(2));
    }

    [Test]
    [Category("Interactions")]
    [Description("Checks if 'Simogatás' increases happiness by 20.")]
    public void Simogatas_IncreasesHappinessBy20()
    {
        List<(string name, Action<IAnimal> action)> interactions = _cat.GetInteractions();
        int before = _cat.Happiness;
        interactions[0].action(_cat);
        Assert.That(_cat.Happiness, Is.EqualTo(before + 20));
    }

    [Test]
    [Category("Interactions")]
    [Description("Checks if 'Simogatás' increases hunger by 3.")]
    public void Simogatas_IncreasesHungerBy3()
    {
        List<(string name, Action<IAnimal> action)> interactions = _cat.GetInteractions();
        int before = _cat.Hunger;
        interactions[0].action(_cat);
        Assert.That(_cat.Hunger, Is.EqualTo(before + 3));
    }

    [Test]
    [Category("Interactions")]
    [Description("Checks if 'Szőr kefélése' increases happiness by 10.")]
    public void SzorKeferese_IncreasesHappinessBy10()
    {
        List<(string name, Action<IAnimal> action)> interactions = _cat.GetInteractions();
        int before = _cat.Happiness;
        interactions[1].action(_cat);
        Assert.That(_cat.Happiness, Is.EqualTo(before + 10));
    }

    [Test]
    [Category("Interactions")]
    [Description("Checks if 'Szőr kefélése' sets IsHealthy to true.")]
    public void SzorKeferese_SetsIsHealthyTrue()
    {
        _cat.IsHealthy = false;
        List<(string name, Action<IAnimal> action)> interactions = _cat.GetInteractions();
        interactions[1].action(_cat);
        Assert.That(_cat.IsHealthy, Is.True);
    }

    [Test]
    [Category("Animals")]
    [Description("Checks if a new Cat's default state is Child.")]
    public void DefaultState_IsChild()
    {
        Cat freshCat = new Cat();
        Assert.That(freshCat.State, Is.EqualTo(LifeState.Child));
    }
}
