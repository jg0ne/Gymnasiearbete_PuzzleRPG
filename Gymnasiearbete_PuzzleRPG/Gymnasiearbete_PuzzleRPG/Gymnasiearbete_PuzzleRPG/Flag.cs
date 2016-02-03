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
    class Flag
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public int Timer { get; set; }

        public Flag(Texture2D texture, Vector2 position, int timer)
        {
            this.Texture = texture;
            this.Position = position;
            this.Timer = timer = 100;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Position * 32, Color.White);
        }
    }
}
