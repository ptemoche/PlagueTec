using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlagueTec
{
    class capacidad
    {

        public capacidad(int capacidad)
        {
            Random rnd = new Random();
            int terrestre = rnd.Next(50); 
            int aereo = rnd.Next(100);
            int maritimo = rnd.Next(200); 

        }
        
    }
}
