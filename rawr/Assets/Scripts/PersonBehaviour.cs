using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class PersonBehaviour : MonoBehaviour
{
    public float breedChance;
    public float killChance;
    public float crossChance;
    
    private bool canBreed = false;
    public float breedInterval;
    
    public ColourController _colourController;

    private GameManager _gm;

    private Animator deadAni;

    public GameObject loveObj;

    public AudioSource audioSource; 
    public AudioClip loveSFX; 
    
    private void Start()
    {
        StartCoroutine(BreedTimer(breedInterval));
        
        if (_colourController == null)
        {
            Debug.Log("No colour controller");
            return;
        }
        _colourController.AddPerson(transform);
        GetComponent<SpriteRenderer>().color = _colourController.colour;

        _gm = GameObject.FindWithTag("Ground").GetComponent<GameManager>();

        deadAni = GetComponent<Animator>(); 
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
            if (_colourController.canBreed)
            {
                //Debug.Log("hitt");
                float randValue = Random.value;
                if (randValue < breedChance)
                {
                    Debug.Log("Breeeeeeed");
                    // Instantiate(gameObject, transform.position, quaternion.identity);
                    SpawnPerson(_colourController);
                    StartCoroutine(BreedTimer(breedInterval));
                }
            }
            
        }
        else
        {
            float randValue = Random.value;
            if (randValue < killChance)
            {
                otherPerson.GetComponent<PersonBehaviour>().Die();
            }
            else if (randValue < killChance + crossChance)
            {
                ColourController otherController = col.GetComponent<PersonBehaviour>()._colourController;

                bool isBlue = _colourController == _gm.blueController || otherController == _gm.blueController;
                
                bool isRed = _colourController == _gm.redController || otherController == _gm.redController;
                
                bool isYellow = _colourController == _gm.yellowController || otherController == _gm.yellowController;

                // purple
                if (isBlue && isRed && _gm.purpleController.canBreed)
                {
                    Debug.Log("crosssss Breeeeeeed");
                    SpawnPerson(_gm.purpleController);
                    
                    StartCoroutine(BreedTimer(breedInterval));
                }

                // orange
                if (isYellow && isRed && _gm.orangeController.canBreed)
                {
                    Debug.Log("crosssss Breeeeeeed");
                    SpawnPerson(_gm.orangeController);
                    
                    StartCoroutine(BreedTimer(breedInterval));
                }

                // green
                if (isYellow && isBlue && _gm.greenController.canBreed)
                {
                    Debug.Log("crosssss Breeeeeeed");
                    SpawnPerson(_gm.greenController);
                    
                    StartCoroutine(BreedTimer(breedInterval));
                }
                
            }
            
        }
    }


    void SpawnPerson(ColourController controller)
    {
        GameObject person = Instantiate(_gm.person, transform.position, quaternion.identity);
        person.GetComponent<PersonMovement>()._colourController = controller;
        person.GetComponent<PersonBehaviour>()._colourController = controller;

        audioSource.PlayOneShot(loveSFX, 0.4f); 
        Destroy(Instantiate(loveObj, transform.position, transform.rotation, transform),1.2f);
        
        
    }
    
    IEnumerator BreedTimer(float wait)
    {
        canBreed = false;
        yield return new WaitForSeconds(wait);
        canBreed = true;
    }

    public void Die()
    {
        _colourController.RemovePerson(transform);
        Destroy(gameObject,3);
        GetComponent<PersonMovement>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        
        deadAni.SetBool("die",true);
        transform.localScale = new Vector3(1, 1, 1) * 1.35f;
    }
}
