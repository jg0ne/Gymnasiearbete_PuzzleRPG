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
    class TextureManager
    {
        public static Texture2D
            block,
            bomb,
            ground,
            flag,
            cursor;

        public static void LoadContent(ContentManager content)
        {
            block = content.Load<Texture2D>("grass");
            bomb = content.Load<Texture2D>("bomb");
            ground = content.Load<Texture2D>("ground");
            flag = content.Load<Texture2D>("flag");
            cursor = content.Load<Texture2D>("cursor");
        }


    }
}
