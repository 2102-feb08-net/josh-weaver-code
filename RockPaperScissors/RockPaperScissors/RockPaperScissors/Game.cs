using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors
{
    class Game
    {
        public Player player { get; }
        public Player computer { get; }

        public Game(string _playerName)
        {
            player = new Player(_playerName);
            computer = new Player("Computer");
        }

        public void Play()
        {
            bool keepPlaying = true;

            do
            {
                player.Choose();
                computer.RandChoose();
                Console.WriteLine($"{player.name} chose {player.selection} and {computer.name} chose {computer.selection}");

                if ((player.selection == Hand.SCISSORS && computer.selection == Hand.PAPER)
                    || (player.selection == Hand.PAPER && computer.selection == Hand.ROCK)
                    || (player.selection == Hand.ROCK && computer.selection == Hand.SCISSORS))
                {
                    Console.WriteLine($"{player.name} wins!");
                    player.win++;
                }

                else if (player.selection == computer.selection)

                {
                    Console.WriteLine("It's a draw");
                }

                else
                {
                    Console.WriteLine($"{computer.name} wins!");
                    computer.win++;
                }

                Console.WriteLine("Would you like to keep playing? Y/N");

                if (Console.ReadLine().ToUpper() == "N")
                    keepPlaying = false;

            } while (keepPlaying == true);
        }


    }

    public enum Hand
    {
        ROCK,
        PAPER,
        SCISSORS
    }
}
