﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Models;

namespace Test.ModelsTest.SceneTest
{
    [TestClass]

    public class SceneTest
    {
        [TestMethod]
        public void CreateScene_OkTest()
        {
            Scene newScene = new Scene();
        }
    }
}
