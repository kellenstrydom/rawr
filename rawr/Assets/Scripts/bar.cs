using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bar : MonoBehaviour
{
    public GameManager gm;
    public Image healthBar;

    private void Update()
    {
        healthBar.fillAmount = gm.worldHealth / 100f;
    }
}
