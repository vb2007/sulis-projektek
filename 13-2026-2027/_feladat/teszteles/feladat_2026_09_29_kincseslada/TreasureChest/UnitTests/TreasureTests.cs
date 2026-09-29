using TreasureChest;

namespace UnitTests
{
    [TestFixture]
    public class TreasureTests
    {
        private static Treasure _treasure;

        [Test]
        [Description("Verifies the Treasure class can store data fields correctly.")]
        public void CheckSavedFields()
        {
            string name = "Test";
            int volume = 5;
            _treasure = new(name, volume);

            Assert.Multiple(() =>
            {
                Assert.That(_treasure.Name, Is.EqualTo(name));
                Assert.That(_treasure.Volume, Is.EqualTo(volume));
            });
        }
    }
}
