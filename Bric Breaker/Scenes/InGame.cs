using Scenes.Standard;
using Management;
using Object;
using System;
using Map;
using System.Threading;

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
            BlockManager.GetInstance.Render();
            player.Render();
            ball.Render();
        }
        public void Input()
        {
            DirectionKey = InputManager.GetInstance.KeyInput().Key;
        }

        public bool Initialize()
        {
            Console.Beep();
            GameManager.GetInstance.ResetScore();
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
            BlockManager.GetInstance.Update();
        }
        public void Dispose()
        {
            
            Console.Clear();
        }
    }
}