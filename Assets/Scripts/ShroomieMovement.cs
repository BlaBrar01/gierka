using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomieMovement : MonoBehaviour
{
    //attack
    public GameObject attackPoint;
    [SerializeField] float radiusOfAttack;
    public LayerMask Player;
    [SerializeField] public float damage; 
    private GameObject HealthBar;
    private Transform HealthBarCanvas;
    //Movment
    [SerializeField] Rigidbody2D FollowObject;
    Rigidbody2D body;
    [SerializeField] float speed = 2f;
    float currentSpeed;
    Collider2D collider;
    private Animator animator;
    private bool CanAttack = true;
    private bool CanMove = false;

    void Attack()
    {
        if (CanAttack == false)
        {
        }
        else
        {
            animator.SetBool("Attack", true);

            StartCoroutine(AttackCooldown(1f));
        }
    }
    void AttackHit()
    {
        Collider2D[] PlayerColliders = Physics2D.OverlapCircleAll(attackPoint.transform.position, radiusOfAttack, Player);
        foreach (Collider2D PlayerGameobject in PlayerColliders)
        {
            PlayerGameobject.GetComponent<PlayerHealthHandler>().health -= damage;
        }
    }
    void Start()
    {
        currentSpeed = speed;
        HealthBar = GameObject.Find("HealthBarEnemy");
        HealthBarCanvas = HealthBar.transform.GetChild(0);
        HealthBar.SetActive(false);
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("IsDead"))
        {

            HealthBar.SetActive(false);
            currentSpeed = 0;
            int LayerCorpse = LayerMask.NameToLayer("Corpses");
            gameObject.layer = LayerCorpse;
        }
        else if (currentSpeed != 0)
        {
            HealthBar.SetActive(true);
            if ((float)FollowObject.position.x > body.position.x)
            {
                animator.SetBool("Attack", false);
                body.velocity = new Vector2(currentSpeed, body.velocity.y);
                transform.localScale = Vector3.one;
                transform.localScale = new Vector3(1, 1, 1);
                HealthBarCanvas.transform.localScale = new Vector3(1, 1, 1);
                animator.SetBool("isWalking", true);
                if ((float)FollowObject.position.x - 4 <= body.position.x)
                {
                    animator.SetBool("isWalking", false);
                    body.velocity = new Vector2(0, 0);
                }

            }
            else if ((float)FollowObject.position.x < body.position.x)
            {
                animator.SetBool("Attack", false);
                body.velocity = new Vector2((-1) * currentSpeed, body.velocity.y);
                transform.localScale = new Vector3(-1, 1, 1);
                HealthBarCanvas.transform.localScale = new Vector3(-1, 1, 1);
                animator.SetBool("isWalking", true);
                if ((float)FollowObject.position.x + 4 >= body.position.x)
                {
                    animator.SetBool("isWalking", false);
                    body.velocity = new Vector2(0, 0);
                }
            }

        }
        if ((float)FollowObject.position.x - 2 <= body.position.x && !animator.GetBool("isWalking"))
        {
            Attack();
        }
        if ((float)FollowObject.position.x + 2 >= body.position.x && !animator.GetBool("isWalking"))
        {
            Attack();
        }
    }
    void CorpseState()
    {
        animator.SetBool("CorpseState", true);
        GlobalVariables.ShroomiesKilled++;
    }
    void TakingDamageStop()
    {
        HealthBar.SetActive(true);
        currentSpeed = 0;
        body.velocity = new Vector2(0, 0);
    }
    void TakingDamageStart()
    {
        currentSpeed = speed;
    }
    void StartAttack()
    {
        currentSpeed = 0;
        body.velocity = new Vector2(0, 0);
    }
    void EndAttack()
    {
        animator.SetBool("Attack", false);
        currentSpeed = speed;
    }
    private IEnumerator AttackCooldown(float waitTime)
    {
        CanAttack = false;
        yield return new WaitForSeconds(waitTime);
        CanAttack = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radiusOfAttack);
    }
}
