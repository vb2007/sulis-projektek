using NUnit.Framework;

namespace SetupTearDownFeladat.Tests;

[TestFixture]
public class ReadOnlyDatabaseServiceTests : DatabaseServiceTests
{
    // Azért előnyös itt a származtatás, mert a SetUp és TearDown metódusokat újra felhasználhatjuk.
    // Így elkerülhetjük a kód duplikációt.
}