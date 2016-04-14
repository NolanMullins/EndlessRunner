using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformlist;

    private ScoreManager theScoreManager;

	// Use this for initialization
	void Start () {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RestartGame()
    {
        StartCoroutine("RestartGameCo");
    }

    public IEnumerator RestartGameCo()
    {
        //On death
        theScoreManager.onPlayerDeath();
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
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
}
