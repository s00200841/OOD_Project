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
    /// 7:00 nearly 200 lines in, just filler for the last 30 mins but done for today
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<SelectableCharacters> selectableCharacters = new ObservableCollection<SelectableCharacters>();
        
        public MainWindow()
        {
            InitializeComponent();
        }


        // TODO : Window Loader to load objects into Window 
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
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

            // Add abilities and skill
            mage.Abilities.Add(mageSkill1);
            mage.Abilities.Add(mageSkill2);
            mage.Abilities.Add(mageSkill3);

            warrior.Abilities.Add(warriorSkill1);
            warrior.Abilities.Add(warriorSkill2);

            assasin.Abilities.Add(assasinSkill1);
            assasin.Abilities.Add(assasinSkill2);

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
            }
        }
        // Skill list: Once character choice gets used this will be populated for use
        // Selecting a skill will give a description of the ability
        // TODO: Recheck later if i want more functionality here!!!
        private void lbxSkillList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Abilities selectedAbility = lbxSkillList.SelectedItem as Abilities;
            if(selectedAbility != null)
            {
                tblkSkillDescription.Text = selectedAbility.Details;
            }
        }
        //TODO: Fill Later
        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tbxName_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxName.Clear();
        }
    }
}
