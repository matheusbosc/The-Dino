using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] obstaclePrefabs;
    void Start()
    {
        var oPI = Random.Range(0, obstaclePrefabs.Length + 1);
	    	
        for(int t = transform.childCount; t > 0; t--)
        {
            Destroy(transform.GetChild(t).gameObject);
        }
	    	
        var o = Instantiate(obstaclePrefabs[oPI].gameObject, transform.position, transform.rotation, transform);
        o.tag = "Obstacle";
    }
}
