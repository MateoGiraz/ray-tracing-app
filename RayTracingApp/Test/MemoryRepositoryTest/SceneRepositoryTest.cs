﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Models;
using MemoryRepository;

namespace Test.MemoryRepositoryTest
{
    [TestClass]
    public class SceneRepositoryTest
    {
        private SceneRepository _sceneRepository;

        [TestMethod]
        public void CreateSceneRepository_OkTest()
        {
            _sceneRepository = new SceneRepository();
        }

        [TestMethod]
        public void GetScenesByClient_OwnerName_OkTest()
        {
            _sceneRepository = new SceneRepository();

            Scene _scene = new Scene()
            {
                Name = "Test",
                Owner = "OwnerName",
            };

            _sceneRepository.AddScene(_scene);

            Assert.AreEqual(_scene, _sceneRepository.GetMaterialsByClient("OwnerName")[0]);
        }

    }
}