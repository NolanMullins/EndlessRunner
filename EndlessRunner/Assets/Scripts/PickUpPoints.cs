using UnityEngine;
using System.Collections;

public class PickUpPoints : MonoBehaviour {

    public int value;
    private AudioSource coinSound;

    private ScoreManager theScoreManager;

	// Use this for initialization
	void Start () {
        theScoreManager = FindObjectOfType<ScoreManager>();
        coinSound = GameObject.Find("Coin").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //built in function in unity
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.name == "player")
        {
            if (coinSound.isPlaying)
                coinSound.Stop();
            coinSound.Play();
            theScoreManager.addScore(value);
            gameObject.SetActive(false);
        }
    }
}
