using System;
using System.Collections.Generic;

namespace BlackJackGame.Models
{
    public class Deck
    {
        #region Fields
        private static readonly Random _random = new Random();
        protected IList<BlackJackCard> _cards;
        #endregion

        #region Constructors
        public Deck()
        {
            _cards = new List<BlackJackCard>();
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
            {
                foreach (FaceValue f in Enum.GetValues(typeof(FaceValue)))
                    _cards.Add(new BlackJackCard(s, f));
            }
            Shuffle();
        }

        #endregion


        #region Methods
        private void Shuffle()
        {
            for (int i = 1; i < _cards.Count * 3; i++)
            {
                int randomPosition = _random.Next(0, _cards.Count);
                BlackJackCard card = _cards[randomPosition];
                _cards.RemoveAt(randomPosition);
                _cards.Add(card);
            }
        }

        public BlackJackCard Draw()
        {
            if (_cards.Count == 0)
                throw new InvalidOperationException("Cannot draw card from empty deck");
            BlackJackCard card = _cards[0];
            _cards.RemoveAt(0);
            return card;
        }
        #endregion

    }
}