using System.Collections;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    float moveHorizontal;
    float moveVertical;
    private bool isFacingRight = true;
    public float startSpeed = 5.0f;
    public float speedLimit = 20;
    public static float speed;
    public static float minSpeed; // Cần đưa giá trị sang các file khác
    public static float maxSpeed; // Cần đưa giá trị sang các file khác

    private bool canDash = true;
    private bool isDashing;
    public float dashPower = 24f;
    public float dashTime = 0.2f;
    public float dashCooldown = 1f;

    public float padding = 0.8f;    // padding to keep the player within the screen
    float minX;
    float maxX;
    float minY;
    float maxY;

    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private TrailRenderer tr;

    // For jumping
    // No need ground checking, can jump indefinitely
    [SerializeField] private Rigidbody2D rb;
    public float jump;
    // For jumping

    void Start()
    {
        FindBoundaries();

        speed = startSpeed;
        maxSpeed = speedLimit;
        minSpeed = startSpeed;
        animator = GetComponent<Animator>(); //bắt đầu animation khép mở chân
        sr = GetComponent<SpriteRenderer>();
        sr.flipX = true; // Sprite đang quay về bên trái nên cần quay về bên phải cho hợp với trailrenderer
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("Current Speed: " + speed);
    }

    void Update()
    {
        if (TimeManager.isGameOver || isDashing == true) // nếu trò chơi kết thúc
        {
            return; // thoát khỏi hàm Update
        }

        if (Input.GetKeyDown(KeyCode.Space) ||
            Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.W)) // nếu nhân vật nhảy (nhấn phím space hoặc phím mũi tên lên)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump), ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) ||
            Input.GetKeyDown(KeyCode.RightShift)) // nếu nhân vật dash (nhấn phím shift)
        {
            if (canDash)
            {
                StartCoroutine(Dash());
            }
        }
    }

    void FixedUpdate()
    {
        if (TimeManager.isGameOver || isDashing == true) // nếu trò chơi kết thúc
        {
            return; // thoát khỏi hàm Update
        }

        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        bool isMoving = moveHorizontal != 0; // khai báo biến isMoving
        animator.SetBool("isMoving", isMoving);

        float deltaX = moveHorizontal * speed * Time.deltaTime;
        if (moveVertical > 0)   // Dùng để tăng tốc khi đáp nếu bấm nút xuống
            moveVertical = 0;
        float deltaY = moveVertical * speed * Time.deltaTime;

        transform.position += new Vector3(deltaX, deltaY, 0f);

        // Giữ nhân vật trong khung hình 
        MovementContainer();

        // đổi hướng nhân vật
        Flip();
    }

    // make sure the player stays in the camera viewpoint
    void FindBoundaries()
    {
        Camera gameCam = Camera.main;
        Vector3 min = gameCam.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 max = gameCam.ViewportToWorldPoint(new Vector3(1, 1, 0));
        minX = min.x + padding;
        maxX = max.x - padding;
        minY = min.y + padding;
        maxY = max.y - padding;

        Debug.Log("minX: " + minX + " maxX: " + maxX + " minY: " + minY + " maxY: " + maxY);
    }

    void MovementContainer()
    {
        if (transform.position.x < minX)
        {
            transform.position = new Vector3(minX, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > maxX)
        {
            transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
        }
        if (transform.position.y > maxY)
        {
            transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
        }
        else if (transform.position.y < minY)
        {
            transform.position = new Vector3(transform.position.x, minY, transform.position.z);
        }
    }

    void Flip()
    {
        if (isFacingRight && moveHorizontal < 0f || !isFacingRight && moveHorizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            // sr.flipX = isFacingRight;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        Vector2 originalVelocity = rb.velocity;
        rb.gravityScale = 0;
        rb.velocity = new Vector2(transform.localScale.x * dashPower, 0f);
        tr.emitting = true;

        yield return new WaitForSeconds(dashTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        rb.velocity = originalVelocity;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);

        canDash = true;
    }
}
