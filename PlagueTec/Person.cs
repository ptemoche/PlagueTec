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

        public int edad;
        public int ticks;
        public int resistencia;
        public type_person gender;
        public bool can_pregnant;
        bool is_pregnant;
        int time_pregnant;
        bool is_parto;
        bool virus;

        Random prob = new Random();

        public Person()
        {
            ticks = 0;
            edad = prob.Next(80);
            gender = type_person.mujer;
        }

        public void update()
        {
            if(ticks++ > 96)
            {
                edad++;
                ticks = 0;
                Console.WriteLine(edad);
            }

            puedeEmbarazo();

            
        }

        public void puedeEmbarazo()
        {
            
            if (gender == type_person.mujer && edad>20 && edad<40 && prob.Next()>0.5 && !is_pregnant)
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
            return new Person();

        }

    }
}
