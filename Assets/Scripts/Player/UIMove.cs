using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMove : MonoBehaviour
{
    private CharacterMovement cm;
    bool moveLeft;
    bool moveRight;

    // Start is called before the first frame update
    void Start()
    {
        cm = GetComponent<CharacterMovement>();

        moveLeft = false;
        moveRight = false;
    }

    public void PointerDownLeft()
    {
        moveLeft = true;
    }

    public void PointerUpLeft()
    {
        moveLeft = false;
    }


    public void PointerDownRight()
    {
        moveRight = true;
    }


    public void PointerUpRight()
    {
        moveRight = false;
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (moveLeft)
        {
            cm.moveHorizontal = -1;

        }
        else if (moveRight)
        {
            cm.moveHorizontal = 1;
        }
        else
        {
            cm.moveHorizontal = 0;
        }
    }

    private void FixedUpdate()
    {
        // cm.rb.velocity = new Vector2(cm.moveHorizontal, cm.rb.velocity.y);
    }
}
