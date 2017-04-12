using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlagueTec
{
    class transporte
    {
        public int[,] array2D = new int[,] { { -1, 5, -1, 9, -1 }, { -1, -1, 4, -1, -1 }, { -1, -1, -1, 2, -1 }, { 9, 6, -1, -1, 3 }, { -1, -1, -1, 3, -1 } }; //(duración) ESTO PONEN TODAS LAS FILAS DE LA TABLA LA CUAL EL USUARIO LUEGO PONE POR TECLADO LAS RUTAS

        string[] type_tipo = { "terrestre", "aereo", "maritimo" };      //Declaración de TIPO
        int[] capacidades = { 15, 35, 55 };     //declaración de capacidades
        Random rnd = new Random();

        public string tipo; //A ESTÁ 
        public int capacidad; // YA ESTÁ
        public bool finish_route = false;
        public int tiempo; //TIEMPO QUE LLEO EN EL PRESENTE 
        public int duracion;  //DURACIÓN DEL VIAJE  YA ESTÁ 
        public string ruta;     //SI ESTÁ HABILITADA O NO >:V' YA ESTÁ 
                                // DURACIÓN ES (EJEMPLO DE LIMA A HUARAZ SON 7 HORAS)      TIEMPO ES (EJEM EL VIAJE DE LIMA A HUARAZ TARDÓ 8 HORAS)

        Random n = new Random((int)DateTime.Now.Ticks & 0x0000FFFF); //

        public transporte()         //FUNCIÓN
        {
            int num = n.Next(type_tipo.Length);   //número de pasajeros
            tipo = type_tipo[num];      /*para que eliga un transporte random de los atributor*/
            capacidad = capacidades[num];

        }

        public void update()
        {
            if (tiempo >= duracion)
            {
                finish_route = true;
                //Pais destino que reciba los pasajero
            }




            tiempo++;
        }
    }
}

/* 1 SEGUNDO ES 4 CICLOS
 * 24 SEGUN  1 AÑO
 * 12 SEGUN    6 MESES
 * 2 SEGUN     1 MES
 * 1 SEGUND        15 DÍAS */





