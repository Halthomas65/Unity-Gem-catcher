using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    // For jumping
    bool jump = false;
    // private bool stopJump;
    public JumpState jumpState = JumpState.Grounded;
    public float jumpForce = 6.0f;
    // For jumping

    void Start()
    {
        animator = GetComponent<Animator>(); //bắt đầu animation khép mở chân
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (ScoreManager.isGameOver) // nếu trò chơi kết thúc
        {
            return; // thoát khỏi hàm Update
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
        }

        if (Input.GetAxis("Vertical") > 0) // nếu nhân vật nhảy (nhấn phím lên)
        {
            if (jumpState == JumpState.Grounded)    // nếu nhân vật đang ở trạng thái đứng trên mặt đất
            {
                jump = true;
                jumpState = JumpState.Jumping;
            }
        }
        UpdateJumpState();
    }

    // To be fixed
    void UpdateJumpState()
    {
        jump = false;
        switch (jumpState)
        {
            case JumpState.Grounded:
                break;
            case JumpState.Jumping:
                jump = true;
                break;
            case JumpState.InFlight:
                break;
        }
    }

    public enum JumpState
    {
        Grounded,
        Jumping,
        InFlight
    }
}