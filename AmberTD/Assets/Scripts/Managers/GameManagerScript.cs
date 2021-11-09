using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance = null;

    private bool gamePaused;

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

    public void StartGame()
    {
        gamePaused = false;
    }

    public bool IsGamePaused()
    {
        return gamePaused;
    }

    public void PauseGame()
    {
        gamePaused = true;
    }
}
