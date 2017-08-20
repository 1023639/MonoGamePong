using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TejMonoIntro
{
    public class Ball : Sprite
    {
        public Vector2 speed;


        public Ball(Vector2 position, Texture2D texture, Color tint, Vector2 speed)
            : base(position, texture, tint)
        {
            this.speed = speed;
            this.position = position;
            this.texture = texture;
            this.tint = tint; 
        }
        public override void Draw (SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
        public void reset(int width, int height)
        {
            position.X = width / 2;
            position.Y = height / 2;
            
        
        }
        //

    }
}
