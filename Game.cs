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
        public string name;
        public int statBoost;
    }


    class Game
    {
        private bool _gameOver = false;
        private Player _player1;
        private Player _player2;
        private Character _player1Partner;
        private Character _player2Partner;                                                                  
        private Item _bow;
        private Item _lance;
        private Item _stick;
        private Item _axe;
        private Item _keyblade;
        private Item _hammer;

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
            _bow.name = "Bow";
            _bow.statBoost = 15;
            _lance.name = "Lance";
            _lance.statBoost = 16;
            _stick.name = "Stick";
            _stick.statBoost = 6;
            _axe.name = "Axe";
            _axe.statBoost = 14;
            _keyblade.name = "Keyblade";
            _keyblade.statBoost = 10;
            _hammer.name = "Hammer";
            _hammer.statBoost = 18;
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

        public void GetInput(out char input, string option1, string option2, string option3, string query)
        {
            Console.WriteLine(query);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            Console.WriteLine("3. " + option3);
            Console.Write("> ");

            input = ' ';
            while (input != '1' && input != '2' && input != '3')
            {

                input = Console.ReadKey().KeyChar;
                if (input != '1' && input != '2' && input != '3')
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
        public void SelectLoadout(Player player)
        {
            Console.Clear();
            Console.WriteLine("Loadout 1: ");
            Console.WriteLine(_bow.name);
            Console.WriteLine(_lance.name);
            Console.WriteLine(_stick.name);

            Console.WriteLine("\n Loadout 2: ");
            Console.WriteLine(_axe.name);
            Console.WriteLine(_keyblade.name);
            Console.WriteLine(_hammer.name);
            
            
            //Get input for player one
            char input;
            GetInput(out input, "Loadout 1", "Loadout 2", "Please select a loadout.");
            //Equip item based on input value
            if (input == '1')
            {
                Console.Clear();
                Console.WriteLine("You picked loadout 1.");
                Console.WriteLine("\n ");
                Console.WriteLine("Bow: " + _bow.statBoost);
                Console.WriteLine("Lance: " + _lance.statBoost);
                Console.WriteLine("Stick: " + _stick.statBoost);
                player.AddItemToInventory(_bow, 0);
                player.AddItemToInventory(_lance, 1);
                player.AddItemToInventory(_stick, 2);

            }
            else if (input == '2')
            {
                player.AddItemToInventory(_lance, 0);
            }
            else if (input == '3')
            {
                player.AddItemToInventory(_stick, 0);
            }
        }

        public Player CreateCharacter()
        {

            char input = ' ';
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Player player = new Player(name, 100, 10, 3);
            GetInput(out input, "Warrior", "Assassin", "Archer", "Fighter", "choose a role");
            
            switch(input)
            {
                case '1':
                    {
                        
                        Console.WriteLine("\n A warrior. Famous for their strengh");
                        Console.ReadKey();
                        SelectLoadout(player);
                        break;
                    }
            }
            return player;
        }

        public void ClearScreen()
        {
            Console.WriteLine("Press any key to continue");
            Console.Write("> ");
            Console.ReadKey();
            Console.Clear();
        }

        public void SwitchWeapons(Player player)
        {
            Item[] inventory = player.GetInventory();

            char input = ' ';
            //Print out all items to the screen
            for(int i = 0; i < inventory.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + inventory[i].name + " \n Damage: " + inventory[i].statBoost);
            }
            Console.Write("> ");

            switch (input)
            {
                case '1':
                    {
                        player.EquipItem(0);
                        Console.WriteLine("You equipped " + inventory[0].name);
                        Console.WriteLine("Base damage increased by " + inventory[0].statBoost);
                        break;
                    }
                case '2':
                    {
                        player.EquipItem(1);
                        Console.WriteLine("You equipped " + inventory[1].name);
                        Console.WriteLine("Base damage increased by " + inventory[1].statBoost);
                        break;
                    }
                case '3':
                    {
                        player.EquipItem(2);
                        Console.WriteLine("You equipped " + inventory[2].name);
                        Console.WriteLine("Base damage increased by " + inventory[2].statBoost);
                        break;
                    }
                default:
                    {
                        player.UnequipItem();
                        Console.WriteLine("You somehow managed to drop your weapon LOL");
                        Console.WriteLine("Base damage is now set to default");

                        break;
                    }
            }

            
        }

        public void StartBattle()
        {
            ClearScreen();
            Console.WriteLine("Time to fight!");

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
                GetInput(out input, "Attack", "Change Weapon" , "Your turn Player 1");

                if(input == '1')
                {
                    Console.WriteLine(" ");
                    float damageTaken = _player1.Attack(_player2);
                    Console.WriteLine(_player1.GetName() + " did " + damageTaken + " damage);
                }
                else
                {
                    SwitchWeapons(_player1);
                }

                GetInput(out input, "Attack", "Change weapon", "Your turn Player 2");

                if (input == '1')
                {
                    Console.WriteLine(" ");
                    _player2.Attack(_player1);
                }
                else
                {
                    SwitchWeapons(_player2);
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
            _player1Partner = new Wizard(120, "Wizard Lizard", 20, 100);
            _player2Partner = new Wizard(120, "Harry Wizard 101", 20, 100);

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
