using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class buildings : MonoBehaviour
{
    public int index;
    public ColourController controller;

    public void Initialise(ColourController controller)
    {
        this.controller = controller;
        Transform planet = GameObject.FindWithTag("Ground").transform;
        transform.up = (transform.position - planet.position).normalized;
        transform.position = planet.position + transform.up * 22;
        GetComponent<SpriteRenderer>().color = controller.colour;

    }
    void start()
    {
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Explosion"))
        {
            GameObject.FindWithTag("Ground").GetComponentsInChildren<ColourController>()[index].RemoveBuilding(transform);
            controller.RemoveBuilding(transform);
            Destroy(gameObject);
        }
    }
}
