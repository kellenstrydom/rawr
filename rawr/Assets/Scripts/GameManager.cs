using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public ColourController blueController;
    public ColourController redController;
    public ColourController yellowController;
    public ColourController purpleController;
    public ColourController orangeController;
    public ColourController greenController;

    public GameObject person;

    public AudioSource audioSource;

    public bool allowInput = false;

    public float worldHealth;
    public float decayRate;

    public float pollutionLevel;
    public float polluteRate;

    public int capacityPeople;
    public int capacityBuildings;

    private void Update()
    {
        WorldCount();
    }

    void WorldCount()
    {
        int population = 0;
        int buildings = 0;
        foreach (ColourController colour in GetComponentsInChildren<ColourController>())
        {
            population += colour.allPeople.Count;
            buildings += colour.allBuildings.Count;
        }
        
        OverPopulated(population > capacityPeople);
        
        OverBuilt(buildings > capacityBuildings);
        
    }

    void OverPopulated(bool isOver)
    {
        if (isOver)
        {
            worldHealth -= Time.deltaTime * decayRate;
            
            if (worldHealth <= 0)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void OverBuilt(bool isOver)
    {
        if (isOver)
        {
            pollutionLevel -= Time.deltaTime * polluteRate;
        }
    }
}
