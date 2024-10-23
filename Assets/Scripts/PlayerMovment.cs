using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float accerelate = 10;
    public Rigidbody2D body;
    public Animator animator;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * accerelate, body.velocity.y);
        animator.SetFloat("Acceleration", Mathf.Abs(horizontalInput * accerelate));
        //flipping player sprite 
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
        //

        //jump
        if (Input.GetKeyDown("space"))
        {
            body.velocity = new Vector2(body.velocity.x, accerelate);
        }
        //


    }
}
