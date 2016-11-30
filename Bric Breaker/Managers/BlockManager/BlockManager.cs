using singleton;
using System;
using Map;

namespace Management
{
    class BlockManager : Singleton<BlockManager>
    {
        public void Initialize()
        {
            for(int y=5;y<10; y++)
            {
                for(int x=15;x<25;x++)
                {
                    GameMap.GetInstance.SetObjectInMap(x, y, MapInfo.BLOCK); 
                }
            }
        }
        public void AttackBlock(int x, int y)
        {
               
        }
        public void Render()
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 33; x++)
                {
                    Console.SetCursorPosition(x*2, y);
                    if(GameMap.GetInstance[y,x]==MapInfo.BLOCK)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("■");
                    }
                    if(GameMap.GetInstance[y,x]==MapInfo.NONE)
                    {
                        Console.Write("  ");
                    }
                }
            }                                                                           
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
