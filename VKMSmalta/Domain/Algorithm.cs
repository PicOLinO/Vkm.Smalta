﻿using System.Collections.Generic;

namespace VKMSmalta.Domain
{
    public class Algorithm
    {
        public string Name { get; set; }
        public LinkedList<Action> Actions { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}