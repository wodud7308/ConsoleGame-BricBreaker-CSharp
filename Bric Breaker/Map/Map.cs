using System;
using Object.Location;
using singleton;
namespace Map
{
    //MapInformation
    enum MapInfo
    {
        NONE,
        BLOCK,
        BALL,
        PLAYER,
        CEILING,
        SIDE,
        DEAD_LINE
    };
    class GameMap : Singleton<GameMap>
    {
        //Console Width/2  (without score board)
        readonly private int maxX = 35;
        //Console Height
        readonly private int maxY = 25;
        //MapInformation array
        private MapInfo[,] map = new MapInfo[25, 35];

        public int MaxX
        {
            get { return maxX; }
        }

        public int MaxY
        {
            get { return maxY; }
        }

        //Map Indexer
        public MapInfo this[int y ,int x]
        {
            get { return map[y, x]; }
            private set { map[y, x] = value; }
        }

        //Map Initializing
        public void SetMap()
        {
            for (int y = 0; y < maxY; y++)
            {
                for(int x = 0; x<maxX;x++)
                {
                    map[y, x] = MapInfo.NONE;
                }
            }
            for (int x = 0; x < maxX; x += maxX - 1)
            {
                for (int y = 0; y < maxY; y++)
                {
                    map[y, x] = MapInfo.SIDE;
                }
            }
            for (int x = 0; x < maxX; x++)
            {
                map[0, x] = MapInfo.CEILING;
            }
            for (int x = 0; x < maxX; x++)
            {
                map[maxY-1, x] = MapInfo.DEAD_LINE;
            }

        }

        //Map Rendering
        public void Render()
        {
            for(int y=0; y<maxY; y++)
            {
                for(int x=0; x<maxX; x++)
                {
                    Console.SetCursorPosition(x * 2, y);
                    switch(GameMap.GetInstance[y,x])
                    {             
                        case MapInfo.NONE:
                            Console.Write("  ");
                            break;
                        case MapInfo.CEILING:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("▤");
                            break;
                        case MapInfo.SIDE:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("▥");
                            break;
                        case MapInfo.DEAD_LINE:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("▲");
                            break;
                    }
                }
            }
        }
        public void TestRender()
        {
            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    Console.SetCursorPosition(x * 2, y);
                    switch (GameMap.GetInstance[y, x])
                    {
                        case MapInfo.NONE:
                            Console.Write("  ");
                            break;
                        case MapInfo.CEILING:
                            Console.Write("▥");
                            break;
                        case MapInfo.SIDE:
                            Console.Write("▤");
                            break;
                        case MapInfo.PLAYER:
                            Console.Write("〓");
                            break;
                        case MapInfo.DEAD_LINE:
                            Console.Write("△");
                            break;
                    }
                }
            }
        }
        public void SetObjectInMap(int Xpos, int Ypos, MapInfo data)
        {
            GameMap.GetInstance[Ypos, Xpos] = data;   
        }
        public void SetObjectInMap(string ObjectName, int size, Position pos)
        {
            MapInfo data = MapInfo.NONE;
             if(ObjectName == "Player")
            {
                data = MapInfo.PLAYER;
            }
            else if(ObjectName =="Ball")
            {
                data = MapInfo.BALL;
            }
            else if(ObjectName =="None")
            {
                data = MapInfo.NONE;
            }
            for(int seq=0; seq<size; seq ++)
            {
                map[pos.Y, (pos.X / 2) + seq] = data;
            }
        }
        //Map Awake
        public void Initiailize()
        {
            SetMap();
            Render();
        }
    }
}
