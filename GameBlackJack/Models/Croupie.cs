using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBlackJack
{
    class Croupie
    {
        public int Sum { get; set; }
        public string Name = "Croupie";
        public List<Card> Hand = new List<Card>();
    }
}
