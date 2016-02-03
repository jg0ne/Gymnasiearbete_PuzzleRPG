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
    class GameObject
    {
        public enum Direction {  Up = 0, Down = 1, Left = 2, Right = 3 }

        Direction direction;

        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle Hitbox { get; set; }

        public GameObject(Texture2D texture, Vector2 position)
        {
            this.Texture = texture;
            this.Position = position;
        }

        public GameObject(Texture2D texture, Rectangle hitbox)
        {
            this.Texture = texture;
            this.Hitbox = hitbox;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Position * 32, Color.White);
        }
    }
}
