using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingSpawner : MonoBehaviour
{
    public ColourController blueController;
    public ColourController redController;
    public ColourController yellowController;
    
    public GameObject[] buildingPrefabs;
    
    public GameObject[] blueBuildingPrefabs;
    public GameObject[] redBuildingPrefabs;
    public GameObject[] yellowBuildingPrefabs;

    public Button blueBuildingButton;
    public Button redBuildingButton;
    public Button yellowBuildingButton;

    void Start()
    {
        // blueBuildingButton.onClick.AddListener(SpawnBlueBuilding);
        // redBuildingButton.onClick.AddListener(SpawnRedBuilding);
        // yellowBuildingButton.onClick.AddListener(SpawnYellowBuilding);
    }

    void SpawnBlueBuilding()
    {
        SpawnBuilding(blueController);
    }

    void SpawnRedBuilding()
    {
        SpawnBuilding(redController);
    }

    void SpawnYellowBuilding()
    {
        SpawnBuilding(yellowController);
    }

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

