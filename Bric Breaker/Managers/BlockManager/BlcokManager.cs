using singleton;
using Object.Blocks;
using System;
using Map;

namespace Management
{
    class BlcokManager : Singleton<BlcokManager>
    {
        private Block[,] blocks = new Block[5, 33];
        public Block this[int y, int x]
        {
            get { return blocks[y, x]; }
            private set { blocks[y, x] = value; }   
        }
        public void Initialize()
        { 
            for(int y=0;y<5; y++)
            {
                for(int x=0;x<33;x++)
                {
                    blocks[y, x] = new Block();
                    blocks[y, x].Initialize(x, y);
                    GameMap.GetInstance.SetObjectInMap(x+1, y+1, MapInfo.BLOCK);
                }
            }
        }
        public void AttackBlock(int x, int y)
        {
            blocks[y-1, x].DamageBlock(1, x, y-1);
        }
        public void Render()
        {
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 33; x++)
                {
                    Console.SetCursorPosition((x+1) * 2, y);
                    if(GameMap.GetInstance[y,x+1]==MapInfo.BLOCK)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("■");
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
