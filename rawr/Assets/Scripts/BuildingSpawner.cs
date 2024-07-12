using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingSpawner : MonoBehaviour
{
    public ColourController blueController;
    public ColourController redController;
    public ColourController yellowController;

    public GameObject blueBuildingPrefab;
    public GameObject redBuildingPrefab;
    public GameObject yellowBuildingPrefab;

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
        SpawnBuilding(blueController, blueBuildingPrefab);
    }

    void SpawnRedBuilding()
    {
        SpawnBuilding(redController, redBuildingPrefab);
    }

    void SpawnYellowBuilding()
    {
        SpawnBuilding(yellowController, yellowBuildingPrefab);
    }

    void SpawnBuilding(ColourController controller, GameObject buildingPrefab)
    {
        if (controller.allPeople.Count == 0) return;

        Transform randomPerson = controller.allPeople[Random.Range(0, controller.allPeople.Count)];

        GameObject newBuilding = Instantiate(buildingPrefab, randomPerson.position, Quaternion.identity);

        controller.AddBuilding(newBuilding.transform);
    }
}
