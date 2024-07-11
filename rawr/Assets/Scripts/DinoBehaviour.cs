    using System;
    using System.Collections;
using System.Collections.Generic;
    using Unity.VisualScripting;
    using UnityEngine;

public class DinoBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;

    private Transform planet;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Explosion"))
        {
            DinoDie();
        }
    }

    void DinoDie()
    {
        
        Destroy(gameObject);
    }
}
