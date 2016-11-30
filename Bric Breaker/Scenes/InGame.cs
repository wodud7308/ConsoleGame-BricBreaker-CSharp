﻿using Scenes.Standard;
using Management;
using Object;
using System;
using Map;

namespace Scenes
{
    
    class InGame : Scene
    {
        private Player player = new Player();
        private Ball ball = new Ball();
        private ConsoleKey DirectionKey;
                          
        public void Draw()
        {
            GameManager.GetInstance.ShowCurrentScore();
            ball.Render();
            BlockManager.GetInstance.Render();
            player.Render();
        }
        public void Input()
        {
            DirectionKey = InputManager.GetInstance.KeyInput().Key;
        }

        public bool Initialize()
        {
            Console.Beep();
            GameMap.GetInstance.Initiailize();
            BlockManager.GetInstance.Initialize();
            ball.Initialize();
            player.Initialize();
            player.Render();

            return true;
        }

        public void Update()
        {
            if(ball.IsDead())
            {
                Dispose();
                SceneManager.GetInstance.ChangeScene(new GameOver());
                return;
            }
            ball.Update();
            player.Move(DirectionKey);
        }
        public void Dispose()
        {
            
            Console.Clear();
        }
    }
}