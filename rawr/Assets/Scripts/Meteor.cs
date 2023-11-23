using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    private Rigidbody2D rb;
    public float meteorSpeed;
    private bool isLanched;
    public float growthRate;
    public GameObject Explosion;
    public float explosionTimeOut;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        isLanched = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLanched)
        {
            transform.localScale *= 1 + growthRate * Time.deltaTime;
            return;
        }
        
        if (Input.GetKeyUp(Spawn.spawnKey))
        {
            Vector2 dir = ((Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position)).normalized;
            rb.velocity = dir * meteorSpeed;
            isLanched = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Explode();
        }    }
    
    private void Explode()
    {
        GameObject obj = Instantiate(Explosion, transform.position, quaternion.identity);
        obj.transform.localScale = (new Vector3(1, 1, 1)) * transform.localScale.y/0.6f;
        Destroy(obj, explosionTimeOut);
        
        Destroy(gameObject);
    }
}
