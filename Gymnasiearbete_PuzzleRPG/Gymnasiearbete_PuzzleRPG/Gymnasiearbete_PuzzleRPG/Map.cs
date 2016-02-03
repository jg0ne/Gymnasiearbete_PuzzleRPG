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
        public List<int> tmp;
        
        public static void Initialize(ContentManager content)
        {
            map1 = new Tile[20, 12];
            for(int i = 0; i < map1.GetLength(0); i++)
            {
                for (int j = 0; j < map1.GetLength(1); j++)
                {
                    if (Globals.Randomizer.Next(100) <= 90) { map1[i, j] = new Tile(TextureManager.block, Tile.Type.Ground, new Rectangle(0, 0, 32, 32), 0, false); }
                    else { map1[i, j] = new Tile(TextureManager.block, Tile.Type.Bomb, new Rectangle(0, 0, 32, 32), 0, false); }
                    map1[i, j].Hitbox = new Rectangle(i * 32, j * 32, 32, 32);
                }
            }

            for (int i = 0; i < map1.GetLength(0); i++)
            {
                for (int j = 0; j < map1.GetLength(1); j++)
                {
                    for (int k = -1; k < 2; k++)
                    {
                        for (int l = -1; l < 2; l++)
                        {
                            if (i + k >= 0 && i + k < map1.GetLength(0) && j + l >= 0 && j + l < map1.GetLength(1) && map1[i + k, j + l].type == Tile.Type.Bomb)
                            {
                                map1[i, j].AdjacentBombs++;
                            }
                        }
                    }
                }
            }
        }

        public static void Update()
        {

        }

        public static void CheckTile(Vector2 position)
        {
            List<Point> tilesToCheck = new List<Point>();
            tilesToCheck.Add(new Point((int)position.X, (int)position.Y));
            for (int i = 0; i < tilesToCheck.Count; i++)
            {
                map1[(int)tilesToCheck[i].X, (int)tilesToCheck[i].Y].Texture = TextureManager.ground;

                if (map1[(int)tilesToCheck[i].X, (int)tilesToCheck[i].Y].AdjacentBombs == 0)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        for (int k = -1; k < 2; k++)
                        {
                            if ((int)tilesToCheck[i].X + j >= 0 && (int)tilesToCheck[i].X + j < 20 && (int)tilesToCheck[i].Y + k >= 0 && (int)tilesToCheck[i].Y + k < 12 && map1[(int)tilesToCheck[i].X + j, (int)tilesToCheck[i].Y + k].Texture != TextureManager.ground && map1[(int)tilesToCheck[i].X + j, (int)tilesToCheck[i].Y + k].IsFlag == false && !tilesToCheck.Any(item => item == new Point((int)tilesToCheck[i].X + j, (int)tilesToCheck[i].Y + k)))
                            {
                                tilesToCheck.Add(new Point((int)tilesToCheck[i].X + j, (int)tilesToCheck[i].Y + k));
                            }
                        }
                    }
                }

            }


        }

        public static void Draw(SpriteBatch spritebatch)
        {
            for (int i = 0; i < map1.GetLength(0); i++)
            {
                for (int j = 0; j < map1.GetLength(1); j++)
                {
                    if (map1[i, j].Texture == TextureManager.ground && map1[i, j].AdjacentBombs > 0)
                    {
                        spritebatch.Draw(map1[i, j].Texture, new Vector2(i * 32, j * 32), Color.Gray);
                    }
                    else
                    {
                        spritebatch.Draw(map1[i, j].Texture, new Vector2(i * 32, j * 32), Color.White);
                    }
                    if (map1[i, j].Texture == TextureManager.ground && map1[i, j].AdjacentBombs > 0)
                    {
                        spritebatch.DrawString(TextureManager.font1, map1[i, j].AdjacentBombs.ToString(), new Vector2(i * 32, j * 32), Color.Black);
                    }
                }
            }
        }
    }
}
