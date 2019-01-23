using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sinistar.Input.Binders
{
    interface KeyboardBind
    {
        void Began();
        void Ended();
    }
}
