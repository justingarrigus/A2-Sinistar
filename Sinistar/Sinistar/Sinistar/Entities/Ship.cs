using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sinistar.UiControler;
using Sinistar.UiControler.UIElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sinistar
{
    /// <summary>
    ///     The thing the player moves around. This is a wrapper for the
    ///     ship's textures, hit-box, and some other ship-specific variables. 
    /// </summary>
    class Ship : PhysicsBody
    {
        public const float TurnSpeed = 0.05f;
        public const int ShipSizeX = 25;
        public const int ShipSizeY = 25;
        public const float shipSpeed = 3;

        public Rectangle[] sprites;
        public float rot;
        public Vector2 movDir;

        public readonly float AmountRotPerSprite;

        public UISpriteImage image;


        public Ship(UiController ui, Texture2D spriteMap, Rectangle[] sprites) :
            base(new Rectangle(0, 0, ShipSizeX, ShipSizeY), new Vector2(0, 0))
        {
            this.sprites = sprites;
            rot = 0;

            AmountRotPerSprite = (float)(Math.PI * 2 / sprites.Length);
            image = new UISpriteImage(0.5, 0.5, 0, 0, spriteMap);
            image.setSprite(sprites[0]);
            image.rotAnchorX = 0.5;
            image.rotAnchorY = 0.5;
            image.setAnchorPoint(0, 0);

            image.sizeX = ShipSizeX;
            image.sizeY = ShipSizeY;
            image.setZIndex(4); //1: Roid, 2: Enemy, 3:Sinistar, 4:Me

            Point absPos = image.getAbsolutePosition();
            rect.X = 0;//.X;
            rect.Y = 0;//.Y;

            ui.addElement(image);
        }

        public void Fire()
        {

        }

        public void Move()
        {
            updatePhysics();

            image.offsetX = rect.X + image.sizeX/2;
            image.offsetY = rect.Y + image.sizeY/2;
            Console.WriteLine(pos);
        }

        public void Turn(float amount)
        {
            rot += amount; 
            if(rot > Math.PI * 2)
            {
                rot = 0; 
            }
            else if(rot < 0)
            {
                rot = (float)(Math.PI * 2); 
            }
            velo = new Vector2((float)Math.Cos(rot), (float)Math.Sin(rot)) * shipSpeed;
            image.rotation = rot;

            

            //image.setSprite(sprites[(int)(rot * AmountRotPerSprite)]);
        }

        public override void collidedWith(PhysicsBody other)
        {
            throw new NotImplementedException();
        }
    }

}
