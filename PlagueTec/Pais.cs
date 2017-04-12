using System;
using System.Collections.Generic;

public class Pais
{
    enum States { normal, caution, Emergency};
    string name;
    States state;
    float research;
    int population;
    int infected;
    List<int> people;

	public Pais()
	{
        people = new List<int>();
        research = 0;
        infected = 0;
        state = States.normal;
	}

    public void update()
    {
        for(int i = 0; i < people.Count; i++)
        {

        }
    }

    public void researchForCure()
    {
        float delta = ((float)(population - infected) / (float)population)-0.75f;

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
