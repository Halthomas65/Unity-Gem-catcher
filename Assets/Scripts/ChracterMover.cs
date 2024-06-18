using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float startSpeed = 5.0f;
    public float speedLimit = 20;
    public static float speed;
    public static float minSpeed; // Cần đưa giá trị sang các file khác
    public static float maxSpeed; // Cần đưa giá trị sang các file khác

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    // For jumping
    private Rigidbody2D rb;
    public float jump;
    // For jumping

    void Start()
    {
        speed = startSpeed;
        maxSpeed = speedLimit;
        minSpeed = startSpeed;
        animator = GetComponent<Animator>(); //bắt đầu animation khép mở chân
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (ScoreManager.isGameOver) // nếu trò chơi kết thúc
        {
            return; // thoát khỏi hàm Update
        }
        else if (ScoreManager.resetValue) // nếu resetValue = true
        {
            speed = startSpeed; // reset lại tốc độ của nhân vật
            ScoreManager.resetValue = false; // reset lại giá trị của resetValue
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        bool isMoving = moveHorizontal != 0; // khai báo biến isMoving
        animator.SetBool("isMoving", isMoving);

        // đổi hướng nhân vật
        if (moveHorizontal < 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveHorizontal > 0)
        {
            spriteRenderer.flipX = true;
        }

        if (isMoving) // nếu nhân vật đang di chuyển ngang
        {
            transform.position += new Vector3(moveHorizontal * speed * Time.deltaTime, 0f, 0f);
            // transform.position += new Vector2(moveHorizontal * speed * Time.deltaTime, 0f);
        }

        if (Input.GetKeyDown(KeyCode.Space)) // nếu nhân vật nhảy (nhấn phím space)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump), ForceMode2D.Impulse);
        }
    }
}