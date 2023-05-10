﻿using MemoryRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Controller;

namespace Test.MemoryRepositoryTest
{
	[TestClass]
	[ExcludeFromCodeCoverage]
	public class SceneRepositoryTest
	{
		private SceneRepository _sceneRepository;
		private string _owner;
		private int _fov;
		private Vector _lookFrom;
		private Vector _looktTo;

		[TestInitialize]
		public void TestInitialize()
		{
			_owner = "ownerName";
			_fov = 70;
			_lookFrom = new Vector() { X = 1, Y = 0, Z = 1 };
			_looktTo = new Vector() { X = 0, Y = 2, Z = 1 };
		}

		[TestMethod]
		public void CreateSceneRepository_OkTest()
		{
			_sceneRepository = new SceneRepository();
		}

		[TestMethod]
		public void GetScenesByClient_OwnerName_OkTest()
		{
			_sceneRepository = new SceneRepository();

			Scene _scene = new Scene(_owner, _fov, _lookFrom, _looktTo)
			{
				Name = "Test",
				Owner = "OwnerName",
			};

			_sceneRepository.AddScene(_scene);

			List<Scene> iterable = _sceneRepository.GetScenesByClient("OwnerName");
			CollectionAssert.Contains(iterable, _scene);
		}

		[TestMethod]
		public void AddScene_OkTest()
		{
			_sceneRepository = new SceneRepository();

			Scene _scene = new Scene(_owner, _fov, _lookFrom, _looktTo)
			{
				Name = "Test",
				Owner = "OwnerName",
			};

			_sceneRepository.AddScene(_scene);

		}

		[TestMethod]
		public void AddSTwoScenes_OkTest()
		{
			_sceneRepository = new SceneRepository();

			Scene _scene = new Scene(_owner, _fov, _lookFrom, _looktTo)
			{
				Name = "Test",
				Owner = "OwnerName",
			};

			Scene _scene2 = new Scene(_owner, _fov, _lookFrom, _looktTo)
			{
				Name = "Test2",
				Owner = "OwnerName",
			};

			_sceneRepository.AddScene(_scene);
			_sceneRepository.AddScene(_scene2);

			List<Scene> iterable = _sceneRepository.GetScenesByClient("OwnerName");
			List<Scene> subSet = new List<Scene>()
			{
				_scene,
				_scene2
			};

			CollectionAssert.IsSubsetOf(subSet, iterable);
		}

		[TestMethod]
		public void AddDifferentClientScenes_OkTest()
		{
			_sceneRepository = new SceneRepository();

			Scene _scene = new Scene(_owner, _fov, _lookFrom, _looktTo)
			{
				Name = "Test",
				Owner = "OwnerName",
			};

			Scene _scene2 = new Scene(_owner, _fov, _lookFrom, _looktTo)
			{
				Name = "Test2",
				Owner = "OwnerName2",
			};

			_sceneRepository.AddScene(_scene);
			_sceneRepository.AddScene(_scene2);

			List<Scene> iterableOwner1 = _sceneRepository.GetScenesByClient("OwnerName");
			List<Scene> iterableOwner2 = _sceneRepository.GetScenesByClient("OwnerName2");

			CollectionAssert.Contains(iterableOwner1, _scene);
			CollectionAssert.Contains(iterableOwner2, _scene2);
			CollectionAssert.DoesNotContain(iterableOwner2, _scene);
			CollectionAssert.DoesNotContain(iterableOwner1, _scene2);
		}

		[TestMethod]
		public void GetScenesByClient_NoClient_OkTest()
		{
			_sceneRepository = new SceneRepository();
			List<Scene> scenes = _sceneRepository.GetScenesByClient("OwnerName");

			Assert.IsFalse(scenes.Any());
		}

		[TestMethod]
		public void DeleteScene_ExistingScene_OkTest()
		{
			_sceneRepository = new SceneRepository();

			Scene _scene = new Scene(_owner, _fov, _lookFrom, _looktTo)
			{
				Name = "Test",
				Owner = "OwnerName",
			};

			_sceneRepository.AddScene(_scene);

			_sceneRepository.RemoveScene(_scene);

			List<Scene> iterableOwner1 = _sceneRepository.GetScenesByClient("OwnerName");
			CollectionAssert.DoesNotContain(iterableOwner1, _scene);
		}
	}
}
