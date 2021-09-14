using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float progress;
    public float minGameTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        progress = 0;
    }

    // Update is called once per frame
    void Update()
    {
        progress += Time.deltaTime / minGameTime;
    }

    public float GetProgress()
    {
        return progress;
    }
}
