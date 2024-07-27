﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    internal class Data
    {
        string Name;
        string Added;
        string TriggeredAt;
        string Technique;
        string Width;
        string Amplitude;
        string Correct;
        public Data() { }
        public Data(string name, string timeTriggered, string technique, string width, string amplitude, string correct)
        {
            Name = name;
            Added = DateTime.Now.ToString();
            TriggeredAt = timeTriggered;
            Technique = technique;
            Width = width;
            Amplitude = amplitude;
            Correct = correct;
        }
    }
}
