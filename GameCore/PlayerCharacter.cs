using System;
using System.Collections.Generic;
using System.Linq;

namespace GameCore
{
    public class PlayerCharacter
    {
        public int Health { get; private set; } = 100;
        public bool IsDead { get; private set; }
        public int Resistance { get; set; }
        public string Race { get; set; }
        public CharacterClass CharacterClass { get; set; }

        public int MagicPower
        {
            get
            {
                return MagicItems.Sum(i => i.Power);
            }
        }

        public IEnumerable<MagicItem> MagicItems { get; set; }

        public void Hit(int damage)
        {
            if(Race == "Elf")
            {
                Resistance += 20;
            }
            damage -= Resistance;

            Health -= damage;

            if(Health < 0)
            {
                IsDead = true;
            }
        }

        public void CastHealSpell()
        {
            if(CharacterClass == CharacterClass.Healer)
            {
                Health = 100;
            }
            else
            {
                Health += 10;
            }
        }
    }
}
