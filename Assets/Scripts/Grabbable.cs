using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Grabbable : MonoBehaviour
{
    public float speed = 1f;
    Rigidbody2D rb;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveTowards(Vector2 goal)
    {
        Vector2 distance = goal - (Vector2) transform.position;
        rb.velocity = distance * speed;
    }
}
