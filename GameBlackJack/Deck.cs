using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBlackJack
{
    class Deck
    {
        Card cd = new Card();
        public static List<Card> deck = new List<Card>();
        public static int i = 0;

        public Deck()
        {
            this.Generate();
            this.Shuffle();
        }

        public void Generate()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    deck.Add(new Card() { Suit = (Suit)i, Face = (Face)j });
                }
            }
        }

        public void Shuffle()
        {
            Random rng = new Random();
            int n = deck.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card card = deck[k];
                deck[k] = deck[n];
                deck[n] = card;
            }
        }

        public Card DrowCard()
        {
            for (int i = 0;; )
            {
                if (i == deck.Count)
                {
                    Console.Write("Card deck is empty. Pls start game again.\n");
                    return null;
                }

                if (deck[i] != null)
                {
                    cd = deck[i];
                    deck.RemoveAt(i);                  
                    break;
                }

                break;
            }
            return cd;
        }
    }
}
