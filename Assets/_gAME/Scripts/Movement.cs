using UnityEngine;

public class Movement : MonoBehaviour
{

	public float jumpForce = 10f;
	public GameObject groundCheck;
	public LayerMask groundLayer;
	
	private Rigidbody _rb;
	
	private bool _canJump = false;
	
	// Awake is called when the script instance is being loaded.
	private void Awake()
	{
		_rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
	void Update()
	{
		if (Physics.Raycast(groundCheck.transform.position, Vector3.down, 0.15f, groundLayer) && Input.GetKey(KeyCode.Space))
		{
			_rb.AddForce(Vector3.up * jumpForce);
		}
	
	}
}
