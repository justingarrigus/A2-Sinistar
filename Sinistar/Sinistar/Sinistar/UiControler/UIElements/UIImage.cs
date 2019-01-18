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

namespace Sinistar.UiControler.UIElements
{
    class UIImage : UIElement
    {
        public Color color;
        public Texture2D texture;
        /// <summary>
        ///     This is the size of the source image (Not stretched or compressed but the actual file size)
        /// </summary>
        public Rectangle sourceSize;

        public UIImage(double sx, double sy, int ox, int oy, Texture2D texture) : base(sx, sy, ox, oy)
        {
            this.texture = texture;
            this.color = Color.White;
            
            sizeX = 25;
            sizeY = 25;
            sourceSize = new Rectangle(0,0, texture.Height, texture.Width);
        }

        /// <summary>
        ///     PLEASE DONT USE
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="zIndex"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public override void draw(SpriteBatch spriteBatch, double rotOx, double rotOy, float zIndex, int x, int y)
        {
            spriteBatch.Draw(texture, 
                new Rectangle((int)(x +sizeX * anchorPointY), (int)(y+sizeY*anchorPointY), sizeX, sizeY), 
                sourceSize, 
                color, 
                rotation, 
                new Vector2((float)rotOx * sourceSize.Width, (float)rotOy * sourceSize.Height), 
                spriteEffects, 
                zIndex
            );
        }
    }
}
