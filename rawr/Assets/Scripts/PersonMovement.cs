using UnityEngine;

public class PersonMovement : MonoBehaviour
{
    public Transform circle; 
    public float speed = 50.0f;
    public float changeDirectionInterval = 2.0f;

    private float radius;
    private float angle; 
    private bool moveClockwise; 
    private float nextDirectionChangeTime; 

    void Start()
    {
        if (circle == null)
        {
            Debug.LogError("Circle transform is not assigned.");
            return;
        }

        radius = Vector3.Distance(transform.position, circle.position);

        Vector3 direction = transform.position - circle.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        moveClockwise = Random.value < 0.5f;

        UpdatePositionAndRotation();

        nextDirectionChangeTime = Time.time + changeDirectionInterval;
    }

    void Update()
    {
        if (Time.time >= nextDirectionChangeTime)
        {
            float randomAngle = Random.Range(0.0f, 360.0f);
            moveClockwise = angle < randomAngle;

            nextDirectionChangeTime = Time.time + changeDirectionInterval;
        }

        angle += moveClockwise ? speed * Time.deltaTime : -speed * Time.deltaTime;

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

    void UpdatePositionAndRotation()
    {
        float x = circle.position.x + Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
        float y = circle.position.y + Mathf.Sin(angle * Mathf.Deg2Rad) * radius;

        transform.position = new Vector3(x, y, transform.position.z);

        float rotationAngle = angle + 90.0f; 
        transform.rotation = Quaternion.Euler(0, 0, rotationAngle);
    }
}
