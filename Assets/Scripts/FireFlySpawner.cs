using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlySpawner : MonoBehaviour
{
    public GameObject fireflyPrefab;
    public int numberOfFireflies = 10;

    void Start()
    {
        for (int i = 0; i < numberOfFireflies; i++)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(0f, 66f), Random.Range(2f, 10f));
            Instantiate(fireflyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
