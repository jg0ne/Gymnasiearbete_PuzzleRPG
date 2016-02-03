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
    class Player : GameObject
    {
        public string Name { get; set; }
        public int Health { get; set; }
        static List<Vector2> positionToGo;

        float c = 0;

        public Player(Texture2D texture, Vector2 position, string name, int health)
            :base(texture, position)
        {
            this.Texture = texture;
            this.Position = position;
            this.Name = name;
            this.Health = health;
            positionToGo = new List<Vector2>();
            positionToGo.Add(Vector2.Zero);
        }

        public void MoveCharacter(Vector2 position)
        {            
            for (int i = 0; i < Math.Abs(position.Y - this.Position.Y); i++)
            {
                if (this.Position.Y != position.Y)
                {
                    positionToGo.Add(new Vector2(this.Position.X, this.Position.Y + ((i + 1) * ((position.Y - this.Position.Y) / Math.Abs(position.Y - this.Position.Y)))));
                }
            }

            for (int i = 0; i < Math.Abs(position.X - this.Position.X); i++)
            {
                if (this.Position.X != position.X)
                {
                    positionToGo.Add(new Vector2(this.Position.X + ((i + 1) * ((position.X - this.Position.X) / Math.Abs(position.X - this.Position.X))), this.Position.Y + (position.Y - this.Position.Y)));
                }
            }
        }

        public void Update()
        {
            if (positionToGo.Count != 0)
            {
                this.Position = positionToGo[(int)c];
                c += 0.1f;

                if ((int)c == positionToGo.Count)
                {
                    c = 0;
                    positionToGo = new List<Vector2>();
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < positionToGo.Count; i++)
            {
                spriteBatch.DrawString(Game1.textFont, "X: " + positionToGo[i].X + "Y: " + positionToGo[i].Y, new Vector2(680, i * 20), Color.Red);
            }
            base.Draw(spriteBatch);
        }
    }
}
