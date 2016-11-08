using Scenes.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management;
namespace Scenes
{
    class GameOver : Scene
    {
        ConsoleKey key;
        public void Draw()
        {
            Console.SetCursorPosition(32, 11);
            Console.Write("G A M E   O V E R ...");
            Console.SetCursorPosition(31, 13);
            Console.Write("E S C   T O   Q U I T");
            Console.SetCursorPosition(26, 15);
            Console.Write("P R E S S   R   T O   R E P L A Y");
            Console.SetCursorPosition(28, 17);
            Console.Write("P R E S S   ←   T O   M A I N");
        }
        public void Input()
        {
            key = InputManager.GetInstance.KeyInput().Key;
        }
        public bool Initialize()
        {
            return true;
        }

        public void Release()
        {
            Console.Clear();
        }

        public void Update()
        {
            switch(key)
            {
                case ConsoleKey.R:
                    Release();
                    SceneManager.GetInstance.ChangeScene(new InGame());
                    break;
                case ConsoleKey.Backspace:
                    Release();
                    SceneManager.GetInstance.ChangeScene(new Main());
                    break;
                case ConsoleKey.Escape:
                    Release();
                    Environment.Exit(0);
                    break;
            } 
        }

        public void Dispose()
        {
            
        }
    }
}
