using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollisionNotifier : MonoBehaviour
{
    public GameObject notificationPrefab; 

    public Transform notificationParent; 

    private List<string> warHeading = new List<string> { "War Erupts!", "OH NO - Conflict!", "Battle Begins!", "They Fighting" };
    private List<string> neutralHeading = new List<string> { "We good", "Peaceful Encounter", "Truce Babygirl", "A Calm Meeting" };
    private List<string> loveHeading = new List<string> { "Love Blooms", "Romance Sparks", "Affection Grows", "Hearts Unite" };

    private int collisionCount = 0;

    private void Start()
    {
        if (GetComponent<Collider2D>() == null)
        {
            gameObject.AddComponent<BoxCollider2D>();
        }
        if (GetComponent<Rigidbody2D>() == null)
        {
            Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Dynamic; 
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PersonR") || collision.gameObject.CompareTag("PersonB") || collision.gameObject.CompareTag("PersonY"))
        {
            string thisTag = gameObject.tag;
            string otherTag = collision.gameObject.tag;

            if (thisTag != otherTag) 
            {
                collisionCount++; 

                if (collisionCount >= 15) 
                {
                    string heading = GetRandomHeading();
                    ShowNotification(heading);
                    collisionCount = 0;
                }
            }
        }
    }

    string GetRandomHeading()
    {
        int randomType = Random.Range(0, 3); 

        switch (randomType)
        {
            case 0:
             return warHeading[Random.Range(0, warHeading.Count)];

            case 1:
             return neutralHeading[Random.Range(0, neutralHeading.Count)];

            case 2:
             return loveHeading[Random.Range(0, loveHeading.Count)];

            default:
             return "IDK";
        }
    }

    void ShowNotification(string heading)
    {
        GameObject notification = Instantiate(notificationPrefab, notificationParent);
        TextMeshProUGUI textComponent = notification.GetComponentInChildren<TextMeshProUGUI>();

        if (textComponent != null)
        {
            textComponent.text = heading;
        }

        notification.SetActive(true);
        StartCoroutine(HideNotification(notification));
    }

    IEnumerator HideNotification(GameObject notification)
    {
        yield return new WaitForSeconds(3f); 
        Destroy(notification);
    }
}

