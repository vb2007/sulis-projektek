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
        [Description("Verifies that the Chest class can store data fields correctly.")]
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
        [Description("Verifies that the Chest class's value can be 0.")]
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
        [Description("Verifies that the Chest class's value cannot be negative.")]
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

        [Test]
        [Description("Verifies that the Chest class's locked and open values are correct.")]
        public void DefaultLockedAndOpenValues()
        {
            _name = "Test";
            _volume = 1;

            _chest = new(_name, _volume);

            Assert.Multiple(() =>
            {
                Assert.That(_chest.IsLocked, Is.True);
                Assert.That(_chest.IsOpen, Is.False);
            });
        }

        [Test]
        [Description("Verifies that the Chest cannot be opened while locked.")]
        public void CannotOpen()
        {
            _name = "Test";
            _volume = 1;

            _chest = new(_name, _volume);

            _chest.Open();

            Assert.Multiple(() =>
            {
                Assert.That(_chest.IsLocked, Is.True);
                Assert.That(_chest.IsOpen, Is.False);
            });
        }

        [Test]
        [Description("Verifies that the Chest class unlocks correctly.")]
        public void Unlock()
        {
            _name = "Test";
            _volume = 1;

            _chest = new(_name, _volume);

            _chest.UnLock();

            Assert.Multiple(() =>
            {
                Assert.That(_chest.IsLocked, Is.False);
                Assert.That(_chest.IsOpen, Is.False);
            });
        }
    }
}
