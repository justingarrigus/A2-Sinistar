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
            // TODO: Add your initialization logic here
            spriteBatch = new SpriteBatch(GraphicsDevice);

            uiController = new UiController(spriteBatch, GraphicsDevice);

            UIText textLabel = new UIText(0.5, 0.5, 0, 0, this.Content.Load<SpriteFont>("SpriteFont2"));
            textLabel.setAnchorPoint(0, 0.5);
            textLabel.setText("SOME LONG RANDOM TEXT");
            textLabel.setZIndex(10);

            UIText textLabel2 = new UIText(0.8, 0.5, 0, 0, this.Content.Load<SpriteFont>("SpriteFont2"));

            textLabel2.setAnchorPoint(0, 0.5);
            textLabel2.setText("ANOTHER LONG STRING OF TEXT");
            textLabel2.textColor = Color.Red;
            textLabel2.setZIndex(4);

            image = new UIImage(0.5, 0.5, 0, 0, this.Content.Load<Texture2D>("Untitled"));
            image.setAnchorPoint(0.5, 0.5);
            image.sizeX = 100;
            image.sizeY = 100;
            


            //uiController.addElement(textLabel);
            uiController.addElement(image);

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

            // TODO: Add your update logic here

            image.rotation += 1;

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