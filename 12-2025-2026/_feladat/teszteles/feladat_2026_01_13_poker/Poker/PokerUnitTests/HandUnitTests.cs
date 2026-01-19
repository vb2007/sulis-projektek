using PokerLib;

namespace PokerUnitTests;

public class HandUnitTests
{
    private Hand _hand;

    [SetUp]
    public void Setup()
    {
        _hand = new Hand();
    }

    [Test]
    public void NewHandShouldBeEmpty()
    {
        Assert.That(_hand.Cards.Count, Is.EqualTo(0));
    }

    [Test]
    public void AddCardShouldAddCardToHand()
    {
        bool result = _hand.AddCard(Hand.Faces.Ace, Hand.Suites.Hearts);

        Assert.That(result, Is.True);
        Assert.That(_hand.Cards.Count, Is.EqualTo(1));
    }

    [Test]
    public void AddCardShouldStoreFaceAndSuiteCorrectly()
    {
        var expectedFace = Hand.Faces.King;
        var expectedSuite = Hand.Suites.Diamonds;

        _hand.AddCard(expectedFace, expectedSuite);

        Assert.That(_hand.Cards[0].Face, Is.EqualTo(expectedFace));
        Assert.That(_hand.Cards[0].Suite, Is.EqualTo(expectedSuite));
    }

    [Test]
    public void AddCardShouldAddTwoDifferentCards()
    {
        bool firstCard = _hand.AddCard(Hand.Faces.Ace, Hand.Suites.Hearts);
        bool secondCard = _hand.AddCard(Hand.Faces.King, Hand.Suites.Spades);

        Assert.That(firstCard, Is.True);
        Assert.That(secondCard, Is.True);
        Assert.That(_hand.Cards.Count, Is.EqualTo(2));
    }

    [Test]
    public void AddCardShouldPreventDuplicateCards()
    {
        _hand.AddCard(Hand.Faces.Queen, Hand.Suites.Clubs);

        bool result = _hand.AddCard(Hand.Faces.Queen, Hand.Suites.Clubs);

        Assert.That(result, Is.False);
        Assert.That(_hand.Cards.Count, Is.EqualTo(1));
    }

    [Test]
    public void HandShouldContainMaximumFiveCards()
    {
        _hand.AddCard(Hand.Faces.Ace, Hand.Suites.Hearts);
        _hand.AddCard(Hand.Faces.King, Hand.Suites.Hearts);
        _hand.AddCard(Hand.Faces.Queen, Hand.Suites.Hearts);
        _hand.AddCard(Hand.Faces.Jack, Hand.Suites.Hearts);
        _hand.AddCard(Hand.Faces.Ten, Hand.Suites.Hearts);

        Assert.That(_hand.Cards.Count, Is.EqualTo(5));
    }

    [Test]
    public void AddCardShouldNotAddSixthCard()
    {
        _hand.AddCard(Hand.Faces.Ace, Hand.Suites.Hearts);
        _hand.AddCard(Hand.Faces.King, Hand.Suites.Hearts);
        _hand.AddCard(Hand.Faces.Queen, Hand.Suites.Hearts);
        _hand.AddCard(Hand.Faces.Jack, Hand.Suites.Hearts);
        _hand.AddCard(Hand.Faces.Ten, Hand.Suites.Hearts);

        bool result = _hand.AddCard(Hand.Faces.Nine, Hand.Suites.Hearts);

        Assert.That(result, Is.False);
        Assert.That(_hand.Cards.Count, Is.EqualTo(5));
    }

    [Test]
    public void AddHandShouldBuildHandFromString()
    {
        string handString = "HA, DK, SQ, CJ, H10";

        _hand.AddHand(handString);

        Assert.That(_hand.Cards.Count, Is.EqualTo(5));
        Assert.That(_hand.Cards[0].Face, Is.EqualTo(Hand.Faces.Ace));
        Assert.That(_hand.Cards[0].Suite, Is.EqualTo(Hand.Suites.Hearts));
        Assert.That(_hand.Cards[1].Face, Is.EqualTo(Hand.Faces.King));
        Assert.That(_hand.Cards[1].Suite, Is.EqualTo(Hand.Suites.Diamonds));
        Assert.That(_hand.Cards[2].Face, Is.EqualTo(Hand.Faces.Queen));
        Assert.That(_hand.Cards[2].Suite, Is.EqualTo(Hand.Suites.Spades));
        Assert.That(_hand.Cards[3].Face, Is.EqualTo(Hand.Faces.Jack));
        Assert.That(_hand.Cards[3].Suite, Is.EqualTo(Hand.Suites.Clubs));
        Assert.That(_hand.Cards[4].Face, Is.EqualTo(Hand.Faces.Ten));
        Assert.That(_hand.Cards[4].Suite, Is.EqualTo(Hand.Suites.Hearts));
    }

    [Test]
    public void RemoveAllCardsShouldClearHand()
    {
        _hand.AddCard(Hand.Faces.Ace, Hand.Suites.Hearts);
        _hand.AddCard(Hand.Faces.King, Hand.Suites.Diamonds);
        _hand.AddCard(Hand.Faces.Queen, Hand.Suites.Spades);

        _hand.RemoveAllCards();

        Assert.That(_hand.Cards.Count, Is.EqualTo(0));
    }
}