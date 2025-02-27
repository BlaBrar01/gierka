using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomyTrigger : MonoBehaviour
{
    bool interacted = false;
    [SerializeField] Collider2D collider;
    [SerializeField] Animator BushAnimator;
    public GameObject ShroomiePrefab;
    [SerializeField] public int numberOfEnemies = 1;

    void Start()
    {
        collider = GetComponent<Collider2D>();
    }
    void Update()
    {
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") && !interacted)
        {
            interacted = true;
            BushAnimator.SetBool("ShroomieTrigger", true);
        }
    }
    void EndAmbush()
    {
        BushAnimator.SetBool("ShroomieTrigger", false);
    }
    void SpawnShroomie()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector2 spawnPosition = new Vector2(transform.localPosition.x, transform.localPosition.y);
            ShroomiePrefab.SetActive(true);
            Instantiate(ShroomiePrefab, spawnPosition, Quaternion.identity);
        }
        ShroomiePrefab.SetActive(false);
    }
}
