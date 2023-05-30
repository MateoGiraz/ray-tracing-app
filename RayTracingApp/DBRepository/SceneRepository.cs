﻿using Domain;
using MemoryRepository.Exceptions;
using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository
{
    public class SceneRepository : IRepositoryScene
    {
        private const string NotFoundSceneMessage = "Scene was not found or already deleted";
        public string DBName { get; set; } = "RayTracingAppDB";
        public void AddScene(Scene scene)
        {
            using (var context = new AppContext(DBName)) 
            {
                context.Scenes.Add(scene);
                context.SaveChanges();
            }
        }

        public List<Scene> GetScenesByClient(string username)
        {
            using (var context = new AppContext(DBName))
            {
                return context.Scenes.Where(scene => scene.Owner.Equals(username)).ToList();
            }
        }

        public void RemoveScene(Scene scene)
        {
            using (var context = new AppContext(DBName))
            { 
                Scene deleteScene = context.Scenes.FirstOrDefault(s => s.Id == scene.Id);

                if (deleteScene is null)
                {
                    throw new NotFoundSceneException(NotFoundSceneMessage);
                }

                context.Scenes.Remove(deleteScene);
                context.SaveChanges();
            }
        }
    }
}