using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Normal()
    {
        Time.timeScale = 1f;
    }
    public void FastForward()
    {
        Time.timeScale = 2f;
    }
}
