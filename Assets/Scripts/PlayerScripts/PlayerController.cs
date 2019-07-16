using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpVelocity;
    private float moveInput;
    public float fallMultiplier;
    public GameObject weapon;
    private Rigidbody2D rb;
    public int health = 100;
    private bool facingRight = true;

    public bool isGrounded;
    public Transform groundCheck;   
    public float checkRadius;
    public LayerMask whatIsGround;
    public bool otherMovement;
    private int extraJumps;
    public int extraJumpValue;
    private bool jumpRequest;

    private void Awake()
    {
        otherMovement = false;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        extraJumps = extraJumpValue;
    }

    private void Update()
    {
        JumpRequest();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        GravityShift();
        Jumping();
        HorizontalMovement();
        FlipOnMouse();
    }

    private void JumpRequest()
    {
        if (!otherMovement)
        {
            if (Input.GetKeyDown(KeyCode.W) && extraJumps > 0)
            {
                jumpRequest = true;
            }
            else if (Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && isGrounded == true)
            {
                jumpRequest = true;
            }

            if (isGrounded == true)
                extraJumps = extraJumpValue;
        }
    }

    private void GravityShift()
    {
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallMultiplier;
        }
        else
            rb.gravityScale = 1f;
    }

    private void Jumping()
    {
        if (jumpRequest)
        {
            rb.velocity = Vector2.up * jumpVelocity;
            extraJumps--;
            jumpRequest = false;
        }
    }

    private void HorizontalMovement()
    {
        moveInput = Input.GetAxis("Horizontal");
        if (!otherMovement)
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    private void FlipOnMouse()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x - gameObject.transform.position.x < 0 && facingRight)
            Flip();
        else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x - gameObject.transform.position.x > 0 &&
                 !facingRight)
            Flip();
    }
    
    public void Flip()
    {
        //gameObject.GetComponentInChildren<MeleeWeapon>().transform.rotation = Quaternion.Euler(0f, 0f, -gameObject.GetComponentInChildren<MeleeWeapon>().transform.rotation.z);
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}