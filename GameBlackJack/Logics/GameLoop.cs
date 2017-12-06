using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBlackJack
{
    class GameLoop
    {
        private bool Start, FirstIterationPlayerLoop = false;

        Game game = new Game();
        Deck deck = new Deck();
        Player player = new Player();
        Croupie croupie = new Croupie();
        ConsoleView consoleview = new ConsoleView();

        public void LoopGame()
        {
            bool way;

            if (!Start)
            {
                player.Name = consoleview.InputName();
                Start = true;
            }

            way = consoleview.StartGame(); 

            if (way)
            {
                consoleview.ConsoleClear();
                FirstIterationPlayerLoop = false;
                game.Init(ref deck,ref player,ref croupie);

                PlayerLoop();

                CroupieLoop();

                consoleview.WriteWinner(game.GameResult(croupie, player)); 

                LoopGame();
            }         
        }

        public void PlayerLoop()
        {
            if (!FirstIterationPlayerLoop)
            {
                player = game.PlayerPlay(player, deck);
                consoleview.Card(player.Hand[player.Hand.Count - 1], player.Name);

                player = game.PlayerPlay(player, deck);
                consoleview.Card(player.Hand[player.Hand.Count - 1], player.Name);
                consoleview.Score(player.Sum, player.Name);

                FirstIterationPlayerLoop = true;
            }

            bool way = consoleview.Game();
            if (way)
            {
                player = game.PlayerPlay(player, deck);
                consoleview.Card(player.Hand[player.Hand.Count - 1], player.Name);
                consoleview.Score(player.Sum, player.Name);

                PlayerLoop();
            }
        }

        public void CroupieLoop()
        {
            game.CroupiePlay(croupie, deck);

            for (int i = 0; i < croupie.Hand.Count; i++)
            {
                consoleview.Card(croupie.Hand[i], croupie.Name);
            }

            consoleview.Score(croupie.Sum, croupie.Name);
        }
    }
}
