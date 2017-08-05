﻿using Microsoft.Xna.Framework;
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
        Vector2 speed;
        Vector2 position;
        Texture2D texture;
        Color tint; 


        public Ball(Vector2 position, Texture2D texture, Color tint, Vector2 speed)
            : base(position, texture, tint)
        {
            this.speed = speed;
            this.position = position;
            this.texture = texture;
            this.tint = tint; 
        }
        public void draw (SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture,position, tint);
            spriteBatch.End();
        }
        public void reset(int height, int width)
        {
            position.X = width / 2;
            position.Y = height / 2;
       
        }
        //

    }
}
