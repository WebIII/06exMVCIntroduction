using System.Collections.Generic;
using System.Linq;

namespace BlackJackGame.Models
{
    public class Hand
    {

        #region Fields
        private readonly IList<BlackJackCard> _cards;
        #endregion

        #region Properties
        public IEnumerable<BlackJackCard> Cards { get { return _cards; } }

        public int NrOfCards { get { return Cards.Count(); } }

        public int Value { get { return CalculateValue(); } }
        #endregion

        #region Constructors
        public Hand()
        {
            _cards = new List<BlackJackCard>();
        }
        #endregion

        #region Methods
        public void AddCard(BlackJackCard blackJackCard)
        {
            _cards.Add(blackJackCard);
        }

        public void TurnAllCardsFaceUp()
        {
            foreach (BlackJackCard c in Cards)
                if (!c.FaceUp)
                    c.TurnCard();
        }
        private int CalculateValue()
        {
            int total = 0;
            bool ace = false;
            foreach (BlackJackCard c in Cards)
            {
                total += c.Value;
                if (c.FaceUp && c.FaceValue == FaceValue.Ace)
                    ace = true;
            }
            if (ace && (total + 10) <= 21)
                total += 10;
            return total;
        }
        #endregion
    }
}