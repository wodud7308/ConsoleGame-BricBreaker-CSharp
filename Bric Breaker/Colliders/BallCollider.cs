using System;
using Map;
using Object.Location;
using Management;
using Object;

namespace Collision
{
    class BallCollider
    {
        public bool Collide(string direction, Position pos, int y, int x)
        {
        
            if(direction == "vertical")
            {
                if (GameMap.GetInstance[pos.Y+y,pos.X/2] == MapInfo.CEILING)
                {
                    return true;
                }
             
            }
            else if(direction == "horizontal")
            {
                int xVelocity = 0;
                if( x > 0)
                {
                    xVelocity = 1;
                }
                if(x < 0)
                {
                    xVelocity = -1;
                }
                if (GameMap.GetInstance[pos.Y, (pos.X)/2+xVelocity] == MapInfo.SIDE)
                {
                    return true;
                }
            }
            return false;
        }
        public bool CollideOnBlock(int yVelocity, Position pos)
        {
            if (GameMap.GetInstance[pos.Y + yVelocity, pos.X / 2] == MapInfo.BLOCK)
            {
                GameMap.GetInstance.SetObjectInMap(pos.X / 2, pos.Y+yVelocity, MapInfo.NONE);
                GameManager.GetInstance.Score = 100;
                return true;
            }
            return false;
        }
        public bool CollideOnBlock(int xVelocity, int yVelocity, Position pos)
        {
            int x = pos.X;
            if(xVelocity < 0)
            {
                xVelocity = -1;
            }
            if(xVelocity > 0)
            {
                xVelocity = 1;
            }
            int y = pos.Y + yVelocity;
   
            if (GameMap.GetInstance[y, x / 2 + xVelocity] == MapInfo.BLOCK)
            {
                GameMap.GetInstance.SetObjectInMap(x / 2 + xVelocity, y, MapInfo.NONE);
                GameManager.GetInstance.Score = 100;
                return true;
            }
            return false;
        }
        public bool CollideOnPlayer(Position pos, int yVelocity)
        {
            if (GameMap.GetInstance[pos.Y + yVelocity, pos.X / 2] == MapInfo.PLAYER)
            {
                return true;
            }
            return false;
        }
    }
}
