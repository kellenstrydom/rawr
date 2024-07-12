using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourController : MonoBehaviour
{
    public List<Transform> allBuildings;
    public List<Transform> allPeople;

    public Color colour;

    public void AddPerson(PersonMovement person)
    {
        allPeople.Add(person.transform);
    }

    public void RemovePerson(PersonMovement person)
    {
        
    }

    public void AddBuilding(Transform building)
    {
        allBuildings.Add(building);
    }
    
    public void RemoveBuilding(Transform building)
    {
        allBuildings.Remove(building);
    }
}
