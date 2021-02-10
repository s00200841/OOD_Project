using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOD_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// GitHub : https://github.com/s00200841/OOD_Project
    /// Name: Andrew Casey
    /// Student Number: S00200841
    /// 04/02/2021 3:00 started. going to take it slow and see what i can get done in a few hours,,
    /// Plans Mabey use Images... set up window and some simple interaction code... have an overall idea of what im doing.
    /// 6:35 set up a basic pick class/see info setup, took a while, couldnt get second listbox to work until i made my list an ObservableCollection
    /// happy to have some progress, done a lot and it looks like a little amount but happy with it.
    /// 7:00 nearly 200 lines in, just filler for the last 30 mins but done for today.
    /// 06/02/2021 Saturday, thinking about code made me get on and do some, few additions, Wanted Stats on UI for each individual character
    /// added functionality to the Next button, will need to learn how to add a new window to continue on that
    /// added more comments to bring clarity to code
    /// 10/02/2021 10:00 the way ive set my code up i cant seem to be able to change the numbers ex, character hp, skill damage, Edit: I can now update and change numbers.
    /// So where i am is i may need base skills to go off because i update my stat and it gets updated every time so i end up with unrealistic stats
    /// UpdateSkillDamage made to test this!! 
    /// 1:30 now and kind of tired of coding for now
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<SelectableCharacters> selectableCharacters = new ObservableCollection<SelectableCharacters>();

        // TODO: Later i plan on adding skills when i meet certian criteria( ex i add some more points to strength i gain a new skill)
        // So i have to have these outside the methods for access

        // sets up classes and skills
        SelectableCharacters mage = new Mage();
        Abilities mageSkill1 = new FireBall();
        Abilities mageSkill2 = new IceFall();
        Abilities mageSkill3 = new Thunder();

        SelectableCharacters warrior = new Warrior();
        Abilities warriorSkill1 = new SlamAttack();
        Abilities warriorSkill2 = new Swipe();

        SelectableCharacters assasin = new Assasin();
        Abilities assasinSkill1 = new SneakAttack();
        Abilities assasinSkill2 = new Invisible();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Window Loader loads objects into the Window to be shown on startup and for use later
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {            
            // Add abilities and skills
            mage.Abilities.Add(mageSkill1);
            mage.Abilities.Add(mageSkill2);
            mage.Abilities.Add(mageSkill3);

            warrior.Abilities.Add(warriorSkill1);
            warrior.Abilities.Add(warriorSkill2);

            assasin.Abilities.Add(assasinSkill1);
            assasin.Abilities.Add(assasinSkill2);

            // Adds Characters
            selectableCharacters.Add(mage);
            selectableCharacters.Add(warrior);
            selectableCharacters.Add(assasin);

            // Display Characters
            lbxCharacterChoice.ItemsSource = selectableCharacters;
        }

        // CharacterChoice is when selecting a character other lists and texts get filled in with info for selected character
        private void lbxCharacterChoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectableCharacters selectedCharacter = lbxCharacterChoice.SelectedItem as SelectableCharacters;

            if (selectedCharacter != null)
            {           
                // Displays abilities for the selected class
                lbxSkillList.ItemsSource = selectedCharacter.Abilities;
                // Displays the background story for selected character
                tblkCharacterInfoBackground.Text = string.Format($"{selectedCharacter.Details}");

                // Character Stats
                tblkHealth.Text = string.Format($"{selectedCharacter.Health}");
                tblkMana.Text = string.Format($"{selectedCharacter.Mana}");
                tblkStr.Text = string.Format($"{selectedCharacter.Strength}");
                tblkInt.Text = string.Format($"{selectedCharacter.Inteligence}");
                tblkDex.Text = string.Format($"{selectedCharacter.Dexterity}");
            }
        }
        // Skill list: Once character choice gets seleted this will be populated for use
        // Selecting a skill will give a description of the ability and mana cost
        // TODO: Recheck later if i want more functionality here!!!
        private void lbxSkillList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Abilities selectedAbility = lbxSkillList.SelectedItem as Abilities;
            if(selectedAbility != null)
            {
                // Skill Stats
                // Turning int to string here. TODO: Recheck if i need to change back
                tblkSkillDescription.Text = selectedAbility.Details;
                if (selectedAbility.AbilityDamage == 0)
                {
                    tblkDamage.Text = "";
                }
                else
                {
                    tblkDamage.Text = selectedAbility.AbilityDamage.ToString();
                }
                if(selectedAbility.AbilityDuration == 0)
                {
                    tblkDuration.Text = "";
                }
                else
                {
                    tblkDuration.Text = selectedAbility.AbilityDuration.ToString();
                }
                
                tblkManaCost.Text = selectedAbility.AbilityCost.ToString();
            }
        }

        // Update Skills Damage for testing purpose this exists .. TODO: Recheck value, if more skills added this need updating etc, TODO: try move to Abilities
        private void UpdateSkillDamage()
        {
            Abilities selectedAbility = lbxSkillList.SelectedItem as Abilities;
            if (selectedAbility != null)
            {
                // TODO: Check
                if (selectedAbility == selectedAbility as FireBall || selectedAbility == selectedAbility as IceFall || selectedAbility == selectedAbility as Thunder)
                    selectedAbility.AbilityDamageScale(mage.Inteligence);
                else if (selectedAbility == selectedAbility as SlamAttack || selectedAbility == selectedAbility as Swipe)
                    selectedAbility.AbilityDamageScale(warrior.Strength);
                else if (selectedAbility == selectedAbility as SneakAttack || selectedAbility == selectedAbility as Invisible)
                    selectedAbility.AbilityDamageScale(assasin.Dexterity);

            }
        }
        //TODO: Fill Later, Temp Code added for now , Can also use this for now as a button tester to update stuff!!!
        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            string message = "Here i plan on adding a second window that will hold two main things for now\n" +
                            "Firstly the character name and secondly the chosen character class.";
            MessageBox.Show(message);

        }
        // Gotfocus clears text so that a name can be added
        private void tbxName_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxName.Clear();
        }
    }
}
