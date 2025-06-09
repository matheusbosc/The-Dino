using System;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    
    public GameObject floorPrefab;
    public Transform floorSpawnPoint;
	public float floorSpeed = 10f;
	public GameObject[] spawnPoints;
	public GameObject[] obstaclePrefabs;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
	    for (int i = 0; i <= 1; i++)
	    {
	    	var sPI = UnityEngine.Random.Range(0, spawnPoints.Length);
	    	var oPI = UnityEngine.Random.Range(0, obstaclePrefabs.Length);
	    	
	    	for(int t = spawnPoints[sPI].transform.childCount; t > 0; i--)
	    	{
	    		Destroy(spawnPoints[sPI].transform.GetChild(t + 1).gameObject);
	    	}
	    	
		    Instantiate(obstaclePrefabs[oPI].gameObject, spawnPoints[sPI].transform.position, spawnPoints[sPI].transform.rotation, spawnPoints[sPI].transform);
		    
	    }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * (Time.deltaTime * floorSpeed));
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided");
        if (other.gameObject.CompareTag("FloorTrigger"))
        {
            Debug.Log("Collided Floor");
            var i = Instantiate(floorPrefab, floorSpawnPoint.position, floorPrefab.transform.rotation);
            i.GetComponent<FloorSpawner>().floorSpawnPoint = floorSpawnPoint;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("UnCollided");
        if (other.gameObject.CompareTag("FloorTrigger"))
        {
            Debug.Log("UnCollided Floor");
            Destroy(this.gameObject);
        }
    }
}
