using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlagueTec
{
    class transporte
    {                                           
        public int[,] duraciones = new int[,]{ { -1, 5,  -1,  9, 15 },
                                               { -1, -1,  4, -1, -1 },
                                               { -1, -1, -1,  2, -1 }, 
                                               {  9,  6, -1, -1,  3 }, 
                                               { 15, -1, -1,  3, -1 } }; //(duración) ESTO PONEN TODAS LAS FILAS DE LA TABLA LA CUAL EL USUARIO LUEGO PONE POR TECLADO LAS RUTAS

        string[] type_tipo = { "terrestre", "aereo", "maritimo" };      //Declaración de TIPO
        int[] capacidades = { 1, 3, 4 };     //declaración de capacidades
        Random rnd = new Random();

        public string tipo; //A ESTÁ 
        public int capacidad; // YA ESTÁ
        public bool finish_route = false;
        public int tiempo; //TIEMPO QUE LLEO EN EL PRESENTE 
        public int duracion;  //DURACIÓN DEL VIAJE  YA ESTÁ 
        public string ruta;     //SI ESTÁ HABILITADA O NO >:V' YA ESTÁ 
                                // DURACIÓN ES (EJEMPLO DE LIMA A HUARAZ SON 7 HORAS)      TIEMPO ES (EJEM EL VIAJE DE LIMA A HUARAZ TARDÓ 8 HORAS)
        public List<Person> people;
        public int rute_inicio;
        public int rute_finish;
        int died_for_virus;
        int infected;


        Random n = new Random((int)DateTime.Now.Ticks & 0x0000FFFF); //

        public transporte()         //FUNCIÓN
        {
            int num = n.Next(type_tipo.Length);   //número de pasajeros
            tipo = type_tipo[num];      /*para que eliga un transporte random de los atributor*/
            capacidad = capacidades[num]; //DEFINIR CUANTAS RUTAS DE TRANSPORTE SE CREA Y DE QUIÉN A QUIÉN VA
            rute_inicio = 0;                                        // ESCOGER EL INCIO Y EL FIN DE LA RUTA >:V'!!!!!!!!!!!!!!
            rute_finish = 4;
            duracion = duraciones[rute_inicio,rute_finish];
        }

        public void update_passengers()
        {
            this.infected = 0;

            for (int i = people.Count - 1; i > -1; --i)
            {
                Person persona = people[i];

                persona.update();

                if (persona.is_contagious)
                {
                    people[(i + 1) % people.Count].infection();
                    people[((people.Count + (i - 1))) % people.Count].infection();
                    persona.is_contagious = false;
                }

                if (!persona.is_pregnant && persona.can_pregnant && (people[(i + 1) % people.Count].gender == Person.type_person.hombre || people[(people.Count + i - 1) % people.Count].gender == Person.type_person.hombre))
                    persona.embarazo();

                if (persona.is_parto)
                {
                    Person baby = persona.parto();
                    people.Insert(i + 1, baby);
                }
                if (persona.is_died)
                {
                    if (persona.died_for_virus)
                    {
                        died_for_virus++;
                    }
                    people.RemoveAt(i);
                }
                else
                {
                    if (persona.isInfected())
                        infected++;
                }

            }

        }

        public void update()
        {
            if (tiempo >= duracion)
            {
                finish_route = true;
                //Pais destino que reciba los pasajero
               
            }
            
            update_passengers();
            printInfo();
            tiempo++;
        }

        public void printInfo()
        {
            Console.WriteLine("Transporte route: {0} {1} tipo:{2}", this.rute_inicio, this.rute_finish, this.tipo);
            Console.WriteLine("Población: {0} virus: {1}", this.people.Count, this.died_for_virus);
            int infectedPercentage = (this.people.Count > 0) ? (infected * 50) / this.people.Count : 50;
            Console.Write("infected: [");
            for (int i = 0; i < 50; ++i)
            {
                char sign = (infectedPercentage > i) ? '#' : '_';
                Console.Write(sign);
            }
            Console.WriteLine("] {0}%\n", infectedPercentage * 2);
        }
    }
}

/* 1 SEGUNDO ES 4 CICLOS
 * 24 SEGUN  1 AÑO
 * 12 SEGUN    6 MESES
 * 2 SEGUN     1 MES
 * 1 SEGUND        15 DÍAS */


   




