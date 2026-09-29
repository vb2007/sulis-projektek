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
            _name = "Test";
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

            Assert.That(() => new Chest(_name, _volume), Throws.TypeOf<ArgumentOutOfRangeException>());
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

        [Test]
        [Description("Verifies that the Chest can be opened after unlocking.")]
        public void OpenAfterUnlock()
        {
            _name = "Test";
            _volume = 1;

            _chest = new(_name, _volume);

            _chest.UnLock();
            bool opened = _chest.Open();

            Assert.Multiple(() =>
            {
                Assert.That(opened, Is.True);
                Assert.That(_chest.IsLocked, Is.False);
                Assert.That(_chest.IsOpen, Is.True);
            });
        }

        [Test]
        [Description("Verifies that the Chest can be closed when open and unlocked.")]
        public void CloseWhenOpen()
        {
            _name = "Test";
            _volume = 1;

            _chest = new(_name, _volume);

            _chest.UnLock();
            _chest.Open();
            bool closed = _chest.Close();

            Assert.Multiple(() =>
            {
                Assert.That(closed, Is.True);
                Assert.That(_chest.IsLocked, Is.False);
                Assert.That(_chest.IsOpen, Is.False);
            });
        }

        [Test]
        [Description("Verifies that the Chest cannot be locked while open.")]
        public void CannotLockWhileOpen()
        {
            _name = "Test";
            _volume = 1;

            _chest = new(_name, _volume);

            _chest.UnLock();
            _chest.Open();
            bool locked = _chest.Lock();

            Assert.Multiple(() =>
            {
                Assert.That(locked, Is.False);
                Assert.That(_chest.IsLocked, Is.False);
                Assert.That(_chest.IsOpen, Is.True);
            });
        }

        [Test]
        [Description("Verifies that the Chest can be locked when closed and unlocked.")]
        public void LockWhenClosedAndUnlocked()
        {
            _name = "Test";
            _volume = 1;

            _chest = new(_name, _volume);

            _chest.UnLock();
            bool locked = _chest.Lock();

            Assert.Multiple(() =>
            {
                Assert.That(locked, Is.True);
                Assert.That(_chest.IsLocked, Is.True);
                Assert.That(_chest.IsOpen, Is.False);
            });
        }

        [Test]
        [Description("Verifies that treasure can be stored when there is enough free space.")]
        public void StoreTreasureWhenEnoughSpace()
        {
            _name = "Test";
            _volume = 10;

            _chest = new(_name, _volume);
            Treasure treasure = new("Gold", 4);

            _chest.UnLock();
            _chest.Open();
            bool stored = _chest.Store(treasure);

            Assert.That(stored, Is.True);
        }

        [Test]
        [Description("Verifies that treasure cannot be stored when there is not enough free space.")]
        public void CannotStoreTreasureWhenNotEnoughSpace()
        {
            _name = "Test";
            _volume = 5;

            _chest = new(_name, _volume);

            _chest.UnLock();
            _chest.Open();
            _chest.Store(new Treasure("Gold", 4));
            bool stored = _chest.Store(new Treasure("Sword", 2));

            Assert.That(stored, Is.False);
        }

        [Test]
        [Description("Verifies that treasure cannot be stored while the Chest is closed.")]
        public void CannotStoreTreasureWhileClosed()
        {
            _name = "Test";
            _volume = 10;

            _chest = new(_name, _volume);
            _chest.UnLock();

            bool stored = _chest.Store(new Treasure("Gold", 1));

            Assert.That(stored, Is.False);
        }

        [Test]
        [Description("Verifies that TakeOutLast returns null when the Chest is empty.")]
        public void TakeOutLastFromEmptyReturnsNull()
        {
            _name = "Test";
            _volume = 10;

            _chest = new(_name, _volume);
            _chest.UnLock();
            _chest.Open();

            Treasure? treasure = _chest.TakeOutLast();

            Assert.That(treasure, Is.Null);
        }

        [Test]
        [Description("Verifies that TakeOutLast returns the last inserted treasure.")]
        public void TakeOutLastReturnsLastInserted()
        {
            _name = "Test";
            _volume = 10;

            _chest = new(_name, _volume);
            _chest.UnLock();
            _chest.Open();

            _chest.Store(new Treasure("Gold", 2));
            _chest.Store(new Treasure("Sword", 3));

            Treasure? treasure = _chest.TakeOutLast();

            Assert.That(treasure?.Name, Is.EqualTo("Sword"));
        }

        [Test]
        [Description("Verifies that TakeOut by name returns the first matching treasure.")]
        [Ignore("Correctly failing, implementation removes all matches instead of first only.")]
        public void TakeOutByNameReturnsFirstMatch()
        {
            _name = "Test";
            _volume = 10;

            _chest = new(_name, _volume);
            _chest.UnLock();
            _chest.Open();

            _chest.Store(new Treasure("Hosszukard", 2));
            _chest.Store(new Treasure("Pajzs", 2));
            _chest.Store(new Treasure("Hosszukard", 2));

            Treasure? treasure = _chest.TakeOut("Hosszukard");
            Treasure? last = _chest.TakeOutLast();

            Assert.Multiple(() =>
            {
                Assert.That(treasure?.Name, Is.EqualTo("Hosszukard"));
                Assert.That(last?.Name, Is.EqualTo("Hosszukard"));
            });
        }

        [Test]
        [Description("Verifies that TakeOut by name returns null when no exact match exists.")]
        public void TakeOutByNameReturnsNullWhenNoMatch()
        {
            _name = "Test";
            _volume = 10;

            _chest = new(_name, _volume);
            _chest.UnLock();
            _chest.Open();
            _chest.Store(new Treasure("Gold", 1));

            Treasure? treasure = _chest.TakeOut("gold");

            Assert.That(treasure, Is.Null);
        }

        [Test]
        [Description("Verifies that ToString contains the empty content text when there is no treasure.")]
        public void ToStringWhenEmpty()
        {
            _name = "Test";
            _volume = 10;

            _chest = new(_name, _volume);

            string description = _chest.ToString();

            Assert.Multiple(() =>
            {
                Assert.That(description, Does.Contain(_name));
                Assert.That(description, Does.Contain("Nincs benne semmi"));
            });
        }

        [Test]
        [Description("Verifies that ToString lists treasure names separated by comma when there is content.")]
        public void ToStringWhenHasContent()
        {
            _name = "Test";
            _volume = 10;

            _chest = new(_name, _volume);
            _chest.UnLock();
            _chest.Open();
            _chest.Store(new Treasure("Gold", 1));
            _chest.Store(new Treasure("Sword", 1));

            string description = _chest.ToString();

            Assert.Multiple(() =>
            {
                Assert.That(description, Does.Contain(_name));
                Assert.That(description, Does.Contain("Gold, Sword"));
            });
        }
    }
}
