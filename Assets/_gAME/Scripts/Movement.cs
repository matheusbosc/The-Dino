using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{

	public float jumpHeight = 2f;
        public float gravity = -30f;
        public LayerMask groundMask;
        public Transform groundCheck;
        public float groundCheckRadius = 0.2f;

        public Collider[] standCol;
        public Collider[] crouchCol;

        public Animator anim;

        public GameObject deadMenu;
    
        private float verticalVelocity = 0f;
        private bool isGrounded = false;
	private CharacterController controller;
	public bool isDead, isCrouched = false;
    
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
            if (Input.GetKey(KeyCode.Space) && isGrounded)
            {
                verticalVelocity = Mathf.Sqrt(-2f * gravity * jumpHeight);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                isCrouched = true;
            } else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                isCrouched = false;
            }
    
            // Apply gravity
            verticalVelocity += gravity * Time.deltaTime;
            
            // Animations
            anim.SetBool("IsGrounded", isGrounded);
            anim.SetBool("IsDead", isDead);
            anim.SetBool("IsCrouched", isCrouched);
            
            if (isCrouched)
            {
                foreach (var a in crouchCol)
                {
                    a.enabled = true;
                }
                
                foreach (var a in standCol)
                {
                    a.enabled = false;
                }
            }
            else
            {
                foreach (var a in crouchCol)
                {
                    a.enabled = false;
                }
                
                foreach (var a in standCol)
                {
                    a.enabled = true;
                }
            }
    
            // Move
	        Vector3 move = new Vector3(0, verticalVelocity, 0); // 5f = horizontal speed
	        move = isDead ? Vector3.zero : move;
            controller.Move(move * Time.deltaTime);
        }

        public void ToggleDeadMenu(bool a)
        {
            deadMenu.SetActive(a);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene("Game");
        }

        public void OpenMenu()
        {
            SceneManager.LoadScene("Main Menu");
        }
}
