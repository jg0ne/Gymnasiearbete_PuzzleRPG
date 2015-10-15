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
    class Tile : GameObject
    {
        public enum Type {  Bomb = 0, Block = 1, Ground = 2}
        public Texture2D Texture;

        public Type type;

        public Tile(Texture2D texture, Type typ, Rectangle hitbox)
            :base(texture, hitbox)
        {
            this.Texture = texture;
            this.type = typ;
        }
    }
}
