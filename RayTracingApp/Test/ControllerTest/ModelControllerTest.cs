﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Controller;
using Models;
using MemoryRepository.Exceptions;
using Controller.ModelExceptions;

namespace Test.ControllerTest
{
    [TestClass]
    public class ModelControllerTest
    {
        private ModelController _modelController;

        [TestInitialize]
        public void Testinitialize()
        {
            _modelController = new ModelController();
        }

        [TestMethod]
        public void CreateModelController_OkTest()
        {
            _modelController = new ModelController();
        }

        [TestMethod]
        public void ListModels_ValidUsername_OkTest() 
        {
            _modelController = new ModelController();
            Model targetModel = new Model()
            {
                Owner = "targetOwner"
            };
            _modelController.Repository.AddModel(targetModel);

            Model anotherModel = new Model()
            {
                Owner = "otherOwner"
            };
            _modelController.Repository.AddModel(anotherModel);

            CollectionAssert.Contains(_modelController.ListModels("targetOwner"), targetModel);
            CollectionAssert.DoesNotContain(_modelController.ListModels("targetOwner"), anotherModel);
        }


        [TestMethod]
        [ExpectedException(typeof(NotFoundModelException))]
        public void ListModels_InvalidUsername_FailTest()
        {
            _modelController.ListModels("owner");
        }

        [TestMethod]
        public void AddModel_ValidModel_OkTest()
        {
            Model _newModel = new Model()
            {
                Name = "Test",
            };
            _modelController.AddModel(_newModel, "OwnerName");
            CollectionAssert.Contains(_modelController.Repository.GetModelsByClient("OwnerName"), _newModel);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidModelInputException))]
        public void AddModel_DuplicatedModel_OkTest()
        {
            Model _newModel = new Model()
            {
                Name = "Test",
            };
            _modelController.AddModel(_newModel, "user");
            _modelController.AddModel(_newModel, "user");
        }
        [TestMethod]
        public void AddModel_TwoValidModels_OkTest()
        {
            Model _fstNewModel = new Model()
            {
                Name = "Test one",
            };
            Model _sndNewModel = new Model()
            {
                Name = "Test two"
            };
            _modelController.AddModel(_fstNewModel, "user");
            _modelController.AddModel(_sndNewModel, "user");
            Assert.AreEqual(2, _modelController.Repository.GetModelsByClient("user").Count);
        }
    }
}