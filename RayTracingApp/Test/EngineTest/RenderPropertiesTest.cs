﻿using Engine.RenderProperties;
using Engine.RenderProperties.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Test.EngineTest
{
	[TestClass]
	[ExcludeFromCodeCoverage]
	public class RenderPropertiesTest
	{
		private RenderProperties _properties;

		[TestInitialize]
		public void TestInitialize()
		{
			_properties = new RenderProperties();
		}

		[TestMethod]
		public void CreateRenderProperties_OkTest()
		{
			RenderProperties properties = new RenderProperties();
		}

		[TestMethod]
		public void SetResolutionX_OkTest()
		{
			_properties.ResolutionX = 300;

			Assert.AreEqual(300, _properties.ResolutionX);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidRenderPropertiesInputException))]
		public void SetResolutionX_LowerThanMin_FailTest()
		{
			_properties.ResolutionX = 0;
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidRenderPropertiesInputException))]
		public void SetResolutionY_LowerThanMin_FailTest()
		{
			_properties.ResolutionY = 0;
		}

		[TestMethod]
		public void DefaultResolutionX_OkTest()
		{
			Assert.AreEqual(300, _properties.ResolutionX);
		}

		[TestMethod]
		public void SetResolutionY_OkTest()
		{
			_properties.ResolutionY = 300;

			Assert.AreEqual(300, _properties.ResolutionY);
		}

		[TestMethod]
		public void DefaultResolutionY_OkTest()
		{
			Assert.AreEqual(200, _properties.ResolutionY);
		}

		[TestMethod]
		public void SetAspectRatio_OkTest()
		{
			_properties.AspectRatio = 1;

			Assert.AreEqual(1, _properties.AspectRatio);
		}

		[TestMethod]
		public void SetResolutionXNotChangeAspectRatio_OkTest()
		{
			_properties.ResolutionX = 600;

			Assert.AreEqual(400, _properties.ResolutionY);
		}

		[TestMethod]
		public void SetResolutionYNotChangeAspectRatio_OkTest()
		{
			_properties.ResolutionY = 400;

			Assert.AreEqual(600, _properties.ResolutionX);
		}
	}
}
