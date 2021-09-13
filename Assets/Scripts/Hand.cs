using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Handle the hand movement and grabbing.
/// 
/// Move the hand to the mouse (in world coordinates).
/// Position is limited to the window area.
/// </summary>
public class Hand : MonoBehaviour
{
    public UnityEvent onGrab;
    public UnityEvent onRelease;
    Grabbable grabbedItem;

    void Awake()
    {
        grabbedItem = null;
    }

    void Update()
    {
        transform.position = GetMouseWorldPosition();

        if (Input.GetMouseButtonDown(0))
        {
            onGrab.Invoke();
            grabbedItem = GetGrabbable();
        }
        if (Input.GetMouseButtonUp(0))
        {
            onRelease.Invoke();
            grabbedItem = null;
        }

        if (grabbedItem) {
            grabbedItem.MoveTowards(transform.position);
        }
    }

    Vector2 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(GetCappedMousePosition());
    }

    Vector2 GetCappedMousePosition()
    {
        return Vector2.Min(Vector2.Max(Vector2.zero, Input.mousePosition), new Vector2(Screen.width, Screen.height));
    }

    Grabbable GetGrabbable()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.zero);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.gameObject.TryGetComponent(out Grabbable grabbable))
            {
                return grabbable;
            }
        }
        return null;
    }
}
