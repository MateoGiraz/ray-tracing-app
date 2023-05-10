﻿using Controller;
using Controller.Exceptions;
using Domain;
using Domain.Exceptions;
using Engine;
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
    public partial class ModelListItem : UserControl
    {
        private ModelController _modelController;
        private ModelList _modelList;

        private Model _model;

        private string _currentClient;
        private bool isEditing;

        public ModelListItem(ModelList modelList, ModelController modelController, Model model)
        {
            InitializeComponent();
            InitializePanelAtributes(model);
            InitializeControllers(modelList, modelController, model);
        }

        private void InitializeControllers(ModelList modelList, ModelController modelController, Model model)
        {
            _modelList = modelList;
            _modelController = modelController;
            _currentClient = model.Owner;
            _model = model;
            isEditing = false;
        }

        private void InitializePanelAtributes(Model model)
        {
            string FigureName = model.Figure.Name;
            string MaterialName = model.Material.Name;
            Color materialColor = model.Material.Color;

			Renderer renderer = new Renderer();
			renderer.RenderModelPreview(model);
			string preview = model.Preview;
            
            Scanner scanner = new Scanner();
            Bitmap image = scanner.ScanImage(preview);

            picIconSphere.Image = image;

            txtModelName.Text = model.Name;
            lblFigureName.Text = $"Figure: {FigureName}";
            lblMaterialName.Text = $"Material: {MaterialName}";

            picMaterialColor.BackColor = System.Drawing.Color.FromArgb(materialColor.Red, materialColor.Green, materialColor.Blue);
        }

        private void picIconX_Click(object sender, EventArgs e)
        {
            _modelController.RemoveModel(txtModelName.Text, _currentClient);
            _modelList.PopulateItems();
        }

        private void picIconPencilTick_Click(object sender, EventArgs e)
        {
            isEditing = !isEditing;

            if (isEditing)
            {
                picIconPencilTick.Image = GUI.Properties.Resources.tick;
                txtModelName.Enabled = true;
                picXIcon.Visible = true;
            }
            else
            {
                picIconPencilTick.Image = GUI.Properties.Resources.pencil;
                txtModelName.Enabled = false;
                picXIcon.Visible = false;
                ChangeModelName(txtModelName.Text, _model);
            }
        }

        private void picXIcon_Click(object sender, EventArgs e)
        {
            isEditing = false;
            picIconPencilTick.Image = GUI.Properties.Resources.pencil;

            txtModelName.Enabled = false;
            picXIcon.Visible = false;

            _modelList.PopulateItems();
        }

        private void ChangeModelName(string newName, Model model)
        {
            try
            {
                _modelController.UpdateModelName(model, _currentClient, newName);
                _modelList.PopulateItems();
            }
            catch (InvalidModelInputException ex)
            {
                _modelList.PopulateItems();
                MessageBox.Show(ex.Message);
            }
        }

    }
}

    