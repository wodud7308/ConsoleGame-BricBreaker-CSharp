﻿using System;
using Map;
using Object.Location;
using Collision;

namespace Object
{
    public class Player
    {
        //X, Y position
        private Position position;
        //Collide Check
        private PlayerCollider collider;
        private int playerSize;

        public static int MiddlePos
        {
            get
            {
                int x = 2;
                int count = 0;
                while(count < 3 )
                {
                    if(GameMap.GetInstance[21, x] == MapInfo.PLAYER)
                    {
                        count++;
                    }
                    x++;
                }
                return x+1;
            }
        }
        public static int LeftPos
        {
            get
            {
                int x = 0;
                while(GameMap.GetInstance[21,x]!=MapInfo.PLAYER)
                {
                    x++;
                }
                return x;
            }
        }
        public static int RightPos
        {
            get
            {
                int x = 33;
                while (GameMap.GetInstance[21, x] != MapInfo.PLAYER)
                {
                    x--;
                }
                return x;
            }
        }

        public int PlayerSize
        {
            get { return playerSize; }
            private set { playerSize = value; }
        }

        public Position PlayerPosition
        {
            get { return position; }
            private set { position = value; }
        }
    
        public  Player PlayerInfo
        {
            get { return this; }
        }

        public void Initialize()
        {
            position = new Position();
            collider = new PlayerCollider();
            PlayerSize = 7;
            position.SetPosition(38, 21);
            GameMap.GetInstance.SetObjectInMap("Player", PlayerSize, position);
        }

        public void PlayerPositionInfo()
        {
            Console.SetCursorPosition(20, 5);
            Console.Write("x {0} y {1} value {2}", position.X, position.Y, GameMap.GetInstance[position.Y, position.X / 2]);
        }

        public void Render()
        {
            Console.SetCursorPosition(position.X, position.Y);
            for (int seq = 0; seq < 7; seq++)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("〓");
            }
        }
        //If key input, move that direction
        public void Move(ConsoleKey key)
        {
            if(collider.Collide(position, key))
            {
                return;  
            }
            switch(key)
            {
                case ConsoleKey.LeftArrow:
                    Remove();
                    position.TransformPosition(-2, 0);
                    break;
                case ConsoleKey.RightArrow:
                    Remove();
                    position.TransformPosition(2, 0);
                    break;                   
            }
            GameMap.GetInstance.SetObjectInMap("Player", PlayerSize, position);
        }

        private void Remove()
        {
            Console.SetCursorPosition(position.X, position.Y);
            for (int seq = 0; seq < 7; seq++)
            {
                Console.Write("  ");
            }
            GameMap.GetInstance.SetObjectInMap("None", PlayerSize, position);
        }
    }
}
