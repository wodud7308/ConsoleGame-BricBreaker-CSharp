using System;
using Management;
using Object;
namespace Object.Location
{
    public class Position
    {
        private int x;
        private int y;
        public int X { get { return x; } private set { x = value; } }
        public int Y { get { return y; } private set { y = value; } }

        public void SetPosition(int x, int y)
        {
            X = x;
            Y = y;  
        }
        public void TransformPosition(int speed, int Yposition)
        {
            X += (speed * 2);
            Y += Yposition;
        }
    }
}
