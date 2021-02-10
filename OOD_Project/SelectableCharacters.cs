using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Project
{
    // Character script, base class and then character classes
    public abstract class SelectableCharacters
    {
        // TODO: sort out Encapsulation if i need it
        protected string CharacterName { get; set; }
        public List<Abilities> Abilities { get; set; }
        public string Details { get; set; }
        //Stats
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Strength { get; set; }
        public int Inteligence { get; set; }
        public int Dexterity { get; set; }

        // Testing 
        public float HPScaling { get; set; }
        public float MPScaling { get; set; }

        protected int HealthScaling()
        {
            HPScaling *=Strength;
            return Health = Convert.ToInt32(Health + HPScaling);
        }

        protected int ManaScaling()
        {
            MPScaling *= Inteligence;
            return Mana = Convert.ToInt32(Mana + MPScaling);
        }

        public SelectableCharacters( string characterName )
        {
            CharacterName = characterName;
            Abilities = new List<Abilities>();
        }

        public SelectableCharacters() : this(""){ }

        public override string ToString()
        {
            return CharacterName;
        }
    }

    // Characters class take in the Character type Name, the base stats and a description background
    // Can easily make more Characters
    public class Mage : SelectableCharacters
    {         
        public Mage(string characterName = "Mage")
        {
            CharacterName = characterName;
            HPScaling = 0.3f;
            MPScaling = 0.5f;
            Health = 90;            
            Mana = 150;
            Strength = 20;
            Inteligence = 50;
            Dexterity = 20;
            Details = "From far to the south the mage was raised to fight against the spawn.\n" +
                      "With Magic bestowed opon them from the gods they strike against their foe.";
            HealthScaling();
            ManaScaling();
        }
    }

    public class Warrior : SelectableCharacters
    {
       
        public Warrior(string characterName = "Warrior")
        {
            CharacterName = characterName;
            HPScaling = 0.7f;
            MPScaling = 0.2f;
            Health = 150;
            Mana = 60;
            Strength = 50;
            Inteligence = 20;
            Dexterity = 20;
            Details = "Fighting from ever reach of the plains the warriors fights againt all who stand before them.";

            HealthScaling();
            ManaScaling();
        }
    }
    public class Assasin : SelectableCharacters
    {
        public Assasin(string characterName = "Assasin")
        {
            CharacterName = characterName;
            HPScaling = 0.4f;
            MPScaling = 0.3f;
            Health = 80;
            Mana = 95;
            Strength = 20;
            Inteligence = 20;
            Dexterity = 50;
            Details = "To the North the Assasins live in the shadows\n" +
                      "Kill of be Killed. The life of an assasin is a ruthless one.";

            HealthScaling();
            ManaScaling();
        }
    }
}
