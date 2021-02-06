using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Project
{
    // Abilities come from the base class Abilities
    // To add a new Ability a new class can be made below and will work off the base
    public abstract class Abilities
    {
        // TODO: sort encapsulation if its needed
        protected string AbilityName { get; set; }
        public string Details { get; set; }
        public int AbilityCost { get; set; }

        public Abilities(string abilityName)
        {
            AbilityName = abilityName;
        }

        public Abilities() : this ("")
        {

        }

        public override string ToString()
        {
            return AbilityName;
        }
    }

    // Mage skills ****
    public class FireBall : Abilities
    {
        public FireBall(string abilityname = "FireBall")
        {
            AbilityName = abilityname;
            AbilityCost = 5;
            Details = $"{AbilityName}: Shoots a ball of fire at foes.\nMana Cost: {AbilityCost}";
        }   
    }

    public class IceFall : Abilities
    {
        public IceFall( string abilityname = "IceFall")
        {
            AbilityName = abilityname;
            AbilityCost = 7;
            Details = $"{AbilityName}: Ice falls opon foes, chilling all how get hit.\nMana Cost: {AbilityCost}";
        }
    }
    public class Thunder : Abilities
    {
        public Thunder(string abilityname = "Thunder")
        {
            AbilityName = abilityname;
            AbilityCost = 5;
            Details = $"{AbilityName}: Thunder strikes the ground with massive force. Stunning and damaging all foes in its range.\nMana Cost: {AbilityCost}";
        }
    }

    // Warrior Skills ****
    public class SlamAttack : Abilities
    {
       public SlamAttack(string abilityname = "Slam Attack")
        {
            AbilityName = abilityname;
            AbilityCost = 6;
            Details = $"{AbilityName}: Jump and slam the ground at opponents location.\nMana Cost: {AbilityCost}";
        }
    }
    public class Swipe : Abilities
    {
        public Swipe(string abilityname = "Swipe")
        {
            AbilityName = abilityname;
            AbilityCost = 3;
            Details = $"{AbilityName}: Swing weapon with huge force in an arc infront of you hitting all targets in its range.\nMana Cost: {AbilityCost}";
        }
    }

    // Assasin skills ****
    public class SneakAttack : Abilities
    {
       public SneakAttack(string abilityname = "Sneak Attack")
        {
            AbilityName = abilityname;
            AbilityCost = 10;
            Details = $"{AbilityName}: Stab opponent in back.\nMana Cost: {AbilityCost}";
        }
    }
    public class Invisible : Abilities
    {
        public Invisible(string abilityname = "Invisible")
        {
            AbilityName = abilityname;
            AbilityCost = 7;
            Details = $"{AbilityName}: Turns character invisible increasing movement speed and damage while in stealth.\nMana Cost: {AbilityCost}";
        }
    }
}
