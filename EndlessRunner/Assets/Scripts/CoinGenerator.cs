using UnityEngine;
using System.Collections;

public class CoinGenerator : MonoBehaviour {

    public ObjectPooler coinPool;

    public float distBetweenSpots;

	public void spawnCoins(Vector3 startPosition)
    {
        GameObject coin = coinPool.getPooledObject();

        float dist = Random.Range(-distBetweenSpots, distBetweenSpots);

        coin.transform.position = new Vector3(startPosition.x + dist, startPosition.y, startPosition.z);

        coin.SetActive(true);
    }
}
