using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Project
{
    public abstract class Abilities
    {
        public string AbilityName { get; set; }
        public string Details { get; set; }
        

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

    // Mage skills
    public class FireBall : Abilities
    {
        public FireBall(string abilityname = "FireBall")
        {
            AbilityName = abilityname;
            Details = $"{AbilityName}: Shoots a ball of fire at foes";
        }   
    }

    public class IceFall : Abilities
    {
        public IceFall( string abilityname = "IceFall")
        {
            AbilityName = abilityname;
            Details = $"{AbilityName}: Ice falls opon foes, chilling all how get hit.";
        }
    }
    public class Thunder : Abilities
    {
        public Thunder(string abilityname = "Thunder")
        {
            AbilityName = abilityname;
            Details = $"{AbilityName}: Thunder strikes the ground with massive force. Stunning and damaging all foes in its range.";
        }
    }


    // Warrior Skills
    public class SlamAttack : Abilities
    {
       public SlamAttack(string abilityname = "Slam Attack")
        {
            AbilityName = abilityname;
            Details = $"{AbilityName}: Jump and slam the ground at opponents location.";
        }
    }
    public class Swipe : Abilities
    {
        public Swipe(string abilityname = "Swipe")
        {
            AbilityName = abilityname;
            Details = $"{AbilityName}: Swing weapon with huge force in an arc infront of you hitting all targets in its range.";
        }
    }


    // Assasin skills
    public class SneakAttack : Abilities
    {
       public SneakAttack(string abilityname = "Sneak Attack")
        {
            AbilityName = abilityname;
            Details = $"{AbilityName}: Stab opponent in back";
        }
    }
    public class Invisible : Abilities
    {
        public Invisible(string abilityname = "Invisible")
        {
            AbilityName = abilityname;
            Details = $"{AbilityName}: Turns character invisible increasing movement speed and damage while in stealth.";
        }
    }
}
