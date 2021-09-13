using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Grabbable : MonoBehaviour
{
    public float speed = 1f;
    public float linearDeceleration = 0f;
    public float angularDeceleration = 0f;
    Rigidbody2D rb;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        rb.velocity = DecreaseBy(rb.velocity, linearDeceleration);
    }

    Vector2 DecreaseBy(Vector2 value, float change) {
        float nextLength = DecreaseBy(value.magnitude, change);
        return value.normalized * nextLength;
    }

    /// <summary>
    /// Move value towards zero by change.
    /// If new value sign is not the same sign as value, returns zero
    /// </summary>
    float DecreaseBy(float value, float change) {
        float startSign = Mathf.Sign(value);
        float newValue = value - Mathf.Abs(change) * startSign;
        if (Mathf.Sign(newValue) != startSign) newValue = 0;
        return newValue;
    }

    public void MoveTowards(Vector2 goal)
    {
        Vector2 distance = goal - (Vector2) transform.position;
        rb.velocity = distance * speed;
    }
}
