using System;
using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;
using Random = UnityEngine.Random;

public class PersonMovement : MonoBehaviour
{
    public enum State
    {
        still,
        left,
        right
    }

    [Serializable]
    struct probalities
    {
        public float left;
        public float right;
        public float still;
    }
    
    public Transform circle; 
    public float speed = 30.0f;
    public float changeDirectionInterval = 2.0f;
    public State currentState;

    public AnimationCurve curve;

    public float stillChance;
    
    public ColourController _colourController;

    
    private float radius;
    private float angle; 
    
    private bool moveClockwise; 
    private float nextDirectionChangeTime; 

    void Awake()
    {
        circle = GameObject.FindWithTag("Ground").transform;
            
        if (circle == null)
        {
            Debug.LogError("Circle transform is not assigned.");
            return;
        }
        
        
        StartCoroutine(Tick(changeDirectionInterval));
        
        radius = Vector3.Distance(transform.position, circle.position);

        Vector3 direction = transform.position - circle.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        UpdatePositionAndRotation();

        
        //moveClockwise = Random.value < 0.5f;



        //nextDirectionChangeTime = Time.time + changeDirectionInterval;
    }

    void Update()
    {
        // if (Time.time >= nextDirectionChangeTime)
        // {
        //     float randomAngle = Random.Range(0.0f, 360.0f);
        //     moveClockwise = angle < randomAngle;
        //
        //     nextDirectionChangeTime = Time.time + changeDirectionInterval;
        // }

        switch (currentState)
        {
            case State.right:
                angle -= speed * Time.deltaTime;
                break;
            case State.left:
                angle += speed * Time.deltaTime;
                break;
            case State.still:
                break;
        }
        //angle += moveClockwise ? speed * Time.deltaTime : -speed * Time.deltaTime;

        if (angle >= 360.0f)
        {
            angle -= 360.0f;
        }
        else if (angle < 0.0f)
        {
            angle += 360.0f;
        }

        UpdatePositionAndRotation();
    }

    Transform ClosestBuilding()
    {
        Transform closestBuilding = null;
        foreach (Transform building in _colourController.allBuildings)
        {
            if (closestBuilding == null)
            {
                closestBuilding = building;
            }
            else
            {
                if (Vector3.Distance(transform.position,building.position) < Vector3.Distance(transform.position,closestBuilding.position))
                {
                    closestBuilding = building;
                }
            }
        }

        return closestBuilding;
    }

    void UpdatePositionAndRotation()
    {
        float x = circle.position.x + Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
        float y = circle.position.y + Mathf.Sin(angle * Mathf.Deg2Rad) * radius;

        transform.position = new Vector3(x, y, transform.position.z);
        

        float rotationAngle = angle - 90.0f; 
        transform.rotation = Quaternion.Euler(0, 0, rotationAngle);
    }

    IEnumerator Tick(float wait)
    {
        yield return new WaitForSeconds(wait);

        Transform closestBuilding = ClosestBuilding();
        
        Vector3 startDir = transform.position.normalized;
        Vector3 targetDir = closestBuilding.position.normalized;
        float angleFromBuilding = Vector3.Angle(startDir, targetDir);
        Vector3 cross = Vector3.Cross(startDir, targetDir);
        
        //Debug.Log($"angle : {angleFromBuilding}");
        //Debug.Log($"cross : {cross}");

        float rightChance;
        float leftChance;
        if (cross.z > 0) // Assuming positive y-axis is the "up" direction
        {

            rightChance = curve.Evaluate(angleFromBuilding / 180) * (.5f - stillChance / 2) ;
            //rightChance = Mathf.Lerp(.5f - stillChance / 2, minBravery, angleFromBuilding / 180);
            leftChance = 1 - stillChance - rightChance;
            //Debug.Log("right");
            
        }
        else
        {
            leftChance = curve.Evaluate(angleFromBuilding / 180)  * (.5f - stillChance / 2);
            //leftChance = Mathf.Lerp(.5f - stillChance / 2, minBravery, angleFromBuilding / 180);
            rightChance = 1 - stillChance - leftChance;
            //Debug.Log("left");
            
        }
        
        float randValue = Random.value;
        if (randValue < stillChance)
        {
            currentState = State.still;
        }
        else if (randValue < (stillChance + leftChance)) // 45% of the time
        {
            currentState = State.left;
        }
        else // 10% of the time
        {
            currentState = State.right;
        }

        //Debug.Log($"left:{leftChance}, right:{rightChance}, still:{stillChance} = {leftChance + rightChance + stillChance}");

        float tickVariance = Random.Range(-.5f, .5f);
        StartCoroutine(Tick(changeDirectionInterval + tickVariance));
    }

    
}
