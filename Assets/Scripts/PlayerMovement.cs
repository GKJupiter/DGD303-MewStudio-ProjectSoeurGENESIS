using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;       // Karakterin hareket hızı
    public float jumpForce = 10f;     // İlk zıplama kuvveti
    public float jumpHoldForce = 2f;  // Basılı tutma kuvveti
    public float maxJumpTime = 0.2f;  // Maksimum zıplama süresi
    public LayerMask groundLayer;     // Zemin katmanı
    public Transform groundCheck;     // Zemin kontrol noktası

    private Rigidbody2D rb;           // Rigidbody bileşeni
    private bool isGrounded;          // Karakter zeminde mi?
    private bool isJumping;           // Karakter şu anda zıplıyor mu?
    private float jumpTimeCounter;    // Zıplama süresi sayacı
    private float moveInput;          // Hareket girdisi

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HorizontalMovement();
        FlipCharacter();
        GroundCheck();
        Jump();
    }

    private void HorizontalMovement()
    {
        // Sağa sola hareket
        moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private void FlipCharacter()
    {
        // Karakterin yönünü döndür
        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1); // Sağa bak
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1); // Sola bak
    }

    private void GroundCheck()
    {
        // Zemin kontrolü
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }
}