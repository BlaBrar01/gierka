using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimeMovment : MonoBehaviour
{
    Transform target;
    [SerializeField] public float speed;

    public float currentSpeed;
    [SerializeField] Rigidbody2D FollowObject;
    public Animator animatorLime;
    Rigidbody2D body;

    void Start()
    {
            body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void jumpStart()
    {
        currentSpeed = speed;
    }
    void jumpEnd()
    {
        currentSpeed = 0;
    }
    
    void Update()
    {
        if ((float)FollowObject.position.x > body.position.x) {
            animatorLime.SetBool("NeedToMove",true);
            animatorLime.Play("slime_green - sprite_Clip");
            body.velocity = new Vector2(currentSpeed, body.velocity.y);
            transform.localScale = Vector3.one;
            if ((float)FollowObject.position.x - 4 < body.position.x )
            {
                animatorLime.SetBool("NeedToMove", false);
                body.velocity = new Vector2(0, 0);
            }
        }
        else if ((float)FollowObject.position.x < body.position.x) {
            animatorLime.SetBool("NeedToMove", true);
            animatorLime.Play("slime_green - sprite_Clip");
            body.velocity = new Vector2((-1)* currentSpeed, body.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
            if((float)FollowObject.position.x + 4 > body.position.x)
            {
                animatorLime.SetBool("NeedToMove", false);
                body.velocity = new Vector2(0, 0);
            }
        }
        animatorLime.SetFloat("AccelerationLime", Mathf.Abs(((float)body.velocity.x)));
    }
}
