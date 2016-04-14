using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public Text highScoreText;

    private float scoreCount;
    private float highScoreCount;

    public float PointsPerSecond;

    private bool isPlayerAlive;

	// Use this for initialization
	void Start () {
        isPlayerAlive = true;
        if (PlayerPrefs.HasKey("HS"))
            highScoreCount = PlayerPrefs.GetFloat("HS");
	}
	
	// Update is called once per frame
	void Update () {

        if (isPlayerAlive)
        {
            scoreCount += PointsPerSecond * Time.deltaTime;
        }

        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HS", scoreCount);
        }

        scoreText.text = Mathf.Round(scoreCount) + " m";
        highScoreText.text = "High Score: " + Mathf.Round(highScoreCount) + " m";
	}

    public void onPlayerDeath()
    {
        isPlayerAlive = false;
    }

    public void onReset()
    {
        scoreCount = 0;
        isPlayerAlive = true;
    }

    public void addScore(int add)
    {
        scoreCount += add;
    }

}
