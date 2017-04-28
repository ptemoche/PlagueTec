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
        List<transporte> transportes = new List<transporte>();
        
        int numPaises = 5;
        string[] nombres = new string[5] { "pais 1", "pais 2", "pais 3", "pais 4", "pais 5" };
        int[] poblacion = new int[5] { 100, 150, 175, 200, 250 };
        int tick = 0;
        int travel = 20;
        

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

            for(int i=(transportes.Count-1); i>-1; --i)
            {
                transporte transport = transportes[i];

                transport.update();

                if (transport.finish_route)
                {
                    paises[transport.rute_finish].people.AddRange(transport.people);
                    transportes.RemoveAt(i);
                }


            }

            if (tick++ > travel)
            {
                transporte newTransport = new transporte();
                int cap = newTransport.capacidad;
                if (paises[newTransport.rute_inicio].people.Count>cap) {
                    newTransport.people = paises[newTransport.rute_inicio].people.GetRange(0, cap);
                    paises[newTransport.rute_inicio].people.RemoveRange(0, cap);
                    transportes.Add(newTransport);
                }
                tick = 0;
            }

            return true;
        }

        public void initCountries()
        {
            for (int i = 0; i<this.numPaises; ++i)
            {
                paises.Add(new Pais(nombres[i], poblacion[i]));
            }
            
        }

        public void create_transporte()
        {
            
        }
    }
}
