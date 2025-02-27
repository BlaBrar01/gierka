using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] protected static float accerelate = 6;
    protected static float currentAccerelate = accerelate;
    public Rigidbody2D body;
    public Animator animator;
    protected bool touchesFloor = true;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * currentAccerelate, body.velocity.y);
        animator.SetFloat("Acceleration", Mathf.Abs(horizontalInput * currentAccerelate));
        //flipping player sprite 
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
        //

        //jump
        if (Input.GetKeyDown("space") && touchesFloor == true)
        {
            touchesFloor = false;
            body.velocity = new Vector2(body.velocity.x, currentAccerelate);
        }

        //
    }
     void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Floor") {
            touchesFloor = true;
            animator.SetBool("inAir", false);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "BarrelLimeCutsceneCollider")
        {
            currentAccerelate = 0;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.gameObject.name == "Floor") {
            touchesFloor = false;
            animator.SetBool("inAir", true); 
        }
        if (collider.gameObject.name == "BarrelLimeCutsceneCollider")
        {
            currentAccerelate = accerelate;
        }
    }

}
