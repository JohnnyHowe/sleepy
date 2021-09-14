using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Image red;
    public Image green;
    RectTransform greenTrans;

    // Start is called before the first frame update
    void Start()
    {
        greenTrans = green.GetComponent<RectTransform>();
        SetProgress(0);
    }

    void SetProgress(float n)
    {
        float p = Mathf.Min(Mathf.Max(0, n), 1);

        Vector3 size = green.transform.localScale;
        size.x = p;
        green.transform.localScale = size;

        Vector2 pos = greenTrans.anchoredPosition;
        pos.x = (p - 1) * greenTrans.rect.width / 2;
        greenTrans.anchoredPosition = pos;
    }

    void Update()
    {
        SetProgress(GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().GetProgress());
    }
}
