using System;

namespace RockPaperScissors
{
    class RockPaperScissors
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your name.");
            Game game = new Game(Console.ReadLine());
            game.Play();

            Console.WriteLine($"Results:\n{game.player.name}\t{game.computer.name}\n{game.player.win}\t{game.computer.win}");
        }
    }
}
