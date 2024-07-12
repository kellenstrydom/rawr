using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool isPaused = false;

    public void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0f; 
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
