using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    //Create a turn based PvP game. It should have a battle loop where both players
    //must fight until one is dead. The game should allow players to upgrade their stats
    //using items. Both players and items should be defined as structs. 


    struct Item
    {
        public int statBoost;
    }


    class Game
    {
        private bool _gameOver = false;
        private Player _player1;
        private Player _player2;
        private Item _bow;
        private Item _lance;

        //Run the game
        public void Run()
        {
            Start();

            while(_gameOver == false)
            {
                Update();
            }

            End();

        }

        public void InitializeItems()
        {
            _bow.statBoost = 15;
            _lance.statBoost = 20;
        }

        //Displays two options to the player. Outputs the choice of the two options
        public void GetInput(out char input, string option1, string option2, string query)
        {
            //Print description to console
            Console.WriteLine(query);
            //print options to console
            Console.WriteLine("1." + option1);
            Console.WriteLine("2." + option2);
            Console.Write("> ");

            input = ' ';
            //loop until valid input is received
            while (input != '1' && input != '2')
            {
                input = Console.ReadKey().KeyChar;
                if(input != '1' && input != '2')
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }

        public void GetInput(out char input, string option1, string option2, string option3, string option4, string query)
        {
            Console.WriteLine(query);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            Console.WriteLine("3. " + option3);
            Console.WriteLine("4. " + option4);
            Console.Write("> ");

            input = ' ';
            while (input != '1' && input != '2' && input != '3' && input != '4')
            {

                input = Console.ReadKey().KeyChar;
                if (input != '1' && input != '2' && input != '3' && input != '4')
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }

        //Equip items to both players in the beginning of the game
        public void SelectItem(Player player)
        {
            //Get input for player one
            char input;
            GetInput(out input, "Bow", "Lance", "Welcome! Please choose a weapon.");
            //Equip item based on input value
            if (input == '1')
            {
                Console.Clear();
                Console.WriteLine(" You picked the bow." +
                    "Attack increased by 15.");
                player.AddItemToInventory(_bow, 0);

            }
            else if (input == '2')
            {
                player.AddItemToInventory(_lance, 1);
            }
        }

        public Player CreateCharacter()
        {

            
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Player player = new Player(name, 100, 10, 5);
            GetInput(out char input, "Warrior", "Assassin", "Archer", "Fighter", "choose a role");
            SelectItem(player);
            return player;
        }

        public void ClearScreen()
        {
            Console.WriteLine("Press any key to continue");
            Console.Write("> ");
            Console.ReadKey();
            Console.Clear();
        }

        public void StartBattle()
        {
            ClearScreen();
            Console.WriteLine("Now GO!");

            while(_player1.GetIsAlive() && _player2.GetIsAlive())
            {
                //print player stats to console
                Console.WriteLine("Player1");
                _player1.PrintStats();
                Console.WriteLine(" ");
                Console.WriteLine("Player2");
                _player2.PrintStats();
                //Player 1 turn start
                //Get player input
                char input;
                GetInput(out input, "Attack", "NO", "Your turn Player 1");

                if(input == '1')
                {
                    Console.WriteLine(" ");
                    _player1.Attack(_player2);
                }
                else
                {
                    Console.WriteLine("NO!!!!!");
                    Console.WriteLine("I shall not fight you");
                }

                GetInput(out input, "Attack", "NO", "Your turn Player 2");

                if (input == '1')
                {
                    Console.WriteLine(" ");
                    _player2.Attack(_player1);
                }
                else
                {
                    Console.WriteLine("NO!!!!!");
                }
                Console.Clear();
            }
            if(_player1.GetIsAlive())
            {
                Console.WriteLine("Player 1 wins");
            }
            else
            {
                Console.WriteLine("Player 2 wins");
            }
            ClearScreen();
            _gameOver = true;
        }


        //Performed once when the game begins
        public void Start()
        {
            InitializeItems();
        }

        //Repeated until the game ends
        public void Update()
        {
            
            _player1 = CreateCharacter();
            _player2 = CreateCharacter();
            StartBattle();

        }

        //Performed once when the game ends
        public void End()
        {
            
        }
    }
}
