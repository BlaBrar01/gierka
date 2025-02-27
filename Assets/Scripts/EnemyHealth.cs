using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float currentHealth;
    private Animator animator;
    [SerializeField] public Slider healthBar;
    public float MaxHealth;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = health;
        MaxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {

        if (health < currentHealth)
        {
            currentHealth = health;
            animator.SetTrigger("Attacked");
        }
        if(health <=0)
        {
            animator.SetBool("IsDead",true);
        }
        healthBar.value = currentHealth/MaxHealth;
    }
}
