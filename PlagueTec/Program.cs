using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PlagueTec
{
    class Program
    {
        static void Main(string[] args)
        {
            int fps = 4;
            int time = 0;
            int counterDay = 4;
            int day = 0;
            transporte test = new transporte();


            Person girl = new Person();

            while (true)
            {
                uint initTime = (uint)DateTime.Now.Ticks;
                Console.Clear();

                day = day + ((++time%counterDay == 0)?1:0);

                Console.Write("dia #{0}", day);
                girl.update();
                test.update();

                uint milliSeconds = (uint)DateTime.Now.Ticks - initTime;
                Thread.Sleep((1000 / fps) - new TimeSpan(milliSeconds).Milliseconds);

            }
        }
    }
}







