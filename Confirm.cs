using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_data_structuresCrashCourse
{
    
    public partial class Confirm : Form
    {
        public bool buttonPress = false;
        public int numberBring = 0;
        public Confirm()
        {
            InitializeComponent();
        }


        private void yesButton_Click(object sender, EventArgs e)
        {
            buttonPress = true;
            int i = 1;
            numberBring = i;
            Console.WriteLine("Debugging yesButton_Click: \nLog:\n");
            Console.WriteLine("buttonPress = " + buttonPress + " \n");
            Console.WriteLine("Number Passing = " + i + " \n");
            Close();
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            int i = 0;
            numberBring = i;
            Console.WriteLine("Debugging noButton_Click: \nLog:\n");
            Console.WriteLine("buttonPress = " + buttonPress + " \n");
            Console.WriteLine("Number Passing = " + i + " \n");
            Close();
        }
    }
}
