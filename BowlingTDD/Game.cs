using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingTDDNS
{
    public class Game
    {
        private int score = 0;

        public Game()
        {

        }

        public void Roll(int pins)
        {
            score += pins; 
        }

        public int Score()
        {
            return score; 
        }
    }
}
