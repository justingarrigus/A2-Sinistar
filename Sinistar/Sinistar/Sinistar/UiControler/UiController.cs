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
    class UiController
    {

        private SpriteBatch spriteBatch;
        private GraphicsDevice graphicsDevice;

        private int viewXSize;
        private int viewYSize;
        private List<UIElement> elements;

        public UiController(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            this.spriteBatch = spriteBatch;
            this.graphicsDevice = graphicsDevice;
            this.elements = new List<UIElement>();
        }


        public void updateScreenSize()
        {
            viewXSize = graphicsDevice.Viewport.Width;
            viewYSize = graphicsDevice.Viewport.Height;
        }


        public void addElement(UIElement element)
        {
            elements.Add(element);
        }
        public void addElement(UIElement element, int ox, int oy, int sx, int sy)
        {
            element.offsetX = ox;
            element.offsetY = oy;
            element.scaleX = sx;
            element.scaleY = sy;

            elements.Add(element);
        }

        public void drawElement(UIElement element)
        {
            //Takes the view size multiplies it by the scale position, adds the offset, then uses the anchor point to position it onto the screen
            int x = (int)(viewXSize * element.scaleX + element.offsetX + element.sizeX * element.anchorPointX);
            int y = (int)(viewYSize * element.scaleY + element.offsetY + element.sizeY * element.anchorPointY);

            element.draw(spriteBatch, x, y);
        }

        
        public void draw()
        {
            for (int i = 0; i <= elements.Count; i++) {
                elements.ElementAt(i);
            }

        }


        /// <summary>
        ///     This draws the provided text using the sprite font, 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        ///
        public void drawText(string text, SpriteFont font, int textSize, double x, double y)
        {
            spriteBatch.DrawString()
        }


        
    }
}
