using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 2f;
    public float changeDirectionTime;
    private float timer;
    private Vector2 movementDirection;

    void Start()
    {
        SetRandomMovementDirection();
        changeDirectionTime = Random.Range(1f, 5.0f);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > changeDirectionTime)
        {
            SetRandomMovementDirection();
            timer = 0f;
        }

        transform.Translate(movementDirection * moveSpeed * Time.deltaTime);
    }

    void SetRandomMovementDirection()
    {
        movementDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}