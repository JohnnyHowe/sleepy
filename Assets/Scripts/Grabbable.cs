using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Grabbable : MonoBehaviour
{
    [Header("Phyics/Movement")]
    public float speed = 1f;
    [Header("Color/Hover Things")]
    public Color hoveredColor = Color.green;
    Color normalColor;
    float hoveredTime = 0;
    public float hoverFadeTime = 0.5f;

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        normalColor = spriteRenderer.color;
    }

    void Update()
    {
        hoveredTime = Mathf.Max(0, hoveredTime - Time.deltaTime / hoverFadeTime);
        spriteRenderer.color = Color.Lerp(normalColor, hoveredColor, hoveredTime);
    }

    public void Hovered()
    {
        hoveredTime = Mathf.Min(1, hoveredTime + Time.deltaTime * 2 / hoverFadeTime);
    }

    public void MoveTowards(Vector2 goal)
    {
        Vector2 distance = goal - (Vector2)transform.position;
        rb.velocity = distance * speed;
    }
}
