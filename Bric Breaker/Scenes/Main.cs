using Scenes.Standard;
using System;
using Management;

namespace Scenes
{
    class Main : Scene
    {
        ConsoleKey key;
        public void Draw()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("M to Menual");
            Console.SetCursorPosition(0, 1);
            Console.Write("ESC to Quit");
            Console.SetCursorPosition(38, 10);
            Console.Write("B R I C   B R E A K E R");
            Console.SetCursorPosition(32, 14);
            Console.Write("P R E S S    S P A C E   T O   S T A R T");
        }

        public void Input()
        {
            key = InputManager.GetInstance.KeyInput().Key;
        }

        public bool Initialize()
        {
            Console.Beep();
            Console.ForegroundColor = ConsoleColor.Yellow;
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
                case ConsoleKey.M:
                    Release();
                    SceneManager.GetInstance.ChangeScene(new Menual());
                    break;
                case ConsoleKey.Spacebar:
                    Release();
                    SceneManager.GetInstance.ChangeScene(new InGame());

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
