using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator anim;
    public float speed;
    public float posPadding = 0.5f;

    public Vector3 patrolPointAPos;
    public Vector3 patrolPointBPos;
    public Vector3 targetPatrolPoint;

    // public BoxCollider2D envDetector;
    public BoxCollider2D trigger;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(SpawnAction());
        
        // anim = GetComponent<Animator>();
        // anim.SetBool("isRunning", true);
    }

    public void Setup() {
        targetPatrolPoint = pointA.transform.position;
        patrolPointAPos = pointA.transform.position;
        patrolPointBPos = pointB.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = targetPatrolPoint - transform.position;
        if (targetPatrolPoint == patrolPointBPos)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, targetPatrolPoint) < posPadding)
        {
            if (targetPatrolPoint == patrolPointAPos)
            {
                targetPatrolPoint = patrolPointBPos;
                Flip();                
            }
            else if (targetPatrolPoint == patrolPointBPos)
            {
                targetPatrolPoint = patrolPointAPos;
                Flip();
            }
        }
    }

    IEnumerator SpawnAction()
    {
        // start spawn animation

        // blink character

        // shut of collider
        trigger.enabled = false;
        yield return new WaitForSeconds(2);

        // turn on collider
        trigger.enabled = true;
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
