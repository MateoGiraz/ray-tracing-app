﻿using Controller;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class MainForm : Form
    {
        private UserControl _signInPanel;
        private UserControl _signUpPanel;
        private UserControl _homePanel;

        private MainController _mainController;

        public MainForm()
        {
            InitializeComponent();
            _mainController = new MainController();

            _signInPanel = new SignIn(this, _mainController.ClientController);
            _signUpPanel = new SignUp(this, _mainController.ClientController);

            flyMain.Controls.Add(_signInPanel);
        }

        public void GoToSignIn()
        {
            flyMain.Controls.Clear();
            flyMain.Controls.Add(_signInPanel);
        }

        public void GoToSignUp()
        {
            flyMain.Controls.Clear();
            flyMain.Controls.Add(_signUpPanel);
        }

        public void GoToHome(Client currentClient)
        {
            flyMain.Controls.Clear();
            _homePanel = new Home(this, _mainController, currentClient);
            flyMain.Controls.Add(_homePanel);
        }
    }
}
