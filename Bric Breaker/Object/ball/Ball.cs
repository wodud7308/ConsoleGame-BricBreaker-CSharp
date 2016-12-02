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


        public bool IsDead()
        {            
            if(GameMap.GetInstance[position.Y+yVelocity,position.X/2]==MapInfo.DEAD_LINE)
            {
                return true;
            }                            
            return false;
        }
       public void Bounce()
        {
            if (collider.Collide("vertical", position, yVelocity, xVelocity)|| collider.CollideOnBlock(yVelocity, position))
            {
                yVelocity = yVelocity * -1;
            }
            if(collider.Collide("horizontal", position, yVelocity, xVelocity))
            {
                xVelocity = xVelocity * -1;
            }
            if(collider.CollideOnBlock(xVelocity, yVelocity, position))
            {
                yVelocity = yVelocity * -1;
                xVelocity = xVelocity * -1;
            }
            if (collider.CollideOnPlayer(position, yVelocity))
            {
                if (position.X/2 < Player.MiddlePos && position.X/2 >= Player.LeftPos)
                {    
                    xVelocity = -1;
                }
                if (position.X/2 == Player.LeftPos)
                {
                    xVelocity = -2;
                }
                if (position.X/2 > Player.MiddlePos && position.X/2 <= Player.RightPos)
                {  
                    xVelocity = 1;
                }
                if (position.X/2 == Player.RightPos)
                {     
                    xVelocity = 2;
                }
                yVelocity = yVelocity * -1;
            }
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
      
        public void Move()
        {
            Remove(position.X, position.Y);
            if(xVelocity == -2 || xVelocity == 2)
            {

            }
            position.TransformPosition(xVelocity, yVelocity);
            GameMap.GetInstance.SetObjectInMap(position.X / 2, position.Y, MapInfo.BALL);
        }

        public void Update()
        {
           Bounce();
            Move();
        }

        public void Remove(int x, int y)
        {
            GameMap.GetInstance.SetObjectInMap(x/2, y, MapInfo.BALL);
            Console.SetCursorPosition(x, y);
            Console.Write("  ");
        }

        public void Render()
        {;
            Console.SetCursorPosition(position.X, position.Y);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("◎");
        }
    }         
}
