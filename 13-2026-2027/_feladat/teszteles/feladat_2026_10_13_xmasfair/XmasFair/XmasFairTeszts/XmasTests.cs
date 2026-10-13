using XmasFair_Lib;

namespace XmasFair
{
    public class Tests
    {
        [Test]
        public void CreateFairTests()
        {
            Assert.That(new Fair("Mikulás napi vásár", 20, 20000, "2025.12.05", "2025.12.07").Name, Is.EqualTo("Mikulás napi vásár"), "Ha helyes adatokat adtam meg, létrejön a vásár, lekérdezhető lesz a neve is");
            Assert.That(new Fair("Mikulás napi vásár", 1, 5000, "2025.12.06", "2025.12.06").Name, Is.EqualTo("Mikulás napi vásár"), "Ha helyes adatokat adtam meg, létrejön a vásár, lekérdezhető lesz a neve is");
            Assert.Throws<ArgumentException>(() => { new Fair("", 20, 2000, "2025.12.05", "2025.12.07"); }, "Név nélkül nem jön létre, exceptiont kell dobjon");
            Assert.Throws<ArgumentException>(() => { new Fair("vásár", -5, 2000, "2025.12.05", "2025.12.07"); }, "Negatív számú stand nem lehet a vásárban");
            Assert.Throws<ArgumentException>(() => { new Fair("vásár", 5, -2000, "2025.12.05", "2025.12.07"); }, "Negatív összeget nem kérhetnek a standokért");
            Assert.Throws<ArgumentException>(() => { new Fair("vásár", 5, 2000, "2025.12.07", "2025.12.06"); }, "Ha a végdátum kisebb, mint a kező dátum, az nem jó");
        }

        [Test]
        public void CreateStandTests()
        {
            Assert.That(new Stand("Bódog bódéja", "étel").Name, Is.EqualTo("Bódog bódéja"), "Ha helyes adatokat adtam meg, létrejön a bódé, lekérdezhető lesz a neve is");
            Assert.That(new Stand("Bódog boldog bódéja", new List<string> { "ital", "étel" }).Name, Is.EqualTo("Bódog boldog bódéja"), "Ha helyes adatokat adtam meg, több terméktípussal, akkor is létrejön a bódé, lekérdezhető lesz a neve is");
            Assert.Throws<ArgumentException>(() => { new Stand("", "valami"); }, "Név nélkül nem jön létre a bódé, exceptiont kell dobjon");
            Assert.Throws<ArgumentException>(() => { new Stand("Üres stand", ""); }, "Üres terméktípussal nem jön létre a stand, exceptiont kell dobjon");
            Assert.Throws<ArgumentException>(() => { new Stand("Üres stand", new List<string> { }); }, "Üres terméktípussal nem jön létre a stand, exceptiont kell dobjon");
        }

        [Test]
        public void StandToFairTests()
        {
            Fair sut = new Fair("Mikulás napi vásár", 2, 20000, "2025.12.05", "2025.12.07");
            Assert.That(sut.FreePlace, Is.EqualTo(2), "2 hely van a standoknak, még nincs benne semmi");
            Assert.That(sut.AddStand(new Stand("Bódog bódéja", "étel")), Is.True, "Van még hely a vásárban, hozzá lehet adni egy árúsító helyet.");
            Assert.That(sut.FreePlace, Is.EqualTo(1), "Hozzááadtunk egy standot, nincs több hely");
            Assert.That(sut.AddStand(new Stand("Bódog bódéja", "étel")), Is.False, "Két ugyanolyan nevű bódét nem adhatunk hozzá");
            Assert.That(sut.AddStand(new Stand("Ágoston árudája", "fajáték")), Is.True, "Van még hely a vásárban, hozzá lehet adni egy árúsító helyet.");
            Assert.That(sut.FreePlace, Is.EqualTo(0), "Hozzááadtunk egy standot, nincs több hely");
            Assert.That(sut.AddStand(new Stand("Bódog 2. bódéja", "étel")), Is.False, "Nincs több hely a vásárban, nem lehet hozzáadni egy újabb árúsító helyet.");
            Assert.That(sut.FreePlace, Is.EqualTo(0), "a sikertelen hozzáadás után sem változott a szabad helyek száma");
            Assert.That(sut.RemoveStand("Bódog 2. bódéja"), Is.False, "Nincs benne ilyen nevű stand, nem lehet eltávolítani");
            Assert.That(sut.FreePlace, Is.EqualTo(0), "a sikertelen eltávolítás után sem változott a szabad helyek száma");
            Assert.That(sut.RemoveStand("Bódog bódéja"), Is.True, "Nincs benne ilyen nevű stand, nem lehet eltávolítani");
            Assert.That(sut.FreePlace, Is.EqualTo(1), "a sikeres eltávolítás után nőtt a szabad helyek száma");
            Assert.That(sut.RemoveStand("Bódog bódéja"), Is.False, "Ezt már kiszedtük, nem lehet újra eltávolítani");
        }

