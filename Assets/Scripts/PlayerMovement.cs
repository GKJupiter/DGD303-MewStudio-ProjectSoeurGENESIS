using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;       // Karakterin hareket hızı
    public float jumpForce = 10f;      // Zıplama kuvveti
    public LayerMask groundLayer;      // Zemin katmanı
    public Transform groundCheck;      // Zemin kontrol noktası
    public float groundCheckRadius = 0.2f; // Zemini kontrol etmek için küçük bir yarıçap

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    private bool isJumping;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        GroundCheck();
        HorizontalMovement();
        FlipCharacter();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        UpdateAnimations();
    }

    private void HorizontalMovement()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        isJumping = true;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); // Dikey hareketi sıfırla (daha iyi zıplama hissi)
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // Daha iyi bir zıplama hissi için AddForce kullandık
        animator.SetTrigger("IsJumping");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") // Hata buradaydı, CompareTag kullanmaya gerek yok
        {
            isGrounded = true;
        }
    }

    private void FlipCharacter()
    {
        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private void GroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (isGrounded)
        {
            isJumping = false;
        }
    }

    private void UpdateAnimations()
    {
        animator.SetFloat("xVelocity", Mathf.Abs(rb.linearVelocity.x));
        animator.SetFloat("yVelocity", rb.linearVelocity.y);
        animator.SetBool("isJumping", isJumping);
    }
}
