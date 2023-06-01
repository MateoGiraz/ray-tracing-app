﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Engine.Exporter;
using System.Drawing;
using System.IO;
using Engine.Exceptions;


namespace Test.EngineTest
{
    [TestClass]
    public class ExporterTest
    {
        [TestMethod]
        public void CanCreateJPGExporter_OkTest()
        {
            IExporter exporter = new JPGExporter();
        }

        [TestMethod]
        public void CanExport_JPGExporter_OkTest()
        {
            IExporter exporter = new JPGExporter();
            
            string testPath = Path.Combine(Directory.GetCurrentDirectory(), "image.jpg");
            Image testImage = new Bitmap(800, 600);

            exporter.Export(testPath, testImage);
        }

        [TestMethod]
        [ExpectedException(typeof(ExporterException))]
        public void CanExport_JPGExporter_FailTest()
        {
            IExporter exporter = new JPGExporter();
            Image testImage = new Bitmap(800, 600);

            exporter.Export("", testImage);
        }

        [TestMethod]
        public void CanCreatePNGExporter_OkTest()
        {
            IExporter exporter = new PNGExporter();
        }

        [TestMethod]
        public void CanExport_PNGExporter_OkTest()
        {
            IExporter exporter = new PNGExporter();

            string testPath = Path.Combine(Directory.GetCurrentDirectory(), "image.jpg");
            Image testImage = new Bitmap(800, 600);

            exporter.Export(testPath, testImage);
        }
    }
}
