using ByteFriend_Lib.Entities;
using ByteFriend_Lib.Entities.Animals;
using ByteFriend_Tests.Helpers;

namespace ByteFriend_Tests.Tests.ClassTests.AnimalTests;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GoldfishTests
{
    private Goldfish _fish = null!;

    [SetUp]
    public void Setup()
    {
        ExcelReportGenerator.StartTest(TestContext.CurrentContext.Test.FullName);
        
        _fish = new Goldfish { Name = "Nemo", Hunger = 30, Happiness = 50 };
    }

    [TearDown]
    public void TearDown()
    {
        ExcelReportGenerator.EndTest();
    }

    [Test]
    [Category("Animals")]
    [Description("Checks if the TypeName property returns 'Aranyhal'.")]
    public void TypeName_ReturnsAranyhal()
    {
        Assert.That(_fish.TypeName, Is.EqualTo("Aranyhal"));
    }

    [Test]
    [Category("Animals")]
    [Description("Checks if the AsciiArt property is not empty.")]
    public void AsciiArt_IsNotEmpty()
    {
        Assert.That(_fish.AsciiArt, Is.Not.Empty);
    }

    [Test]
    [Category("Animals")]
    [Description("Verifies that the aquarium is not smashed by default.")]
    public void AquariumSmashed_DefaultIsFalse()
    {
        Assert.That(_fish.AquariumSmashed, Is.False);
    }

    [Test]
    [Category("Interactions")]
    [Description("Checks if GetInteractions returns two interactions for Goldfish.")]
    public void GetInteractions_ReturnsTwoInteractions()
    {
        List<(string name, Action<IAnimal> action)> interactions = _fish.GetInteractions();
        Assert.That(interactions, Has.Count.EqualTo(2));
    }

    [Test]
    [Category("Interactions")]
    [Description("Checks if cleaning the aquarium increases happiness by 15.")]
    public void AkvariumTakaritasa_IncreasesHappinessBy15()
    {
        List<(string name, Action<IAnimal> action)> interactions = _fish.GetInteractions();
        int before = _fish.Happiness;
        interactions[0].action(_fish);
        Assert.That(_fish.Happiness, Is.EqualTo(before + 15));
    }

    [Test]
    [Category("Interactions")]
    [Description("Checks if cleaning the aquarium increases hunger by 3.")]
    public void AkvariumTakaritasa_IncreasesHungerBy3()
    {
        List<(string name, Action<IAnimal> action)> interactions = _fish.GetInteractions();
        int before = _fish.Hunger;
        interactions[0].action(_fish);
        Assert.That(_fish.Hunger, Is.EqualTo(before + 3));
    }

    [Test]
    [Category("Interactions")]
    [Description("Verifies that smashing the aquarium sets AquariumSmashed to true.")]
    public void AkvariumFoldhozVagasa_SetsAquariumSmashedTrue()
    {
        List<(string name, Action<IAnimal> action)> interactions = _fish.GetInteractions();
        interactions[1].action(_fish);
        Assert.That(_fish.AquariumSmashed, Is.True);
    }

    [Test]
    [Category("Interactions")]
    [Description("Verifies that smashing the aquarium only affects Goldfish instances.")]
    public void AkvariumFoldhozVagasa_DoesNotAffectNonGoldfish()
    {
        Cat cat = new Cat { Name = "Cirmi", Happiness = 50 };
        List<(string name, Action<IAnimal> action)> interactions = _fish.GetInteractions();
        interactions[1].action(cat);
        Assert.Pass(); //semmi nem történik, ha az állat nem aranyhal
    }
}
