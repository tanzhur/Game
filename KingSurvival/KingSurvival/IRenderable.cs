﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival
{
    interface IRenderable
    {
       // MatrixCoords GetTopLeft();

        char[,] GetImage();
    }
}
