﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRepository;
using Model;

namespace MemoryRepository
{
    public class FigureRepository
    {
        List<Figure> _figureList;

        public FigureRepository()
        {
            _figureList = new List<Figure>();
        }
    }
}
