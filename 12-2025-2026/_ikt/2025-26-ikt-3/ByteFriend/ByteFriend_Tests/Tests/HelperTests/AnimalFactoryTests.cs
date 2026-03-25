using ByteFriend_Lib.Entities;
using ByteFriend_Lib.Entities.Animals;
using ByteFriend_Lib.Helpers;
using ByteFriend_Tests.Helpers;

namespace ByteFriend_Tests.Tests.HelperTests;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class AnimalFactoryTests
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
    [Category("Helpers")]
    [Description("Verifies that an animal can be correctly reconstructed from save data.")]
    public void FromSaveData_CreatesCat_WithCorrectProperties()
    {
        SaveData data = new SaveData
        {
            Name = "Cirmi",
            TypeName = "Macska",
            Age = 10,
            IsHealthy = true,
            Hunger = 40,
            Happiness = 60,
            State = LifeState.Child
        };

        IAnimal animal = AnimalFactory.FromSaveData(data);

        Assert.That(animal, Is.InstanceOf<Cat>());
        Assert.That(animal.Name, Is.EqualTo("Cirmi"));
        Assert.That(animal.Age, Is.EqualTo(10));
        Assert.That(animal.Hunger, Is.EqualTo(40));
        Assert.That(animal.Happiness, Is.EqualTo(60));
    }

    [Test]
    [Category("Helpers")]
    [Description("Verifies that Monkey is correctly created from save data.")]
    public void FromSaveData_CreatesMonkey()
    {
        SaveData data = new SaveData { Name = "George", TypeName = "Majom" };
        IAnimal animal = AnimalFactory.FromSaveData(data);
        Assert.That(animal, Is.InstanceOf<Monkey>());
    }

    [Test]
    [Category("Helpers")]
    [Description("Verifies that Goldfish specific properties are restored from save data.")]
    public void FromSaveData_CreatesGoldfish_WithAquariumSmashed()
    {
        SaveData data = new SaveData
        {
            Name = "Nemo",
            TypeName = "Aranyhal",
            AquariumSmashed = true
        };

        IAnimal animal = AnimalFactory.FromSaveData(data);

        Assert.That(animal, Is.InstanceOf<Goldfish>());
        Assert.That(((Goldfish)animal).AquariumSmashed, Is.True);
    }

    [Test]
    [Category("Helpers")]
    [Description("Verifies that an unknown type name in save data throws an exception.")]
    public void FromSaveData_UnknownType_ThrowsInvalidOperationException()
    {
        SaveData data = new SaveData { Name = "X", TypeName = "Kutya" };
        Assert.Throws<InvalidOperationException>(() => AnimalFactory.FromSaveData(data));
    }

    [Test]
    [Category("Helpers")]
    [Description("Verifies that an animal instance is correctly converted to save data.")]
    public void ToSaveData_ReturnsCorrectData()
    {
        Cat cat = new Cat
        {
            Name = "Cirmi",
            Age = 15,
            IsHealthy = false,
            Hunger = 70,
            Happiness = 25,
            State = LifeState.Adult
        };

        SaveData data = AnimalFactory.ToSaveData(cat);

        Assert.That(data.Name, Is.EqualTo("Cirmi"));
        Assert.That(data.TypeName, Is.EqualTo("Macska"));
        Assert.That(data.Age, Is.EqualTo(15));
        Assert.That(data.IsHealthy, Is.False);
        Assert.That(data.Hunger, Is.EqualTo(70));
        Assert.That(data.Happiness, Is.EqualTo(25));
        Assert.That(data.State, Is.EqualTo(LifeState.Adult));
    }

    [Test]
    [Category("Helpers")]
    [Description("Verifies that Goldfish specific properties are preserved during serialization.")]
    public void ToSaveData_Goldfish_PreservesAquariumSmashed()
    {
        Goldfish fish = new Goldfish { Name = "Nemo", AquariumSmashed = true };
        SaveData data = AnimalFactory.ToSaveData(fish);
        Assert.That(data.AquariumSmashed, Is.True);
    }

    [Test]
    [Category("Helpers")]
    [Description("Verifies that non-goldfish entities do not have aquarium properties set.")]
    public void ToSaveData_NonGoldfish_AquariumSmashedIsFalse()
    {
        Monkey monkey = new Monkey { Name = "George" };
        SaveData data = AnimalFactory.ToSaveData(monkey);
        Assert.That(data.AquariumSmashed, Is.False);
    }
}
