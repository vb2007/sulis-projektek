using OnkiszolgaloKassza_VB_Lib;

namespace OnkiszolgaloKassza_VB_Test;

[TestFixture]
public class CashRegisterTests
{
    [SetUp]
    public void Setup()
    {
        if (CashRegister.IsSessionActive())
        {
            CashRegister.Payment(CashRegister.FinalSum());
        }
    }

    [Test]
    public void TestStartNewSession_StartsSuccessfully()
    {
        CashRegister.StartNewSession();
        Assert.That(CashRegister.IsSessionActive(), Is.True);
        Assert.That(CashRegister.FinalSum(), Is.EqualTo(0));
    }

    [Test]
    public void TestStartNewSession_ThrowsWhenSessionActive()
    {
        CashRegister.StartNewSession();
        Assert.Throws<InvalidOperationException>(() => CashRegister.StartNewSession());
    }

    [Test]
    public void TestScanItem_AddsItemAndUpdatesSum()
    {
        CashRegister.StartNewSession();
        CashRegister.ScanItem("Kenyér", 500);
        
        Assert.That(CashRegister.FinalSum(), Is.EqualTo(500));
        Assert.That(CashRegister.ItemsInSession(), Has.Length.EqualTo(1));
        Assert.That(CashRegister.ItemsInSession()[0], Is.EqualTo("Kenyér - 500 Ft"));
    }

    [Test]
    public void TestScanItem_MultipleItems()
    {
        CashRegister.StartNewSession();
        CashRegister.ScanItem("Kenyér", 500);
        CashRegister.ScanItem("Tej", 400);
        CashRegister.ScanItem("Sajt", 1200);
        
        Assert.That(CashRegister.FinalSum(), Is.EqualTo(2100));
        Assert.That(CashRegister.ItemsInSession(), Has.Length.EqualTo(3));
    }

    [Test]
    public void TestScanItem_ThrowsWhenNoSession()
    {
        Assert.Throws<InvalidOperationException>(() => CashRegister.ScanItem("Kenyér", 500));
    }

    [Test]
    public void TestRemoveItem_RemovesLastItem()
    {
        CashRegister.StartNewSession();
        CashRegister.ScanItem("Kenyér", 500);
        CashRegister.ScanItem("Tej", 400);
        
        CashRegister.RemoveItem();
        
        Assert.That(CashRegister.FinalSum(), Is.EqualTo(500));
        Assert.That(CashRegister.ItemsInSession(), Has.Length.EqualTo(1));
    }

    [Test]
    public void TestRemoveItem_ThrowsWhenNoSession()
    {
        Assert.Throws<InvalidOperationException>(() => CashRegister.RemoveItem());
    }

    [Test]
    public void TestRemoveItem_ThrowsWhenNoItems()
    {
        CashRegister.StartNewSession();
        Assert.Throws<InvalidOperationException>(() => CashRegister.RemoveItem());
    }

    [Test]
    public void TestFinalSum_ReturnsZeroForNewSession()
    {
        CashRegister.StartNewSession();
        Assert.That(CashRegister.FinalSum(), Is.EqualTo(0));
    }

    [Test]
    public void TestFinalSum_ThrowsWhenNoSession()
    {
        Assert.Throws<InvalidOperationException>(() => CashRegister.FinalSum());
    }

    [Test]
    public void TestItemsInSession_ReturnsEmptyForNewSession()
    {
        CashRegister.StartNewSession();
        Assert.That(CashRegister.ItemsInSession(), Has.Length.EqualTo(0));
    }

    [Test]
    public void TestItemsInSession_ThrowsWhenNoSession()
    {
        Assert.Throws<InvalidOperationException>(() => CashRegister.ItemsInSession());
    }

    [Test]
    public void TestPayment_ExactAmount()
    {
        CashRegister.StartNewSession();
        CashRegister.ScanItem("Kenyér", 500);
        
        int change = CashRegister.Payment(500);
        
        Assert.That(change, Is.EqualTo(0));
        Assert.That(CashRegister.IsSessionActive(), Is.False);
    }

    [Test]
    public void TestPayment_WithChange()
    {
        CashRegister.StartNewSession();
        CashRegister.ScanItem("Kenyér", 500);
        CashRegister.ScanItem("Tej", 400);
        
        int change = CashRegister.Payment(1000);
        
        Assert.That(change, Is.EqualTo(100));
        Assert.That(CashRegister.IsSessionActive(), Is.False);
    }

    [Test]
    public void TestPayment_ThrowsWhenNoSession()
    {
        Assert.Throws<InvalidOperationException>(() => CashRegister.Payment(1000));
    }

    [Test]
    public void TestPayment_ThrowsWhenInsufficientAmount()
    {
        CashRegister.StartNewSession();
        CashRegister.ScanItem("Kenyér", 500);
        
        Assert.Throws<InvalidOperationException>(() => CashRegister.Payment(400));
    }

    [Test]
    public void TestIsSessionActive_ReturnsFalseInitially()
    {
        Assert.That(CashRegister.IsSessionActive(), Is.False);
    }

    [Test]
    public void TestCompleteWorkflow()
    {
        //új session
        CashRegister.StartNewSession();
        Assert.That(CashRegister.IsSessionActive(), Is.True);
        
        //itemek hozzáadása
        CashRegister.ScanItem("Kenyér", 500);
        CashRegister.ScanItem("Tej", 400);
        CashRegister.ScanItem("Sajt", 1200);
        
        //egy item kiszedése
        CashRegister.RemoveItem();
        
        //végösszeg check
        Assert.That(CashRegister.FinalSum(), Is.EqualTo(900));
        
        //itemek csekkolása
        string[] items = CashRegister.ItemsInSession();
        Assert.That(items, Has.Length.EqualTo(2));
        
        //fizetés
        int change = CashRegister.Payment(1000);
        Assert.That(change, Is.EqualTo(100));
        Assert.That(CashRegister.IsSessionActive(), Is.False);
        
        //új session fizetés után
        CashRegister.StartNewSession();
        Assert.That(CashRegister.IsSessionActive(), Is.True);
        Assert.That(CashRegister.FinalSum(), Is.EqualTo(0));
    }
}