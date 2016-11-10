using System;
using Map;
using Object.Location;
using Collision;

namespace Object
{
    class Ball
    {    
        private Position position;
        private Collider collider;
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

        public void Initialize()
        {
            position = new Position();
            collider = new Collider();
            position.SetPosition(34, 10);
            xVelocity = 1;
            yVelocity = 1;
            GameMap.GetInstance[10, 2] = MapInfo.BALL;
        }
 
        private void Collide()
        {
            collider.Collide("vertical", position, ref yVelocity);
            collider.Collide("horizontal", position, ref xVelocity);
        }
        public void Move()
        {
            Remove(position.X, position.Y);
            position.TransformPosition(xVelocity, yVelocity);
            GameMap.GetInstance[position.Y, position.X / 2] = MapInfo.BALL;
        }

        public void Update()
        {
            Collide();
            Move();
        }

        public void Remove(int x, int y)
        {
            GameMap.GetInstance[y, x / 2] = MapInfo.NONE;
            Console.SetCursorPosition(x, y);
            Console.Write("  ");
        }

        public void Render()
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write("◎");
        }
    }         
}
