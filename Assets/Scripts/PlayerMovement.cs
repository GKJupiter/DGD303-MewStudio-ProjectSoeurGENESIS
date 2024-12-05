using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Horizontal Movement Settings")]
    [SerializeField] public float walkSpeed = 10f;

    [Header("Ground Check Settings")]
    [SerializeField] public float jumpForce = 45f;
    [SerializeField] public Transform groundCheckPoint;
    [SerializeField] public float groundCheckY = 0.2f;
    [SerializeField] public float groundCheckX = 0.5f;

    [SerializeField] public LayerMask whatIsGround;

    private Rigidbody2D rb;
    private float xAxis;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PrintInstruction();
    }

    void Update()
    {
        GetInputs();
        MovePlayer();
        Jump();
        Flip();
    }

    void PrintInstruction()
    {
        Debug.Log("Welcome to the Forest");
        Debug.Log("Move using arrow keys or wasd");
    }
    void GetInputs()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
    }

    private void MovePlayer()
    {
        rb.linearVelocity = new Vector2(walkSpeed * xAxis, rb.linearVelocity.y);
    }

    public bool Grounded()
    {
        if(Physics2D.Raycast(groundCheckPoint.position, Vector2.down, groundCheckY, whatIsGround) 
           || Physics2D.Raycast(groundCheckPoint.position + new Vector3(groundCheckX, 0, 0), Vector2.down, groundCheckY, whatIsGround)
           || Physics2D.Raycast(groundCheckPoint.position + new Vector3(-groundCheckX, 0, 0), Vector2.down, groundCheckY, whatIsGround))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    void Jump()
    {
        if(Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        }

        if(Input.GetButtonDown("Jump") && Grounded())
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce);
        }
    }

    void Flip()
    {
        if(xAxis < 0)
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
        else if (xAxis > 0)
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
    }    
}
