using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
public class Meteor : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform planet;
    public float meteorSpeed;
    public Vector2 currentVec;
    public float meteorAcceleration;
    private bool isLanched;
    public float growthRate;
    public GameObject Explosion;
    public float explosionTimeOut;
    
    // Start is called before the first frame update
    void Awake()
    {
        planet = GameObject.FindWithTag("Ground").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale *= 1 + growthRate * Time.deltaTime;
        
        ApplyGravity();
        transform.Translate(currentVec * Time.deltaTime);
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Explode();
        }    
    }
    
    private void Explode()
    {
        GameObject obj = Instantiate(Explosion, transform.position, quaternion.identity);
        obj.transform.localScale = (new Vector3(1, 1, 1)) * transform.localScale.y/0.6f;
        Destroy(obj, explosionTimeOut);
        
        Destroy(gameObject);
    }

    void ApplyGravity()
    {
        //transform.up = (planet.position - transform.position).normalized;
        currentVec += (Vector2)((meteorAcceleration * Time.deltaTime) * (planet.position - transform.position).normalized);
    }
    public void SetInitialVelocity()
    {
        currentVec = Vector2.zero;
        Vector3 dir = Vector3.Normalize(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        
        currentVec += (Vector2)dir * meteorSpeed;
        Debug.Log(currentVec.magnitude);
    }
}
