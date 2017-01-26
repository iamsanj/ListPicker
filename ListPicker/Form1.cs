using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Diagnostics;

namespace ListPicker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Users = File.ReadAllText("Users.txt");
            string Options = File.ReadAllText("Options.txt");
            string UserOption = "";

            string[] splitUsers = Users.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            string[] splitOptions = Options.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            ArrayList listOptions = new ArrayList();
            foreach (string option in splitOptions)
            {
                listOptions.Add(option);
            }

            Random rnd = new Random();
            foreach (string user in splitUsers)
            {
                if (user != "")
                {
                    int random = rnd.Next(0, listOptions.Count - 1);
                    UserOption = UserOption + user + "=" + listOptions[random] + Environment.NewLine;
                    listOptions.RemoveAt(random);
                }
            }

            File.WriteAllText("Results.txt", UserOption.Trim());
            Process.Start("Results.txt");
        }
    }
}
