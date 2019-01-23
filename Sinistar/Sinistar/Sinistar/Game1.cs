using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Sinistar.UiControler;
using Sinistar.UiControler.UIElements;
using Sinistar.Input;

namespace Sinistar
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;

        UiController uiController;
        InputManager inputManager;

        UIImage image;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);

            uiController = new UiController(spriteBatch, GraphicsDevice);
            inputManager = new InputManager();

            // TODO: Add your initialization logic here
            inputManager.addListener(new INPUTEXAMPLE());

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            //font = Content.Load<SpriteFont>("SpriteFont1");

            // TODO: use this.Content to load your game content here
            image = new UIImage(0.5, 0.5, 0, 0, this.Content.Load<Texture2D>("Untitled"));

            uiController.addElement(image);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            uiController.updateScreenSize();
            inputManager.updateInput();
            // TODO: Add your update logic here

            image.offsetX += (int)INPUTEXAMPLE.movementExample.X;
            image.offsetY += (int)INPUTEXAMPLE.movementExample.Y;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            uiController.drawElements();
            // TODO: Add your drawing code here

            



            base.Draw(gameTime);
        }
    }
}