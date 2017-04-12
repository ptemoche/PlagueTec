using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlagueTec
{
    class Person
    {
        public enum type_person
        {
            hombre,
            mujer
        }

        float[] res_edad = new float[] { 0.15f, 0.4f, 0.1f };

        public int edad;
        public int ticks;
        public float resistencia;
        public type_person gender;
        public bool can_pregnant;
        bool is_pregnant;
        int time_pregnant;
        bool is_parto;
        Virus virus;
        Random prob = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
        public bool is_died;

        public Person()
        {
            ticks = 0;
            edad = prob.Next(90);
            gender = (type_person)(prob.Next()%2);
            is_died = false;
            


        }
        

        /*public  void dead()
        {
            if (this.virus.letalidad == 1)
                is_died = true;
        }*/

        public float resist() {
            Console.WriteLine("La resistencia es "+ res_edad[edad / 30]);
            return res_edad[edad/30];
        
        }
        public void update()
        {
            //Para cumplir años
            if(ticks++ > 2)
            {
                edad++;
                ticks = 0;
            }



            Console.WriteLine("\n edad:{0}, gender:{1}, can_be_Pregnat:{2}",this.edad,this.gender,this.can_pregnant);
            resist();
            puedeEmbarazo();
            


        }

        public void puedeEmbarazo()
        {
            
            if (gender == type_person.mujer && edad>20 && edad<40 && prob.Next()>0.20 && !is_pregnant)
            {
                can_pregnant = true;
            }
        }

        public void embarazo()
        {
            time_pregnant = 0;
            is_pregnant = true; 

        }

        public void whilePregnant()
        {
            if (is_pregnant)
            {
                time_pregnant++;
                if (time_pregnant > 72)
                {
                    is_pregnant = false;
                    is_parto = true;

                }
            }
        }

        public Person parto()
        {
            Person baby = new Person();

            if (virus != null)
                baby.virus = new Virus();

            return baby;

        }

    }
}
