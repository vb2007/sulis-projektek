using TreasureChest;

namespace UnitTests
{
    [TestFixture]
    public class ChestTests
    {
        private static Chest? _chest;
        private static int _volume;
        private static string? _name;

        [Test]
        [Description("Verifies that the Chess class can store data fields correctly.")]
        public void Success()
        {
            _name = "a";
            _volume = 0;

            _chest = new (_name, _volume);

            Assert.Multiple(() =>
            {
                Assert.That(_chest.Name, Is.EqualTo(_name));
                Assert.That(_chest.Volume, Is.EqualTo(_volume));
            });
        }
    }
}