        [Test]
        public void CreateGoodTests()
        {
            Assert.That(new Good("forralt bor", "ital", 1500).Value, Is.EqualTo(1500), "jó adat megadásánál létrejön a termék, lekérdezhető az ára");
            Assert.That(new Good("forralt bor", "ital", -500).Value, Is.EqualTo(0), "Negatív összegnél 0-ra módosítja az árát");
            Assert.Throws<ArgumentException>(() => { new Good("", "valami", 5); }, "Név nélkül nem jön létre a termék, exceptiont kell dobjon");
            Assert.Throws<ArgumentException>(() => { new Good("valami termék", "", 5); }, "Üres terméktípussal nem jön létre a termék, exceptiont kell dobjon");
        }

        [Test]
        public void AddGoodsToStandTests()
        {
            Stand sut = new Stand("Böbe bárpultja", "étel");
            sut.Add(new Good("zsíros kenyér", "étel", 500));
            Assert.That(sut.NumGoods, Is.EqualTo(1), "Sikeres termék hozzáadás után 1re nőtt a termékek száma.");
            sut.Add(new Good("fánk", "étel", 250));
            Assert.That(sut.NumGoods, Is.EqualTo(2), "Sikeres termék hozzáadás után 2re nőtt a termékek száma.");
            Assert.Throws<ArgumentException>(() => { sut.Add(new Good("forralt bor", "ital", 750)); }, "Nem árul a stand ilyen terméket, hibát kell kapjunk");
            Assert.Throws<ArgumentException>(() => { sut.Add(new Good("zsíros kenyér", "étel", 250)); }, "Ilyen nevű termék már hozzá lett adva, ne adjuk újra hozzá");
            Assert.That(sut.NumGoods, Is.EqualTo(2), "A sikertelen hozzáadás nem módosította a termékek számát");
        }

        [Test]
        public void FairIncomeTests()
        {
            Fair sut = new Fair("Mikulás napi vásár", 3, 20000, "2025.12.05", "2025.12.07");
            Assert.That(sut.Income, Is.EqualTo(0), "Még nem adtak ki egy standot sem, nulla a bevétel");
            sut.Add(new Stand("Böbe bárpultja", "étel"));
            Assert.That(sut.Income, Is.EqualTo(20000), "1 stand kiadva, így a bevétel 20000");
            sut.Add(new Stand("Böbe bárpultja 2", "étel"));
            sut.Add(new Stand("Böbe bárpultja 3", "étel"));
            Assert.That(sut.Income, Is.EqualTo(60000), "3 stand kiadva, így a bevétel 60000");
        }

        [Test]
        public void StandIncomeTests()
        {
            Stand sut = new Stand("Böbe bárpultja", "étel");
            Assert.That(sut.DailyIncome, Is.EqualTo(0), "Ma még nem adtak el egy terméket sem");
            sut.Add(new Good("fánk", "étel", 250));
            sut.Add(new Good("zsíros kenyér", "étel", 500));
            sut.Sell("fánk", 3);
            Assert.That(sut.DailyIncome, Is.EqualTo(750), "3 fánk eladása után 750 a bevétel");
            sut.Sell("zsíros kenyér", 1);
            Assert.That(sut.DailyIncome, Is.EqualTo(1250), "1 zsíros kenyér eladása után 1250 a bevétel");
        }

        [Test]
        public void StandSellTests()
        {
            Stand sut = new Stand("Böbe bárpultja", "étel");
            Assert.That(sut.DailyIncome, Is.EqualTo(0), "Ma még nem adtak el egy terméket sem");
            sut.Add(new Good("fánk", "étel", 250));
            sut.Sell("fánk", 3);
            Assert.That(sut.DailyIncome, Is.EqualTo(750), "3 fánk eladása után 750 a bevétel");
            Assert.Throws<ArgumentException>(() => { sut.Sell("kenyér", 1); }, "Nincs ilyen termék, nem lehet eladni");
        }

        [Test]
        public void SellGoodTests()
        {
            Stand sut = new Stand("Böbe bárpultja", "étel");
            Assert.That(sut.DailyIncome, Is.EqualTo(0), "Ma még nem adtak el egy terméket sem");
            sut.Add(new Good("fánk", "étel", 250));
            sut.Add(new Good("zsíros kenyér", "étel", 500));
            Assert.That(sut.Sell("fánk", 2), Is.True, "Van ilyen termék, el lehet adni");
            Assert.That(sut.Sell("fánk", 0), Is.False, "0 darabot nem lehet eladni");
            Assert.That(sut.Sell("fánk", -2), Is.False, "-2 darabot nem lehet eladni");
        }
    }
}