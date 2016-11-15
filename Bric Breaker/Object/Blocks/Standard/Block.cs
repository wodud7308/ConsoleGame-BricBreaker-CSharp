using System;
using Object.Location;
using Map;

namespace Object.Blocks
{
    class Block
    {
        private Position position;
        private ConsoleColor blockColor;
        private int blockHP =1;

        public ConsoleColor BlockColor
        {
            get { return blockColor; }
            private set { blockColor = value; }
        }
        public int BlockHP
        {
            get { return blockHP; }
            private set { blockHP = value; }
        }         
        public void SetBlockColor(ConsoleColor color)
        {
            BlockColor = color;
        }
        public void DamageBlock(int damage, int x, int y)
        {
            //BlockHP -= damage;
            //if (BlockHP == 0)
            //{
                BlockDestroy(x, y);
           // }
        }
        public void BlockDestroy(int x, int y)
        {
            GameMap.GetInstance.SetObjectInMap(x, y, MapInfo.NONE);
        }
        public void Initialize(int x, int y)
        {
            position = new Position();
            position.SetPosition(x*2, y);
        }
    }
}
