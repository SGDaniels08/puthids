﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Puthids.Entities
{
    public class Puthid
    {
        public float X { get; set; }    // x position of Puthid (top-left corner)
        public float Y { get; set; }    // y position of Puthid (top-left corner)
        public float Width { get; set; }    // width of Puthid
        public float Height { get; set; }   // height of Puthid
        public float MovementSpeed { get; set; } // movement speed per frame of puthid
        public string FacingDirection { get; set; } //
        private Texture2D imgPuthid { get; set; }   // current image of Puthid
        private SpriteBatch _spriteBatch;    // allows us to write on backbuffer when we need to draw self
        private GameContent _gameContent;   
        private int FrameIndex 
        { get; set; }

        public Puthid(float x, float y, SpriteBatch spriteBatch, GameContent gameContent)
        {
            X = x;
            Y = y;
            _gameContent = gameContent;
            // Might need to take it from a List<>
            
            imgPuthid = gameContent.WalkingAnimation[0];
            Width = imgPuthid.Width;
            Height = imgPuthid.Height;
            FacingDirection = Direction.RIGHT;
            this._spriteBatch = spriteBatch;
            MovementSpeed = 3;
            FrameIndex = 0;
        }

        public void Draw()
        {
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (this.FacingDirection == Direction.RIGHT)
                spriteEffects = SpriteEffects.None;
            else if (this.FacingDirection == Direction.LEFT)
                spriteEffects = SpriteEffects.FlipHorizontally;
            if (FrameIndex > 23) FrameIndex = 0;
            imgPuthid = _gameContent.WalkingAnimation[FrameIndex];
            _spriteBatch.Draw(imgPuthid, new Vector2(X, Y), null, Color.White, 0, new Vector2(0, 0), 1.0f, spriteEffects, 0);
        }

        /* MOVEMENT */
        public void MoveLeft(Terrarium terr)
        {
            FrameIndex++;
            float oldX = X;
            float oldY = Y;
            FacingDirection = Direction.LEFT;

            X = X - MovementSpeed;
            Rectangle charRect = new Rectangle((int)X, (int)Y, (int)Width, (int)Height);
            if (charRect.Intersects(terr.LeftWall.WallRect) || charRect.Intersects(terr.RightWall.WallRect)
               || charRect.Intersects(terr.TopWall.WallRect) || charRect.Intersects(terr.BottomWall.WallRect))
            {
                X = oldX;
                Y = oldY;
            }
            foreach (ATerrain block in terr.Terrain.TGrid)
            {
                if (charRect.Intersects(block.TRect))
                {
                    X = oldX;
                    Y = oldY;
                }
            }
        }

        public void MoveRight(Terrarium terr)
        {
            FrameIndex++;

            float oldX = X;
            float oldY = Y;
            FacingDirection = Direction.RIGHT;

            X = X + MovementSpeed;
            Rectangle charRect = new Rectangle((int)X, (int)Y, (int)Width, (int)Height);
            if (charRect.Intersects(terr.LeftWall.WallRect) || charRect.Intersects(terr.RightWall.WallRect)
               || charRect.Intersects(terr.TopWall.WallRect) || charRect.Intersects(terr.BottomWall.WallRect))
            {
                X = oldX;
                Y = oldY;
            }
            foreach (ATerrain block in terr.Terrain.TGrid)
            {
                if (charRect.Intersects(block.TRect))
                {
                    X = oldX;
                    Y = oldY;
                }
            }
        }

        public void MoveUp(Terrarium terr)
        {
            FrameIndex++;

            float oldX = X;
            float oldY = Y;
            Y = Y - MovementSpeed;
            Rectangle charRect = new Rectangle((int)X, (int)Y, (int)Width, (int)Height);
            if (charRect.Intersects(terr.LeftWall.WallRect) || charRect.Intersects(terr.RightWall.WallRect)
               || charRect.Intersects(terr.TopWall.WallRect) || charRect.Intersects(terr.BottomWall.WallRect))
            {
                X = oldX;
                Y = oldY;
            }
            foreach (ATerrain block in terr.Terrain.TGrid)
            {
                if (charRect.Intersects(block.TRect))
                {
                    X = oldX;
                    Y = oldY;
                }
            }
        }

        public void MoveDown(Terrarium terr)
        {
            FrameIndex++;

            float oldX = X;
            float oldY = Y;
            Y = Y + MovementSpeed;
            Rectangle charRect = new Rectangle((int)X, (int)Y, (int)Width, (int)Height);
            if (charRect.Intersects(terr.LeftWall.WallRect) || charRect.Intersects(terr.RightWall.WallRect)
               || charRect.Intersects(terr.TopWall.WallRect) || charRect.Intersects(terr.BottomWall.WallRect))
            {
                X = oldX;
                Y = oldY;
            }
            foreach (ATerrain block in terr.Terrain.TGrid)
            {
                if (charRect.Intersects(block.TRect))
                {
                    X = oldX;
                    Y = oldY;
                }
            }
        }

        public void MoveTo(float x, float y)
        {
            
        }

        /* Other actions */
        public void Select(ATerrain block)
        {
            block.IsSelected = true;
        }



        public Puthid Reproduce(Puthid mate)
        {
            Puthid offspring = new Puthid(0, 0, _spriteBatch, _gameContent);

            return offspring;
        }
    }
}