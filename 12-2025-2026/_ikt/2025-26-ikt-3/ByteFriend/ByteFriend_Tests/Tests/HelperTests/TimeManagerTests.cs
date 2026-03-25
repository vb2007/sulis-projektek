using ByteFriend_Lib.Entities;
using ByteFriend_Lib.Entities.Animals;
using ByteFriend_Lib.Helpers;
using ByteFriend_Tests.Helpers;

namespace ByteFriend_Tests.Tests.HelperTests;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class TimeManagerTests
{
    private Cat _animal = null!;

    [SetUp]
    public void Setup()
    {
        ExcelReportGenerator.StartTest(TestContext.CurrentContext.Test.FullName);
        
        _animal = new Cat { Name = "Cirmi", Age = 0, Hunger = 0, Happiness = 50, IsHealthy = true };
    }

    [TearDown]
    public void TearDown()
    {
        ExcelReportGenerator.EndTest();
    }

    [Test]
    [Category("Helpers")]
    [Description("Verifies that a tick increases animal hunger by 2.")]
    public void Tick_IncreasesHungerBy2()
    {
        int before = _animal.Hunger;
        TimeManager.Tick(_animal);
        Assert.That(_animal.Hunger, Is.EqualTo(before + 2));
    }

    [Test]
    [Category("Helpers")]
    [Description("Verifies that a tick decreases animal happiness by 1.")]
    public void Tick_DecreasesHappinessBy1()
    {
        int before = _animal.Happiness;
        TimeManager.Tick(_animal);
        Assert.That(_animal.Happiness, Is.EqualTo(before - 1));
    }

    [Test]
    [Category("Helpers")]
    [Description("Verifies that a tick increases animal age by 1.")]
    public void Tick_IncreasesAgeBy1()
    {
        int before = _animal.Age;
        TimeManager.Tick(_animal);
        Assert.That(_animal.Age, Is.EqualTo(before + 1));
    }

    [Test]
    [Category("Helpers")]
    [Description("Verifies that the life state transitions to Adult when the age threshold is reached.")]
    public void Tick_UpdatesLifeState_ToAdult()
    {
        _animal.Age = 23; //23 éves, +1 tick => Age=24 => Adult (felnőtt)
        TimeManager.Tick(_animal);
        Assert.That(_animal.State, Is.EqualTo(LifeState.Adult));
    }

    [Test]
    [Category("Helpers")]
    [Description("Verifies that the life state transitions to Elder when the age threshold is reached.")]
    public void Tick_UpdatesLifeState_ToElder()
    {
        _animal.Age = 71; //71 éves, +1 tick => Age=72 => Elder (idős) 
        TimeManager.Tick(_animal);
        Assert.That(_animal.State, Is.EqualTo(LifeState.Elder));
    }

    [Test]
    [Category("Helpers")]
    [Description("Verifies natural death detection logic.")]
    public void IsNaturalDeath_ReturnsTrueWhenElderAndMaxAge()
    {
        _animal.Age = 120;
        _animal.State = LifeState.Elder;
        Assert.That(TimeManager.IsNaturalDeath(_animal), Is.True);
    }

    [Test]
    [Category("Helpers")]
    [Description("Verifies natural death detection does not occur prematurely.")]
    public void IsNaturalDeath_ReturnsFalseWhenYoung()
    {
        _animal.Age = 10;
        _animal.State = LifeState.Child;
        Assert.That(TimeManager.IsNaturalDeath(_animal), Is.False);
    }

    [Test]
    [Category("Helpers")]
    [Description("Verifies that starvation death is detected at 100 hunger.")]
    public void IsStarvationDeath_ReturnsTrueWhenHungerIs100()
    {
        _animal.Hunger = 100;
        Assert.That(TimeManager.IsStarvationDeath(_animal), Is.True);
    }

    [Test]
    [Category("Helpers")]
    [Description("Verifies that starvation death is not detected prematurely.")]
    public void IsStarvationDeath_ReturnsFalseWhenHungerBelow100()
    {
        _animal.Hunger = 99;
        Assert.That(TimeManager.IsStarvationDeath(_animal), Is.False);
    }

    [Test]
    [Category("Helpers")]
    [Description("Checks if the state names are correctly localized.")]
    public void GetStateName_ReturnsCorrectNames()
    {
        Assert.That(TimeManager.GetStateName(LifeState.Child), Is.EqualTo("Gyerek"));
        Assert.That(TimeManager.GetStateName(LifeState.Adult), Is.EqualTo("Felnőtt"));
        Assert.That(TimeManager.GetStateName(LifeState.Elder), Is.EqualTo("Idős"));
    }

    [Test]
    [Category("Helpers")]
    [Description("Verifies that elapsed time impacts hunger and happiness correctly.")]
    public void ApplyElapsedTime_IncreasesHungerAndDecreasesHappiness()
    {
        DateTime closeTime = DateTime.UtcNow.AddHours(-5);
        _animal.Hunger = 0;
        _animal.Happiness = 50;

        TimeManager.ApplyElapsedTime(_animal, closeTime);

        Assert.That(_animal.Hunger, Is.EqualTo(25)); // 5 * 5
        Assert.That(_animal.Happiness, Is.EqualTo(35)); // 50 - 5 * 3
    }

    [Test]
    [Category("Helpers")]
    [Description("Verifies that an animal becomes unhealthy after 6 hours of neglect.")]
    public void ApplyElapsedTime_SetsUnhealthyAfter6Hours()
    {
        DateTime closeTime = DateTime.UtcNow.AddHours(-7);
        _animal.IsHealthy = true;

        TimeManager.ApplyElapsedTime(_animal, closeTime);

        Assert.That(_animal.IsHealthy, Is.False);
    }
}
