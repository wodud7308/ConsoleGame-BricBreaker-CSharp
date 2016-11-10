using System;
using Map;
using Object.Location;
using Object;

namespace Collision
{
    class Collider
    {
        public bool Collide(Position pos, ConsoleKey key)
        {
            if(key == ConsoleKey.LeftArrow)
            {
                if(pos.X - 4 == 2)
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
                if(pos.X + 4 == 54)
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
        public void Collide(string direction, Position pos, ref int velocity)
        {
            if(direction == "vertical")
            {
                if (GameMap.GetInstance[pos.Y+velocity,pos.X/2] == MapInfo.CEILING)
                {
                    velocity = velocity * -1;
                }
                if (GameMap.GetInstance[pos.Y + velocity, pos.X / 2] == MapInfo.PLAYER)
                {
                    velocity = velocity * -1;
                }
            }
            else if(direction == "horizontal")
            {
                if (GameMap.GetInstance[pos.Y, (pos.X+ (2*velocity))/2] == MapInfo.SIDE)
                {
                    velocity = velocity * -1;
                }
            }
        }
        private void SearchPlayer(Position pos, int velocity)
        {
            for(int x = 0; x <GameMap.GetInstance.MaxX; x++)
            {
                //if(GameMap.GetInstance[pos.Y])
            }
        }
    }
}
