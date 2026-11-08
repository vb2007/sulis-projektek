using Urhajok_VB_Lib;

namespace Urhajok_VB_Tests;

[TestFixture]
public class SpaceCommandTests
{
    private SpaceCommand _command;
    private Spaceship _ship;
    private Spaceship _otherShip;
    private CrewMember _anna;
    private CrewMember _bob;
    private CrewMember _cid;

    [SetUp]
    public void SetUp()
    {
        SpaceshipType type = new SpaceshipType("Explorer", "Leírás");
        _ship = new Spaceship("Voyager", type, new SpaceshipClass("Alpha"), 2150, 2);
        _otherShip = new Spaceship("Pioneer", type, new SpaceshipClass("Beta"), 2160, 1);

        _anna = new CrewMember("Anna", "Hungarian", new DateTime(1990, 5, 1), "F");
        _bob = new CrewMember("Bob", "British", new DateTime(1985, 3, 12), "M");
        _cid = new CrewMember("Cid", "Spanish", new DateTime(1992, 7, 20), "M");

        _command = new SpaceCommand();
        _command.Spaceships.Add(_ship);
        _command.Spaceships.Add(_otherShip);
        _command.FreeCrew.AddRange(new[] { _anna, _bob, _cid });
    }

    [TearDown]
    public void TearDown()
    {
        _command.Spaceships.Clear();
        _command.FreeCrew.Clear();
    }

    [Test]
    [Description("Új parancsnokság üres.")]
    public void SpaceCommandListsShouldBeEmptyWhenCreated()
    {
        SpaceCommand command = new SpaceCommand();

        Assert.Multiple(() =>
        {
            Assert.That(command.Spaceships, Is.Empty);
            Assert.That(command.FreeCrew, Is.Empty);
        });
    }

    [Test]
    [Description("Szabad tag hozzárendelése sikeres.")]
    public void SpaceCommandAssignShouldReturnTrueWhenMemberIsFreeAndShipHasRoom()
    {
        Assert.That(_command.Assign(_anna, _ship), Is.True);
    }

    [Test]
    [Description("Hozzárendeléskor a tag bekerül a hajóra.")]
    public void SpaceCommandAssignShouldAddMemberToCrewWhenSuccessful()
    {
        _command.Assign(_anna, _ship);

        Assert.That(_ship.Crew, Does.Contain(_anna));
    }

    [Test]
    [Description("Hozzárendeléskor a tag kikerül a szabadok közül.")]
    public void SpaceCommandAssignShouldRemoveMemberFromFreeCrewWhenSuccessful()
    {
        _command.Assign(_anna, _ship);

        Assert.That(_command.FreeCrew, Does.Not.Contain(_anna));
    }

    [Test]
    [Description("Hozzárendeléskor a tag hajója beállítódik.")]
    public void SpaceCommandAssignShouldSetMemberSpaceshipWhenSuccessful()
    {
        _command.Assign(_anna, _ship);

        Assert.That(_anna.Spaceship, Is.SameAs(_ship));
    }

    [Test]
    [Description("Megtelt hajóra nem lehet hozzárendelni.")]
    public void SpaceCommandAssignShouldReturnFalseWhenShipIsFull()
    {
        _command.Assign(_anna, _ship);
        _command.Assign(_bob, _ship);

        Assert.That(_command.Assign(_cid, _ship), Is.False);
    }

    [Test]
    [Description("Sikertelen hozzárendelés után a tag szabad marad.")]
    public void SpaceCommandAssignShouldKeepMemberFreeWhenShipIsFull()
    {
        _command.Assign(_anna, _ship);
        _command.Assign(_bob, _ship);

        _command.Assign(_cid, _ship);

        Assert.Multiple(() =>
        {
            Assert.That(_command.FreeCrew, Does.Contain(_cid));
            Assert.That(_cid.Spaceship, Is.Null);
            Assert.That(_ship.Crew, Has.Count.EqualTo(2));
        });
    }

    [Test]
    [Description("Már hajón lévő tag nem rendelhető újra.")]
    public void SpaceCommandAssignShouldReturnFalseWhenMemberIsAlreadyAssigned()
    {
        _command.Assign(_anna, _ship);

        Assert.That(_command.Assign(_anna, _otherShip), Is.False);
    }

