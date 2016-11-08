using System;
using Map;
using Object.Location;

namespace Collision
{
    public enum Direction
    {
        NONE,
        UP,
        DOWN,
        LEFT,
        RIGHT
    }
    class Collider
    {
        public bool Collide(Position pos, ConsoleKey key)
        {
            if(key == ConsoleKey.LeftArrow)
            {
                if(pos.X - 2 == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (key == ConsoleKey.RightArrow)
            {
                if(pos.X + 2 == 70)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public bool Collide(string direction, Position pos, ref int velocity)
        {
            if(direction == "vertical")
            {
               if(GameMap.GetInstance[pos.Y+velocity,pos.X] == MapInfo.WALL)
                {
                    velocity = velocity * -1;
                    return true;
                }
               else
                {
                    return false;
                }
            }
            else if(direction == "horizontal")
            {
                if (GameMap.GetInstance[pos.Y, pos.X+ velocity] == MapInfo.WALL)
                {
                    velocity = velocity * -1;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
