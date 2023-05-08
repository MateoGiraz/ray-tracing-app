﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Engine;

namespace Test.EngineTest
{
    [TestClass]
    public class CameraTest
    {
        [TestMethod]
        public void CanCreateCamera_OkTest()
        {
            Vector newVector = new Vector()
            {
                X = 10,
                Y = 20,
                Z = 30
            };

            int fieldOfView = 10;
            double aspectRatio = 10;

            Camera camera = new Camera(newVector, newVector, newVector, fieldOfView, aspectRatio);
        }

        [TestMethod]
        public void CanGetRay_OkTest()
        {
            Vector newVector = new Vector()
            {
                X = 10,
                Y = 20,
                Z = 30
            };

            int fieldOfView = 10;
            double aspectRatio = 10;

            Camera camera = new Camera(newVector, newVector, newVector, fieldOfView, aspectRatio);

            Vector horizontalPosition = newVector.Multiply(1);
            Vector verticalPosition = newVector.Multiply(2);

            Vector pointPosition = newVector.Add(horizontalPosition.Add(verticalPosition));

            Ray newRay = new Ray()
            {
                Origin = newVector,
                Direction = pointPosition.Substract(newVector)
            };

            Ray cameraRay = camera.GetRay(1, 2);

            Assert.AreEqual(newRay.Origin, cameraRay.Origin);
            Assert.AreEqual(newRay.Direction, cameraRay.Direction);

        }


    }
}
