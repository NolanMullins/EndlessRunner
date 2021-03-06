﻿using UnityEngine;
using System.Collections;

public class DeathMenu : MonoBehaviour {

    public string mainMenuLevel;

    public void restartGame()
    {
        FindObjectOfType<GameManager>().reset();
    }

    public void quitToMain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(mainMenuLevel);
    }
}
