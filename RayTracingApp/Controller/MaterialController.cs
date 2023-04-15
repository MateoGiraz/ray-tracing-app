﻿using IRepository;
using MemoryRepository.MaterialRepository;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class MaterialController
    {
        public IRepositoryMaterial Repository;

        public MaterialController()
        {
            Repository = new MaterialRepository();
        }

        public void AddMaterial(Material material, string username)
        {
            if (Repository.GetMaterialsByClient(username).Find(mat => mat.Owner.Equals(username) && mat.Name.Equals(material.Name)) is object)
            {
                throw new NullReferenceException();
            }

            material.Owner = username;
            Repository.AddMaterial(material);
        }
    }
}
