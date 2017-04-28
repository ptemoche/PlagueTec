using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlagueTec
{
    public class Person
    {
        public enum type_person
        {
            hombre,
            mujer
        }

        float[] res_edad = new float[] { 0.15f, 0.4f, 0.1f };

        public int edad;
        public int ticks;
        public type_person gender;
        public bool can_pregnant;
        public bool is_pregnant;
        int time_pregnant;
        public bool is_parto;
        Virus virus;
        Random prob;
        public bool is_died;
        public bool died_for_virus = false;
        bool pario = false;
        public bool is_contagious = false;

        public Person()
        {
            prob = new Random((int)(DateTime.Now.Ticks & 0x0000FFFF));
            ticks = 0;
            edad = prob.Next(18,60);
            gender = (type_person)(prob.Next() % 2);
            is_died = false;
            if(prob.Next(10) > 7){
                this.infection();
            }


        }


        public void dead()
        {
            /*if (virus!=null && this.virus.letalidad == 1)
            {
                is_died = true;
                virus = null;
            }*/
            if (edad > 89)
            {
                is_died = true;
                virus = null;
            }
        }

        public float resist()
        {
            return res_edad[edad / 30];
        }
        public void update()
        {
            
            //Para cumplir años
            if (ticks++ > 24)
            {
                edad++;
                ticks = 0;
            }

            dead();
            if (is_died)
                return;


            //Console.WriteLine("\n edad:{0}, gender:{1}, virus:{2}, is_contagious:{3}", this.edad, this.gender, (virus!=null)?"infected":"saludable", this.is_contagious);
            resist();
            
            puedeEmbarazo();
            whilePregnant();
            if (virus != null)
            {
                virus.Update();
            }


        }

        public void puedeEmbarazo()
        {

            if (!pario && gender == type_person.mujer && edad > 20 && edad < 40 && prob.Next() > 0.80 && !is_pregnant)
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
                if (time_pregnant > 18)
                {
                    is_pregnant = false;
                    can_pregnant = false;
                    is_parto = true;

                }
            }
        }

        public Person parto()
        {
            Person baby = new Person();
            baby.edad = 0;
            this.is_parto = false;
            this.pario = true;

            if (virus != null)
                baby.infection(); //new Virus(baby); Aqui hubo un error se le pasaba this cuando se le tiene que pasar virus mejor usar la funcion

            return baby;

        }
        public void infection()
        {
            if(this.virus == null)//si no posee el virus
                this.virus = new Virus(this);
            
        }

        public bool isInfected()
        {
            return (virus != null);
        }

    }
}
