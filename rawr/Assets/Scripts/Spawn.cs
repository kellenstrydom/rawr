using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


public class Spawn : MonoBehaviour
{
    static public KeyCode spawnKey = KeyCode.F;
    public GameObject meteor;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(spawnKey))
        {
            Debug.Log(Camera.main.transform.up);
            Vector2 spawnPos = Camera.main.transform.position;
            spawnPos += (Vector2)(Camera.main.transform.up * 5);
            spawnPos += (Vector2)(Camera.main.transform.right *
                                  Random.Range(-8, 8));
            GameObject obj = Instantiate(meteor, spawnPos,quaternion.identity);
            obj.GetComponent<Meteor>().SetInitialVelocity();
        }
    }
}
