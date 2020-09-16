using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class StoryMode
    {
        private string _name;
        private int _roomNum;


        public void Introduction()
        {
            Console.WriteLine("Welcome to the world of Wurtz. This place has peaceful areas and towns.");
            clearScreen();
            Console.WriteLine("The townsfolk here are also quite friendly towards people as well. Yes things here really are lovley.");
            clearScreen();
            Console.WriteLine("Or at least they were");
            clearScreen();
            Console.WriteLine("Everything was normal until they showed up. Creatures that looked abnormal." +
                " Monsters. ");
            clearScreen();
            Console.WriteLine("They started falling from the sky like rain." +
                " Your job as a Knight for the King is to wipe them all out and save Wurtz from this evil.");
            clearScreen();
            Console.WriteLine("On your journey you will encounter many dangers and allies. Pick your comrades carefully." +
                " Not everyone is nice here. One person wants to take the trone. Protect the king. Good luck and stay frosty");
            clearScreen();
        }

        public void Chapter1()
        {
            Console.WriteLine("...");
            clearScreen();
            Console.WriteLine("You feel coldness touch your cheek. What time was it? Did you miss your alarm again?" +
                " You eventually come to your senses. That's right. You were in your bed.");
            clearScreen();
            Console.WriteLine("You remember that you passed out while watching anime again." +
                " What was the anime called again? Fruits Basket.");
            clearScreen();
            Console.WriteLine("..." +
                " You know it's weird for a grown ass knight to be into that stuff but it is what it is." +
                " No one else in living with you so it's all good");



        }

        public void clearScreen()
        {
            Console.Write("> ");
            Console.ReadKey();
            Console.Clear();
        }

        public void woods(string woods, int roomNum)
        {
            _name = woods;
            _roomNum = 1;
        }

    }
}
