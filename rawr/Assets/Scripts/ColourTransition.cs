using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ContinuousColorTransition : MonoBehaviour
{
    public Image panelImage; 
    public float duration = 1f; 

    private void Start()
    {
        if (panelImage == null)
        {
            panelImage = GetComponent<Image>();
        }

        Time.timeScale = 0;

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
            time += Time.fixedUnscaledDeltaTime;
            panelImage.color = Color.Lerp(startColor, endColor, time / duration);
            yield return null;
        }
        panelImage.color = endColor;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        GameObject.FindWithTag("Ground").GetComponent<GameManager>().allowInput = true;
        gameObject.SetActive(false);
    }
}
