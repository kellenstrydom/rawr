using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColourController : MonoBehaviour
{
    public List<Transform> allBuildings;
    public List<Transform> allPeople;
    private BuildingSpawner _buildingSpawner;
    private WorldColour _worldColour;

    public Color colour;

    public float chanceSpawning;
    public float chanceRate;
    
    

    private void Awake()
    {
        _worldColour = GameObject.FindWithTag("Ground").GetComponent<WorldColour>();
        _buildingSpawner = GameObject.FindWithTag("Ground").GetComponent<BuildingSpawner>();
        StartCoroutine(SpawnTimer(5f));
    }

    public void AddPerson(Transform person)
    {
        allPeople.Add(person);
        _worldColour.AddPerson(colour);
    }

    public void RemovePerson(Transform person)
    {
        allPeople.Remove(person);
        _worldColour.RemovePerson(colour);
    }

    public void AddBuilding(Transform building)
    {
        allBuildings.Add(building);
    }
    
    public void RemoveBuilding(Transform building)
    {
        allBuildings.Remove(building);
    }

    IEnumerator SpawnTimer(float wait)
    {
        yield return new WaitForSeconds(wait);
        
        float randValue = Random.value;
        if (randValue < chanceSpawning)
        {
            _buildingSpawner.SpawnBuilding(this);
            chanceSpawning = .1f;
        }
        else
        {
            chanceSpawning += chanceRate;
        }

        StartCoroutine(SpawnTimer(wait));
    }
}
