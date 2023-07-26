using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextAdventureGame
{
    public partial class MainForm : Form
    {
        private enum GameStage
        {
            Start,
            Village,
            Forest,
            Statue,       // Added stage for the statue scene
            Riddle,       // Added stage for the riddle scene
            Temple,
            HiddenPassage, // Added stage for the hidden passage scene
            FoundAmulet,
            End
        }


        private GameStage currentStage;
        private string playerName;

        public MainForm()
        {
            InitializeComponent();
            currentStage = GameStage.Start;
            DisplayGameText("Welcome to the Quest for the Lost Amulet!\n");
            DisplayGameText("Please enter your name to begin the adventure.\n");
            txtPlayerInput.SetSubmitButton(btnSubmit);
            this.AcceptButton = btnSubmit;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string playerInput = txtPlayerInput.Text.Trim();

            switch (currentStage)
            {
                case GameStage.Start:
                    if (!string.IsNullOrEmpty(playerInput))
                    {
                        playerName = playerInput;
                        DisplayGameText($"Welcome, {playerName}! Your adventure begins in the village.\n");
                        currentStage = GameStage.Village;
                        DisplayVillageScene();
                    }
                    else
                    {
                        DisplayGameText("Please enter a valid name to begin.\n");
                    }
                    break;

                // Add more cases for other game stages as the game progresses

                default:
                    // Handle other game stages based on the player's input
                    HandleGameStages(playerInput);
                    break;
            }

            txtPlayerInput.Clear();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void DisplayGameText(string text)
        {
            customRichTextBox1.AppendTextWithColor(text, Color.White);
        }

        private void DisplayImportantGameText(string text)
        {
            customRichTextBox1.AppendTextWithColor(text, Color.Yellow);
        }

        private void DisplayGameTextWithCustomFont(string text, Font font)
        {
            customRichTextBox1.AppendTextWithFont(text, font);
        }


        /*  private void DisplayGameText(string text)
          {
              customRichTextBox1.AppendText(text);
              customRichTextBox1.ScrollToCaret();
          } */
        private void DisplayVillageScene()
        {
            DisplayGameText("You are in the village, where would you like to go?\n");
            DisplayGameText("1. Go to the forest\n");
            DisplayGameText("2. Talk to the elder\n");
            DisplayGameText("3. Exit the game\n");
        }

        private void HandleGameStages(string playerInput)
        {
            switch (currentStage)
            {
                case GameStage.Village:
                    HandleVillageScene(playerInput);
                    break;
                case GameStage.Forest:
                    HandleForestScene(playerInput);
                    break;
                case GameStage.Statue:
                    HandleStatueScene(playerInput);
                    break;
                case GameStage.Riddle:
                    HandleRiddleScene(playerInput);
                    break;
                case GameStage.Temple:
                    HandleTempleScene(playerInput);
                    break;
                case GameStage.HiddenPassage:
                    HandleHiddenPassageScene(playerInput);
                    break;
                case GameStage.FoundAmulet:
                    HandleGuardianScene(playerInput);
                    break;
                default:
                    DisplayEndScene(playerInput);
                    break;
            }
        }


        private void HandleVillageScene(string playerInput)
        {
            switch (playerInput)
            {
                case "1":
                    currentStage = GameStage.Forest;
                    DisplayGameText("You decide to venture into the forest...\n");
                    DisplayForestScene();
                    break;
                case "2":
                    DisplayGameText("You talk to the elder who tells you more about the Lost Amulet.\n");
                    DisplayGameText("He advises you to be cautious in the forest.\n");
                    DisplayVillageScene();
                    break;
                case "3":
                    currentStage = GameStage.End;
                    DisplayImportantGameText("Thank you for playing! See you again.\n");
                    break;
                default:
                    DisplayGameText("Invalid input. Choose a valid option.\n");
                    DisplayVillageScene();
                    break;
            }
        }

        private void DisplayForestScene()
        {
            DisplayGameText("You are now in the enchanted forest. Choose your path:\n");
            DisplayGameText("1. Go deeper into the forest\n");
            DisplayGameText("2. Go back to the village\n");
        }

        private void HandleForestScene(string playerInput)
        {
            switch (playerInput)
            {
                case "1":
                    currentStage = GameStage.Statue; // Update the current stage to Statue
                    DisplayGameText("You venture deeper into the forest...\n");
                    DisplayGameText("The forest is dense, and you encounter various creatures on your journey.\n");
                    DisplayGameText("After hours of walking, you find a mysterious statue surrounded by glowing mushrooms.\n");
                    DisplayGameText("1. Investigate the statue\n");
                    DisplayGameText("2. Continue exploring the forest\n");
                    break;
                case "2":
                    currentStage = GameStage.Village;
                    DisplayGameText("You decide to return to the village...\n");
                    DisplayVillageScene();
                    break;
                default:
                    DisplayGameText("Invalid input. Choose a valid option.\n");
                    DisplayForestScene();
                    break;
            }
        }

        private void HandleStatueScene(string playerInput)
        {
            switch (playerInput)
            {
                case "1":
                    currentStage = GameStage.Riddle; // Move to the riddle scene
                    DisplayGameText("As you approach the statue, you notice an ancient inscription at its base.\n");
                    DisplayGameText("The inscription speaks of a hidden temple in the forest.\n");
                    DisplayGameText("It says that only those who solve the riddle of the forest guardian may find it.\n");
                    DisplayGameText("1. Try to solve the riddle\n");
                    DisplayGameText("2. Leave the statue and explore further\n");
                    break;
                case "2":
                    currentStage = GameStage.Forest;
                    DisplayGameText("You decide to continue exploring the forest...\n");
                    DisplayForestScene();
                    break;
                default:
                    DisplayGameText("Invalid input. Choose a valid option.\n");
                    DisplayStatueScene();
                    break;
            }
        }

        private void DisplayHiddenPassageScene()
        {
            DisplayGameText("You find yourself in a narrow hidden passage.\n");
            DisplayGameText("The passage is dimly lit, and the air feels eerie.\n");
            DisplayGameText("You can sense a mysterious presence nearby.\n");
            DisplayGameText("1. Continue along the hidden passage\n");
            DisplayGameText("2. Return to the temple\n");
        }

        private void HandleHiddenPassageScene(string playerInput)
        {
            switch (playerInput)
            {
                case "1":
                    DisplayGameText("You follow the hidden passage and reach a chamber.\n");
                    DisplayImportantGameText("Congratulations! You have found the Lost Amulet!\n");
                    currentStage = GameStage.FoundAmulet;
                    DisplayGameText("But wait, there's a guardian protecting the amulet!\n");
                    DisplayGameText("1. Attempt to defeat the guardian\n");
                    DisplayGameText("2. Escape and return later with a plan\n");
                    break;
                case "2":
                    currentStage = GameStage.Temple;
                    DisplayGameText("You decide to return to the temple...\n");
                    DisplayTempleScene();
                    break;
                default:
                    DisplayGameText("Invalid input. Choose a valid option.\n");
                    DisplayHiddenPassageScene();
                    break;
            }
        }

        private void DisplayRiddleScene()
        {
            DisplayGameText("You stand before the ancient statue, ready to face the riddle of the forest guardian.\n");
            DisplayGameText("The guardian's voice echoes in your mind as it presents the riddle...\n");
            DisplayGameText("Voice of Guardian: What has keys but can't open locks? Answer wisely!\n");
            DisplayGameText("1. Attempt to solve the riddle\n");
            DisplayGameText("2. Leave the statue and explore further\n");
        }

        private void HandleRiddleScene(string playerInput)
        {
            switch (playerInput)
            {
                case "1":
                    DisplayGameText("You ponder the riddle and its clues carefully...\n");
                    DisplayGameText("After much thought, you manage to solve the riddle!\n");
                    DisplayImportantGameText("Congratulations! You have unlocked the location of the hidden temple!\n");
                    currentStage = GameStage.Temple;
                    DisplayGameText("Excitedly, you head towards the hidden temple...\n");
                    DisplayTempleScene();
                    break;
                case "2":
                    DisplayGameText("The riddle seems too challenging for now.\n");
                    DisplayGameText("You decide to explore the forest further in search of more clues.\n");
                    DisplayForestScene();
                    break;
                default:
                    DisplayGameText("Invalid input. Choose a valid option.\n");
                    DisplayRiddleScene();
                    break;
            }
        }
        private void DisplayTempleScene()
        {
            DisplayGameText("You are now inside the ancient temple.\n");
            DisplayGameText("The air is thick with mystery, and the walls are adorned with intricate carvings.\n");
            DisplayGameText("1. Explore further into the temple\n");
            DisplayGameText("2. Examine the carvings closely\n");
        }

        private void HandleTempleScene(string playerInput)
        {
            switch (playerInput)
            {
                case "1":
                    currentStage = GameStage.HiddenPassage; // Move to the hidden passage scene
                    DisplayGameText("You cautiously enter the dark temple...\n");
                    DisplayGameText("Inside, you find mysterious symbols on the walls and a hidden passage.\n");
                    DisplayGameText("1. Follow the hidden passage\n");
                    DisplayGameText("2. Investigate the symbols further\n");
                    break;
                case "2":
                    currentStage = GameStage.Forest; // Go back to the forest scene
                    DisplayGameText("You decide to explore the forest further...\n");
                    DisplayForestScene();
                    break;
                default:
                    DisplayGameText("Invalid input. Choose a valid option.\n");
                    DisplayTempleScene(); // Loop back to the temple scene
                    break;
            }
        }


        private void DisplayGuardianScene()
        {
            DisplayGameText("You enter the chamber, and a fearsome guardian stands before you!\n");
            DisplayGameText("The guardian has glowing eyes and wields a powerful weapon.\n");
            DisplayGameText("You must choose your next move carefully.\n");
            DisplayGameText("1. Attempt to fight the guardian\n");
            DisplayGameText("2. Try to negotiate with the guardian\n");
            DisplayGameText("3. Flee and return later with a plan\n");
        }

        private void HandleGuardianScene(string playerInput)
        {
            switch (playerInput)
            {
                case "1":
                    DisplayGameText("You summon your courage and face the guardian...\n");
                    DisplayImportantGameText("With great skill and bravery, you engage in a fierce battle with the guardian.\n");
                    DisplayGameText("After a challenging fight, you emerge victorious!\n");
                    currentStage = GameStage.End;
                    DisplayGameText($"Congratulations, {playerName}! You have completed the Quest for the Lost Amulet!\n");
                    DisplayGameText("The village celebrates your bravery, and you become a legendary hero!\n");
                    break;
                case "2":
                    currentStage = GameStage.Temple;
                    DisplayGameText("You wisely choose to escape and return later with a plan...\n");
                    DisplayTempleScene();
                    break;
                default:
                    DisplayGameText("Invalid input. Choose a valid option.\n");
                    DisplayGuardianScene();
                    break;
            }
        }
        private void DisplayEndScene(string playerInput)
        {
            DisplayGameText("Congratulations on completing the Quest for the Lost Amulet!\n");
            DisplayGameText($"Well done, {playerName}! The village hails you as a hero!\n");
            DisplayGameText("1. Start a new adventure\n");
            DisplayGameText("2. Exit the game\n");
        }




        private void HandleEndScene(string playerInput)
        {
            switch (playerInput)
            {
                case "1":
                    currentStage = GameStage.Start;
                    DisplayGameText("You decide to embark on the Quest for the Lost Amulet once more!\n");
                    DisplayGameText("Good luck on your new adventure!\n");
                    DisplayVillageScene();
                    break;
                case "2":
                    currentStage = GameStage.End;
                    DisplayImportantGameText("Thank you for playing the Quest for the Lost Amulet!\n");
                    break;
                default:
                    DisplayGameText("Invalid input. Choose a valid option.\n");
                    DisplayEndScene(playerInput); // Call the method with the playerInput argument
                    break;
            }
        }




        private void DisplayStatueScene()
        {
            DisplayGameText("You venture deeper into the forest...\n");
            DisplayGameText("The forest is dense, and you encounter various creatures on your journey.\n");
            DisplayGameText("After hours of walking, you find a mysterious statue surrounded by glowing mushrooms.\n");
            DisplayGameText("1. Investigate the statue\n");
            DisplayGameText("2. Continue exploring the forest\n");
        }



    }
}
