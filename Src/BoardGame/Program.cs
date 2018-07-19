using System;
using System.Collections.Generic;

namespace BoardGame
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Boardgame!");
            Console.WriteLine("Enter L , R or M to move");
            Console.WriteLine("");

            var settings = new GameSettings();
            var gameLogic = new GameLogic(settings);

            var engine = new GameEngine(gameLogic);
            engine.Start();


            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
            {
                var key = Console.ReadKey().KeyChar;

                if(gameLogic.ValidateKey(key))
                    engine.ConsoleCommand.Enqueue(key);
            }

            Console.WriteLine("Thank you for playing");

        }


    }
}
