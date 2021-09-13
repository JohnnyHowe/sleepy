using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Grabbable : MonoBehaviour
{
    [Header("Phyics/Movement")]
    public float speed = 1f;
    public float linearDeceleration = 0f;
    [Header("Color/Hover Things")]
    public Color hoveredColor = Color.green;
    Color normalColor;
    float hoveredTime = 0;
    public float hoverFadeTime = 0.5f;

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        normalColor = spriteRenderer.color;
    }

    void Update() {
        hoveredTime = Mathf.Max(0, hoveredTime - Time.deltaTime / hoverFadeTime);
        spriteRenderer.color = Color.Lerp(normalColor, hoveredColor, hoveredTime);
    }

    public void Hovered() {
        hoveredTime = Mathf.Min(1, hoveredTime + Time.deltaTime * 2 / hoverFadeTime);
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
