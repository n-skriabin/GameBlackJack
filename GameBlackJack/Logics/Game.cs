using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBlackJack
{
    class Game
    {
        public const int BlackJackConst = 21, 
            CroupieScoreConst = 17, 
            AceConst = 11, 
            JackQueenKingConst = 10;

        public Player PlayerPlay(Player player, Deck deck)
        {
            Card card = new Card();

            card = Extradition(player.Hand, player.Name, deck);

            player.Sum = Sum(player.Hand);

            return player;
        }

        public void CroupiePlay(Croupie croupie, Deck deck)
        {
            if (croupie.Sum < CroupieScoreConst)
            {
                Extradition(croupie.Hand, croupie.Name, deck);
                croupie.Sum = Sum(croupie.Hand);
                CroupiePlay(croupie, deck);
            }
        }

        public void Init(ref Deck deck, ref Player player, ref Croupie croupie)
        {
            deck.Generate();
            deck.Shuffle();
            player.Sum = 0;
            croupie.Sum = 0;
            deck.DeckList.Clear();
            player.Hand.Clear();
            croupie.Hand.Clear();
        }

        public string GameResult(Croupie croupie, Player player) 
        {
            if (player.Sum > BlackJackConst)
            {              
                return croupie.Name;
            }

            if (croupie.Sum <= BlackJackConst && player.Sum <= BlackJackConst && croupie.Sum > player.Sum)
            {
                return croupie.Name;
            }

            if (croupie.Sum <= BlackJackConst && player.Sum <= BlackJackConst && croupie.Sum < player.Sum)
            {
                return player.Name;
            }

            if (croupie.Sum <= BlackJackConst && player.Sum <= BlackJackConst && croupie.Sum == player.Sum)
            {
                return null;
            }

            if (croupie.Sum > BlackJackConst && player.Sum <= BlackJackConst)
            {
                return player.Name;
            }

            return null;
        }

        public int Sum(List<Card> Hand)
        {
            int buf = 0, Sum = 0;
         
            for (int i = 0; i < Hand.Count; i++)
            {
                if (Hand[i].Face == FaceEnum.Ace && Sum < BlackJackConst)
                {
                    buf = AceConst;
                }

                if (Hand[i].Face == FaceEnum.Ace && Sum > BlackJackConst)
                {
                    buf++;
                }

                if ((int)Hand[i].Face <= (int)FaceEnum.Ten && (int)Hand[i].Face > 1)
                {
                    buf = (int)Hand[i].Face;
                }

                if (Hand[i].Face == FaceEnum.Jack || Hand[i].Face == FaceEnum.Queen || Hand[i].Face == FaceEnum.King)
                {
                    buf = JackQueenKingConst;
                }

                Sum += buf;
            }   

            return Sum;
        }

        public Card Extradition(List<Card> Hand, string name, Deck deck)
        {
            Hand.Add(deck.DrowCard());
            return Hand[Hand.Count - 1];
        }
    }
}
