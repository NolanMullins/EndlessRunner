using UnityEngine;
using System.Collections;

public class pauseMenu : MonoBehaviour {

    public string mainMenuLevel;
    public GameObject menu;

    public void pauseGame()
    {
        Time.timeScale = 0f;
        menu.SetActive(true);
    }

    public void resumeGame()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void restartGame()
    {
        menu.SetActive(false);
        FindObjectOfType<GameManager>().reset();
        Time.timeScale = 1f;
    }

    public void quitToMain()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(mainMenuLevel);
    }
}
