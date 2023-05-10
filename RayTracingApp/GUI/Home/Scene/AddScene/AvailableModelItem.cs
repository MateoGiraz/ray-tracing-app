﻿using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Color = Domain.Color;

namespace GUI
{
    public partial class AvailableModelItem : UserControl
    {
        private List<PosisionatedModel> _posisionatedModels;
        private Model _model;
        private ScenePage _scenePage;

        public AvailableModelItem(ScenePage scenePage, Model model, List<PosisionatedModel> posisionatedModels)
        {
            IntitializeAttributes(scenePage, model, posisionatedModels);
            InitializeComponent();
            InitializePanelAttributes(model);
        }

        private void IntitializeAttributes(ScenePage scenePage, Model model, List<PosisionatedModel> posisionatedModels)
        {
            _posisionatedModels = posisionatedModels;
            _model = model;
            _scenePage = scenePage;
        }

        private void InitializePanelAttributes(Model model)
        {
            lblModelName.Text = model.Name;
            Color modelColor = model.Material.Color;
            picModelColor.BackColor = System.Drawing.Color.FromArgb(modelColor.Red, modelColor.Green, modelColor.Blue);
        }

        private void picAddButton_Click(object sender, EventArgs e)
        {
            PosisionatedModel posisionatedModel = new PosisionatedModel()
            {
                Model = _model,
                Position = new Vector() { X = 0, Y = 0, Z = 0 },
            };

            _posisionatedModels.Add(posisionatedModel);
            _scenePage.PopulateUsedItems();
            _scenePage.ShowWarning();
        }
    }
}
