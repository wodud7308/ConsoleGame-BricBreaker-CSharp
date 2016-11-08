using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenes.Standard
{
    interface Scene : IDisposable
    {
        bool Initialize();
        void Input();
        void Update();
        void Draw();
        //void Dispose구현해야함
    }
}
