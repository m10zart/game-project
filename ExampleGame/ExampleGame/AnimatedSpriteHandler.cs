#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
#endregion

namespace ExampleGame
{
    public class AnimatedSpriteHandler
    {
        public Texture2D Texture { get; set; } // stores texture atlas for animation
        public int Rows { get; set; } // # rows and columns in texture atlas
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;

        /* constructor to make new AnimatedSprite object */
        public AnimatedSpriteHandler(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
        }

        /* changes current frame to next frame */
        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames) currentFrame = 0;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = currentFrame / Columns;
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
