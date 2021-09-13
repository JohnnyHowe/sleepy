using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handle the hand.
/// 
/// Move the hand to the mouse (in world coordinates).
/// Position is limited to the window area.
/// </summary>
public class Hand : MonoBehaviour
{
    void Update()
    {
        transform.position = GetMouseWorldPosition();
    }

    Vector2 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(GetCappedMousePosition());
    }

    Vector2 GetCappedMousePosition() {
        return Vector2.Min(Vector2.Max(Vector2.zero, Input.mousePosition), new Vector2(Screen.width, Screen.height));
    }
}
