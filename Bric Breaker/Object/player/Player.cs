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
        private Collider collider;
        private int playerSize;

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
    
        public Player PlayerInfo
        {
            get { return this; }
        }

        public void Initialize()
        {
            position = new Position();
            collider = new Collider();
            position.SetPosition(38, 17);     
        }

        public void Render()
        {
            Console.SetCursorPosition(position.X, position.Y);
            for (int seq = 0; seq < 7; seq++)
            {
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
                    position.TransformPosition(-1, 0);
                    break;
                case ConsoleKey.RightArrow:
                    Remove();
                    position.TransformPosition(1, 0);
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