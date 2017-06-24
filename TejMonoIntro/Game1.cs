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
        Texture2D texture;
        Texture2D leftPaddleTexture;
        Texture2D rightPaddleTexture;
        Vector2 position;
        Vector2 leftPaddlePosition;
        Vector2 rightPaddlePosition;
        Color tint;
        Color rightPaddleTint;
        Color leftPaddleTint;
        int speedX;
        int speedY;
        int rightPaddleSpeedY;
        int leftPaddleSpeedY;
        KeyboardState ks;

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
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Content.Load<Texture2D>("BlueBall");
            position = new Vector2(0, 0);
            tint = Color.White;
            leftPaddleTexture = Content.Load<Texture2D>("PongPaddleMonogame");
            leftPaddlePosition = new Vector2(0, 140);
            leftPaddleTint = Color.Red;
            rightPaddleTexture = Content.Load<Texture2D>("PongPaddleMonogame");
            rightPaddlePosition = new Vector2(GraphicsDevice.Viewport.Width - 16, 140);
            rightPaddleTint = Color.Red;
            speedX = 5;
            speedY = 5;
            rightPaddleSpeedY = 5;
            leftPaddleSpeedY = 5;
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
            ks = Keyboard.GetState();
            position.X += speedX;
            // Right side
            if (position.X + texture.Width >= rightPaddlePosition.X && position.Y + texture.Height >= rightPaddlePosition.Y && position.Y <= rightPaddlePosition.Y + rightPaddleTexture.Height)
            {
                speedX = -Math.Abs(speedX);
            }
            // Left side
            if (/*right side of paddle*/position.X <= leftPaddlePosition.X + leftPaddleTexture.Width && /*bottom of paddle*/position.Y <= leftPaddlePosition.Y + leftPaddleTexture.Height && /*top of paddle*/position.Y + texture.Height >= leftPaddlePosition.Y)
            {
                speedX = Math.Abs(speedX);
            }
            position.Y += speedY;
            if (position.Y + texture.Height >= GraphicsDevice.Viewport.Height || position.Y <= 0)
            {
                speedY *= -1;
            }
            rightPaddlePosition.Y += rightPaddleSpeedY;
            if (rightPaddlePosition.Y <= 0 || rightPaddlePosition.Y + rightPaddleTexture.Height >= GraphicsDevice.Viewport.Height)
            {
                rightPaddleSpeedY *= -1;
            }
            if (ks.IsKeyDown(Keys.Up) && leftPaddlePosition.Y >= 0)
            {
                leftPaddlePosition.Y -= leftPaddleSpeedY;
            }
            if (ks.IsKeyDown(Keys.Down) && leftPaddlePosition.Y + leftPaddleTexture.Height < GraphicsDevice.Viewport.Height)
            {
                leftPaddlePosition.Y += leftPaddleSpeedY;
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
            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, tint);
            spriteBatch.Draw(leftPaddleTexture, leftPaddlePosition, leftPaddleTint);
            spriteBatch.Draw(rightPaddleTexture, rightPaddlePosition, rightPaddleTint);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
