using System;
using singleton;

namespace Management
{
    class InputManager : Singleton<InputManager>
    {

        public ConsoleKeyInfo KeyInput()
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            if (Console.KeyAvailable)
            // C++ / _kbhit()
            {
                key = Console.ReadKey(true);
            }
            return key;
        }
    }
}
