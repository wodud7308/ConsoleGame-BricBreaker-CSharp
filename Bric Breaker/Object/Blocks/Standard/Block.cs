using System;
using Object.Location;        

namespace Object
{
    class Block
    {
        private Position BlockPosition;
        private ConsoleColor blockColor;
        private int blockHP;

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
        public void BlockDamaged(int damage)
        {
            BlockHP -= damage;
            if(BlockHP == 0)
            {
                BlockDestroy();
            }             
        }
        public void BlockDestroy()
        {

        }
    }
}
