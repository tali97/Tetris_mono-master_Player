using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class player
    {
        GraphicsDeviceManager graphics;
        Texture2D texture;
        Vector2 position;
        bool hasJumped;
       // Texture2D blockTexture;
        Vector2 velocity;
        public player(Texture2D newTexture, Vector2 newPosition)
        {

            texture = newTexture;
            position = newPosition;
            hasJumped = true;
            //blockTexture = blocktext;
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;
            if (Keyboard.GetState().IsKeyDown(Keys.D) /*&& position.X < graphics.PreferredBackBufferWidth - 278*/)
                velocity.X = 3F;
            else if (Keyboard.GetState().IsKeyDown(Keys.A) && position.X > 0)
                velocity.X = -3f;
            else
                velocity.X = 0f;
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && hasJumped == false)
            {
                position.Y -= 10f;
                velocity.Y = -5f;
                hasJumped = true;
            }
            if (hasJumped == true)
            {
                float i = 1;
                velocity.Y += 0.20f * i;
            }

            if (position.Y + texture.Height > 964)
                hasJumped = false;

            if (hasJumped == false)
            {

                velocity.Y = 0f;


            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position1)
        {


            spriteBatch.Draw(texture, position, Color.White);
            //foreach (Vector2 blockPosition in blockPositions)
                //spriteBatch.Draw(blockTexture, blockPosition, Color.White);

        }
    }
}

