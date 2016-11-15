using System;
using Map;
using Object.Location;
using Object;

namespace Collision
{
    class PlayerCollider
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
                if(pos.X + 2 == 56)
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
    }
}
