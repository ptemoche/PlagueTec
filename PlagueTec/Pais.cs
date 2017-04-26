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
        int infected;
        List<Person> people;

        public Pais()
        {
            people = new List<Person>();
            research = 0;
            infected = 0;
            state = States.normal;
        }

        public Pais(int num)
        {
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
                        
            for (int i = people.Count-1; i>-1;--i)
            {
                Person persona = people[i];

                persona.update();

                if (persona.is_contagious)
                {
                    people[(i + 1) % people.Count].infection();
                    people[((people.Count+(i - 1)))%people.Count].infection();
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
                    people.RemoveAt(i);
                }
                
            }
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
    }
}
