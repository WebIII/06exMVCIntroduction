using BlackJackGame.Models;
using Xunit;

namespace BlackJackGame.Tests.Models
{

    public class HandTest
    {
        private readonly Hand _aHand;

        public HandTest()
        {
            _aHand = new Hand();
        }

        [Fact]
        public void NewHand_HasNoCards()
        {
            Assert.Equal(0, _aHand.NrOfCards);
        }

        [Fact]
        public void AddCard_EmptyHand_ResultsInHandWithOneCard()
        {
            _aHand.AddCard(new BlackJackCard(Suit.Hearts, FaceValue.Ace));
            Assert.Equal(1, _aHand.NrOfCards);
        }

        [Fact]
        public void AddCard_AHandWithCards_AddsACard()
        {
            _aHand.AddCard(new BlackJackCard(Suit.Hearts, FaceValue.Ace));
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Jack));
            Assert.Equal(2, _aHand.NrOfCards);
        }

        [Fact]
        public void TurnAllCardsFaceUp_TurnsAllCardsFaceUp()
        {
            BlackJackCard card = new BlackJackCard(Suit.Hearts, FaceValue.Ace);
            card.TurnCard();
            _aHand.AddCard(card);
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Two));
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Two));
            _aHand.TurnAllCardsFaceUp();
            foreach (BlackJackCard c in _aHand.Cards)
                Assert.True(c.FaceUp);
        }

        [Fact]
        public void Value_EmptyHand_IsZero()
        {
            Assert.Equal(0, _aHand.Value);
        }

        [Theory]
        [InlineData(Suit.Hearts, FaceValue.Five, Suit.Hearts, FaceValue.Six, 11)]
        [InlineData(Suit.Hearts, FaceValue.Five, Suit.Hearts, FaceValue.King, 15)]
        public void Value_AddCardToHand_GivesCorrectValue(Suit suit1, FaceValue faceValue1, Suit suit2, FaceValue faceValue2, int value)
        {
            BlackJackCard card = new BlackJackCard(suit1, faceValue1);
            card.TurnCard();
            _aHand.AddCard(card);
            card = new BlackJackCard(suit2, faceValue2);
            card.TurnCard();
            _aHand.AddCard(card);
            Assert.Equal(value, _aHand.Value);
        }

        /*
        [Fact]
        public void Value_HandWith6and5_Is11()
        {
            BlackJackCard card = new BlackJackCard(Suit.Hearts, FaceValue.Five);
            card.TurnCard();
            _aHand.AddCard(card);
            card = new BlackJackCard(Suit.Hearts, FaceValue.Six);
            card.TurnCard();
            _aHand.AddCard(card);
            Assert.Equal(11, _aHand.Value);
        }

        [Fact]
        public void Value_HandWith5AndKing_Is15()
        {
            BlackJackCard card = new BlackJackCard(Suit.Hearts, FaceValue.Five);
            card.TurnCard();
            _aHand.AddCard(card);
            card = new BlackJackCard(Suit.Hearts, FaceValue.King);
            card.TurnCard();
            _aHand.AddCard(card);
            Assert.Equal(15, _aHand.Value);
        }
        */

        [Fact]
        public void Value_HandWithCardsFacingDown_DoesNotAddValuesOfCardsFacingDown()
        {
            BlackJackCard card = new BlackJackCard(Suit.Hearts, FaceValue.Two);
            card.TurnCard();
            _aHand.AddCard(card);
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Jack));
            Assert.Equal(2, _aHand.Value);
        }

        [Theory]
        [InlineData(FaceValue.Ace, FaceValue.Two, FaceValue.Two, 15)]
        [InlineData(FaceValue.Ace, FaceValue.Nine, FaceValue.Nine, 19)]
        public void Value_HandWithAce_TakesCorrectValueForAce(FaceValue value1, FaceValue value2, FaceValue value3, int value)
        {
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, value1));
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, value2));
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, value3));
            _aHand.TurnAllCardsFaceUp();
            Assert.Equal(value, _aHand.Value);
        }

        /*
        [Fact]
        public void Value_HandWithAceAndNotExceeding21_TakesAceAs11()
        {
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Ace));
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Two));
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Two));
            _aHand.TurnAllCardsFaceUp();
            Assert.Equal(15, _aHand.Value);
        }

        [Fact]
        public void ValueHandWithAceAndExceeding21_TakesAceAs1()
        {
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Ace));
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Nine));
            _aHand.AddCard(new BlackJackCard(Suit.Diamonds, FaceValue.Nine));
            _aHand.TurnAllCardsFaceUp();
            Assert.Equal(19, _aHand.Value);
        }
        */

        [Fact]
        public void Value_HandWithAceFaceDown_DoesNotCountAce()
        {
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Two));
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Two));
            _aHand.TurnAllCardsFaceUp();
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Ace));
            Assert.Equal(4, _aHand.Value);
        }
    }
}
