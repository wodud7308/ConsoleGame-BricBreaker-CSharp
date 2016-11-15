using System;
using Map;
using Object.Location;
using Management;
using Object;

namespace Collision
{
    class BallCollider
    {
        public void Collide(string direction, Position pos, ref int velocity, ref int x)
        {
            if(direction == "vertical")
            {
                if (GameMap.GetInstance[pos.Y+velocity,pos.X/2] == MapInfo.CEILING)
                {
                    velocity = velocity * -1;
                }
                if(GameMap.GetInstance[pos.Y+velocity, pos.X/2] == MapInfo.BLOCK)
                {
                    CollideOnBlock(pos.X / 2, pos.Y + velocity);
                    velocity = velocity * -1;
                }
                if (GameMap.GetInstance[pos.Y + velocity, pos.X / 2] == MapInfo.PLAYER)
                {
                    CollideOnPlayer(pos, ref x);
                    velocity = velocity * -1;
                }
            }
            else if(direction == "horizontal")
            {
                if (GameMap.GetInstance[pos.Y, (pos.X+ (2*velocity))/2] == MapInfo.SIDE)
                {
                    velocity = velocity * -1;
                }
                if (GameMap.GetInstance[pos.Y, (pos.X + (2 * velocity)) / 2] == MapInfo.BLOCK)
                {
                    CollideOnBlock(pos.X + (2 * velocity) / 2, pos.Y);
                    velocity = velocity * -1;
                }
            }
        }
        private void CollideOnBlock(int x, int y)
        {
            BlcokManager.GetInstance.AttackBlock(x, y);
        }
        private void CollideOnPlayer(Position pos, ref int velocity)
        {
            int playerX = 0;
            for(int x = 0; x <GameMap.GetInstance.MaxX; x++)
            {
                if(GameMap.GetInstance[pos.Y+1,x]==MapInfo.PLAYER)
                {
                    playerX = x;
                }
            }
            if(playerX - pos.X > -18)
            {
                velocity = velocity * -1;
            }
            else
            {
                return;
            }
        }
    }
}
