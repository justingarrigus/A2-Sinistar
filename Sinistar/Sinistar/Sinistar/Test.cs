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
using Sinistar.Input;
using Sinistar.Input.Listeners;

namespace Sinistar
{
    class Test : KeyboardListener
    {
        public void InputBegan(InputObject input)
        {
            Game1.color = Color.Green;
            Console.WriteLine("BEGAN: " + input.keyboardCode);
        }

        public void InputEnded(InputObject input)
        {
            Game1.color = Color.Red;
            Console.WriteLine("ENDED: " + input.keyboardCode);
        }
    }
}
