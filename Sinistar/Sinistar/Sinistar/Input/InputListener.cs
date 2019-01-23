using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sinistar.Input
{
    interface InputListener
    {
        void InputBegan(InputObject input);
        void InputEnded(InputObject input);   
    }
}
