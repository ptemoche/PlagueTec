using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlagueTec
{
    class transporte
    {
        string[] type_tipo = { "terrestre", "aereo", "maritimo" };
        int[] capacidades = {15 ,35 , 55 };
        Random rnd = new Random();


        public string tipo;
        public int capacidad;
        public int tiempo;
        public int duracion;
        public string ruta;
        public string informacion;

        Random n = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);

        public transporte()
        {
            int num = n.Next(type_tipo.Length);
            tipo = type_tipo[num];
            capacidad = capacidades[num];
           
        }
        
       public void update()
        {
            if (tiempo >= duracion)
            {
                //Pais destino que reciba los pasajeros
            }
                tiempo++;
        }

    }
     /* 1 SEGUNDO ES 4 CICLOS
      * 24 SEGUN  1 AÑO
      * 12 SEGUN    6 MESES
      * 2 SEGUN     1 MES
      * 1 SEGUND        15 DÍAS */


        
    }

