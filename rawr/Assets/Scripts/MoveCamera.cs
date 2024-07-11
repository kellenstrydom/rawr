using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float rotSpeed;
    private Transform planet;

    // Start is called before the first frame update
    void Start()
    {
        planet = GameObject.FindWithTag("Ground").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }
    

    void Rotate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.RotateAround(planet.position, Vector3.back,horizontalInput * rotSpeed * Time.deltaTime );
    }
}
