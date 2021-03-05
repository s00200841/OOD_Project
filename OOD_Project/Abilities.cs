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
        public int BaseAbilityDamage { get; set; }
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
        // TODO: Come back and investigate if i want unique scaling for each character type
        public int AbilityDamageScale(int damageScale)
        {
            return AbilityDamage = Convert.ToInt32(BaseAbilityDamage* damageScale / 3);
        }
    }

    // Mage skills ****
    public class FireBall : Abilities
    {
        public FireBall(string abilityname = "FireBall")
        {           
            AbilityName = abilityname;
            AbilityCost = 5;
            BaseAbilityDamage = 25;
            AbilityDamage = BaseAbilityDamage;
            Details = $"{AbilityName}: Shoots a ball of fire at foes. Can inflict burning damage.";            
        }
    }

    public class IceFall : Abilities
    {
        public IceFall( string abilityname = "IceFall")
        {
            AbilityName = abilityname;
            AbilityCost = 7;
            BaseAbilityDamage = 15;
            AbilityDamage = BaseAbilityDamage;
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
            BaseAbilityDamage = 36;
            AbilityDamage = BaseAbilityDamage;
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
            BaseAbilityDamage = 35;
            AbilityDamage = BaseAbilityDamage;
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
            BaseAbilityDamage = 40;
            AbilityDamage = BaseAbilityDamage;
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
            BaseAbilityDamage = 60;
            AbilityDamage = BaseAbilityDamage;
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
            // BaseAbilityDamage = 0;
            // AbilityDamage = BaseAbilityDamage;
            AbilityDuration = 5.0f;
            Details = $"{AbilityName}: Turns character invisible increasing movement speed and damage while in stealth.";
        }
    }

    // Ranger Skiils ****
    public class TrueStrike : Abilities
    {
        public TrueStrike(string abilityname = "True Strike")
        {
            AbilityName = abilityname;
            AbilityCost = 9;
            BaseAbilityDamage = 45;
            AbilityDamage = BaseAbilityDamage;
            AbilityDuration = 0;
            Details = $"{AbilityName}: Fires a charged Arrow, striking target with great precision.";
        }
    }

    public class RainOfArrows : Abilities
    {
        public RainOfArrows(string abilityname = "Rain of Arrows")
        {
            AbilityName = abilityname;
            AbilityCost = 8;
            BaseAbilityDamage = 11;
            AbilityDamage = BaseAbilityDamage;
            AbilityDuration = 4;
            Details = $"{AbilityName}: Shoots a volley of arrows into the air and shower a designated area with arrows for a duration";
        }
    }

    // BattleMage Skills ***

    public class FlameSurge : Abilities
    {
        public FlameSurge(string abilityname = "Flame Surge")
        {
            AbilityName = abilityname;
            AbilityCost = 9;
            BaseAbilityDamage = 21;
            AbilityDamage = BaseAbilityDamage;
            AbilityDuration = 2;
            Details = $"{AbilityName}: Flames surge forward at close range. igniting all in its path";
        }
    }

    public class LightningEnchant : Abilities
    {
        public LightningEnchant(string abilityname = "Lightning Enchant")
        {
            AbilityName = abilityname;
            AbilityCost = 12;
            BaseAbilityDamage = 6;
            AbilityDamage = BaseAbilityDamage;
            AbilityDuration = 9;
            Details = $"{AbilityName}: Enchances Weapon with the power of Lighting for a short duration";
        }
    }
}
