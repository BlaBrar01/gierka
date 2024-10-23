using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable: MonoBehaviour
{
    private Collider2D collider;
    [SerializeField]
    private ContactFilter2D filter;
    private List<Collider2D> collidedObjects = new List<Collider2D>(0);
    protected virtual void Start()
    {
        collider = GetComponent<Collider2D>();
    }
    protected virtual void Update()
    {
        collider.OverlapCollider(filter, collidedObjects);
        foreach(var o in collidedObjects)
        {
                OnCollided(o.gameObject);
        }
    }
    protected virtual void OnCollided(GameObject collidedObject)
    {
        Debug.Log("Colided with" + collidedObject.name);
    }
}
