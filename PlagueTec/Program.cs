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
            int month = 0;
            int time = 0;
            int counterMonth = 2;

            World mundo = new World();

            bool flag = true;

            while (flag)
            {
                uint initTime = (uint)DateTime.Now.Ticks;
                Console.Clear();

                month = month + ((++time%counterMonth == 0)?1:0);

                Console.WriteLine("Año # {0} mes #{1}\n", month/12,month%12);



                flag = mundo.update();




                uint milliSeconds = (uint)DateTime.Now.Ticks - initTime;

                int deltaTime = (1000 / fps) - new TimeSpan(milliSeconds).Milliseconds;
                int timeSleep = (deltaTime <0)?10: deltaTime;
                Thread.Sleep(timeSleep);

            }
        }

        public static void initPaises()
        {
            
        }
    }
}







