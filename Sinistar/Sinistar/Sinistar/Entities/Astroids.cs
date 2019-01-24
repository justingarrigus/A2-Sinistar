using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sinistar.UiControler.UIElements;
using Sinistar.UiControler;

namespace Sinistar.Entities
{
    class Astroids : PhysicsBody
    {
        private UiController uiController;
        public UISpriteImage image;

        public Astroids(Texture2D sheet, Rectangle source, UiController ui, int sizeX, int sizeY, Vector2 velo) : 
            base(new Rectangle(0, 0, sizeX, sizeY), velo)
        {
            image = new UISpriteImage(0, 0, 0, 0, sheet);
            image.setSprite(source);
            image.rotAnchorX = 0.5;
            image.rotAnchorY = 0.5;
            image.setAnchorPoint(0, 0);

            image.sizeX = sizeX;
            image.sizeY = sizeY;
            image.setZIndex(1); //1: Me, 2: Enemy, 3:Sinistar, 4:Ship
            
            pos.X = source.X;
            pos.Y = source.Y;
            image.offsetX = (int)pos.X + image.sizeX / 2;
            image.offsetY = (int)pos.Y + image.sizeY / 2;

            ui.addElement(image);
            uiController = ui;
        }

        public void update()
        {
            updatePhysics();
            image.offsetX = rect.X + image.sizeX / 2;
            image.offsetY = rect.Y + image.sizeY / 2;
        }

        public override void collidedWith(PhysicsBody other)
        {
            
        }

        public override void updateGraphics()
        {
            image.offsetX = rect.X + image.sizeX / 2;
            image.offsetY = rect.Y + image.sizeY / 2;

            if (disabled)
            {
                image.offsetX = int.MaxValue;
            }
        }

        public override void updateCount(int count)
        {
            //throw new NotImplementedException();
        }
    }
}
