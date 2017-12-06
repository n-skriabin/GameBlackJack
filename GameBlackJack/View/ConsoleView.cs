using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameBlackJack
{
    class ConsoleView
    {
        int way;
        string name;

        const int StartGameConst = 1,
            ExitConst = 2;

        public void ConsoleClear()
        {
            Console.Clear();
        }

        public string InputName()
        {
            Console.WriteLine("Pls, input your name:\n");
            name = Console.ReadLine();
            if(name == "")
            {
                InputName();
            }
            return name;
        }

        public void Score(int Sum, string name)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0} score: {1}", name, Sum);
            Console.ResetColor();
        }

        public void Card(Card card, string name)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0} card: {1} {2}", name, card.Suit, card.Face);
            Console.ResetColor();
        }

        public void WriteWinner(string winner)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            if (winner != null)
            {
                winner = "\n" + winner + " win!\n";
            }

            if (winner == null)
            {
                winner = "\nPUSH\n";
            }

            Console.Write(winner);

            Console.ResetColor();
        }

        public bool Game()
        {
            Console.Write("\nPls, select an action:");

            Console.Write("\n1 - Take a card\n2 - Stop\n>");

            try
            {
                way = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                way = 0;
            }

            if (way != StartGameConst && way != ExitConst)
            {
                Console.Write("\nPlease, select valid action!\n");
                Game();
            }

            if (way == StartGameConst)
            {
                return true;
            }

            if (way == ExitConst)
            {
                return false;
            }

            return false;
        }

        public void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }

        public bool StartGame()
        {

            Console.Write("\nSelect an action:\n1. Start new game \n2. Exit\n\n>");

            try
            {
                way = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                way = 0;
            }

            if (way != StartGameConst && way != ExitConst)
            {
                Console.Write("\nPlease, select valid action!\n");
                StartGame();
            }

            if (way == StartGameConst)
            {
                return true;
            }

            if (way == ExitConst)
            { 
                return false;
            }

            return false;
        }
    }
}