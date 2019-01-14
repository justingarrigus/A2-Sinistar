using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Sinistar.UiControler
{
    abstract class UIElement
    {
        public int offsetX;
        public int offsetY;
        public double scaleX;
        public double scaleY;

        public int sizeX;
        public int sizeY;
        public double anchorPointX;
        public double anchorPointY;

        public UIElement(int sx, int sy, int ox, int oy)
        {
            offsetX = ox;
            offsetY = oy;
            scaleX = sx;
            scaleY = sy;
        }

        public abstract void draw(SpriteBatch spriteBatch, int x, int y);

    }

    public class UIText
    {

    }

    public class UIImage
    {

    }

    public class UIButton
    {

    }

}
