using BlackJackGame.Models;
using System.Collections.Generic;

namespace BlackJackGame.Tests.Models.DeckStubs
{
    public class EqualValuesDeck : Deck
    {

        public EqualValuesDeck()
        {
            _cards = new List<BlackJackCard>
            {
                //dealer
                new BlackJackCard(Suit.Clubs, FaceValue.Seven),
                new BlackJackCard(Suit.Clubs, FaceValue.Five),
            
                //player
                new BlackJackCard(Suit.Clubs, FaceValue.Seven),
                new BlackJackCard(Suit.Clubs, FaceValue.Seven),

                //dealer
                new BlackJackCard(Suit.Clubs, FaceValue.Two),
            };
        }
    }
}
