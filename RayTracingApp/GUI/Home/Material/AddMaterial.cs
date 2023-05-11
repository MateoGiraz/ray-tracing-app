﻿using Controller;
using Controller.Exceptions;
using Domain;
using Domain.Exceptions;
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
    public partial class AddMaterial : UserControl
    {
        private const string NamePlaceholder = "Name";
        private const string RedPlaceholder = "Red";
        private const string GreenPlaceholder = "Green";
        private const string BluePlaceholder = "Blue";
        private const string ColorInputErrorMessage = "Color must be a number between 0 and 255";
        
        private MaterialController _materialController;
        private Client _currentClient;

        private MaterialHome _materialHome;
        
        public AddMaterial(MaterialHome materialHome, MaterialController materialController, Client currentClient)
        {
            _materialHome = materialHome;
            _materialController = materialController;
            _currentClient = currentClient;
            InitializeComponent();
        }

        private void AddNewMaterial()
        {
            Color newColor;

            try
            {
                newColor = CreateColor();
            }
            catch (InvalidMaterialInputException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            try
            {
                string Name = txtInputName.Text;
                Material newMaterial = CreateMaterial(newColor, Name);
                
                _materialController.AddMaterial(newMaterial, _currentClient.Username);
                _materialHome.GoToMaterialList();

                ResetPlaceholders();
            }
            catch (InvalidMaterialInputException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private static Material CreateMaterial(Color newColor, string Name)
        {
            return new Material()
            {
                Name = Name,
                Color = newColor
            };
        }

        private Color CreateColor()
        {
            try
            {
                int red = Int32.Parse(txtInputRed.Text);
                int green = Int32.Parse(txtInputGreen.Text);
                int blue = Int32.Parse(txtInputBlue.Text);

                return CreateColorInstance(red, green, blue);
            }
            catch (Exception ex) when (ex is InvalidColorNumberException || ex is FormatException)
            {
                throw new InvalidMaterialInputException(ColorInputErrorMessage);
            }

        }

        private static Color CreateColorInstance(int red, int green, int blue)
        {
            return new Color()
            {
                Red = red,
                Green = green,
                Blue = blue
            };
        }
        private void ReplaceFontColor()
        {
            Color currentColor;

            try
            {
                currentColor = CreateColor();
            }
            catch (InvalidMaterialInputException)
            {
                currentColor = new Color()
                {
                    Red = 30,
                    Green = 30,
                    Blue = 30,
                };
            }

            int red = currentColor.Red;
            int green = currentColor.Green;
            int blue = currentColor.Blue;

            lblColor.ForeColor = System.Drawing.Color.FromArgb(red, green, blue);
        }

        private void picRectangleFieldSave_Click(object sender, EventArgs e)
        {
            AddNewMaterial();
        }

        private void lblSave_Click(object sender, EventArgs e)
        {
            AddNewMaterial();
        }

        private void ResetPlaceholders()
        {
            InputUtils.ResetPlaceholder(ref txtInputName, NamePlaceholder);
            InputUtils.ResetPlaceholder(ref txtInputRed, RedPlaceholder);
            InputUtils.ResetPlaceholder(ref txtInputGreen, GreenPlaceholder);
            InputUtils.ResetPlaceholder(ref txtInputBlue, BluePlaceholder);

        }

        private void picRectangleFieldCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void Cancel()
        {
            ResetPlaceholders();
            _materialHome.GoToMaterialList();
        }

        private void txtInputName_Enter(object sender, EventArgs e)
        {
            InputUtils.RemovePlaceHolder(ref txtInputName, NamePlaceholder);
        }

        private void txtInputName_Leave(object sender, EventArgs e)
        {
            InputUtils.SetPlaceHolder(ref txtInputName, NamePlaceholder);
        }

        private void txtInputRed_Enter(object sender, EventArgs e)
        {
            InputUtils.RemovePlaceHolder(ref txtInputRed, RedPlaceholder);
        }

        private void txtInputRed_Leave(object sender, EventArgs e)
        {
            InputUtils.SetPlaceHolder(ref txtInputRed, RedPlaceholder);
        }

        private void txtInputGreen_Enter(object sender, EventArgs e)
        {
            InputUtils.RemovePlaceHolder(ref txtInputGreen, GreenPlaceholder);
        }

        private void txtInputGreen_Leave(object sender, EventArgs e)
        {
            InputUtils.SetPlaceHolder(ref txtInputGreen, GreenPlaceholder);
        }

        private void txtInputBlue_Enter(object sender, EventArgs e)
        {
            InputUtils.RemovePlaceHolder(ref txtInputBlue, BluePlaceholder);
        }

        private void txtInputBlue_Leave(object sender, EventArgs e)
        {
            InputUtils.SetPlaceHolder(ref txtInputBlue, BluePlaceholder);
        }

        private void txtInputRed_TextChanged(object sender, EventArgs e)
        {
            ReplaceFontColor();
        }

        private void txtInputGreen_TextChanged(object sender, EventArgs e)
        {
            ReplaceFontColor();
        }

        private void txtInputBlue_TextChanged(object sender, EventArgs e)
        {
            ReplaceFontColor();
        }


    }
}
