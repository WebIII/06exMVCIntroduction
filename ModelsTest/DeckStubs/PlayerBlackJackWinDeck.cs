using BlackJackGame.Models;
using System.Collections.Generic;

namespace BlackJackGame.Tests.Models.DeckStubs
{
    class PlayerBlackJackWinDeck : Deck
    {

        public PlayerBlackJackWinDeck()
        {
            _cards = new List<BlackJackCard>
            {
                //dealer
                new BlackJackCard(Suit.Clubs, FaceValue.Seven),
                new BlackJackCard(Suit.Clubs, FaceValue.Seven),
            
                //player
                new BlackJackCard(Suit.Clubs, FaceValue.Ace),
                new BlackJackCard(Suit.Clubs, FaceValue.Ten),

                //dealer
                new BlackJackCard(Suit.Clubs, FaceValue.Ten),
            };
        }
    }
}
