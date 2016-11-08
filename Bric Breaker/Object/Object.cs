using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object.Standard
{
    interface StandardObject
    {
        void Initialize();
        void Remove(int x, int y);
        void Render();
    }
}
