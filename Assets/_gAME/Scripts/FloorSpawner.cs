using System;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    
    public GameObject floorPrefab;
    public Transform floorSpawnPoint;
    public float floorSpeed = 10f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
