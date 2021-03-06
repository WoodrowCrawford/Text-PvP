﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Player
    {
        private string _name;
        private string _role;
        private int _health;
        private int _baseDamage;
        private Item[] _inventory;
        private Item _currentWeapon;
        private Item _hands;

        public Player() : base()
        {
            _inventory = new Item[3];
            _hands.name = "Hands";
            _hands.statBoost = 0;
        }

        public Player(string nameVal, float healthVal, float damageVal, int inventorySize)
            : base 
        {
            _name = nameVal;
            _health = healthVal;
            _baseDamage = damageVal;
            _inventory = new Item[inventorySize];
            _hands.name = "Hands";
            _hands.statBoost = 0;
        }

        public Item[] GetInventory()
        {
            return _inventory;
        }

       

        public void AddItemToInventory(Item item, int index)
        {
            _inventory[index] = item;
        }

        public bool Contains(int itemIndex)
        {
            if(itemIndex > 0 && itemIndex < _inventory.Length)
            {
                return true;
            }
            return false;
        }

        public void EquipItem(int itemIndex)
        {
            if(Contains(itemIndex) == true)
            {
                _currentWeapon = _inventory[itemIndex];
            }
            
        }
        
        

        public void UnequipItem()
        {
            _currentWeapon = _hands;
        }

        public  Attack(Player enemy)
        {
            int totalDamage = _baseDamage + _currentWeapon.statBoost;
            enemy.TakeDamage(totalDamage);
            
        }

        public void PrintStats()
        {
            Console.WriteLine("Name: " + _name);
            Console.WriteLine("Role: " + _role);
            Console.WriteLine("Health: " + _health);
            Console.WriteLine("Damage: " + _baseDamage);
        }

        private void TakeDamage(int damageVal)
        {
            if(GetIsAlive())
            {
                _health -= damageVal;
            }
            Console.WriteLine(_name + " took " + damageVal + " damage!!!");
        }
    }
}
