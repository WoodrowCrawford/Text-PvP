using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Enemy
    {
        private string _name;
        private int _health;
        private int _damage;

        public void enemy(string nameVal, int healthVal, int damageVal)
        {
            _name = nameVal;
            _health = healthVal;
            _damage = damageVal;
        }

        public bool GetIsEnemyAlive()
        {
            return _health > 0;
        }

        public void Attack(Enemy player)
        {
            player.TakeDamage(_damage);
        }

        public void TakeDamage(int damageVal)
        {
            if(GetIsEnemyAlive())
            {
                _health -= damageVal;
            }
            Console.WriteLine(_name + " took " + damageVal + " damage! ");
        }


    }
}
