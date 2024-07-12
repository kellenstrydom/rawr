using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class buildings : MonoBehaviour
{
    public int index;
    void Awake()
    {
        Transform planet = GameObject.FindWithTag("Ground").transform;
        
        transform.up = (transform.position - planet.position).normalized;
        transform.position = planet.position + transform.up * 22;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Explosion"))
        {
            GameObject.FindWithTag("Ground").GetComponentsInChildren<ColourController>()[index].RemoveBuilding(transform);
            Destroy(gameObject);
        }
    }
}
