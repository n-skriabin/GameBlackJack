using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBlackJack
{
    class Deck
    {
        const int DECK_SIZE = 52,
            FACE_SIZE = 14,
            SUIT_SIZE = 4;

        public List<Card> DeckList = new List<Card>();
        public List<Card> ShuffledDeckList = new List<Card>();

        public void Generate()
        {
            for (int i = 0; i < SUIT_SIZE; i++)
            {
                for (int j = 1; j < FACE_SIZE; j++)
                {
                    DeckList.Add(new Card() { Suit = (SuitEnum)i, Face = (FaceEnum)j });
                }

                if (DeckList.Count == DECK_SIZE)
                {
                    break;
                }
            }
        }

        public void Shuffle()
        {
            ShuffledDeckList = DeckList.OrderBy(x => Guid.NewGuid().ToString()).ToList();
        }

        public Card DrowCard()
        {
            int i = 0;
            Card card = new Card();

            card = ShuffledDeckList[i];
            ShuffledDeckList.RemoveAt(i);

            return card;
        }
    }
}
