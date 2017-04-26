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

        float timeinfect = 0; 

        float porcent_virus = 0.0f ; 
       
        
        Person Persona = new Person(); 


        public Virus()
        {
            this.name = "k1r10";

            ticks = 0; 

            //Console.WriteLine("La letalidad que tiene esta persona es :" + letalidad);

            this.letalidad = 1 - (Persona.resistencia)+timeinfect;
            this.tiemp_de_reproduccion = 0;
           
        }

        public void VirusAttack()
        {
            Random n = new Random((int)DateTime.Now.Ticks & 0X0000FFFF);

            float x = Convert.ToSingle(n.NextDouble()); 

            if(letalidad < x)
            {
                porcent_virus += 0.0175f; 
                
            }
           
            if (porcent_virus >= 1.0f)
            {

                Persona.is_died = true; 

            }
                           
               

        }
       

        public void Update()
        {

            TimeReproduccion();    
                VirusAttack();
                


        }
       
        public void TimeReproduccion()
        {
            tiemp_de_reproduccion += 0.15f;

            this.tiempotrans += 0.05f;

            if(tiempotrans >= 0.25f)
            {
                timeinfect += 0.05f; 
                this.tiempotrans = 0.075f;

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
