using Scenes.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using Management;

namespace Scenes
{
    class Menual : Scene
    {
        ConsoleKey key;
        public void Draw()
        {
            Console.SetCursorPosition(23, 8);
            Console.Write("LEFT ARROW ◀      ▶ RIGHT ARROW");
            Console.SetCursorPosition(23, 10);
            Console.Write("MOVE LEFT             MOVE RIGHT");
            Console.SetCursorPosition(27, 12);
            Console.Write("PRESS SPACE TO START GAME");
        }

        public void Input()
        {
            key = InputManager.GetInstance.KeyInput().Key;
        }

        public bool Initialize()
        {
            Console.Beep();
            Console.ForegroundColor = ConsoleColor.Green;
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
                case ConsoleKey.Spacebar:
                    Release();
                    SceneManager.GetInstance.ChangeScene(new InGame());
                    break;
                case ConsoleKey.Backspace:
                    Release();
                    SceneManager.GetInstance.ChangeScene(new Main());
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
            }
        }
        public void Dispose()
        {
            
        }                                                                                
    }
}
