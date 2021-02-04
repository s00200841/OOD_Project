using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Project
{
    public abstract class SelectableCharacters
    {
        public string CharacterName { get; set; }
        public List<Abilities> Abilities { get; set; }
        public string Details { get; set; }
        
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

    public class Mage : SelectableCharacters
    {         
        public Mage(string characterName = "Mage")
        {
            CharacterName = characterName;
            Details = "From far to the south the mage was raised to fight against the spawn.\n" +
                      "With Magic bestowed opon them from the gods they strike against their foe.";
        }
    }

    public class Warrior : SelectableCharacters
    {
       
        public Warrior(string characterName = "Warrior")
        {
            CharacterName = characterName;
            Details = "Fighting from ever reach of the plains the warriors fights againt all who stand before them.";
        }
    }
    public class Assasin : SelectableCharacters
    {
        public Assasin(string characterName = "Assasin")
        {
            CharacterName = characterName;
            Details = "To the North the Assasins live in the shadows\n" +
                      "Kill of be Killed. The life of an assasin is a ruthless one.";
        }
    }
}
