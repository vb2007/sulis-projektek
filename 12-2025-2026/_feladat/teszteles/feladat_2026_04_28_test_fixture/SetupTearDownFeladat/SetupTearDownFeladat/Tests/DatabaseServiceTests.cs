using NUnit.Framework;

namespace SetupTearDownFeladat.Tests;

[TestFixture]
public class DatabaseServiceTests
{
    protected DatabaseService _service;
    protected const string TestDbPath = "test_library.db";
    
    // 1. feladat:
    // Az alábbiak miatt lenne rossz gyakorlat minden tesztnél meghívni az OpenConnection() és a CloseConnection() metódusokat:
    // - Kódismétlés: Minden teszthez ugyanazt a kódot kellene bemásolni (nehezebb karbantartás, kód ismétlése)
    // - Hibalehetőség: Könnyen elfelejthetjük meghívni ezeket a metódusokat egy tesztnél, ami hibákhoz vezethet

    // TODO: Írd meg a SetUp-ot, amely példányosítja a DatabaseService-t a TestDbPath paraméterrel!
    [SetUp]
    public void SetUp()
    {
        DatabaseService db = new DatabaseService(TestDbPath);
        db.OpenConnection();
        _service = db;
    }
    
    // TODO: Írd meg a Teardown-t, amely bezárja a kapcsolatot és törli is a fájlt, ha létezik!
    [TearDown]
    public void TearDown()
    {
        _service.CloseConnection();
        
        if (File.Exists(TestDbPath)) {
            File.Delete(TestDbPath);
        }
    }
    
    // Ellenőrizd, hogy a megfelelő SetUp és Teardown megírása után sikeresen lefutnak-e a tesztek!
    
    [Test]
    public void AddBook_ShouldIncreaseCount()
    {
        // Act
        _service.AddBook("Egri Csillagok");
        int count = _service.GetBookCount();

        // Assert
        Assert.That(count, Is.EqualTo(1));
    }

    [Test]
    public void Clear_ShouldRemoveAllBooks()
    {
        // Arrange
        _service.AddBook("A Pál utcai fiúk");
        
        // Act
        _service.Clear();
        
        // Assert
        Assert.That(_service.GetBookCount(), Is.EqualTo(0));
    }
    
    [Test]
    public void Test_Connection_Is_Active()
    {
        Assert.That(_service.IsConnected, Is.True);
    }
}