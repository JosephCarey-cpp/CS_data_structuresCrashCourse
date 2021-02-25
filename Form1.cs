using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CS_data_structuresCrashCourse
{

    // this is to hold items within the method Form1_Load
    struct Profile 
    {
        public string firstName;
        public string lastName;
        public string username;
        public string school;
        public string major;
        public string tutor;
        public string progressValue;
    }

    public partial class Form1 : Form
    {

        // writes to existing file
        // int mode is items 1-7, see IF listings on lines 55-61 
        // string inputValue is what is being written/overwriting                 
        private void writeToExFile(int mode, string inputValue)
        {

            StreamReader inputFile;
            string line;

            Profile textElement = new Profile(); // using the placeholder structure
            inputFile = File.OpenText("CS_DataStructuresProfile.txt");
            while (!inputFile.EndOfStream)
            {
                line = inputFile.ReadLine();
                string[] element = line.Split(','); // splits it's items at commas and puts it into
                                                    // an array form
                textElement.firstName = element[0];
                textElement.lastName = element[1];
                textElement.username = element[2];
                textElement.school = element[3];
                textElement.major = element[4];
                textElement.tutor = element[5];
                textElement.progressValue = element[6];
            }
            inputFile.Close();

            /*
             * The following IF's are the existing modes:
             * 1. First name        5. Major
             * 2. Last name         6. Tutor element (T/F)
             * 3. Username          7. Progress value (CANNOT be changed by the user) (character element)
             * 4. School               
            */

            if (mode == 1)
            {
                StreamWriter output_file;
                output_file = File.CreateText("CS_DataStructuresProfile.txt");

                output_file.WriteLine(inputValue + ',' + textElement.lastName + ','
                                    + textElement.username + ',' + textElement.school + ','
                                    + textElement.major + ',' + textElement.tutor + ","
                                    + textElement.progressValue);
                output_file.Close();

            }

            if (mode == 2)
            {
                StreamWriter output_file;
                output_file = File.CreateText("CS_DataStructuresProfile.txt");

                output_file.WriteLine(textElement.firstName + ',' + inputValue + ','
                                    + textElement.username + ',' + textElement.school + ','
                                    + textElement.major + ',' + textElement.tutor + ","
                                    + textElement.progressValue);
                output_file.Close();

            }

            if (mode == 3)
            {
                StreamWriter output_file;
                output_file = File.CreateText("CS_DataStructuresProfile.txt");

                output_file.WriteLine(textElement.firstName + ',' + textElement.lastName + ','
                                    + inputValue + ',' + textElement.school + ','
                                    + textElement.major + ',' + textElement.tutor + ","
                                    + textElement.progressValue);
                output_file.Close();

            }

            if (mode == 4)
            {
                StreamWriter output_file;
                output_file = File.CreateText("CS_DataStructuresProfile.txt");

                output_file.WriteLine(textElement.firstName + ',' + textElement.lastName + ','
                                    + textElement.username + ',' + inputValue + ','
                                    + textElement.major + ',' + textElement.tutor + ","
                                    + textElement.progressValue);
                output_file.Close();

            }

            if (mode == 5)
            {
                StreamWriter output_file;
                output_file = File.CreateText("CS_DataStructuresProfile.txt");

                output_file.WriteLine(textElement.firstName + ',' + textElement.lastName + ','
                                    + textElement.username + ',' + textElement.school + ','
                                    + inputValue + ',' + textElement.tutor + ","
                                    + textElement.progressValue);
                output_file.Close();

            }

            if (mode == 6)
            {
                StreamWriter output_file;
                output_file = File.CreateText("CS_DataStructuresProfile.txt");

                output_file.WriteLine(textElement.firstName + ',' + textElement.lastName + ','
                                    + textElement.username + ',' + textElement.school + ','
                                    + textElement.major + ',' + inputValue + ","
                                    + textElement.progressValue);
                output_file.Close();

            }

            if (mode == 7)
            {
                StreamWriter output_file;
                output_file = File.CreateText("CS_DataStructuresProfile.txt");

                output_file.WriteLine(textElement.firstName + ',' + textElement.lastName + ','
                                    + textElement.username + ',' + textElement.school + ','
                                    + textElement.major + ',' + textElement.tutor + ","
                                    + inputValue);
                output_file.Close();

            }
        }

        // reads the profile and returns a value
        // the return value can be the:
        /*
             * 0. NULL              4. School 
             * 1. First name        5. Major
             * 2. Last name         6. Tutor element (T/F)
             * 3. Username          7. Progress value (character element)
        */
        private string readProfileAndReturn(int value)
        {
            StreamReader inputFile;
            string line;

            Profile textElement = new Profile(); // using the structure Profile for user's info
            inputFile = File.OpenText("CS_DataStructuresProfile.txt");
            while (!inputFile.EndOfStream)
            {
                line = inputFile.ReadLine();
                string[] element = line.Split(','); // splits it's items at commas and puts it into
                                                    // an array form
                textElement.firstName = element[0];
                textElement.lastName = element[1];
                textElement.username = element[2];
                textElement.school = element[3];
                textElement.major = element[4];
                textElement.tutor = element[5];
                textElement.progressValue = element[6];
            }
            inputFile.Close();

            profileInfoList.Text = "Name: " + textElement.firstName + " " + textElement.lastName + "\r\n\r\n"
                                    + "Username: " + textElement.username + "\r\n\r\n" + "Campus: " + textElement.school
                                    + "\r\n\r\n" + "Major: " + textElement.major + "\r\n\r\n" + "Tutorial: " + textElement.tutor;

            if (value == 1)
                return textElement.firstName;
            else if (value == 2)
                return textElement.lastName;
            else if (value == 3)
                return textElement.username;
            else if (value == 4)
                return textElement.school;
            else if (value == 5)
                return textElement.major;
            else if (value == 6)
                return textElement.tutor;
            else if (value == 7)
                return textElement.progressValue;
            else
                return "NULL";
        }

        // Welcome Message On/Off sequences for menu changes
        private void welcomeMenuToggle(bool onOff)
        {
            // turns the visibility on or off

            WelcomeLabel.Visible = onOff;
            subHeaderLabel.Visible = onOff;
            firstName_label.Visible = onOff;
            firstNameInput.Visible = onOff;
            lastName_label.Visible = onOff;
            lastNameInput.Visible = onOff;
            profileTitle.Visible = onOff;
            ProTitleInput.Visible = onOff;
            campus_label.Visible = onOff;
            CampusInput.Visible = onOff;
            majorPick_Label.Visible = onOff;
            MajorInput.Visible = onOff;
            profileCreator_button.Visible = onOff;

            // if the objects are turning on (true)
            // then bring everything to the front
            if (onOff == true)
            {
                WelcomeLabel.BringToFront();
                subHeaderLabel.BringToFront();
                firstName_label.BringToFront();
                firstNameInput.BringToFront();
                lastName_label.BringToFront();
                lastNameInput.BringToFront();
                profileTitle.BringToFront();
                ProTitleInput.BringToFront();
                campus_label.BringToFront();
                CampusInput.BringToFront();
                majorPick_Label.BringToFront();
                MajorInput.BringToFront();
                profileCreator_button.BringToFront();
            }
            // else if the objects are turning off (false)
            // then send everything to the back
            else if (onOff == false)
            {
                WelcomeLabel.SendToBack();
                subHeaderLabel.SendToBack();
                firstName_label.SendToBack();
                firstNameInput.SendToBack();
                lastName_label.SendToBack();
                lastNameInput.SendToBack();
                profileTitle.SendToBack();
                ProTitleInput.SendToBack();
                campus_label.SendToBack();
                CampusInput.SendToBack();
                majorPick_Label.SendToBack();
                MajorInput.SendToBack();
                profileCreator_button.SendToBack();
            }
        }

        // Main Menu On/Off sequences for menu changes
        private void mainMenuToggle(bool onOff)
        {
            // objects turning on/off

            mainMenuBack.Visible = onOff;
            mainWelcomeMsg.Visible = onOff;
            mathTab.Visible = onOff;
            structTab.Visible = onOff;
            tricksTab.Visible = onOff;
            profileTab.Visible = onOff;
            creditsTab.Visible = onOff;
            bugFixTab.Visible = onOff;
            Tutor_Tab.Visible = onOff;
            infoBox(onOff);
            tutorBoxToggle(onOff);

            CreditsTabToggle(false);
            bugFixTabToggle(false);
            profileTabToggle(false);
            editScreenToggle(false);

            // if the objects are turning on (true)
            // then bring everything to the front
            if (onOff == true)
            {
                mainMenuBack.BringToFront();
                mainWelcomeMsg.BringToFront();
                mathTab.BringToFront();
                structTab.BringToFront();
                tricksTab.BringToFront();
                profileTab.BringToFront();
                creditsTab.BringToFront();
                bugFixTab.BringToFront();
                Tutor_Tab.BringToFront();
            }

            // else if the objects are turning off (false)
            // then send everything to the back
            else if (onOff == false)
            {
                mainMenuBack.SendToBack();
                mainWelcomeMsg.SendToBack();
                mathTab.SendToBack();
                structTab.SendToBack();
                tricksTab.SendToBack();
                profileTab.SendToBack();
                creditsTab.SendToBack();
                bugFixTab.SendToBack();
                Tutor_Tab.SendToBack();
            }
        }

        // custom username header: any username made is shown as its own
        private void welcomeMsgProfile(string username) { mainWelcomeMsg.Text = "Welcome " + username; }

        // custom tab header: the user selects tabs and shows it's respective title
        private void tabInfoHeader(string tabInfo) { mainWelcomeMsg.Text = tabInfo; }

        // the boxes to hold information visually
        private void infoBox(bool onOff)
        {
            //objects turning on/off

            infoBoxBack1.Visible = onOff;
            infoBoxBack2.Visible = onOff;

            // if the objects are turning on (true)
            // then bring everything to the front
            if (onOff == true)
            {
                infoBoxBack1.BringToFront();
                infoBoxBack2.BringToFront();
            }

            // else if the objects are turning off (false)
            // then send everything to the back
            else if (onOff == false)
            {
                infoBoxBack1.SendToBack();
                infoBoxBack2.SendToBack();
            }
        }

        // toggle for the tutorial to be shown
        private void tutorBoxToggle(bool onOff)
        {
            // objects turning on/off

            tutorBox.Visible = onOff;
            infoBox(onOff);
            tutorCheck.Visible = onOff;

            // if the objects are turning on (true)
            // then bring everything to the front
            if (onOff == true)
            {
                tutorBox.BringToFront();
                tutorCheck.BringToFront();
            }

            // else if the objects are turning off (false)
            // then send everything to the back
            else if (onOff == false)
            {
                tutorBox.SendToBack();
                tutorCheck.SendToBack();
            }
        }



        // toggle for the Credits Tab to be shown
        private void CreditsTabToggle(bool onOff)
        {
            CreditsHeader.Visible = onOff;
            creditsBox1.Visible = onOff;
            creditsBox2.Visible = onOff;
            creditsBox4.Visible = onOff;

            if (onOff == true)
            {
                CreditsHeader.BringToFront();
                creditsBox1.BringToFront();
                creditsBox2.BringToFront();
                creditsBox4.BringToFront();
            }
            else if (onOff == false)
            {
                CreditsHeader.SendToBack();
                creditsBox1.SendToBack();
                creditsBox2.SendToBack();
                creditsBox4.SendToBack();
            }
        }

        // toggle for the Bug Fixes Tab to be shown
        private void bugFixTabToggle(bool onOff)
        {
            bugFixesHeader.Visible = onOff;
            bugBox1.Visible = onOff;
            bugBox2.Visible = onOff;
            ver_label.Visible = onOff;

            if (onOff == true)
            {
                bugFixesHeader.BringToFront();
                bugBox1.BringToFront();
                bugBox2.BringToFront();
                ver_label.BringToFront();
            }
            else if (onOff == false)
            {
                bugFixesHeader.SendToBack();
                bugBox1.SendToBack();
                bugBox2.SendToBack();
                ver_label.SendToBack();
            }
        }

        // toggle for the Profile tab to be shown
        private void profileTabToggle(bool onOff)
        {
            try
            {
                readProfileAndReturn(0);
                tutorBoxToggle(false);
                infoBox(true);
                infoBoxBack2.Text = " ";
                profileTabContentsToggle(onOff);
            }
            catch
            {
                tutorBoxToggle(false);
                infoBox(false);
                infoBoxBack2.Text = " ";
                profileTabContentsToggle(onOff);
            }


        }

        private void profileTabContentsToggle(bool onOff)
        {
            // objects turning on/off
            profileHeader.Visible = onOff;
            profileInfoList.Visible = onOff;
            editProfileButton.Visible = onOff;


            label1.Visible = onOff;
            progressBarBack.Visible = onOff;
            lvl1Box.Visible = onOff;
            lvl2Box.Visible = onOff;
            lvl3Box.Visible = onOff;
            lvl4Box.Visible = onOff;
            lvl5Box.Visible = onOff;
            lvl6Box.Visible = onOff;
            lvl7Box.Visible = onOff;
            lvl8Box.Visible = onOff;
            lvl9Box.Visible = onOff;
            lvl10Box.Visible = onOff;


            // if the objects are turning on (true)
            // then bring everything to the front
            if (onOff == true)
            {
                profileHeader.BringToFront();
                profileInfoList.BringToFront();
                editProfileButton.BringToFront();

                label1.BringToFront();
                progressBarBack.BringToFront();
                lvl1Box.BringToFront();
                lvl2Box.BringToFront();
                lvl3Box.BringToFront();
                lvl4Box.BringToFront();
                lvl5Box.BringToFront();
                lvl6Box.BringToFront();
                lvl7Box.BringToFront();
                lvl8Box.BringToFront();
                lvl9Box.BringToFront();
                lvl10Box.BringToFront();
            }

            // else if the objects are turning off (false)
            // then send everything to the back
            else if (onOff == false)
            {
                profileHeader.BringToFront();
                profileInfoList.BringToFront();
                editProfileButton.BringToFront();


                label1.SendToBack();
                progressBarBack.SendToBack();
                lvl1Box.SendToBack();
                lvl2Box.SendToBack();
                lvl3Box.SendToBack();
                lvl4Box.SendToBack();
                lvl5Box.SendToBack();
                lvl6Box.SendToBack();
                lvl7Box.SendToBack();
                lvl8Box.SendToBack();
                lvl9Box.SendToBack();
                lvl10Box.SendToBack();
            }
        }

        private void editScreenToggle(bool onOff)
        {
            //turning on/off
            firstNameEdit.Visible = onOff;
            firstNameEditLabel.Visible = onOff;
            lastNameEdit.Visible = onOff;
            lastNameEditLabel.Visible = onOff;
            usernameEdit.Visible = onOff;
            usernameEditLabel.Visible = onOff;
            schoolEdit.Visible = onOff;
            schoolEditLabel.Visible = onOff;
            majorEdit.Visible = onOff;
            majorEditLabel.Visible = onOff;
            tutorEdit.Visible = onOff;
            tutorEditLabel.Visible = onOff;
            resetProgressButton.Visible = onOff;
            saveEditsButton.Visible = onOff;

            // if the objects are turning on (true)
            // then bring everything to the front
            if (onOff == true)
            {
                firstNameEditLabel.BringToFront();
                lastNameEditLabel.BringToFront();
                usernameEditLabel.BringToFront();
                schoolEditLabel.BringToFront();
                majorEditLabel.BringToFront();
                tutorEditLabel.BringToFront();

                firstNameEdit.BringToFront();
                lastNameEdit.BringToFront();
                usernameEdit.BringToFront();
                schoolEdit.BringToFront();
                majorEdit.BringToFront();
                tutorEdit.BringToFront();
                resetProgressButton.BringToFront();
                saveEditsButton.BringToFront();
            }

            // else if the objects are turning off (false)
            // then send everything to the back
            else if (onOff == false)
            {
                firstNameEdit.SendToBack();
                firstNameEditLabel.SendToBack();
                lastNameEdit.SendToBack();
                lastNameEditLabel.SendToBack();
                usernameEdit.SendToBack();
                usernameEditLabel.SendToBack();
                schoolEdit.SendToBack();
                schoolEditLabel.SendToBack();
                majorEdit.SendToBack();
                majorEditLabel.SendToBack();
                tutorEdit.SendToBack();
                tutorEditLabel.SendToBack();
                resetProgressButton.SendToBack();
                saveEditsButton.SendToBack();
            }

        }
        // settings for the progress bar to turn green and gold
        private void progressAmount(string value)
        {

            if (value == "0")
            {
                lvl1Box.BackColor = Color.Snow;
                lvl2Box.BackColor = Color.Snow;
                lvl3Box.BackColor = Color.Snow;
                lvl4Box.BackColor = Color.Snow;
                lvl5Box.BackColor = Color.Snow;
                lvl6Box.BackColor = Color.Snow;
                lvl7Box.BackColor = Color.Snow;
                lvl8Box.BackColor = Color.Snow;
                lvl9Box.BackColor = Color.Snow;
                lvl10Box.BackColor = Color.Snow;
                
            }

            if (value == "1")
                lvl1Box.BackColor = Color.LimeGreen;

            if (value == "2")
                lvl2Box.BackColor = Color.LimeGreen;

            if (value == "3")
                lvl3Box.BackColor = Color.LimeGreen;

            if (value == "4")
                lvl4Box.BackColor = Color.LimeGreen;

            if (value == "5")
                lvl5Box.BackColor = Color.LimeGreen;

            if (value == "6")
                lvl6Box.BackColor = Color.LimeGreen;

            if (value == "7")
                lvl7Box.BackColor = Color.LimeGreen;

            if (value == "8")
                lvl8Box.BackColor = Color.LimeGreen;

            if (value == "9")
                lvl9Box.BackColor = Color.LimeGreen;

            if (value == "10")
            {
                lvl10Box.BackColor = Color.LimeGreen;
            }
            if (value == "11")
            {
                lvl1Box.BackColor = Color.Goldenrod;
                lvl2Box.BackColor = Color.Goldenrod;
                lvl3Box.BackColor = Color.Goldenrod;
                lvl4Box.BackColor = Color.Goldenrod;
                lvl5Box.BackColor = Color.Goldenrod;
                lvl6Box.BackColor = Color.Goldenrod;
                lvl7Box.BackColor = Color.Goldenrod;
                lvl8Box.BackColor = Color.Goldenrod;
                lvl9Box.BackColor = Color.Goldenrod;
                lvl10Box.BackColor = Color.Goldenrod;
                
            }
        }

        private async void showcaseLoop()
        {
            for (int i = 0; i<=24; i++)
            {
                if (i==0 || i == 12 || i == 24) { progressAmount("0");  await Task.Delay(750); }
                else if (i == 1 || i == 13) { progressAmount("1"); await Task.Delay(750); }
                else if (i == 2 || i == 14) { progressAmount("2"); await Task.Delay(750); }
                else if (i == 3 || i == 15) { progressAmount("3"); await Task.Delay(750); }
                else if (i == 4 || i == 16) { progressAmount("4"); await Task.Delay(750); }
                else if (i == 5 || i == 17) { progressAmount("5"); await Task.Delay(750); }
                else if (i == 6 || i == 18) { progressAmount("6"); await Task.Delay(750); }
                else if (i == 7 || i == 19) { progressAmount("7"); await Task.Delay(750); }
                else if (i == 8 || i == 20) { progressAmount("8"); await Task.Delay(750); }
                else if (i == 9 || i == 21) { progressAmount("9"); await Task.Delay(750); }
                else if (i == 10 || i == 22) { progressAmount("10"); await Task.Delay(750); }
                else if (i == 11 || i == 23) { progressAmount("11"); await Task.Delay(750); }
                
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        // form loading sequence
        private void Form1_Load(object sender, EventArgs e)
        {
            try // see if the user has a profile, if so read it...
            {
                StreamReader inputFile;
                string line;

                Profile textElement = new Profile(); // using the structure Profile for user's info
                inputFile = File.OpenText("CS_DataStructuresProfile.txt");
                while (!inputFile.EndOfStream)
                {
                    line = inputFile.ReadLine();
                    string[] element = line.Split(','); // splits it's items at commas and puts it into
                                                        // an array form
                    textElement.firstName = element[0];
                    textElement.lastName = element[1];
                    textElement.username = element[2];
                    textElement.school = element[3];
                    textElement.major = element[4];
                    textElement.tutor = element[5];
                    textElement.progressValue = element[6];
                }
                inputFile.Close();

                // after the profile is loaded, the message will confirm
                // and clear the welcome screen elements, then shows the
                // main menu
                welcomeMenuToggle(false);
                mainMenuToggle(true);
                welcomeMsgProfile(textElement.username);
                infoBoxBack1.Text = " ";
                infoBoxBack2.Text = " ";

                // Debug pruposes:
                //MessageBox.Show("Profile Logged In");

                // if the file says the tutorial is not shown, then set it to false
                // otherwise, set it to true
                if (textElement.tutor == "Disabled")
                {
                    tutorBoxToggle(false);
                    profileTabToggle(true);
                    tabInfoHeader(profileTab.Text);
                }

                else if (textElement.tutor == "Enabled")
                {
                    tutorBoxToggle(true);
                    tabInfoHeader("Tutorial");
                }


            }
            catch  // otherwise, ask the user to make a profile
            {
                welcomeMenuToggle(true);
                mainMenuToggle(false);
                MessageBox.Show("Please create your profile to get started.");
            }
        }

        private void profileCreator_button_Click(object sender, EventArgs e)
        {

            // parsing all input values to validate input

            if (string.IsNullOrEmpty(firstNameInput.Text) ||
                string.IsNullOrEmpty(lastNameInput.Text) ||
                string.IsNullOrEmpty(ProTitleInput.Text) ||
                string.IsNullOrEmpty(CampusInput.Text) ||
                string.IsNullOrEmpty(MajorInput.Text))
            {
                MessageBox.Show("ERROR: One or more inputs are blank.");
            }

            else
            {
                try
                {
                    StreamWriter output_file;
                    output_file = File.CreateText("CS_DataStructuresProfile.txt");
                    output_file.WriteLine(firstNameInput.Text + ',' + lastNameInput.Text + ','
                                          + ProTitleInput.Text + ',' + CampusInput.Text + ','
                                          + MajorInput.Text + ",Enabled" + ",0");
                    output_file.Close();

                    // tell the user thier profile is created and clear the welcome screen elements
                    welcomeMenuToggle(false);
                    mainMenuToggle(true);
                    welcomeMsgProfile(ProTitleInput.Text);
                    infoBoxBack1.Text = " ";
                    infoBoxBack2.Text = " ";
                    tutorBoxToggle(true);
                    MessageBox.Show("Profile Creation Successful");
                }
                catch
                {
                    MessageBox.Show("ERROR: Profile Creation Unsuccessful");
                }
            }
        }

        private void tutorCheck_CheckedChanged(object sender, EventArgs e)
        {       
                if (tutorCheck.Checked)
                    writeToExFile( 6, "Disabled");
                else
                    writeToExFile( 6, "Enabled");
        }

        private void profileTab_Click(object sender, EventArgs e)
        {
            tabInfoHeader(profileTab.Text);
            tutorBoxToggle(false);
            infoBox(true);
            infoBoxBack2.Text = " ";

            CreditsTabToggle(false);
            bugFixTabToggle(false);
            editScreenToggle(false);

            profileTabToggle(true);

            readProfileAndReturn(0);

            //showcaseLoop();
        }

        private void creditsTab_Click(object sender, EventArgs e)
        {
            tabInfoHeader(creditsTab.Text);
            tutorBoxToggle(false);
            infoBox(true);
            infoBoxBack2.Text = " ";

            bugFixTabToggle(false);
            profileTabToggle(false);
            editScreenToggle(false);


            CreditsTabToggle(true);
        }

        private void bugFixTab_Click(object sender, EventArgs e)
        {
            tabInfoHeader(bugFixTab.Text);
            tutorBoxToggle(false);
            infoBox(true);
            infoBoxBack2.Text = " ";

            CreditsTabToggle(false);
            profileTabToggle(false);
            editScreenToggle(false);

            bugFixTabToggle(true);
        }

        private void mathTab_Click(object sender, EventArgs e)
        {
            tabInfoHeader(mathTab.Text);
            tutorBoxToggle(false);
            infoBox(true);
            infoBoxBack2.Text = "     Here is some math info: ";
            
            CreditsTabToggle(false);
            bugFixTabToggle(false);
            profileTabToggle(false);
            editScreenToggle(false);

        }

        private void structTab_Click(object sender, EventArgs e)
        {
            tabInfoHeader(structTab.Text);
            tutorBoxToggle(false);
            infoBox(true);
            infoBoxBack2.Text = "     Here is some structures info: ";

            bugFixTabToggle(false);
            CreditsTabToggle(false);
            profileTabToggle(false);
            editScreenToggle(false);

        }

        private void tricksTab_Click(object sender, EventArgs e)
        {
            tabInfoHeader(tricksTab.Text);
            tutorBoxToggle(false);
            infoBox(true);
            infoBoxBack2.Text = "      Here is some tricks info: ";
            
            CreditsTabToggle(false);
            bugFixTabToggle(false);
            profileTabToggle(false);
            editScreenToggle(false);

        }


        private void saveEditsButton_Click(object sender, EventArgs e)
        {
            string tutorEnable;


            if (string.IsNullOrEmpty(firstNameEdit.Text) ||
                string.IsNullOrEmpty(lastNameEdit.Text) ||
                string.IsNullOrEmpty(usernameEdit.Text) ||
                string.IsNullOrEmpty(schoolEdit.Text) ||
                string.IsNullOrEmpty(majorEdit.Text))
            {
                MessageBox.Show("ERROR: One or more inputs are blank.");
            }
            else
            {
                if (tutorEdit.Checked)
                    tutorEnable = "Enabled";
                else
                    tutorEnable = "Disabled";
                
                
                StreamWriter output_file;
                output_file = File.CreateText("CS_DataStructuresProfile.txt");
                output_file.WriteLine(firstNameEdit.Text + ',' + lastNameEdit.Text + ','
                                      + usernameEdit.Text + ',' + schoolEdit.Text + ','
                                      + majorEdit.Text + "," + tutorEnable + ",0");
                output_file.Close();

                readProfileAndReturn(0);

                editScreenToggle(false);
                profileTabToggle(true);

                MessageBox.Show("Edits have successfully saved.");

            }
        }

        private void resetProgressButton_Click(object sender, EventArgs e)
        {
            // needs another form to confirm resetting the progress

            Confirm newConfirm = new Confirm();

            newConfirm.ShowDialog();

            int numberPassed = newConfirm.numberBring;
            bool buttonPress = newConfirm.buttonPress;

            if (numberPassed == 1 && buttonPress == true)
            {
                writeToExFile(7, "0");
                MessageBox.Show("Progress has been erased");
            }
            else if (numberPassed == 0 && buttonPress == false)
            { MessageBox.Show("Cancelled progress reset"); }


            Console.WriteLine("Debugging resetButton once clicked: \nLog:\n");
            Console.WriteLine("buttonPress = " + buttonPress + " \n");
            Console.WriteLine("Number Passing = " + numberPassed + " \n");
        }

        private void editProfileButton_Click(object sender, EventArgs e)
        {
            CreditsTabToggle(false);
            bugFixTabToggle(false);
            profileTabToggle(false);


            editScreenToggle(true);

            
        }

        private void Tutor_Tab_Click(object sender, EventArgs e)
        {
            tabInfoHeader(Tutor_Tab.Text);
            CreditsTabToggle(false);
            bugFixTabToggle(false);
            profileTabToggle(false);
            editScreenToggle(false);

            tutorBoxToggle(true);
        }
    }    
}
