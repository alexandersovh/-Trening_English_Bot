﻿using System;

namespace Trening_English_Bot
{
    class Program
    {

        static void Main(string[] args)
         {
            var bot = new BotWorker();

            bot.Inizalize();
            bot.Start();

            Console.WriteLine("Напишите stop для прекращения работы");

            string command;
            do
            {
                command = Console.ReadLine();


            } while (command != "stop") ;

            bot.Stop();

        }

       
    }
}
