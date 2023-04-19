﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Models;
using System.Reflection;

namespace Test.ModelsTest
{
    [TestClass]
    public class PosisionatedModelTest
    {
        [TestMethod]
        public void CreatePosisionatedModel_OkTest()
        {
            PosisionatedModel posisionatedModel = new PosisionatedModel();
        }

        [TestMethod]
        public void SetPosition_OkTest()
        {
            Coordinate newCoordinate = new Coordinate()
            {
                X = 10,
                Y = 20,
                Z = 30,
            };

            PosisionatedModel posisionatedModel = new PosisionatedModel()
            {
                Position = newCoordinate,
            };

            foreach (PropertyInfo property in newCoordinate.GetType().GetProperties())
            {
                Assert.AreEqual(property.GetValue(newCoordinate), property.GetValue(posisionatedModel.Position));
            }
        }

        [TestMethod]
        public void SetModel_OkTest()
        {
            Model newModel = new Model()
            {
                Name = "figureName",
                Owner = "ownerName"
            };

            PosisionatedModel posisionatedModel = new PosisionatedModel()
            {
                Model = newModel,
            };

            foreach (PropertyInfo property in newModel.GetType().GetProperties())
            {
                Assert.AreEqual(property.GetValue(newModel), property.GetValue(posisionatedModel.Model));
            }
        }
    }
}