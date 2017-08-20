using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace TejMonoIntro
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState ks;
        Ball ball;
        Paddle leftPaddle;
        Paddle rightPaddle;
        bool resetBall;

        int difficulty = 0;
        //0 easy, 1 medium, 2 hard

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {


            spriteBatch = new SpriteBatch(GraphicsDevice);
            resetBall = false;
            ball = new Ball(new Vector2(0, 0), Content.Load<Texture2D>("BlueBall"), Color.White, new Vector2(4));
            leftPaddle = new Paddle(new Vector2(0, 140), Content.Load<Texture2D>("PongPaddleMonogame"), Color.Red, new Vector2(0, 10));
            rightPaddle = new Paddle(new Vector2(GraphicsDevice.Viewport.Width - 16, 140), Content.Load<Texture2D>("PongPaddleMonogame"), Color.Red, new Vector2(0, 5));
            // Create a new SpriteBatch, which can be used to draw textures.

            if (difficulty == 0)
            {
                rightPaddle.speed.Y = 5;
            }
            if (difficulty == 1)
            {
                rightPaddle.speed.Y = 1.5f;
            }
            if (difficulty == 2)
            {
                rightPaddle.speed.Y = 4;
            }
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (ball.hitbox.Intersects(rightPaddle.hitbox))
            {
                ball.speed.X *= -1;
                resetBall = false;
            }
            if (ball.hitbox.Intersects(leftPaddle.hitbox))
            {
                ball.speed.X *= -1;
                resetBall = false;
            }
            leftPaddle.Update(gameTime);
            rightPaddle.Update(gameTime);
            ball.Update(gameTime);
            ks = Keyboard.GetState();
            ball.position.X += ball.speed.X;
            ball.position.Y += ball.speed.Y;
            // Right side
            /// reset()
            // Left side
            if (ball.position.X + ball.texture.Width > GraphicsDevice.Viewport.Width || ball.position.X < 0)
            {
                resetBall = true;
            }
            if (resetBall == true)
            {
                ball.reset(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
                resetBall = false;
            }
            else if (ball.position.Y + ball.texture.Height >= GraphicsDevice.Viewport.Height || ball.position.Y <= 0)
            {
                ball.speed.Y *= -1;
            }
            //hard difficulty
            if (difficulty == 2)
            {
                rightPaddle.position.Y = ball.position.Y;
            }
            //easy difficulty
             if (rightPaddle.position.Y <= 0 || rightPaddle.position.Y + rightPaddle.texture.Height >= GraphicsDevice.Viewport.Height && difficulty == 0)
             {
                 rightPaddle.speed.Y *= -1;
             }

            //medium difficulty

            if (ball.position.Y + ball.texture.Height / 2 >= rightPaddle.position.Y + rightPaddle.texture.Height / 2 && difficulty ==1)
            {
                rightPaddle.position.Y += rightPaddle.speed.Y;
            }
            else if (ball.position.Y / 2 <= rightPaddle.position.Y / 2)
            {
                rightPaddle.position.Y -= rightPaddle.speed.Y;
            }
            else
            {
                //nothing happens when the y's are equal to each other
            }

            if (ks.IsKeyDown(Keys.Up) && leftPaddle.position.Y >= 0)
            {
                leftPaddle.position.Y -= leftPaddle.speed.Y;
            }
            else if (ks.IsKeyDown(Keys.Down) && leftPaddle.position.Y + leftPaddle.texture.Height < GraphicsDevice.Viewport.Height)
            {
                leftPaddle.position.Y += leftPaddle.speed.Y;
            }
            //GraphicsDevice.Viewport.Height
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Ivory);
            ball.Draw(spriteBatch);
            rightPaddle.Draw(spriteBatch);
            leftPaddle.Draw(spriteBatch);
            base.Draw(gameTime);
        }
    }
}
