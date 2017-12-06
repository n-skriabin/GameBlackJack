using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBlackJack
{
    class Game
    {
        const int BLACKJACK = 21;

        public List<Card> deck = new List<Card>();

        public void Main()
        {
            int way;
            while (true)
            {
                Console.Write("\nSelect an action:\n1. Start new game \n2. Exit\n\n>");
                way = Convert.ToInt32(Console.ReadLine());

                if (way == 1)
                {
                    Console.Clear();
                    Deck cd = new Deck();
                    Init();
                    GameMethod();
                }

                if (way == 2)
                {
                    Environment.Exit(0);
                }          
            }
        }

        public void GameMethod()
        {
            Player pl = new Player();
            Croupie cr = new Croupie();
            int way;
            bool check = false;

            Init();

            pl.Extradition();

            while(true) //игрок
            {
                Console.Write("Pls, select an action: \n1 - Take a card\n2 - Stop\n>");
                way = Convert.ToInt32(Console.ReadLine());


                if (way == 1)
                {
                    pl.Extradition();
                }

                if (way == 2)
                {
                    pl.Result();
                    check = true;
                }               
                            
                if (check)
                    break;
            }

            while(true) //крупье
            {
                if (Croupie.Sum < 17)
                    cr.Extradition();

                if (Croupie.Sum > 17)
                {
                    cr.Result();
                    Console.Write("Croupie score: {0}\n\n", Croupie.Sum);
                    break;
                }
            }

            GameResult();
        }

        public static void Init() //инициализация перед новой игрой
        {
            Game gm = new Game();

            Player.I = 0;
            Croupie.I = 0;
            Player.Sum = 0;
            Croupie.Sum = 0;
            gm.deck.Clear();
            Player.Hand.Clear();
            Croupie.Hand.Clear();
        }

        public void GameResult() //проверяем кто выиграл
        {
            if ((Croupie.Sum > BLACKJACK) && (Player.Sum > BLACKJACK) || (Croupie.Sum == Player.Sum))
                Console.Write("Draw\n\n");
            else
               if ((Croupie.Sum > BLACKJACK) && (Player.Sum <= BLACKJACK) || (Player.Sum > Croupie.Sum)
               && (Croupie.Sum <= BLACKJACK) && (Player.Sum <= BLACKJACK))
                Console.Write("You win\n\n");
            else
                Console.Write("You lose\n\n");
        }
    }
}
