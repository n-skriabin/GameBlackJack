using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBlackJack
{
    class Player
    {
        public int Sum { get; set; }
        public string Name = "none";
        public List<Card> Hand = new List<Card>();
    }
}
