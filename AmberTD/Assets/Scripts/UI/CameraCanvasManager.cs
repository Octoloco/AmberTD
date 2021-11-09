using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCanvasManager : MonoBehaviour
{
    public static CameraCanvasManager instance = null;

    [SerializeField]
    private UIPanel gameOverPanel;
    [SerializeField]
    private UIPanel winPanel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.Show();
        GameManagerScript.instance.PauseGame();
    }

    public void ShowWinPanel()
    {
        winPanel.Show();
        winPanel.GetComponent<WinPanel>().CalculateStars();
        GameManagerScript.instance.PauseGame();
    }
}
