using UnityEngine;

public class MyCharacterController : MonoBehaviour
{
    public CharacterController player;

	[SerializeField]
    float speed = 6.0f;
	[SerializeField]
    float gravity = -20f;

    public Transform groundCheck;
    public float groundDistance = .4f;
    public LayerMask groundMask;
    private bool isGrounded;

    public float jumpHeight = 2.0f;
    
    Vector3 velocity;
    public Vector3 move = Vector3.zero;

    public void Start()
    {
		//hide the mouse
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
        player = GetComponent<CharacterController>();
        groundCheck = transform.GetChild(1).GetComponent<Transform>();
    }

    void Update()
    {
        //ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //reset gravity if grounded
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //movement
        move = transform.right * x + transform.forward * z;
		
        player.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        player.Move(velocity * Time.deltaTime);

        //toggle the mouse hide with escape
        if (Input.GetKeyDown("escape"))
        {
			if (Cursor.lockState == CursorLockMode.None)
			{
				Cursor.visible = false;
				Cursor.lockState = CursorLockMode.Locked;
			}
			else if (Cursor.lockState == CursorLockMode.Locked)
			{
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
			}
        }
    }

    public void CheckIsGrounded()
    {
        RaycastHit2D[] hits;

        //We raycast down 1 pixel from this position to check for a collider
        Vector2 positionToCheck = transform.position;
        hits = Physics2D.RaycastAll(positionToCheck, new Vector2(0, -1), 0.01f);

        //if a collider was hit, we are grounded
        if (hits.Length > 0)
        {
            isGrounded = true;
        }
    }
}
