using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Gymnasiearbete_PuzzleRPG
{
    class Globals
    {
        public static Random Randomizer;
        public static KeyboardState ks;
        public static KeyboardState prevKs;
        public static List<Flag> flags;

        public static void Initialize()
        {
            Randomizer = new Random();
            ks = Keyboard.GetState();
            flags = new List<Flag>();
        }

        public static void Update()
        {
            prevKs = ks;
            ks = Keyboard.GetState();
        }
    }
}
