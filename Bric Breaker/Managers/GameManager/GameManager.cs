using singleton;
using System;
using System.Threading;

namespace Management
{
    class GameManager : Singleton<GameManager>
    {
        AutoResetEvent AutoReset = new AutoResetEvent(false);
        private readonly int frame = 15;
        private readonly int second = 1000;
        private int score = 0;

        public int Score
        {
            get { return score; }
            private set { score = value; }
        }

        public void UpdateEachFrame(int frame)
        {
            AutoReset.WaitOne(frame);   
        }

        public void Delay()
        {
 
        }

        public void Update()
        {
            Thread.Sleep(second/frame); 
        }
    }
}
