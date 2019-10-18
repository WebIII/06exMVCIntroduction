using System;

namespace BlackJackGame.Models
{
    public class BlackJack
    {
        #region Fields
        public const bool FaceDown = false;
        public const bool FaceUp = true;
        private readonly Deck _deck;
        #endregion

        #region Properties
        public GameState GameState { get; private set; }
        public Hand DealerHand { get; private set; }
        public Hand PlayerHand { get; private set; }
        #endregion

        #region Constructors
        public BlackJack() : this(new Deck()) { }

        public BlackJack(Deck deck)
        {
            _deck = deck;
            DealerHand = new Hand();
            PlayerHand = new Hand();
            Deal();
        }
        #endregion

        #region Methods
        private void Deal()
        {
            AddCardToHand(DealerHand, FaceUp);
            AddCardToHand(DealerHand, FaceDown);
            AddCardToHand(PlayerHand, FaceUp);
            AddCardToHand(PlayerHand, FaceUp);
            AdjustGameState(GameState.PlayerPlays);
        }

        public void GivePlayerAnotherCard()
        {
            if (GameState != GameState.PlayerPlays)
                throw new InvalidOperationException("You cannot take a card now...");
            AddCardToHand(PlayerHand, FaceUp);
            AdjustGameState();
        }

        public void PassToDealer()
        {
            DealerHand.TurnAllCardsFaceUp();
            AdjustGameState(GameState.DealerPlays);
            LetDealerFinalize();
        }
        private void LetDealerFinalize()
        {
            while (GameState == GameState.DealerPlays)
            {
                AddCardToHand(DealerHand, FaceUp);
                AdjustGameState();
            }
        }

        private void AdjustGameState(GameState? gameState = null)
        {
            if (gameState.HasValue)
                GameState = gameState.Value;
            if (GameState == GameState.PlayerPlays && PlayerHand.Value >= 21)
                PassToDealer();
            if (GameState == GameState.DealerPlays && (PlayerHand.Value > 21 || DealerHand.Value >= 21 || DealerHand.Value >= PlayerHand.Value))
                GameState = GameState.GameOver;
        }

        private void AddCardToHand(Hand hand, bool faceUp)
        {
            BlackJackCard card = _deck.Draw();
            if (faceUp)
                card.TurnCard();
            hand.AddCard(card);
        }

        public string GameSummary()
        {
            if (GameState != GameState.GameOver)
                return null;
            if (PlayerHand.Value > 21)
                return "Player burned, dealer wins";
            if (PlayerHand.Value == 21 && PlayerHand.NrOfCards == 2 && DealerHand.Value != 21)
                return "BLACKJACK";
            if (PlayerHand.Value == DealerHand.Value)
                return "Equal, dealer wins";
            if (DealerHand.Value > 21)
                return "Dealer burned, player wins";
            if (DealerHand.Value > PlayerHand.Value)
                return "Dealer wins";
            return "Player wins";
        }
        #endregion
    }
}