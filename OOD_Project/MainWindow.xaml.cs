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
using System.IO;
using Newtonsoft.Json;

namespace OOD_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// GitHub : https://github.com/s00200841/OOD_Project
    /// Name: Andrew Casey
    /// Student Number: S00200841
    /// ********************************** Project Lifetime Notes (Thought's During Creation Cycle Of Project) *******************************
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
    /// 14/02/2021 3:40, working on UpdateSkillDamage(), have added a base stat to ensure damage gets scaled once only, previously was getting multiplied over and over.
    /// Added another character just to test out
    /// 05/03/2021 5:00 Wow been a while since added stuff( been theory crafting outside of code and thinking on how im to proceed)
    /// Added new Tabs, focused on second tab (not sure as to how im wanting it visualy sofar(just have code from the first window i want on second showing correctly for now)).
    /// Idea is to clean up a few parts in tab 1 and to spruce up tab two a bit, then i need to work out tab 3: my stat changing page (idea take say ex 40 point and distribute
    /// on selected character,,, reset if i change char,,, to be not able to go over or under the 40 points i can use(can add then remove to re add, handle any other case!!!)
    /// Mabey add a Fourth tab then to show new character with updated stats and name and allow saving then(if i try save without using all points (i should have a (Are you sure!)
    /// option show first too.. 
    /// 8:15 over 3 hours will do, feel happy with what ive done, and know what to do next and to ask
    /// 21/03/2021 8:00 Added some functionality to tab 3 to work from, added a save button with no function yet!!
    /// 9:10 happy with progress for now
    /// 21/04/2021 5:00 Attemping images and mabey save to json 
    /// 8:30 images are working as intended 
    /// json is having issues finding path
    /// Created Database and it works fine!
    /// 9:20 Time! tired and im happy with progress
    /// 9:28 - 9:40. noticed the video for images/ watched and got right back on to try, got images working now as intended
    /// 23/04/2021 10:00 Plans: add some styles to fill out quota. try fix Json or if not(Ask). not sure if its just path issues on my pc or if its wrong code
    /// 10:30 have some Styles in(just black on white, looks better than most other color combinations) json path issue still there, made some adjustments to the save code
    /// just need to ask to make sure.
    /// 10:50 will get back on later to check Json file issue(if it is an issue) and then Project will be complete!
    /// </summary>

    public partial class MainWindow : Window
    {
        ObservableCollection<SelectableCharacters> selectableCharacters = new ObservableCollection<SelectableCharacters>();
        // DataBase 
        CharacterSheetContainer db = new CharacterSheetContainer();

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

        SelectableCharacters ranger = new Ranger();
        Abilities rangerSkill1 = new TrueStrike();
        Abilities rangerSkill2 = new RainOfArrows();

        SelectableCharacters battleMage = new BattleMage();
        Abilities battleMageSkill1 = new FlameSurge();
        Abilities battleMageSkill2 = new LightningEnchant();

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

            ranger.Abilities.Add(rangerSkill1);
            ranger.Abilities.Add(rangerSkill2);

            battleMage.Abilities.Add(battleMageSkill1);
            battleMage.Abilities.Add(battleMageSkill2);

            // Adds Characters
            selectableCharacters.Add(mage);
            selectableCharacters.Add(warrior);
            selectableCharacters.Add(assasin);
            selectableCharacters.Add(ranger);
            selectableCharacters.Add(battleMage);

            // Display Characters
            lbxCharacterChoice.ItemsSource = selectableCharacters;
        }

        // CharacterChoice is when selecting a character other lists and texts get filled in with info for selected character
        private void lbxCharacterChoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectableCharacters selectedCharacter = lbxCharacterChoice.SelectedItem as SelectableCharacters;

            if (selectedCharacter != null)
            {
                tblkNo_Character_Selected.Text = $"The {selectedCharacter} class is currently selected.";
                // Displays abilities for the selected class
                lbxSkillList.ItemsSource = selectedCharacter.Abilities;
                lbxSkillList1.ItemsSource = selectedCharacter.Abilities;
                // Displays the background story for selected character
                tblkCharacterInfoBackground.Text = string.Format($"{selectedCharacter.Details}");

                // Character Stats
                tblkHealth.Text = string.Format($"{selectedCharacter.Health}");
                tblkMana.Text = string.Format($"{selectedCharacter.Mana}");
                tblkStr.Text = string.Format($"{selectedCharacter.Strength}");
                tblkInt.Text = string.Format($"{selectedCharacter.Inteligence}");
                tblkDex.Text = string.Format($"{selectedCharacter.Dexterity}");

                // Tab 3 
                tblk_t3_Health.Text = string.Format($"{selectedCharacter.Health}");
                tblk_t3_Mana.Text = string.Format($"{selectedCharacter.Mana}");
                tblk_t3_Strength.Text = string.Format($"{selectedCharacter.Strength}");
                tblk_t3_Inteligence.Text = string.Format($"{selectedCharacter.Inteligence}");
                tblk_t3_Dexterity.Text = string.Format($"{selectedCharacter.Dexterity}");

                tblk_ClassChosen.Text = string.Format($"{selectedCharacter}");

                // Image
                img_CharacterImage.Source = new BitmapImage(new Uri(selectedCharacter.CharacterImage, UriKind.Relative));


            }
        }
        // Skill list: Once character choice gets seleted this will be populated for use
        // Selecting a skill will give a description of the ability and mana cost
        private void lbxSkillList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Abilities selectedAbility = lbxSkillList.SelectedItem as Abilities;
            if(selectedAbility != null)
            {
                UpdateSkillDamage();
                // Skill Stats
                // Turning int to string here.
                tblkSkillDescription.Text = selectedAbility.Details;
                tblkSkillDescription1.Text = selectedAbility.Details;
                if (selectedAbility.AbilityDamage == 0)
                {
                    tblkDamage.Text = "";
                    tblkDamage1.Text = "";
                }
                else
                {
                    tblkDamage.Text = selectedAbility.AbilityDamage.ToString();
                    tblkDamage1.Text = selectedAbility.AbilityDamage.ToString();
                }
                if(selectedAbility.AbilityDuration == 0)
                {
                    tblkDuration.Text = "";
                    tblkDuration1.Text = "";
                }
                else
                {
                    tblkDuration.Text = selectedAbility.AbilityDuration.ToString();
                    tblkDuration1.Text = selectedAbility.AbilityDuration.ToString();
                }
                
                tblkManaCost.Text = selectedAbility.AbilityCost.ToString();
                tblkManaCost1.Text = selectedAbility.AbilityCost.ToString();
            }
        }
        private void lbxSkillList1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { // Copy of lbkSkillList to sort through the new list in skill tab also
            Abilities selectedAbility = lbxSkillList1.SelectedItem as Abilities;
            if (selectedAbility != null)
            {
                UpdateSkillDamage1();
                // Skill Stats
                // Turning int to string here.
                tblkSkillDescription.Text = selectedAbility.Details;
                tblkSkillDescription1.Text = selectedAbility.Details;
                if (selectedAbility.AbilityDamage == 0)
                {
                    tblkDamage.Text = "";
                    tblkDamage1.Text = "";
                }
                else
                {
                    tblkDamage.Text = selectedAbility.AbilityDamage.ToString();
                    tblkDamage1.Text = selectedAbility.AbilityDamage.ToString();
                }
                if (selectedAbility.AbilityDuration == 0)
                {
                    tblkDuration.Text = "";
                    tblkDuration1.Text = "";
                }
                else
                {
                    tblkDuration.Text = selectedAbility.AbilityDuration.ToString();
                    tblkDuration1.Text = selectedAbility.AbilityDuration.ToString();
                }

                tblkManaCost.Text = selectedAbility.AbilityCost.ToString();
                tblkManaCost1.Text = selectedAbility.AbilityCost.ToString();
            }
        }

        // Updates skills damage to show the stats after the stat increase from selected characters stats
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
                else if (selectedAbility == selectedAbility as TrueStrike || selectedAbility == selectedAbility as RainOfArrows)
                    selectedAbility.AbilityDamageScale(ranger.Dexterity);
                else if (selectedAbility == selectedAbility as FlameSurge || selectedAbility == selectedAbility as LightningEnchant)
                    selectedAbility.AbilityDamageScale(battleMage.Inteligence);
            }
        }

        // Same as above but shos the stats on a different Tab
        // Updates skills damage to show the stats after the stat increase from selected characters stats
        private void UpdateSkillDamage1()
        {
            Abilities selectedAbility = lbxSkillList1.SelectedItem as Abilities;
            if (selectedAbility != null)
            {
                if (selectedAbility == selectedAbility as FireBall || selectedAbility == selectedAbility as IceFall || selectedAbility == selectedAbility as Thunder)
                    selectedAbility.AbilityDamageScale(mage.Inteligence);
                else if (selectedAbility == selectedAbility as SlamAttack || selectedAbility == selectedAbility as Swipe)
                    selectedAbility.AbilityDamageScale(warrior.Strength);
                else if (selectedAbility == selectedAbility as SneakAttack || selectedAbility == selectedAbility as Invisible)
                    selectedAbility.AbilityDamageScale(assasin.Dexterity);
                else if (selectedAbility == selectedAbility as TrueStrike || selectedAbility == selectedAbility as RainOfArrows)
                    selectedAbility.AbilityDamageScale(ranger.Dexterity);
                else if (selectedAbility == selectedAbility as FlameSurge || selectedAbility == selectedAbility as LightningEnchant)
                    selectedAbility.AbilityDamageScale(battleMage.Inteligence);
            }
        }

        // Gotfocus clears text so that a name can be added
        private void tbxName_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxName.Clear();
        }

        // Just a submit name option
        private void btn_SubmitName_Click(object sender, RoutedEventArgs e)
        {
            // Tab 3 : If text is empty then say no name selected, otherwise show chosen name
            if(tbxName.Text == "")           
                tblk_CharacterName.Text = "No Name Selected on Tab 1";           
            else
            tblk_CharacterName.Text = tbxName.Text;
        }

        private void btn_t3_SaveProfile_Click(object sender, RoutedEventArgs e)
        {
            SelectableCharacters selectedCharacter = lbxCharacterChoice.SelectedItem as SelectableCharacters;           
            if (tbxName.Text != "" && selectedCharacter != null)
            {
                //string CharacterData = $"Name: {tblk_CharacterName}\nClass: {tblk_ClassChosen}\n"+
                //    $"Health: {tblk_t3_Health}\nMana: {tblk_t3_Mana}\nStrength: {tblk_t3_Strength}\n" +
                //    $"Inteligence: {tblk_t3_Inteligence}\nDexterity: {tblk_t3_Dexterity}"; 
                Character c = new Character()
                {
                    Name = string.Format($"{tblk_CharacterName.Text}"),
                    Class = string.Format($"{selectedCharacter}"),
                    Health = selectedCharacter.Health,
                    Mana = selectedCharacter.Mana,
                    Strength = selectedCharacter.Strength,
                    Inteligence = selectedCharacter.Inteligence,
                    Dexterity = selectedCharacter.Dexterity
                };

                try
                {
                    string data = JsonConvert.SerializeObject(c, Formatting.Indented);
                    using (StreamWriter sw = new StreamWriter("c:tempFolder/Charactersheet.json"))
                    {
                        sw.Write(data);
                        sw.Close();
                    }
                    string message = "Character Information has been save to Json";
                    MessageBox.Show(message);
                }
                catch
                {
                    string message = "Path Not Found Exception. File Not Saved to Json";
                    MessageBox.Show(message);
                }
                try
                {                  
                    db.Characters.Add(c);
                    db.SaveChanges();
                    string message = "Character Information has been saved to Database";
                    MessageBox.Show(message);
                }
                catch
                {
                    string message = "Database Not Found Exception. File Not Saved to Database";
                    MessageBox.Show(message);
                }
            }
            else
            {
                string message = "No Character/Name Chosen";
                MessageBox.Show(message);
            }
        }
    }
}
