using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinPanel : UIPanel
{
    [SerializeField]
    private TextMeshProUGUI starsText;

    public void CalculateStars()
    {
        if (PlayerHealth.instance.GetCurrentHealth() == PlayerHealth.instance.GetMaxHealth())
        {
            starsText.text = "Stars = " + 3 + "/3";
        }
        else if (PlayerHealth.instance.GetCurrentHealth() < PlayerHealth.instance.GetMaxHealth() && PlayerHealth.instance.GetCurrentHealth() >= (PlayerHealth.instance.GetMaxHealth() / 2))
        {
            starsText.text = "Stars = " + 2 + "/3";
        }
        else
        {
            starsText.text = "Stars = " + 1 + "/3";
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex;
        nextSceneIndex++;
        if (nextSceneIndex >= 4)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
