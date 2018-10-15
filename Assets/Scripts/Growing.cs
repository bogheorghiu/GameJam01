using UnityEngine;
using System.Collections;

public class Growing : MonoBehaviour
{
    int startSize = 1;
    int minSize = 1;
    int maxSize = 1;

    public float speed = 0.5f;

    private Vector3 targetScale;
    private Vector3 baseScale;
    private int currScale;

    void Start()
    {
        baseScale = transform.localScale;
        transform.localScale = baseScale * startSize;
        currScale = startSize;
        targetScale = baseScale * startSize;
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(baseScale, new Vector3(maxx, maxy, maxz), fly);


        if (Input.GetMouseButton(1))
            ChangeSize(true);
        if (Input.GetMouseButtonUp(1))
        {
            ChangeSize(false);
            fly = 0f;
        }
    }
    float maxx = 2f;
    float maxy = 4f; 
    float maxz = 1.5f;
    float fly = 0f;
    public void ChangeSize(bool bigger)
    {

        if (bigger)
            currScale++;
        else
            currScale--;

        currScale = Mathf.Clamp(currScale, minSize, maxSize + 1);

        targetScale = baseScale * currScale;

        Mathf.Clamp01(fly+=0.1f);
    }
}
