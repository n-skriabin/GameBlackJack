using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            GameLoop gameloop = new GameLoop();
            gameloop.LoopGame();
        }
    }
}
