using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtmosphereSpin : MonoBehaviour
{
    public float rotationSpeed = 10f;
    //public float alphaValue = 0.5f;
    public float alphaIncrement = 0.1f;
    private SpriteRenderer spriteRenderer;

    void Update()
    {
        transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
    }
}
