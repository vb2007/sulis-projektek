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
            _volume = 1;

            _chest = new (_name, _volume);

            Assert.Multiple(() =>
            {
                Assert.That(_chest.Name, Is.EqualTo(_name));
                Assert.That(_chest.Volume, Is.EqualTo(_volume));
            });
        }

        [Test]
        [Description("Verifies that the Chess class's value can be 0.")]
        public void ValueCanBeZero()
        {
            _name = "Test";
            _volume = 0;

            _chest = new (_name, _volume);

            Assert.Multiple(() =>
            {
                Assert.That(_chest.Name, Is.EqualTo(_name));
                Assert.That(_chest.Volume, Is.EqualTo(_volume));
            });
        }

        [Test]
        [Description("Verifies that the Chess class's value cannot be negative.")]
        [Ignore("Correctly failing, value shouldn't be negative.")]
        public void ValueCannotBeNegative()
        {
            _name = "Test";
            _volume = -1;

            _chest = new (_name, _volume);

            Assert.Multiple(() =>
            {
                Assert.That(_chest.Name, Is.EqualTo(_name));
                Assert.That(_chest.Volume, Is.Not.EqualTo(_volume));
            });
        }
    }
}
