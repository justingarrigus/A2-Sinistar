using Sinistar.Input.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sinistar
{
    class KBBindTest : KeyboardBind
    {
        public void Began()
        {
            Console.WriteLine("key 'A' was pressed");
        }

        public void Ended()
        {
            Console.WriteLine("key 'A' was released");
        }
    }
}
