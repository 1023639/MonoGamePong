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
        public Vector2 speed;
        public Texture2D texture;
        Color tint;

        public Paddle(Vector2 position, Texture2D texture, Color tint, Vector2 speed) 
            : base(position, texture, tint)
        {
            this.position = position;
            this.texture = texture;
            this.tint = tint;
            this.speed = speed; 
        }
        public override void Draw (SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
