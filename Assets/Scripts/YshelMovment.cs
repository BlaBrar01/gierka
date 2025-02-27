using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YshelMovment : MonoBehaviour
{
    //Movment
    [SerializeField] Rigidbody2D FollowObject;
    Rigidbody2D body;
    Collider2D collider;
    private Animator animator;

    [SerializeField] float speed = 3f;
    float currentSpeed = 0f;
    private bool CanMove = false;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (body.position.x < 3.8f)
        {
            GlobalVariables.YshelMoves = false;
            animator.SetBool("isWalking", false);
            animator.SetBool("Reveal", true);
            body.velocity = new Vector2(0, 0);
            currentSpeed = 0f;
            GlobalVariables.YshelTriggerer = false;
        }
        if (currentSpeed == 0f)
        {
            GlobalVariables.YshelMoves = false;
            animator.SetBool("isWalking", false);
            if ((float)FollowObject.position.x > body.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);

            }
            else if ((float)FollowObject.position.x < body.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        if(currentSpeed != 0f)
        {

            GlobalVariables.YshelMoves = true;
            animator.SetBool("isWalking", true);
            transform.localScale = new Vector3(-1, 1, 1);
            body.velocity = new Vector2((-1) * currentSpeed, body.velocity.y);
        }
        if (GlobalVariables.YshelTriggerer)
        {
            StartCoroutine(ReadTimer(2f));
        }
    }
    private IEnumerator ReadTimer(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        currentSpeed = speed;
    }

}