    [Test]
    [Description("Egy tag csak egy hajón lehet.")]
    public void SpaceCommandAssignShouldKeepMemberOnFirstShipWhenAssignedTwice()
    {
        _command.Assign(_anna, _ship);

        _command.Assign(_anna, _otherShip);

        Assert.Multiple(() =>
        {
            Assert.That(_anna.Spaceship, Is.SameAs(_ship));
            Assert.That(_otherShip.Crew, Does.Not.Contain(_anna));
        });
    }

    [Test]
    [Description("Ismeretlen (nem szabad) tag nem rendelhető.")]
    public void SpaceCommandAssignShouldReturnFalseWhenMemberIsNotInFreeCrew()
    {
        CrewMember stranger = new CrewMember("Dan", "German", new DateTime(1980, 1, 1), "M");

        Assert.That(_command.Assign(stranger, _ship), Is.False);
    }

    [Test]
    [Description("Nulla férőhelyű hajóra nem lehet rendelni.")]
    public void SpaceCommandAssignShouldReturnFalseWhenCapacityIsZero()
    {
        Spaceship ship = new Spaceship("Tiny", new SpaceshipType("Basic", "Leírás"), new SpaceshipClass("Gamma"), 2000, 0);

        Assert.That(_command.Assign(_anna, ship), Is.False);
    }

    [Test]
    [Description("Férőhely nélküli (null) hajóra nem lehet rendelni.")]
    public void SpaceCommandAssignShouldReturnFalseWhenCapacityIsNull()
    {
        _ship.Capacity = null;

        Assert.That(_command.Assign(_anna, _ship), Is.False);
    }

    [Test]
    [Description("Visszavonás hajón lévő tagnál sikeres.")]
    public void SpaceCommandUnassignShouldReturnTrueWhenMemberIsAssigned()
    {
        _command.Assign(_anna, _ship);

        Assert.That(_command.Unassign(_anna), Is.True);
    }

    [Test]
    [Description("Visszavonáskor a tag kikerül a hajóról.")]
    public void SpaceCommandUnassignShouldRemoveMemberFromCrewWhenSuccessful()
    {
        _command.Assign(_anna, _ship);

        _command.Unassign(_anna);

        Assert.That(_ship.Crew, Does.Not.Contain(_anna));
    }

    [Test]
    [Description("Visszavonáskor a tag szabad lesz.")]
    public void SpaceCommandUnassignShouldAddMemberToFreeCrewWhenSuccessful()
    {
        _command.Assign(_anna, _ship);

        _command.Unassign(_anna);

        Assert.That(_command.FreeCrew, Does.Contain(_anna));
    }

    [Test]
    [Description("Visszavonáskor a tag hajója törlődik.")]
    public void SpaceCommandUnassignShouldClearMemberSpaceshipWhenSuccessful()
    {
        _command.Assign(_anna, _ship);

        _command.Unassign(_anna);

        Assert.That(_anna.Spaceship, Is.Null);
    }

    [Test]
    [Description("Hajó nélküli tag visszavonása sikertelen.")]
    public void SpaceCommandUnassignShouldReturnFalseWhenMemberHasNoSpaceship()
    {
        Assert.That(_command.Unassign(_anna), Is.False);
    }

    [Test]
    [Description("Sikertelen visszavonás nem duplázza a szabad tagot.")]
    public void SpaceCommandUnassignShouldNotDuplicateFreeMemberWhenNotAssigned()
    {
        _command.Unassign(_anna);

        Assert.That(_command.FreeCrew.Count(m => m == _anna), Is.EqualTo(1));
    }

    [Test]
    [Description("Visszavonás után a hely újra felszabadul.")]
    public void SpaceCommandAssignShouldReturnTrueWhenRoomIsFreedByUnassign()
    {
        _command.Assign(_anna, _ship);
        _command.Assign(_bob, _ship);
        _command.Unassign(_bob);

        Assert.That(_command.Assign(_cid, _ship), Is.True);
    }

    [Test]
    [Description("Áthelyezés: visszavonás után másik hajóra rendelhető.")]
    public void SpaceCommandTransferShouldMoveMemberWhenUnassignedAndAssignedToOtherShip()
    {
        _command.Assign(_anna, _ship);

        _command.Unassign(_anna);
        bool result = _command.Assign(_anna, _otherShip);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.True);
            Assert.That(_anna.Spaceship, Is.SameAs(_otherShip));
            Assert.That(_ship.Crew, Does.Not.Contain(_anna));
            Assert.That(_otherShip.Crew, Does.Contain(_anna));
        });
    }
}
