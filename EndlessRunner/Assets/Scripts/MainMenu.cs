using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public string playScene;

	public void playGame()
    {
        //Application.LoadLevel(playScene);
        UnityEngine.SceneManagement.SceneManager.LoadScene(playScene);
    }

    public void quitGame()
    {
        Application.Quit();
    }

}
