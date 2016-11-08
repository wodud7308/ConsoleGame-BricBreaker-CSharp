using System;
using Object.Location;
using singleton;
namespace Map
{
    //MapInformation
    enum MapInfo
    {
        NONE = 0,
        BLOCK = 1,
        BALL = 2,
        PLAYER = 3,
        WALL = 4,
        DEAD_LINE = 5
    };
    class GameMap : Singleton<GameMap>
    {
        //Console Width/2
        readonly private int maxX = 42;
        //Console Height
        readonly private int maxY = 23;
        //MapInformation array
        private MapInfo[,] map = new MapInfo[23, 42];

        //Map Indexer
        public MapInfo this[int y ,int x]
        {
            get { return map[y, x]; }
            set { map[y, x] = value; }
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
            for(int x = 0; x < maxX; x++)
            {
                map[0, x] = MapInfo.WALL;
            }
            for(int x = 0; x<maxX; x+=maxX-1)
            {
                for(int y=0; y<maxY; y++)
                {
                    map[y, x] = MapInfo.WALL;
                }
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
                        case MapInfo.WALL:
                            Console.Write("■");
                            break;
                        case MapInfo.DEAD_LINE:
                            Console.Write("△");
                            break;
                    }
                }
            }
        }
        //Test Function
        public void Render(bool IsTest)
        {
            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    Console.SetCursorPosition(x * 2, y);
                    switch (GameMap.GetInstance[y, x])
                    {
                        case MapInfo.NONE:
                            Console.Write("0");
                            break;
                        case MapInfo.WALL:
                            Console.Write("1");
                            break;
                        case MapInfo.PLAYER:
                            Console.Write("5");
                            break;
                    }
                }
            }
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
