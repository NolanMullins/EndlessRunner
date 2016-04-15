using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformlist;

    private ScoreManager theScoreManager;

    public DeathMenu theDeathScreen;

	// Use this for initialization
	void Start () {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager>();

        theDeathScreen.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
        }
    }

    public void RestartGame()
    {
        theScoreManager.onPlayerDeath();
        thePlayer.gameObject.SetActive(false);
        //StartCoroutine("RestartGameCo");

        theDeathScreen.gameObject.SetActive(true);
    }

    public void reset()
    {
        theDeathScreen.gameObject.SetActive(false);
        platformlist = FindObjectsOfType<PlatformDestroyer>();
        for (int a = 0; a < platformlist.Length; a++)
        {
            platformlist[a].gameObject.SetActive(false);
        }
        //Reset Game
        theScoreManager.onReset();
        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);
    }

    /*public IEnumerator RestartGameCo()
    {
        //On death
        
        yield return new WaitForSeconds(1.25f);
        
    }*/
}
