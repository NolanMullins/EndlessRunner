using UnityEngine;
using System.Collections;

public class PickUpPoints : MonoBehaviour {

    public int value;

    private ScoreManager theScoreManager;

	// Use this for initialization
	void Start () {
        theScoreManager = FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //built in function in unity
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.name == "player")
        {
            theScoreManager.addScore(value);
            gameObject.SetActive(false);
        }
    }
}
