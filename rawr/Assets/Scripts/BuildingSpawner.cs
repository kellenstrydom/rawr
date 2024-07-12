using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingSpawner : MonoBehaviour
{
   public GameObject[] buildingPrefabs;
    
   public void SpawnBuilding(ColourController controller)
    {
        if (controller.allPeople.Count == 0) return;

        Transform randomPerson = controller.allPeople[Random.Range(0, controller.allPeople.Count)];

        GameObject buildingPrefab = buildingPrefabs[Random.Range(0, buildingPrefabs.Length)];
        GameObject newBuilding = Instantiate(buildingPrefab, randomPerson.position, Quaternion.identity);

        newBuilding.GetComponent<buildings>().Initialise(controller);
        
        

        controller.AddBuilding(newBuilding.transform);
    }
}

