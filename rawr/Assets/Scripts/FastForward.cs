using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FastForward : MonoBehaviour
{
    public TextMeshProUGUI speedIndicator; 
    public Button fastForwardButton; 
    private bool isFastForward = false;

    void Start()
    {
        if (fastForwardButton != null)
        {
            fastForwardButton.onClick.AddListener(ToggleFastForward);
        }

        if (speedIndicator != null)
        {
            speedIndicator.gameObject.SetActive(false);
        }
    }

    void ToggleFastForward()
    {
        isFastForward = !isFastForward;

        if (isFastForward)
        {
            Time.timeScale = 2f; 
            speedIndicator.gameObject.SetActive(true); 
            speedIndicator.text = "x2"; 
        }
        else
        {
            Time.timeScale = 1f; 
            speedIndicator.gameObject.SetActive(false); 
        }
    }

    private void OnDestroy()
    {
        if (fastForwardButton != null)
        {
            fastForwardButton.onClick.RemoveListener(ToggleFastForward);
        }

        Time.timeScale = 1f;
    }
}
