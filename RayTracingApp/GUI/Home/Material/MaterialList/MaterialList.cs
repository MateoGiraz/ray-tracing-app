﻿using Controller;
using MemoryRepository.Exceptions;
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
    public partial class MaterialList : UserControl
    {
        private MaterialHome _materialHome;

        private MaterialController _materialController;
        private MainController _mainController;

        private Client _currentClient;
        public MaterialList(MaterialHome materialHome, MainController mainController, Client currentClient)
        {
            _mainController = mainController;
            _materialController = mainController.MaterialController;

            _currentClient = currentClient;
            _materialHome = materialHome;
            
            InitializeComponent();
        }


        private void MaterialList_Paint(object sender, PaintEventArgs e)
        {
            PopulateItems();
        }

        public void PopulateItems()
        {

            List<Material> materials;

            try
            {
                materials = _materialController.ListMaterials(_currentClient.Username);
            }
            catch (NotFoundMaterialException)
            {
                return;
            }

            flyMaterialList.Controls.Clear();

            foreach (Material material in materials)
            {
                MaterialListItem item = new MaterialListItem(_mainController, material);
                flyMaterialList.Controls.Add(item);
            }

        }

        private void picAddMaterial_Click(object sender, EventArgs e)
        {
            _materialHome.GoToAddMaterial();
        }

        private void lblAddMaterial_Click(object sender, EventArgs e)
        {
            _materialHome.GoToAddMaterial();
        }

        private void picIconPlus_Click(object sender, EventArgs e)
        {
            _materialHome.GoToAddMaterial();
        }

    }
}