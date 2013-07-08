#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace ExampleGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class FirstGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        ParticleEngine particleEngine;
        private Texture2D arrow;

        /*
        private Texture2D boardImage;
        private SpriteFont myFont;
        //private AnimatedSpriteHandler animatedSprite;
        private Texture2D arrow;
        private float arrowAngle = 0;

        private Texture2D blue, green, red;
        private float blueAngle = 0;
        private float greenAngle = 0;
        private float redAngle = 0;
        private float blueSpeed = 0.025f;
        private float greenSpeed = 0.017f;
        private float redSpeed = 0.022f;
        private float distance = 100;
         */

        public FirstGame()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
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
            graphics.PreferredBackBufferWidth = (int)ScreenManager.Instance.Dimensions.X;
            graphics.PreferredBackBufferHeight = (int)ScreenManager.Instance.Dimensions.Y;
            graphics.ApplyChanges();
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

            // SCREEN MANAGER
            ScreenManager.Instance.GraphicsDevice = GraphicsDevice;
            ScreenManager.Instance.SpriteBatch = spriteBatch;
            ScreenManager.Instance.LoadContent(Content);

            // PARTICLE ENGINE
            List<Texture2D> textures = new List<Texture2D>();
            textures.Add(Content.Load<Texture2D>("circle"));
            textures.Add(Content.Load<Texture2D>("star"));
            textures.Add(Content.Load<Texture2D>("diamond"));
            particleEngine = new ParticleEngine(textures, new Vector2(400, 240));

            // SCREEN MANAGER LOAD
            arrow = Content.Load<Texture2D>("arrow");

            //arrow = Content.Load<Texture2D>("arrow");
            //myFont = Content.Load<SpriteFont>("myFont");

            /*
            // TODO: use this.Content to load your game content here
            boardImage = Content.Load<Texture2D>("1");
            myFont = Content.Load<SpriteFont>("myFont");

            //Texture2D texture = Content.Load<Texture2D>("Car1");
            //animatedSprite = new AnimatedSpriteHandler(texture, 4, 4); 

            blue = Content.Load<Texture2D>("blue");
            green = Content.Load<Texture2D>("green");
            red = Content.Load<Texture2D>("red");
             */
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            ScreenManager.Instance.UnloadContent();
            //Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            //animatedSprite.Update();
            /*
            arrowAngle += 0.01f;

            blueAngle += blueSpeed;
            greenAngle += greenSpeed;
            redAngle += redSpeed;
             */

            // SCREEN MANAGER UPDATE
            ScreenManager.Instance.Update(gameTime);

            // PARTICLE ENGINE UPDATE
            particleEngine.EmitterLocation = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            particleEngine.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);
            graphics.GraphicsDevice.Clear(Color.Black);

            /*
            Vector2 bluePosition = new Vector2((float)Math.Cos(blueAngle) * distance, (float)Math.Sin(blueAngle) * distance);
            Vector2 greenPosition = new Vector2((float)Math.Cos(greenAngle) * distance, (float)Math.Sin(greenAngle) * distance);
            Vector2 redPosition = new Vector2((float)Math.Cos(redAngle) * distance, (float)Math.Sin(redAngle) * distance);
            Vector2 colorCenter = new Vector2(300, 140); // where sprites are centered
             */

            // TODO: Add your drawing code here
           // spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);
            spriteBatch.Begin();
            ScreenManager.Instance.Draw(spriteBatch);
            /*
            spriteBatch.Draw(boardImage, new Rectangle(100, 20, 450, 450), Color.White);
            spriteBatch.DrawString(myFont, "YOOOO THIS WORKS!!!! HELLLOOOO WORLD!", new Vector2(10, 10), Color.White);

            //animatedSprite.Draw(spriteBatch, new Vector2(400, 200));

            Vector2 arrowLocation = new Vector2(400, 240);
            Vector2 arrowOrigin = new Vector2(arrow.Width/2, arrow.Height);
            Rectangle arrowSourceRectangle = new Rectangle(0, 0, arrow.Width, arrow.Height);
            spriteBatch.Draw(arrow, arrowLocation, arrowSourceRectangle, Color.White, arrowAngle, arrowOrigin, 1.0f, SpriteEffects.None, 1);

            spriteBatch.Draw(blue, colorCenter + bluePosition, Color.White);
            spriteBatch.Draw(green, colorCenter + greenPosition, Color.White);
            spriteBatch.Draw(red, colorCenter + redPosition, Color.White);
             */
            spriteBatch.End();

            //particleEngine.Draw(spriteBatch);
            
            base.Draw(gameTime);
        }
    }
}
