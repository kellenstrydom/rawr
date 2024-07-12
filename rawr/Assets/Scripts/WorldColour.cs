using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldColour : MonoBehaviour
{
    public List<Color> peopleColors = new List<Color>();

    void Start()
    {
        // peopleColors.Add(Color.red);
        // peopleColors.Add(Color.blue);
        // peopleColors.Add(Color.yellow);

        //UpdateAverageColor();
    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.A))
        // {
        //     //AddPerson(new Color(1, 0.5f, 0));
        //     AddPerson(Color.red); 
        // }
        // if (Input.GetKeyDown(KeyCode.B))
        // {
        //     RemovePerson(Color.red);
        // }
    }

    public void AddPerson(Color color)
    {
        peopleColors.Add(color);
        UpdateAverageColor();
    }

    public void RemovePerson(Color color)
    {
        peopleColors.Remove(color);
        UpdateAverageColor();
    }

    void UpdateAverageColor()
    {
        if (peopleColors.Count == 0)
            return;

        Color averageColor = CalculateAverageColor();
        GetComponent<SpriteRenderer>().color = averageColor;
    }

    Color CalculateAverageColor()
    {
        float r = 0, g = 0, b = 0;
        foreach (Color color in peopleColors)
        {
            r += color.r;
            g += color.g;
            b += color.b;
        }

        r /= peopleColors.Count;
        g /= peopleColors.Count;
        b /= peopleColors.Count;

        return new Color(r, g, b);
    }
}
