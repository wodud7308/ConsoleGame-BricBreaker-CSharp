using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bric_Breaker.Colliders
{
    class BlockCollider
    {
        private int x;
        private int y;
        
        public int Xpos
        {
            get { return x; }
            private set { x = value; }
        }
        public int Ypos
        {
            get { return y; }
            private set { y = value; }
        }
        BlockCollider(int x, int y)
        {
            Xpos = x;
            Ypos = y;
        }
        public void Collide()
        {
        }
    }
}
