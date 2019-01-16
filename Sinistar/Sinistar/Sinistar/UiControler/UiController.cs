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

        /// <summary>
        ///     Updates the screen size.
        /// </summary>
        public void updateScreenSize()
        {
            viewXSize = graphicsDevice.Viewport.Width;
            viewYSize = graphicsDevice.Viewport.Height;
        }

        /// <summary>
        ///     Adds an element to this controller or frame.
        /// </summary>
        /// <param name="element"></param>
        public void addElement(UIElement element)
        {
            elements.Add(element);
        }

        /// <summary>
        ///     Adds an element to this controller or frame.
        /// </summary>
        /// <param name="element">Element to add</param>
        /// <param name="ox">Offset of the element in the X direction</param>
        /// <param name="oy">Offset of the element in the Y direction</param>
        /// <param name="sx">Scale of the element in the X direction</param>
        /// <param name="sy">Scale of the element in the Y direction</param>
        public void addElement(UIElement element, int ox, int oy, int sx, int sy)
        {
            element.offsetX = ox;
            element.offsetY = oy;
            element.scaleX = sx;
            element.scaleY = sy;

            elements.Add(element);
        }


        /// <summary>
        ///     Draws a specific element
        /// </summary>
        /// <param name="element">Element to draw</param>
        /// <param name="zScale">ZIndex scale</param>
        private void drawElement(UIElement element, float zScale)
        {
            //Takes the view size multiplies it by the scale position, adds the offset, then uses the anchor point to position it onto the screen
            int x = (int)((viewXSize * element.scaleX - element.sizeX * element.anchorPointX) + element.offsetX);
            int y = (int)((viewYSize * element.scaleY - element.sizeY * element.anchorPointY) + element.offsetY);
            element.draw(spriteBatch, zScale * (float)element.getZIndex(), x, y);
        }
        
        /// <summary>
        ///     Draws all registered elements
        /// </summary>
        public void drawElements()
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
            float zScale = 1f / (float)UIElement.getMaxZIndex();
            for (int i = 0; i < elements.Count; i++) {
                drawElement(elements.ElementAt(i), zScale);
            }
            spriteBatch.End();
        }

        
    }
}
