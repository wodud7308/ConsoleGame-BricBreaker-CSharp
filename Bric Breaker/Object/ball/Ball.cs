using System;
using Map;
using Object.Location;
using Collision;

namespace Object
{
    class Ball
    {    
        private Position position;
        private BallCollider collider;
        private int yVelocity;
        private int xVelocity;

        public void BlockPosInfo()
        {
            Console.SetCursorPosition(80,5);
            Console.Write("Next value : {0} ",GameMap.GetInstance[position.Y +yVelocity, position.X / 2]);
            Console.SetCursorPosition(80, 8);
            Console.Write("This value : {0} ", GameMap.GetInstance[position.Y, position.X / 2]);
            Console.SetCursorPosition(80, 11);
            Console.Write("vlaue zero of y pos : {0}", GameMap.GetInstance[0, 2]);
        }

        public bool IsDead()
        {            
            if(GameMap.GetInstance[position.Y+yVelocity,position.X/2]==MapInfo.DEAD_LINE)
            {
                return true;
            }                            
            return false;
        }

        public void Initialize()
        {
            position = new Position();
            collider = new BallCollider();
            position.SetPosition(34, 10);
            xVelocity = 1;
            yVelocity = 1;
            GameMap.GetInstance.SetObjectInMap(2, 10, MapInfo.BALL);
        }
 
        private void Collide()
        {
            collider.Collide("vertical", position, ref yVelocity, ref xVelocity);
            collider.Collide("horizontal", position, ref xVelocity, ref yVelocity);            
        }
        public void Move()
        {
            Remove(position.X, position.Y);
            position.TransformPosition(xVelocity, yVelocity);
            GameMap.GetInstance.SetObjectInMap(position.X / 2, position.Y, MapInfo.BALL);
        }

        public void Update()
        {
            Collide();
            Move();
        }

        public void Remove(int x, int y)
        {
            GameMap.GetInstance.SetObjectInMap(x/2, y, MapInfo.BALL);
            Console.SetCursorPosition(x, y);
            Console.Write("  ");
        }

        public void Render()
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("◎");
        }
    }         
}
