using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class PersonBehaviour : MonoBehaviour
{
    public float breedChance;
    
    private bool canBreed = false;
    
    public ColourController _colourController;

    
    private void Awake()
    {
        StartCoroutine(BreedTimer(5f));
        
        if (_colourController == null)
        {
            Debug.Log("No colour controller");
            return;
        }
        _colourController.allPeople.Add(transform);
        GetComponent<SpriteRenderer>().color = _colourController.colour;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Explosion"))
        {
            Die();
        }
        
        if (!col.CompareTag("people")) return;
        
        //Debug.Log("Collided with: " + col.gameObject.name);
        PersonMovement otherPerson = col.transform.GetComponent<PersonMovement>();

        if (otherPerson == null)
        {
            Debug.LogWarning("ColourController component not found on the collided object.");
            return;
        }
        
        if (!canBreed) return;
        if (_colourController == otherPerson._colourController) // same colour
        {
            //Debug.Log("hitt");
            float randValue = Random.value;
            if (randValue < breedChance)
            {
                Debug.Log("Breeeeeeed");
                Instantiate(gameObject, transform.position, quaternion.identity);
                StartCoroutine(BreedTimer(5f));
            }
        }
    }
    
    IEnumerator BreedTimer(float wait)
    {
        canBreed = false;
        yield return new WaitForSeconds(wait);
        canBreed = true;
    }

    void Die()
    {
        //_colourController.RemovePerson(this);
        Destroy(gameObject);
    }
}
