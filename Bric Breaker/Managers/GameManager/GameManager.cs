using singleton;
using System.Threading;

namespace Management
{
    class GameManager : Singleton<GameManager>
    {
        AutoResetEvent AutoReset = new AutoResetEvent(false);
        private readonly int frame = 60;
        private readonly int second = 1000;
        private int score = 0;
        private bool isGameOn = false;

        public int Score
        {
            get { return score; }
            private set { score = value; }
        }
        public bool IsGameOn()
        {
            return isGameOn;
        }
        public void GameStart()
        {
            isGameOn = true;
        }

        public void UpdatePerFrame(int frame)
        {
            AutoReset.WaitOne(frame);   
        }

        public void Delay()
        {
            
        }

        public void Update()
        {
            UpdatePerFrame(second/frame); 
        }
    }
}
