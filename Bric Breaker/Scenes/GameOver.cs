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
            Console.SetCursorPosition(44, 11);
            Console.Write("G A M E   O V E R ...");
            Console.SetCursorPosition(43, 13);
            Console.Write("E S C   T O   Q U I T");
            Console.SetCursorPosition(38, 15);
            Console.Write("P R E S S   R   T O   R E P L A Y");
            Console.SetCursorPosition(36, 17);
            Console.Write("P R E S S   S P A C E   T O   M A I N");
        }
        public void Input()
        {
            key = InputManager.GetInstance.KeyInput().Key;
        }
        public bool Initialize()
        {
            return true;
        }

        public void Dispose()
        {
            Console.Clear();
        }

        public void Update()
        {
            switch (key)
            {
                case ConsoleKey.R:
                    Dispose();
                    SceneManager.GetInstance.ChangeScene(new InGame());
                    break;
                case ConsoleKey.Escape:
                    Dispose();
                    Environment.Exit(0);
                    break;
                case ConsoleKey.Spacebar:
                    Dispose();
                    SceneManager.GetInstance.ChangeScene(new Main());
                    break;
            }
        }
    }
}
