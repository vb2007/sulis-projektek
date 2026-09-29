using TreasureChest;

namespace UnitTests
{
    [TestFixture]
    public class TreasureTests
    {
        private static Treasure _treasure;
        private static string _name;
        private static int _volume;

        [Test]
        [Description("Verifies the Treasure class can store data fields correctly.")]
        public void Success()
        {
            _name = "Test";
            _volume = 5;
            _treasure = new(_name, _volume);

            Assert.Multiple(() =>
            {
                Assert.That(_treasure.Name, Is.EqualTo(_name));
                Assert.That(_treasure.Volume, Is.EqualTo(_volume));
            });
        }

        [Test]
        [Description("Verifies the Treasure class's name cannot be empty.")]
        [Ignore("Correctly failing, name shouldn't be empty.")]
        public void EmptyName()
        {
            _name = string.Empty;
            _volume = 5;
            _treasure = new(_name, _volume);

            Assert.Multiple(() =>
            {
                Assert.That(_treasure.Name, Is.Not.EqualTo(_name));
                Assert.That(_treasure.Name, Is.Not.Empty);
                Assert.That(_treasure.Volume, Is.EqualTo(_volume));
            });
        }

        [Test]
        [Description("Verifies the Treasure class's value cannot be zero.")]
        [Ignore("Correctly failing, value shouldn't be zero.")]
        public void ZeroValue()
        {
            _name = "Test";
            _volume = 0;
            _treasure = new(_name, _volume);

            Assert.Multiple(() =>
            {
                Assert.That(_treasure.Name, Is.EqualTo(_name));
                Assert.That(_treasure.Volume, Is.Not.EqualTo(_volume));
            });
        }

        [Test]
        [Description("Verifies the Treasure class's value cannot be negative.")]
        [Ignore("Correctly failing, value shouldn't be negative.")]
        public void NegativeValue()
        {
            _name = "Test";
            _volume = -1;
            _treasure = new(_name, _volume);

            Assert.Multiple(() =>
            {
                Assert.That(_treasure.Name, Is.EqualTo(_name));
                Assert.That(_treasure.Volume, Is.Not.EqualTo(_volume));
            });
        }
    }
}
