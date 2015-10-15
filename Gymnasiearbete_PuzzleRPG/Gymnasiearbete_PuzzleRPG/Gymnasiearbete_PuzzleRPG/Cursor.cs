﻿using System;
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
    class Cursor
    {
        public static Vector2 cursorPosition;

        public Cursor()
        {
            
        }

        public static void SetFlag(Vector2 position)
        {

        }

        public static void Update()
        {
            if (cursorPosition.X > 0) { if (Globals.ks.IsKeyDown(Keys.Left) && Globals.prevKs.IsKeyUp(Keys.Left)) { cursorPosition.X += -1; } }
            if (cursorPosition.X < Map.map1.GetLength(0) - 1) { if (Globals.ks.IsKeyDown(Keys.Right) && Globals.prevKs.IsKeyUp(Keys.Right)) { cursorPosition.X += 1; } }
            if (cursorPosition.Y > 0) { if (Globals.ks.IsKeyDown(Keys.Up) && Globals.prevKs.IsKeyUp(Keys.Up)) { cursorPosition.Y += -1; } }
            if (cursorPosition.Y < Map.map1.GetLength(1) - 1) { if (Globals.ks.IsKeyDown(Keys.Down) && Globals.prevKs.IsKeyUp(Keys.Down)) { cursorPosition.Y += 1; } }

            if (Globals.ks.IsKeyDown(Keys.Space) && Globals.prevKs.IsKeyUp(Keys.Space)) 
            { 
                if (Map.map1[(int)cursorPosition.X, (int)cursorPosition.Y].type == Tile.Type.Bomb) 
                { 
                    Map.map1[(int)cursorPosition.X, (int)cursorPosition.Y].Texture = TextureManager.bomb; 
                }

                if (Map.map1[(int)cursorPosition.X, (int)cursorPosition.Y].type == Tile.Type.Ground)
                {
                    Map.map1[(int)cursorPosition.X, (int)cursorPosition.Y].Texture = TextureManager.ground;
                    Map.CheckTile(cursorPosition);
                    Map.CheckTile(new Vector2(cursorPosition.X + 1, cursorPosition.Y));
                    Map.CheckTile(new Vector2(cursorPosition.X - 1, cursorPosition.Y));
                    Map.CheckTile(new Vector2(cursorPosition.X, cursorPosition.Y + 1));
                    Map.CheckTile(new Vector2(cursorPosition.X, cursorPosition.Y - 1));
                } 
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureManager.cursor, new Vector2(cursorPosition.X * 32, cursorPosition.Y * 32), Color.White);
        }
    }
}
