﻿using Controller;
using Domain;
using Domain.Exceptions;
using Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ScenePage : UserControl
    {
        private SceneHome _sceneHome;

        private MainController _mainController;
        private ModelController _modelController;
        private SceneController _sceneController;

        private Scene _scene;
        private Client _currentClient;
        private List<PosisionatedModel> _posisionatedModels;
        
        RenderProperties _renderProperties;

        public ScenePage(Scene scene, SceneHome sceneHome, MainController mainController, Client currentClient, RenderProperties renderProperties)
        {
            _sceneHome = sceneHome;

            _mainController = mainController;
            _modelController = mainController.ModelController;
            _sceneController = mainController.SceneController;

            _currentClient = currentClient;
            _posisionatedModels = scene.PosisionatedModels;
            _renderProperties = renderProperties;

            InitializeComponent();

            _scene = scene;
            SetSceneTextAtributes();
            txtSceneName.KeyPress += new KeyPressEventHandler(CheckNameChange);

        }

        public void PopulateAvailableItems()
        {

            List<Model> models = _modelController.ListModels(_currentClient.Username);

            if (models.Any())
            {
                flyModels.BackColor = System.Drawing.Color.FromArgb(45, 45, 65);
            }

            flyModels.Controls.Clear();

            foreach (Model model in models)
            {
                AvailableModelItem item = new AvailableModelItem(this, model, _posisionatedModels);
                flyModels.Controls.Add(item);
            }

            if(_scene.Preview is object)
            {
				picScene.Image = _scene.Preview;
			}

        }

        public void PopulateUsedItems()
        {
            flyUsedModels.Controls.Clear();

            foreach (PosisionatedModel model in _posisionatedModels)
            {
                flyUsedModels.BackColor = System.Drawing.Color.FromArgb(45, 45, 65);
                UsedModelItem item = new UsedModelItem(this, model, _posisionatedModels);
                flyUsedModels.Controls.Add(item);
            }   

        }

        public void ShowWarning()
        {
            lblImageOutdated.Visible = true;
            picIconWarning.Visible = true;
        }

        private void picRender_Click(object sender, EventArgs e)
        {
            Render();
        }
		private void lblRender_Click(object sender, EventArgs e)
		{
			Render();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			Render();
		}

		private void Render()
        {
            int fov;
            Vector lookFrom;
            Vector lookAt;

            try
            {
                (fov, lookFrom, lookAt) = SceneUtils.GetCameraAtributes(txtFov, txtLookAt, txtLookFrom);
            }
            catch (InvalidSceneInputException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            try
            {
                SetSceneAtributes(fov, lookFrom, lookAt);
            }
            catch (InvalidSceneInputException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            pbrRender.Visible = true;
            lblImageOutdated.Visible = false;
            picIconWarning.Visible = false;

            Thread RenderingThread = new Thread(new ThreadStart(RenderImage));
            RenderingThread.Start();

            _sceneController.UpdateLastRenderDate(_scene);
        }

        private void RenderImage()
        {
            Renderer renderer = new Renderer()
            {
                Properties = _renderProperties,
                Scene = _scene,
            };

            string image = renderer.Render(pbrRender);

            Scanner scanner = new Scanner();
            Bitmap img = scanner.ScanImage(image);
            SetRenderedImage(img);

            ReInitialazeUI();
        }

        private void SetRenderedImage(Bitmap img)
        {
            _scene.Preview = img;
            picScene.Image = img;
        }

        private void ReInitialazeUI()
        {
            if (!RunningOnUiThread())
            {
                BeginInvoke(new Action(ReInitialazeUI));

                return;
            }

            pbrRender.Visible = false;
        }

        private bool RunningOnUiThread()
        {
            return !this.InvokeRequired;
        }

        private void SetSceneAtributes(int fov, Vector lookFrom, Vector lookAt)
        {
            try
            {
                _scene.Fov = fov;
                _scene.CameraPosition = lookFrom;
                _scene.ObjectivePosition = lookAt;
                _scene.PosisionatedModels = _posisionatedModels;
            }
            catch(InvalidSceneInputException ex)
            {
                throw new InvalidSceneInputException(ex.Message);
            }
        }

        private void picIconBack_Click(object sender, EventArgs e)
        {
            _sceneController.UpdateLastModificationDate(_scene);
            
            int fov;
            Vector lookFrom;
            Vector lookAt;

            try
            {
                (fov, lookFrom, lookAt) = SceneUtils.GetCameraAtributes(txtFov, txtLookAt, txtLookFrom);
            }
            catch (InvalidSceneInputException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            try
            {
                SetSceneAtributes(fov, lookFrom, lookAt);
            }
            catch (InvalidSceneInputException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            _sceneHome.GoToSceneList();
        }

        private void ScenePage_Paint(object sender, PaintEventArgs e)
        {
            PopulateAvailableItems();
            PopulateUsedItems();
        }

        private void SetSceneTextAtributes()
        {

            txtSceneName.Text = _scene.Name;

            Vector lookFrom = _scene.CameraPosition;
            Vector lookAt = _scene.ObjectivePosition;

            int fov = _scene.Fov;
            
            txtLookFrom.Text = StringUtils.ConstructVectorFormat(lookFrom);
            txtLookAt.Text = StringUtils.ConstructVectorFormat(lookAt);

            txtFov.Text = $"{fov}";
            
            lblLastModified.Text = $"Last Modified: {_scene.LastModificationDate}";

        }
        private void CheckNameChange(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                try
                {
                    _sceneController.UpdateSceneName(_scene, _currentClient.Username, txtSceneName.Text);
                }
                catch(InvalidSceneInputException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                ActiveControl = txtLookFrom;

                e.Handled = true;
            }
        }
	}
}
