﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public interface ICommandManager
    {
        void Execute(string input);
        string GetOutput();
    }
}
