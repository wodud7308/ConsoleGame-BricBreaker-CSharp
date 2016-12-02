using singleton;
using System;
using Map;
using Scenes;

namespace Management
{
    class BlockManager : Singleton<BlockManager>
    {
        private int blockCount;
        public int BlockCount
        {
            get { return blockCount; }
            private set { blockCount = value; }
        }
        public void Initialize()
        {
            BlockCount = 0;
            for(int y=3;y<8; y++)
            {
                for(int x=15;x<25;x++)
                {
                    BlockCount++;                          
                    GameMap.GetInstance.SetObjectInMap(x, y, MapInfo.BLOCK); 
                }
            }
        }

        public void Update()
        {
            if(blockCount == 0)
            {
                Console.Clear();
                SceneManager.GetInstance.ChangeScene(new GameOver());
            }
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
