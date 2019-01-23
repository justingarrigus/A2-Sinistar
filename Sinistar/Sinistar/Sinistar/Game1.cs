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
        UiController uiController;

        PhysicsField phyicsField;


        SpriteBatch spriteBatch;
        SpriteFont font;

        int screenWidth = 1000, screenHeight = 850; 

        KeyboardState lastKb; 

        
        UISpriteImage image;

        Texture2D spriteSheet;
        Texture2D debugSquare;
        Ship ship; 

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.ApplyChanges(); 
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
            phyicsField = new PhysicsField();

            // TODO: Add your initialization logic here

            lastKb = Keyboard.GetState();

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
            spriteSheet = Content.Load<Texture2D>("spritesheet");
            debugSquare = Content.Load<Texture2D>("Square"); 

            Dictionary<string, Rectangle[]> textures = Load.Sprites();
            ship = new Ship(uiController, spriteSheet, textures["ship"]); 
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
            phyicsField.updateBodies();
            KeyboardState kb = Keyboard.GetState();
            
            // TODO: Add your update logic here
            if(kb.IsKeyDown(Keys.Left))
            {
                ship.Turn(-Ship.TurnSpeed); 
            }
            else if(kb.IsKeyDown(Keys.Right))
            {
                ship.Turn(Ship.TurnSpeed); 
            }
            else if(kb.IsKeyDown(Keys.Space))
            {
                ship.Fire();
            }

            ship.Move();





            lastKb = kb;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            // TODO: Add your drawing code here

            //DEBUG
            spriteBatch.Begin();

            //Ship
            spriteBatch.Draw(debugSquare, new Rectangle(
                (int)(ship.image.absX + ship.image.sizeX * ship.image.anchorPointX) - ship.image.offsetX + ship.rect.X,
                (int)(ship.image.absY + ship.image.sizeY * ship.image.anchorPointY) - ship.image.offsetY + ship.rect.Y,
                ship.rect.Width, ship.rect.Height
            ), Color.Red);

            //Sinistar

            //Asteroids
            List<PhysicsBody> roids = phyicsField.physBodies;
            for (int i = 0; i < roids.Count; i++)
            {
                PhysicsBody body = roids[i];
                // (body is void) {

                //}
            }

            //Bad boys

            spriteBatch.End();

            //////////////
            uiController.drawElements();
            base.Draw(gameTime);
        }
    }
}