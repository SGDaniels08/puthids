﻿using Microsoft.Xna.Framework.Graphics;
using Puthids.Entities.Terrain;

namespace Puthids.Entities
{
    public class Terrarium
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Length { get; set; }
        public float Height { get; set; }
        public float WallThickness { get; set; }
        public HWall TopWall { get; set; }
        public HWall BottomWall { get; set; }
        public VWall LeftWall { get; set; }
        public VWall RightWall { get; set; }
        public float AirHeight { get; set; }
        public ATerrainGrid Terrain { get; set; }
        private SpriteBatch _spriteBatch;

        public Terrarium(float x, float y, float wallThickness, float airHeight, ATerrainGrid groundGrid, SpriteBatch spriteBatch)
        {
            X = x; Y = y; WallThickness = wallThickness; Length = groundGrid.Length; Height = airHeight + groundGrid.Height;
            _spriteBatch = spriteBatch;

            // Build walls based on airHeight and groundGrid dimensions
            TopWall = new HWall(X, Y, WallThickness, Terrain.Length + (2 * (WallThickness)), _spriteBatch);
            BottomWall = new HWall(X, Y + WallThickness + AirHeight + Terrain.Height, WallThickness, Terrain.Length + (2 * (WallThickness)), _spriteBatch);
            LeftWall = new VWall(X, Y, WallThickness, Terrain.Height + (2 * (WallThickness)), _spriteBatch);
            RightWall = new VWall(X + WallThickness + Terrain.Length, Y, WallThickness, Terrain.Height + (2 * (WallThickness)), _spriteBatch);

        }
        public Terrarium (float x, float y, float length, float height, float thickness, SpriteBatch spriteBatch)
        {
            X = x; Y = y; Length = length; Height = height; WallThickness = thickness;
            _spriteBatch = spriteBatch;

            TopWall = new HWall(X, Y, WallThickness, Length, _spriteBatch);
            BottomWall = new HWall(X, Y + Height - WallThickness, WallThickness, Length, _spriteBatch);
            LeftWall = new VWall(X, Y, WallThickness, Height, _spriteBatch);
            RightWall = new VWall(X + Length, Y, WallThickness, Height, _spriteBatch);

            // Build groundgrid
            float terrainStartX = (X + WallThickness);
            float terrainStartY = 215;
            int columns = 19;
            int rows = 4;
            Terrain = new GroundGrid(terrainStartX, terrainStartY, columns, rows, _spriteBatch);
        }

        public void Draw()
        {
            TopWall.Draw();
            BottomWall.Draw();
            LeftWall.Draw();
            RightWall.Draw();
            Terrain.Draw();
        }
    }
}