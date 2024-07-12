using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourController : MonoBehaviour
{
    public List<Transform> allBuildings;
    public List<Transform> allPeople;

    public Color colour;

    public void AddPerson(Transform person)
    {
        allPeople.Add(person);
    }

    public void RemovePerson(Transform person)
    {
        allPeople.Remove(person);
    }

    public void AddBuilding(Transform building)
    {
        
    }
    
    public void RemoveBuilding(Transform building)
    {
        
    }
}
