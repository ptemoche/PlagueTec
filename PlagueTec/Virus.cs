using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlagueTec
{
    class Virus
    {
        public string name;
        public float letalidad;
        public float tiemp_de_reproduccion;
        public int ticks; 

        
        float tiempotrans;

        float timeinfect; 

        float porcent_virus; 
       

        Person persona; 


        public Virus(Person _p)
        {
            this.name = "k1r10";
            this.persona = _p;
            this.porcent_virus = 0.0f;
            ticks = 0;
            timeinfect = 0;

            //Console.WriteLine("La letalidad que tiene esta persona es :" + letalidad);

            this.letalidad = 1.0f - (persona.resist())+timeinfect;

            this.tiemp_de_reproduccion = 0;
            
        }

        public void VirusAttack()
        {
            Random n = new Random((int)DateTime.Now.Ticks & 0X0000FFFF);

            float x = Convert.ToSingle(n.NextDouble());
            this.letalidad = 1.0f - persona.resist(); //+ timeinfect;
            
            if (letalidad > x)//tiene que ser mayor para q la probabilidad aumente con mayor letalidad
            {
                this.porcent_virus += 0.0175f; 
                
            }
            //Console.WriteLine("letalidad {0}, resistencia {1}, porcentaje {2}, variable {3} bool:{4}", this.letalidad, persona.resist(), this.porcent_virus, x, (letalidad > x));

            if (this.porcent_virus >= 1.0f)
            {

                persona.is_died = true;
                persona.died_for_virus = true;

            }
                           
               

        }
       

        public void Update()
        {

            TimeReproduccion();    
                VirusAttack();
                


        }
       
        public void TimeReproduccion()
        {
            //tiemp_de_reproduccion += 0.15f;

            this.tiempotrans += 0.05f;

            if(tiempotrans >= 0.5f)
            {
                //timeinfect += 0.05f; 
                this.tiempotrans = -0.5f;
                persona.is_contagious = true;

            }

        }



        /*
         public void Sintomas()
         {
             string[] Grado1 = { "Sudoración", "Cansancio", "Dolor de Cabeza" };
             string[] Grado2 = { "Vomito", "Desmayo" };
             string[] Grado3 = { "Sangre por la Boca ", "Cangrena " };

             Random n = new Random((int)DateTime.Now.Ticks & 0X0000FFFF);

             if (porcent_virus <= 0.30 && porcent_virus >= 0.01 )
             {

                 string name = Grado1[n.Next(Grado1.Length)];

             }
             else if (porcent_virus > 0.30 && porcent_virus <= 0.60)
             {

                 string name = Grado2[n.Next(Grado2.Length)];
             }
             else if (porcent_virus > 0.60 )
             {

                 string name = Grado3[n.Next(Grado3.Length)];
             }

             Console.WriteLine("La persona tiene " + name );


         }
    */
    }

    
}
