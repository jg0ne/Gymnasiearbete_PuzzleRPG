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
    class Map
    {

        private int mines;
        public static Tile[,] map1;

        public static void Initialize(ContentManager content)
        {
            map1 = new Tile[20, 12];
            for(int i = 0; i < map1.GetLength(0); i++)
            {
                for (int j = 0; j < map1.GetLength(1); j++)
                {
                    if (Globals.Randomizer.Next(100) <= 80) { map1[i, j] = new Tile(TextureManager.block, Tile.Type.Ground, new Rectangle(0, 0, 32, 32)); }
                    else { map1[i, j] = new Tile(TextureManager.block, Tile.Type.Bomb, new Rectangle(0, 0, 32, 32)); }
                    map1[i, j].Hitbox = new Rectangle(i * 32, j * 32, 32, 32);
                }
            }
        }

        public static void Update()
        {

        }

        public static void CheckTile(Vector2 position)
        {
            if (position.X > 0) { if (map1[(int)position.X - 1, (int)position.Y].type == Tile.Type.Ground) { map1[(int)position.X - 1, (int)position.Y].Texture = TextureManager.ground; } }
            if (position.X < map1.GetLength(0) - 1) { if (map1[(int)position.X + 1, (int)position.Y].type == Tile.Type.Ground) { map1[(int)position.X + 1, (int)position.Y].Texture = TextureManager.ground; } }
            if (position.Y > 0) { if (map1[(int)position.X, (int)position.Y - 1].type == Tile.Type.Ground) { map1[(int)position.X, (int)position.Y - 1].Texture = TextureManager.ground; } }
            if (position.Y < map1.GetLength(1) - 1) { if (map1[(int)position.X, (int)position.Y + 1].type == Tile.Type.Ground) { map1[(int)position.X, (int)position.Y + 1].Texture = TextureManager.ground; } }
        }

        public static void Draw(SpriteBatch spritebatch)
        {
            for (int i = 0; i < map1.GetLength(0); i++)
            {
                for (int j = 0; j < map1.GetLength(1); j++)
                {
                    spritebatch.Draw(map1[i, j].Texture, new Vector2(i * 32, j * 32), Color.White);
                }
            }
        }
    }
}
