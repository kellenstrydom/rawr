using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    static public KeyCode spawnKey = KeyCode.F;
    public GameObject meteor;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(spawnKey))
        {
            Instantiate(meteor, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,5),quaternion.identity, transform);
        }
    }
}
