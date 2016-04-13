using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

    public GameObject[] platform;
    public Transform generationPoint;

    private float distanceBetween;

    private float[] platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    private int platformNum;

    //public ObjectPooler objPool;

	// Use this for initialization
	void Start () {
        platformWidth = new float[platform.Length];
        for (int a = 0; a < platform.Length; a++)
        {
            platformWidth[a] = platform[a].GetComponent<BoxCollider2D>().size.x;
        }
        
	}
	
	// Update is called once per frame
	void Update () {
	    
        if (transform.position.x < generationPoint.position.x)
        {
            //random num (min, max)
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            platformNum = Random.Range(0, platform.Length);
            transform.position = new Vector3(transform.position.x + platformWidth[platformNum] + distanceBetween, transform.position.y, transform.position.z);

            //creates an object at a point
            Instantiate(platform[platformNum], transform.position, transform.rotation);

            /*GameObject obj = objPool.getPooledObject();
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;
            obj.SetActive(true);*/
        }

	}
}
