using ByteFriend_Lib.Entities;
using ByteFriend_Tests.Helpers;

namespace ByteFriend_Tests.Tests.ClassTests;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SaveDataTests
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
    [Category("Core")]
    [Description("Checks if the default name in SaveData is empty.")]
    public void DefaultName_IsEmptyString()
    {
        SaveData data = new SaveData();
        Assert.That(data.Name, Is.EqualTo(string.Empty));
    }

    [Test]
    [Category("Core")]
    [Description("Checks if the default type name in SaveData is empty.")]
    public void DefaultTypeName_IsEmptyString()
    {
        SaveData data = new SaveData();
        Assert.That(data.TypeName, Is.EqualTo(string.Empty));
    }

    [Test]
    [Category("Core")]
    [Description("Checks if the default health status in SaveData is true.")]
    public void DefaultIsHealthy_IsTrue()
    {
        SaveData data = new SaveData();
        Assert.That(data.IsHealthy, Is.True);
    }

    [Test]
    [Category("Core")]
    [Description("Checks if the default happiness in SaveData is 50.")]
    public void DefaultHappiness_Is50()
    {
        SaveData data = new SaveData();
        Assert.That(data.Happiness, Is.EqualTo(50));
    }

    [Test]
    [Category("Core")]
    [Description("Checks if the default life state in SaveData is Child.")]
    public void DefaultState_IsChild()
    {
        SaveData data = new SaveData();
        Assert.That(data.State, Is.EqualTo(LifeState.Child));
    }

    [Test]
    [Category("Core")]
    [Description("Checks if the default aquarium status in SaveData is false.")]
    public void DefaultAquariumSmashed_IsFalse()
    {
        SaveData data = new SaveData();
        Assert.That(data.AquariumSmashed, Is.False);
    }

    [Test]
    [Category("Core")]
    [Description("Verifies that initialization properties are correctly assigned in SaveData.")]
    public void InitProperties_AreSetCorrectly()
    {
        SaveData data = new SaveData
        {
            Name = "Cirmi",
            TypeName = "Macska",
            Age = 10,
            IsHealthy = false,
            Hunger = 75,
            Happiness = 30,
            State = LifeState.Adult
        };

        Assert.That(data.Name, Is.EqualTo("Cirmi"));
        Assert.That(data.TypeName, Is.EqualTo("Macska"));
        Assert.That(data.Age, Is.EqualTo(10));
        Assert.That(data.IsHealthy, Is.False);
        Assert.That(data.Hunger, Is.EqualTo(75));
        Assert.That(data.Happiness, Is.EqualTo(30));
        Assert.That(data.State, Is.EqualTo(LifeState.Adult));
    }
}
