﻿using Domain;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class UsedModelItem : UserControl
    {
		private const string InvalidFormatMessageError = "Vector input must be three integer values splited by coma format only: x,y,z";
		private List<PosisionatedModel> _posisionatedModels;
        private PosisionatedModel _posisionatedModel;

        private ScenePage _scenePage;
		private bool isEditing = false;

		public UsedModelItem(ScenePage scenePage, PosisionatedModel posisionatedModel, List<PosisionatedModel> posisionatedModels)
        {
            _posisionatedModels = posisionatedModels;
            _posisionatedModel = posisionatedModel;

            _scenePage = scenePage;
            
            InitializeComponent();
            
            txtPosition.Text = GetPosisionatedModelString(posisionatedModel);
            lblName.Text = posisionatedModel.Model.Name;
        }

        private string GetPosisionatedModelString(PosisionatedModel posisionatedModel)
        {
            double X = posisionatedModel.Position.X;
            double Y = posisionatedModel.Position.Y;
            double Z = posisionatedModel.Position.Z;

            return X + "," + Y + "," + Z;
        }

        private void picIconX_Click(object sender, EventArgs e)
        {
            _posisionatedModels.Remove(_posisionatedModel);
            _scenePage.PopulateUsedItems();
        }

        public void UpdatePosisionatedModel()
        {
            try
            {
                string[] positionValues = StringUtils.DestructureVectorFromat(txtPosition.Text);
                _posisionatedModel.Position = new Vector()
                {
                    X = double.Parse(positionValues[0]),
                    Y = double.Parse(positionValues[1]),
                    Z = double.Parse(positionValues[2])
                };
            }
            catch(InvalidSceneInputException ex)
            {
				MessageBox.Show(ex.Message);
			}

            _scenePage.PopulateUsedItems();
        }

		private void picIconPencilTick_Click(object sender, EventArgs e)
		{
			isEditing = !isEditing;

			if (isEditing)
			{
				picIconPencilTick.Image = GUI.Properties.Resources.tick;
				txtPosition.Enabled = true;
				picXIcon.Visible = true;
			}
			else
			{
				picIconPencilTick.Image = GUI.Properties.Resources.pencil;
				txtPosition.Enabled = true;
				picXIcon.Visible = false;
				UpdatePosisionatedModel();
			}
		}

		private void picXIcon_Click(object sender, EventArgs e)
		{
			isEditing = false;
			picIconPencilTick.Image = GUI.Properties.Resources.pencil;

			txtPosition.Enabled = false;
			picXIcon.Visible = false;

			_scenePage.PopulateUsedItems();
		}
	}
}
