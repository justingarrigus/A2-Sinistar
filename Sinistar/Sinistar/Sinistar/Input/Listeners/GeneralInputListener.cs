using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sinistar.Input.Listeners
{
    interface GeneralInputListener : InputListener
    {
        void GamepadInputBegan(InputObject input);
        void KeyboardInputBegan(InputObject input);
        void MouseInputBegan(InputObject input);

        void GamepadInputEnded(InputObject input);
        void KeyboardInputEnded(InputObject input);
        void MouseInputEnded(InputObject input);
    }
}
