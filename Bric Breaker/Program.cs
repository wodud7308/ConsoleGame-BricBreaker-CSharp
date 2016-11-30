using System;
using Management;
using System.Collections.Generic;
using singleton;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Object;
namespace Bric_Breaker
{
    class Program
    {
        static void Main(string[] args)
          {

            Console.SetWindowSize(104, 25);
            Console.SetBufferSize(104, 25);
            Game.GetInstance.Initailize();
            Game.GetInstance.Update();
        }
    }
}
