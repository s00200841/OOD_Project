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
        public int AbilityDamage { get; set; }
        public float AbilityDuration { get; set; }
        public int Inteligence { get; set; }

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

        // Can either expand on different stats ex. int , str for more flexability since
        // currrently this code takes the ability damage multiplied by stat divided by 3 
        public int AbilityDamageScale(int damageScale)
        {
            return AbilityDamage = Convert.ToInt32(AbilityDamage* damageScale / 3);
        }
    }

    // Mage skills ****
    public class FireBall : Abilities
    {
        public FireBall(string abilityname = "FireBall")
        {           
            AbilityName = abilityname;
            AbilityCost = 5;
            AbilityDamage = 25;
            Details = $"{AbilityName}: Shoots a ball of fire at foes. Can inflict burning damage.";            
        }
    }

    public class IceFall : Abilities
    {
        public IceFall( string abilityname = "IceFall")
        {
            AbilityName = abilityname;
            AbilityCost = 7;
            AbilityDamage = 15;
            AbilityDuration = 3.5f;
            Details = $"{AbilityName}: Ice falls opon foes, Damaging and chilling all who get hit for a duration.";
        }
    }
    public class Thunder : Abilities
    {
        public Thunder(string abilityname = "Thunder")
        {
            AbilityName = abilityname;
            AbilityCost = 5;
            AbilityDamage = 36;
            //AbilityDuration = 0;
            Details = $"{AbilityName}: Thunder strikes the ground with massive force. Stunning and damaging all foes in its range.";
        }
    }

    // Warrior Skills ****
    public class SlamAttack : Abilities
    {
       public SlamAttack(string abilityname = "Slam Attack")
        {
            AbilityName = abilityname;
            AbilityCost = 6;
            AbilityDamage = 35;
            //AbilityDuration = 0;
            Details = $"{AbilityName}: Jump and slam the ground at opponents location.";
        }
    }
    public class Swipe : Abilities
    {
        public Swipe(string abilityname = "Swipe")
        {
            AbilityName = abilityname;
            AbilityCost = 3;
            AbilityDamage = 40;
           // AbilityDuration = 0;
            Details = $"{AbilityName}: Swing weapon with huge force in an arc infront of you hitting all targets in its range.";
        }
    }

    // Assasin skills ****
    public class SneakAttack : Abilities
    {
       public SneakAttack(string abilityname = "Sneak Attack")
        {
            AbilityName = abilityname;
            AbilityCost = 10;
            AbilityDamage = 60;
            //AbilityDuration = 0;
            Details = $"{AbilityName}: Stab opponent in back.";
        }
    }
    public class Invisible : Abilities
    {
        public Invisible(string abilityname = "Invisible")
        {
            AbilityName = abilityname;
            AbilityCost = 7;
           // AbilityDamage = 0;
            AbilityDuration = 5.0f;
            Details = $"{AbilityName}: Turns character invisible increasing movement speed and damage while in stealth.";
        }
    }
}
