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
    class SoundManager
    {
        public static SoundEffect
            track1,
            track2;

        public static void LoadContent(ContentManager content)
        {
            track1 = content.Load<SoundEffect>("PuzzleRPG_BGM01");
            track2 = content.Load<SoundEffect>("PuzzleRPG_BGM02");
        }
    }
}
