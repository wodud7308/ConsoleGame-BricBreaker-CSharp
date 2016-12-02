using singleton;
using System;
using System.Threading;

namespace Management
{
    class GameManager : Singleton<GameManager>
    {
        AutoResetEvent AutoReset = new AutoResetEvent(false);
        private readonly int frame = 20;
        private readonly int second = 1000;
        private int currentScore = 0;

        public int Score
        {
            get { return currentScore; }
            set { currentScore += value; }
        }
        public void ResetScore()
        {
            currentScore = 0;
        }

        public void UpdateEachFrame(int frame)
        {
            AutoReset.WaitOne(frame);   
        }

        public void Delay()
        {
 
        }

        public void ShowCurrentScore()
        {
            Console.SetCursorPosition(80, 9);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("S C O R E   :   {0}", Score);
        }
        public void Update()
        {
           UpdateEachFrame(second/frame); 
        }
    }
}
