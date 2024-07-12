using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtmosphereBad : MonoBehaviour
{
    public float alphaIncrement = 0.1f;
    public SpriteRenderer spriteRenderer;
    public BuildingSpawner bs; 

    void Update()
    {

        //if ()
        //{
        //    IncreaseAlphaValue();
        //}
    }

    void IncreaseAlphaValue()
    {
        if (spriteRenderer != null)
        {
            Color color = spriteRenderer.color;
            color.a += alphaIncrement;
            color.a = Mathf.Clamp(color.a, 0, 1);
            spriteRenderer.color = color;
        }
    }
}
