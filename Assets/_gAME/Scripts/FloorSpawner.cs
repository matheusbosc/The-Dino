using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FloorSpawner : MonoBehaviour
{
    
    public GameObject[] floorPrefab;
    public Transform floorSpawnPoint;
	public float floorSpeed = 10f;
	public GameObject[] spawnPoints;
	public GameObject[] obstaclePrefabs;
	public Movement player;
	public bool canSpawnFloors = true;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
	    StartCoroutine("SpeedUp");
    }

    // Update is called once per frame
    void Update()
	{
		var move = Vector3.right * (Time.deltaTime * floorSpeed);
		move = player.isDead ? Vector3.zero : move;
		transform.Translate(move);
    }

     IEnumerator SpeedUp()
     {
	     yield return new WaitForSeconds(1.5f);

	     if (floorSpeed <= 30)
	     {
		     floorSpeed += 0.05f;
		     StartCoroutine("SpeedUp");
	     }
     }

    private void OnTriggerEnter(Collider other)
    {
	    if (canSpawnFloors)
	    {
		    Debug.Log("Collided");
		    if (other.gameObject.CompareTag("FloorTrigger"))
		    {
			    var a = Random.Range(0, floorPrefab.Length);
			    Debug.Log("Collided Floor");
			    var i = Instantiate(floorPrefab[a], floorSpawnPoint.position, floorPrefab[a].transform.rotation);
			    i.GetComponent<FloorSpawner>().floorSpawnPoint = floorSpawnPoint;
			    i.GetComponent<FloorSpawner>().player = player;
			    i.GetComponent<FloorSpawner>().floorSpeed = floorSpeed;
			    i.GetComponent<FloorSpawner>().Start();
		    }
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
