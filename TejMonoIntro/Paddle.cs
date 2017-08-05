using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TejMonoIntro
{
    class Paddle : Sprite
    {
        Vector2 speed;
        Vector2 position;
        Texture2D texture;
        Color tint;

        public Paddle(Vector2 position, Texture2D texture, Color tint, Vector2 speed) 
            : base(position, texture, tint)
        {
            this.position = position;
            this.texture = texture;
            this.tint = tint;
            this.speed = speed; 
        }
        public void draw (SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, tint);
            spriteBatch.End();
        }
    }
}
