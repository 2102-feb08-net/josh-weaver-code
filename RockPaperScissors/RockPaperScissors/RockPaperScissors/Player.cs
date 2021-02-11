using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors
{
    class Player
    {
        public string name { get; }
        public Hand selection { get; set; }
        public int win { get; set; }

        private Random rand;

        public Player(string _name)
        {
            name = _name;

            rand = new Random();
        }

        public void Choose()
        {
            bool loop = true;

            Console.WriteLine("Make a selection: Rock, Paper, Scissors");

            do
            {
                string choice = Console.ReadLine().ToUpper();

                switch (choice)
                {
                    case "ROCK":
                        this.selection = Hand.ROCK;
                        loop = false;
                        break;

                    case "PAPER":
                        this.selection = Hand.PAPER;
                        loop = false;
                        break;

                    case "SCISSORS":
                        this.selection = Hand.SCISSORS;
                        loop = false;
                        break;

                    default:
                        Console.WriteLine("Invalid selection. Please choose again.");
                        break;
                }
            } while (loop == true);
        }

        public void RandChoose()
        {
            int choice = rand.Next(Enum.GetNames(typeof(Hand)).Length);
            this.selection = (Hand)choice;
        }

    }


}

