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
            //ball.PositionInfo();
            //ball.Render();
            player.Render();
        }
        public void Input()
        {
            DirectionKey = InputManager.GetInstance.KeyInput().Key;
        }

        public bool Initialize()
        {
            GameMap.GetInstance.Initiailize();
            //ball.Initialize();
            player.Initialize();
            player.Render();
            return true;
        }

        public void Update()
        {
           // ball.Update();
          player.Move(DirectionKey);

        }
        public void Dispose()
        {
            
        }
    }
}