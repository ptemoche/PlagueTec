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
            int counterMonth = 2;
            int month = 0;

            List<Pais> paises = new List<Pais>();

            paises.Add(new Pais(3));
            

            while (true)
            {
                uint initTime = (uint)DateTime.Now.Ticks;
                Console.Clear();

                month = month + ((++time%counterMonth == 0)?1:0);

                Console.Write("mes #{0}", month);
                
                foreach(Pais country in paises)
                {

                    country.update();

                }






                uint milliSeconds = (uint)DateTime.Now.Ticks - initTime;

                Thread.Sleep((1000 / fps) - new TimeSpan(milliSeconds).Milliseconds);

            }
        }
    }
}







