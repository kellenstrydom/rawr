using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMove : MonoBehaviour
{
    private float worldRotate;
    public float rotSpeed;

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Rotate();
    }

    void GetInput()
    {
        worldRotate = Input.GetAxis("Horizontal");
    }

    void Rotate()
    {
        transform.Rotate(0, 0, worldRotate * rotSpeed * Time.deltaTime);
    }
}
