using System;
using Map;
using Object.Location;
using Object.Standard;
using Collision;

namespace Object
{
    class Ball : StandardObject
    {    
        private Position position;
        private Collider collider;
        private int yVelocity;
        private int xVelocity;
        private Direction horizontal;
        private Direction vertical;

        private bool IsDead()
        {                                        
            return false;
        }

        public void PositionInfo()
        {

        }

        public void Initialize()
        {

        }
        public void Move()
        {
            Remove(position.X, position.Y);
            position.TransformPosition(xVelocity, yVelocity);
            GameMap.GetInstance[position.Y, position.X / 2] = MapInfo.BALL;
        }

        public void Update()
        {

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
