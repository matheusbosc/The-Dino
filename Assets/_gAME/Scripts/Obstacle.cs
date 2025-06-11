using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
	// OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider.
	private void OnTriggerEnter(Collider collisionInfo)
	{
		if (collisionInfo.CompareTag("Player"))
		{
			collisionInfo.gameObject.GetComponent<Movement>().isDead = true;
			print ("dead");
		}
	}
}
