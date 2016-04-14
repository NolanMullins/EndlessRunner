using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

    public Transform generationPoint;

    private float distanceBetween;

    private float[] platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    private int platformNum;

    public ObjectPooler[] objPool;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    private CoinGenerator coinGenerator;
    public int coinChance;


	// Use this for initialization
	void Start () {
        platformWidth = new float[objPool.Length];
        for (int a = 0; a < objPool.Length; a++)
        {
            platformWidth[a] = objPool[a].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        coinGenerator = FindObjectOfType<CoinGenerator>();

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
        
	}
	
	// Update is called once per frame
	void Update () {
	    
        if (transform.position.x < generationPoint.position.x)
        {
            //random num (min, max)
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            platformNum = Random.Range(0, objPool.Length);

            //height change
            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);
            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            transform.position = new Vector3(transform.position.x + (platformWidth[platformNum]/2.0f) + distanceBetween, heightChange, transform.position.z);

            //creates an object at a point
            //Instantiate(platform[platformNum], transform.position, transform.rotation);

            GameObject obj = objPool[platformNum].getPooledObject();
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;
            obj.SetActive(true);

            //spawn coins
            if ((int)Random.Range(0, coinChance)==1)
                coinGenerator.spawnCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));

            transform.position = new Vector3(transform.position.x + (platformWidth[platformNum] / 2.0f), transform.position.y, transform.position.z);
        }

	}
}
