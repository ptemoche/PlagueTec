using System;
using System.Collections.Generic;
using System.Threading;

namespace PlagueTec
{
    public class Pais
    {
        enum States { normal, caution, Emergency };
        string name;
        States state;
        float research;
        int population;
        int died_for_virus;
        int infected;
        List<Person> people;
        
        public Pais()
        {
            people = new List<Person>();
            research = 0;
            infected = 0;
            state = States.normal;
        }

        public Pais(string name, int num)
        {
            this.name = name;
            people = new List<Person>();
            research = 0;
            infected = 0;
            state = States.normal;

            for(int i = 0; i < num; ++i)
            {
                people.Add(new Person());
                Thread.Sleep(1);
            }
        }

        public void update()
        {
            this.infected = 0;
                  
            for (int i = people.Count-1; i>-1;--i)
            {
                Person persona = people[i];

                persona.update();

                if (persona.is_contagious)
                {
                    people[(i + 1) % people.Count].infection();
                    people[((people.Count+(i - 1)))%people.Count].infection();
                    persona.is_contagious = false;
                }

                if (!persona.is_pregnant && persona.can_pregnant && (people[(i + 1) % people.Count].gender == Person.type_person.hombre || people[(people.Count + i - 1) % people.Count].gender == Person.type_person.hombre))
                    persona.embarazo();

                if (persona.is_parto)
                {
                    Person baby = persona.parto();
                    people.Insert(i+1,baby);
                }
                if (persona.is_died)
                {
                    if (persona.died_for_virus)
                    {
                        died_for_virus++;
                    }
                    people.RemoveAt(i);
                }else
                {
                    if (persona.isInfected())
                        infected++;
                }
                
            }

            this.printInfo();
        }
                        
        public void researchForCure()
        {
            float delta = ((float)(population - infected) / (float)population) - 0.75f;

            switch (state)
            {
                case States.caution:
                    research += delta * 0.1f;
                    break;
                case States.Emergency:
                    research += delta * 0.3f;
                    break;
            }
        }

        public void printInfo()
        {
            Console.WriteLine("Pais: {0}",this.name);
            Console.WriteLine("Población: {0} virus: {1}", this.people.Count, this.died_for_virus);
            int infectedPercentage = (this.people.Count >0 )?(infected*50) / this.people.Count:50;
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
