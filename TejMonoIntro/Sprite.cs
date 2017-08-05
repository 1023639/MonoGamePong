using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TejMonoIntro
{
    public class Sprite
    {
        Vector2 position;
        Texture2D texture;
        Color tint;
        public Rectangle hitbox;


        public Sprite (Vector2 position, Texture2D texture, Color tint)
        {
            this.position = position;
            this.texture = texture;
            this.tint = tint;
            
        }
        public virtual void Draw (SpriteBatch spriteBatch)
        {
           spriteBatch.Draw(texture, position, tint);
           hitbox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }
        public virtual void Update (GameTime gameTime)
        {
            hitbox.X = (int)position.X;
            hitbox.Y = (int)position.Y;

        }

    }
}
