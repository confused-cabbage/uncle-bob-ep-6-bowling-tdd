using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingTDDNS
{
    public class Game
    {
        private int[] rolls = new int[21];
        private int currentRoll = 0;

        public Game()
        {

        }

        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        public int Score()
        {
            int score = 0;
            int firstInFrame = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(firstInFrame))
                {
                    score += 10 + NextTwoBallsInStrike(firstInFrame);
                    firstInFrame++;
                }
                else if (isSpare(firstInFrame))
                {
                    score += 10 + rolls[firstInFrame + 2];
                    firstInFrame += 2;
                }
                else
                {
                    score += rolls[firstInFrame] + rolls[firstInFrame + 1];
                    firstInFrame += 2;
                }
            }
            return score;
        }

        private int NextTwoBallsInStrike(int firstInFrame)
        {
            return rolls[firstInFrame + 1] + rolls[firstInFrame + 2];
        }

        private bool IsStrike(int firstInFrame)
        {
            return rolls[firstInFrame] == 10;
        }

        private bool isSpare(int firstInFrame)
        {
            return rolls[firstInFrame] + rolls[firstInFrame + 1] == 10;
        }
    }
}
