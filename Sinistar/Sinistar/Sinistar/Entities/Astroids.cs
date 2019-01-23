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

        public UISpriteImage image;

        public Astroids(Texture2D sheet, Rectangle source, UiController ui, int sizeX, int sizeY, Vector2 velo) : 
            base(new Rectangle(0, 0, sizeX, sizeY), velo)
        {
            image = new UISpriteImage(0.5, 0.5, 0, 0, sheet);
            image.setSprite(source);
            image.rotAnchorX = 0.5;
            image.rotAnchorY = 0.5;
            image.setAnchorPoint(0, 0);

            image.sizeX =
                sizeX;
            image.sizeY = sizeY;
            image.setZIndex(1); //1: Me, 2: Enemy, 3:Sinistar, 4:Ship

            Point absPos = image.getAbsolutePosition();
            rect.X = 0;//.X;
            rect.Y = 0;//.Y;

            ui.addElement(image);

        }

        public override void collidedWith(PhysicsBody other)
        {
            //throw new NotImplementedException();
        }
    }
}
