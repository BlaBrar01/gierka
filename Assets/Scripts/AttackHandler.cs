using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : PlayerMovment
{
    public GameObject attackPoint;
    [SerializeField] float radiusOfAttack;
    public LayerMask enemies;
    [SerializeField] public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isAttacking", true);
            currentAccerelate = 0;
        }
    }
    public void endAttack()
    {
        animator.SetBool("isAttacking", false);
        currentAccerelate = accerelate;
    }
    public void Attack()
    {
        Collider2D[] enemyColliders = Physics2D.OverlapCircleAll(attackPoint.transform.position, radiusOfAttack, enemies);
        foreach (Collider2D enemyGameobject in enemyColliders)
        {
            enemyGameobject.GetComponent<EnemyHealth>().health -= damage;
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radiusOfAttack);
    }
}
