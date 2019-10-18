using BlackJackGame.Models;
using System.Collections.Generic;

namespace BlackJackGame.Tests.Models.DeckStubs
{
    class PlayerWinsDealerBurnsDeck : Deck
    {

        public PlayerWinsDealerBurnsDeck()
        {
            _cards = new List<BlackJackCard>
            {
                //dealer
                new BlackJackCard(Suit.Clubs, FaceValue.Seven),
                new BlackJackCard(Suit.Clubs, FaceValue.Seven),
            
                //player
                new BlackJackCard(Suit.Clubs, FaceValue.Nine),
                new BlackJackCard(Suit.Clubs, FaceValue.Nine),

                //dealer
                new BlackJackCard(Suit.Clubs, FaceValue.Ten),
            };
        }
    }
}
