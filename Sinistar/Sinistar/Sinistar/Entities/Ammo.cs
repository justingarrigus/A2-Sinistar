using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sinistar.UiControler;
using Sinistar.UiControler.UIElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sinistar.Entities
{
    class Ammo : PhysicsBody
    {
        public const int SizeX = 3;
        public const int SizeY = 15;

        UIImage image;

        public Ammo(Texture2D img, UiController ui, Point origin, float rotation, Vector2 velo) : 
            base(new Rectangle(origin.X, origin.Y, SizeX, SizeY), velo)
        {
            image = new UIImage(0, 0, 0, 0, img);
            image.rotAnchorX = 0.5;
            image.rotAnchorY = 0.5;
            image.setAnchorPoint(0, 0);

            image.sizeX = SizeX;
            image.sizeY = SizeY;
            image.setZIndex(3); //1: Me, 2: Enemy, 3:Sinistar/Ammo, 4:Ship

            pos.X = origin.X;
            pos.Y = origin.Y;
            image.offsetX = (int)pos.X + image.sizeX / 2;
            image.offsetY = (int)pos.Y + image.sizeY / 2;
            image.rotation = rotation + (float)Math.PI/2;

            ui.addElement(image);

        }

        public override void collidedWith(PhysicsBody other)
        {
            if (other is Ship == false && other is Ammo == false)
            {
                other.disabled = true;
            }
        }

        public override void updateCount(int count)
        {
        }

        public override void updateGraphics()
        {
            image.offsetX = rect.X + image.sizeX / 2;
            image.offsetY = rect.Y + image.sizeY / 2;
        }
    }
}
