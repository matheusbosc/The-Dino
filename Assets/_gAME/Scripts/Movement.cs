using UnityEngine;

public class Movement : MonoBehaviour
{

	public float jumpHeight = 2f;
        public float gravity = -30f;
        public LayerMask groundMask;
        public Transform groundCheck;
        public float groundCheckRadius = 0.2f;
    
        private float verticalVelocity = 0f;
        private bool isGrounded = false;
        private CharacterController controller;
    
        void Start()
        {
            controller = GetComponent<CharacterController>();
        }
    
        void Update()
        {
            // Ground check
            isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask);
    
            if (isGrounded && verticalVelocity < 0)
            {
                verticalVelocity = -2f; // Stick to the ground
            }
    
            // Jump input
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                verticalVelocity = Mathf.Sqrt(-2f * gravity * jumpHeight);
            }
    
            // Apply gravity
            verticalVelocity += gravity * Time.deltaTime;
    
            // Move
            Vector3 move = new Vector3(0, verticalVelocity, 0); // 5f = horizontal speed
            controller.Move(move * Time.deltaTime);
        }
}
