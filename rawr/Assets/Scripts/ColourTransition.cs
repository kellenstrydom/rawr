using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ContinuousColorTransition : MonoBehaviour
{
    public Image panelImage; 
    public float duration = 2f; 

    private void Start()
    {
        if (panelImage == null)
        {
            panelImage = GetComponent<Image>();
        }

        StartCoroutine(ColorTransitionLoop());
    }

    private IEnumerator ColorTransitionLoop()
    {
        while (true)
        {
            Color targetColor = new Color(Random.value, Random.value, Random.value);

            yield return StartCoroutine(SmoothColorChange(panelImage.color, targetColor, duration));
        }
    }

    private IEnumerator SmoothColorChange(Color startColor, Color endColor, float duration)
    {
        float time = 0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            panelImage.color = Color.Lerp(startColor, endColor, time / duration);
            yield return null;
        }
        panelImage.color = endColor;
    }
}
