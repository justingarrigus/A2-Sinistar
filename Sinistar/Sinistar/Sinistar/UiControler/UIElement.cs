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
    public abstract class UIElement
    {
        private static int maxZIndex;

        /// <summary>
        ///     Offset is the position of the element in pixels, this is translated after scale is applied
        /// </summary>
        public int offsetX;
        /// <summary>
        ///     Offset is the position of the element in pixels, this is translated after scale is applied
        /// </summary>
        public int offsetY;
        /// <summary>
        ///     Scale is the relative position to the screen size, 0.5 will be the center of the screen
        /// </summary>
        public double scaleX;
        /// <summary>
        ///     Scale is the relative position to the screen size, 0.5 will be the center of the screen
        /// </summary>
        public double scaleY;

        public int absX;
        public int absY;
        public int sizeX;
        public int sizeY;
        public double anchorPointX;
        public double anchorPointY;

        public double rotAnchorX;
        public double rotAnchorY;

        public float rotation;
        public SpriteEffects spriteEffects;
        private int zIndex;


        public UIElement(double sx, double sy, int ox, int oy)
        {
            offsetX = ox;
            offsetY = oy;
            scaleX = sx;
            scaleY = sy;
        }

        /// <summary>
        ///     Sets the point the image is translated from. For example (0, 0) will be moving the 
        ///     element based on the top left corner
        /// </summary>
        /// <param name="x">X value of the anchor point</param>
        /// <param name="y">Y value of the anchor point</param>
        public void setAnchorPoint(double x, double y)
        {
            anchorPointX = x;
            anchorPointY = y;
        }

        /// <summary>
        ///     Sets the ZIndexof this element.
        ///     
        ///     The zIndex defines what order to draw items in. The greater the ZIndex, 
        ///     those elements will be draw above the lower zIndexed elements.
        /// </summary>
        /// <param name="index">ZIndex to set</param>
        public void setZIndex(int index)
        {
            zIndex = index;
            if (index > maxZIndex)
                maxZIndex = index;
        }
        /// <summary>
        ///     Gets the ZIndex of this element.
        ///     
        ///     The zIndex defines what order to draw items in. The greater the ZIndex, 
        ///     those elements will be draw above the lower zIndexed elements.
        /// </summary>
        /// <returns></returns>
        public int getZIndex()
        {
            return zIndex;
        }

        /// <summary>
        ///     Draw method
        ///     PLEASE DO NOT USE
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="zIndex"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public abstract void draw(SpriteBatch spriteBatch, double rotAnchorX, double rotAnchorY, float zIndex, int x, int y);


        /// <summary>
        ///     Returns the maximum zIndex of all created elements.
        ///     
        ///     The zIndex defines what order to draw items in. The greater the ZIndex, 
        ///     those elements will be draw above the lower zIndexed elements.
        /// </summary>
        /// <returns>The maximum zIndex of all elements</returns>
        public static int getMaxZIndex()
        {
            return maxZIndex;
        }

        public Point getAbsolutePosition()
        {
            return new Point((int)(absX + sizeX * anchorPointY), (int)(absY + sizeY * anchorPointY));
        }
    }

}
