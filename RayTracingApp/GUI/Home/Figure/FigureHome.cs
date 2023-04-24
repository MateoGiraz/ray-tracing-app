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
    public partial class FigureHome : UserControl
    {
        private UserControl _addFigurePanel;
        private UserControl _figureListPanel;

        public FigureHome(FigureController figureController, Client currentClient)
        {
            InitializeComponent();
            _addFigurePanel = new AddFigure(this, figureController, currentClient);
            _figureListPanel = new FigureList(this, figureController, currentClient);
            flyFigureHome.Controls.Add(_figureListPanel);
        }

        public void GoToAddFigure()
        {
            flyFigureHome.Controls.Clear();
            flyFigureHome.Controls.Add(_addFigurePanel);
        }

        public void GoToFigureList()
        {
            flyFigureHome.Controls.Clear();
            flyFigureHome.Controls.Add(_figureListPanel);
        }

    }
}
