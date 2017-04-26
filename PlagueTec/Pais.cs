using System;
using System.Collections.Generic;

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

        public void update()
        {
            int ind_person = 0;
            foreach (Person persona in people)
            {
                persona.update();

                if (persona.can_pregnant && (people[(ind_person + 1) % people.Count].gender == Person.type_person.hombre || people[(people.Count + ind_person - 1) % people.Count].gender == Person.type_person.hombre))
                    persona.embarazo();

                if (persona.is_parto)
                {
                    Person baby = persona.parto();
                    people.Insert(ind_person+1,baby);
                }
                if (persona.is_died)
                {
                    people.Remove(persona);
                }
                ++ind_person;
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
