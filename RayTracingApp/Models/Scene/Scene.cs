﻿using System;
using System.Collections.Generic;
using System.Linq;
using Models.SceneExceptions;

namespace Models
{
    public class Scene
    {
        private const string EmptyNameMessage = "Scene's name must not be empty";
        private const string SpaceCharacterConstant = " ";
        private const string StartOrEndWithSpaceMessage = "Scene's name must not start or end with blank space";
        private const int MinFov = 1;
        private const int MaxFov = 160;
        private string _owner;
        private string _name;
        public string _registerTime = DateTime.Now.ToString("hh:mm:ss - dd/MM/yyyy");
        private string _lastModificationDate = "unmodified";
        private string _lastRenderDate = "unrendered";
        private int _fov = 30;
        private Coordinate _cameraPosition = new Coordinate() { X = 0, Y = 2, Z = 0 };
        private Coordinate _objectivePosition = new Coordinate() { X = 0, Y = 2, Z = 5 };
        private List<PosisionatedModel> _posisionatedModels;
        public string Owner
        {
            get => _owner;
            set => _owner = value;
        }
        public string Name
        {
            get => _name;
            set
            {
                try
                {
                    RunNameIsEmptyChecker(value);
                    RunNameIsSpacedChecker(value);
                    _name = value;
                }
                catch (InvalidSceneInputException ex)
                {
                    throw new InvalidSceneInputException(ex.Message);
                }
            }
        }
        public string RegisterTime
        {
            get => _registerTime;
            set => _registerTime = DateTime.Now.ToString("hh:mm:ss - dd/MM/yyyy");
        }
        public string LastModificationDate
        {
            get => _lastModificationDate;
            set => _lastModificationDate = value;
        }
        public string LastRenderDate
        {
            get => _lastRenderDate;
            set => _lastRenderDate = value;
        }
        public int Fov
        {
            get => _fov;
            set
            {
                try
                {
                    RunFovIsValidChecker(value);
                    _fov = value;
                }
                catch (InvalidSceneInputException ex)
                {
                    throw new InvalidSceneInputException(ex.Message);
                }
            }
        }
        public Coordinate CameraPosition
        {
            get => _cameraPosition;
            set => _cameraPosition = value;
        }
        public Coordinate ObjectivePosition
        {
            get => _objectivePosition;
            set => _objectivePosition = value;
        }
        public List<PosisionatedModel> PosisionatedModels
        {
            get => _posisionatedModels;
            set => _posisionatedModels = value;
        }

        private static void RunNameIsEmptyChecker(string value)
        {
            if (value.Equals(string.Empty))
            {
                throw new EmptyNameException(EmptyNameMessage);
            }
        }

        private static void RunNameIsSpacedChecker(string value)
        {
            if (value.StartsWith(SpaceCharacterConstant) || value.EndsWith(SpaceCharacterConstant))
            {
                throw new InvalidSpacePositionException(StartOrEndWithSpaceMessage);
            }
        }

        private static void RunFovIsValidChecker(int value)
        {
            if (!Enumerable.Range(MinFov, MaxFov).Contains(value))
            {
                throw new InvalidFovException($"Scene's fov must be between {MinFov} and {MaxFov}");
            }
        }
    }
}
