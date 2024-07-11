using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


public class Spawn : MonoBehaviour
{
    static public KeyCode spawnKey = KeyCode.Space;
    public GameObject meteor;
    public Transform planet;

    private void Start()
    {
        planet = GameObject.FindWithTag("Ground").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(spawnKey) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            if ((Camera.main.ScreenToWorldPoint(Input.mousePosition) - planet.position).magnitude > 27f)
                return;
            
            transform.up = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)planet.position).normalized;
            Vector3 spawnPos = planet.position;
            spawnPos += (transform.up * 28);
            spawnPos += (transform.right * Random.Range(-8, 8));
            
            GameObject obj = Instantiate(meteor, spawnPos,quaternion.identity);
            obj.GetComponent<Meteor>().SetInitialVelocity();
        }
    }
}
