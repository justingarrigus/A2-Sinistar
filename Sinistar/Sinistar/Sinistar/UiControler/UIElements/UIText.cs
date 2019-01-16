using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sinistar.UiControler.UIElements
{
    public class UIText : UIElement
    {
        private string text;
        public Color textColor;
        public SpriteFont font;

        public UIText(double sx, double sy, int ox, int oy, SpriteFont textFont) : base(sx, sy, ox, oy)
        {
            text = "NULL";
            textColor = Color.White;
            font = textFont;

            Vector2 txtBounds = font.MeasureString(text);
            sizeX = (int)txtBounds.X;
            sizeY = (int)txtBounds.Y;
        }

        /// <summary>
        ///     Sets the text of this element. The element's size will be resized according to the text bounds
        /// </summary>
        /// <param name="text">Text to set</param>
        /// 
        public void setText(string text)
        {
            this.text = text;

            Vector2 txtBounds = font.MeasureString(text);
            sizeX = (int)txtBounds.X;
            sizeY = (int)txtBounds.Y;
        }

        /// <summary>
        ///     PLEASE DONT USE
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="zIndex"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public override void draw(SpriteBatch spriteBatch, Vector2 rotOrigin, float zIndex, int x, int y)
        {
            spriteBatch.DrawString(font, text, new Vector2(x, y), textColor, rotation, rotOrigin, 1, spriteEffects, zIndex);
        }
    }

}
