﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Controller;
using Models;

namespace Test.ControllerTest
{
    [TestClass]
    public class SceneControllerTest
    {
        [TestMethod]
        public void CreateSceneController_OkTest()
        {
            SceneController sceneController = new SceneController(); 
        }

        [TestMethod]
        public void AddScene_OkTest()
        {
            SceneController sceneController = new SceneController();
            Scene newScene = new Scene()
            {
                Owner = "ownerName"
            };

            sceneController.AddScene(newScene);

            CollectionAssert.Contains(sceneController.GetScenesByClient("ownerName"), newScene);
        }
    }
}
