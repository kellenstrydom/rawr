using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingSpawner : MonoBehaviour
{
    public ColourController blueController;
    public ColourController redController;
    public ColourController yellowController;

    public GameObject[] blueBuildingPrefabs;
    public GameObject[] redBuildingPrefabs;
    public GameObject[] yellowBuildingPrefabs;

    public Button blueBuildingButton;
    public Button redBuildingButton;
    public Button yellowBuildingButton;


    void Start()
    {
        blueBuildingButton.onClick.AddListener(SpawnBlueBuilding);
        redBuildingButton.onClick.AddListener(SpawnRedBuilding);
        yellowBuildingButton.onClick.AddListener(SpawnYellowBuilding);
    }

    void SpawnBlueBuilding()
    {
        SpawnBuilding(blueController, blueBuildingPrefabs);
    }

    void SpawnRedBuilding()
    {
        SpawnBuilding(redController, redBuildingPrefabs);
    }

    void SpawnYellowBuilding()
    {
        SpawnBuilding(yellowController, yellowBuildingPrefabs);
    }

    void SpawnBuilding(ColourController controller, GameObject[] buildingPrefabs)
    {
        if (controller.allPeople.Count == 0) return;

        Transform randomPerson = controller.allPeople[Random.Range(0, controller.allPeople.Count)];

        GameObject buildingPrefab = buildingPrefabs[Random.Range(0, buildingPrefabs.Length)];
        GameObject newBuilding = Instantiate(buildingPrefab, randomPerson.position, Quaternion.identity);

        controller.AddBuilding(newBuilding.transform);
    }
}

