using OnkiszolgaloKassza_VB_Lib;

namespace OnkiszolgaloKassza_VB_Test;

[TestFixture]
public class CashRegisterTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestNewSession()
    {
        CashRegister.StartNewSession();
    }
}