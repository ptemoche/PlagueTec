using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlagueTec
{
    class World
    {
        
        List<Pais> paises = new List<Pais>();
        
        int numPaises = 5;
        string[] nombres = new string[5] { "pais 1", "pais 2", "pais 3", "pais 4", "pais 5" };
        int[] poblacion = new int[5] { 100, 150, 175, 200, 250 };

        

        public World()
        {
            initCountries();

        }

        public bool update()
        {
            foreach (Pais country in paises)
            {

                country.update();

            }
            this.printInfo();
            return true;
        }

        public void initCountries()
        {
            for (int i = 0; i<this.numPaises; ++i)
            {
                paises.Add(new Pais(nombres[i], poblacion[i]));
            }
            
        }

        public void printInfo()
        {
            
        }
    }
}
