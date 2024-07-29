using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Main
{
    public static class GameSettings
    {
        // Subject Test
        public static string Technique;
        public static string Person;
        public static string FileName;

        public static bool RandomMode;

        public static void PopulateModeSettings(bool randomMode)
        {
            RandomMode = randomMode;
        }
    }
}
