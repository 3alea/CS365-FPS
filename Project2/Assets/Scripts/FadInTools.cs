using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadInTools : MonoBehaviour
{
    public TextMeshProUGUI Image;
    public RectTransform rectTrans;
    public float maxScale;
    public float lerpSped;
    public float maxOffsetSin;
    public float offsetSpeed;
    Vector3 originalScale;
    Vector3 OriginalPos;
    float alpha;
    float scale;
    float angle;

    // Start is called before the first frame update
    void Start()
    {
        alpha = 0.0f;
        originalScale = rectTrans.localScale;
        OriginalPos = rectTrans.localPosition;
        scale = 1.0f;
        angle = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        angle += Time.deltaTime * offsetSpeed;
        alpha = Mathf.Lerp(alpha, 1.0f, lerpSped);
        scale = Mathf.Lerp(scale, maxScale, lerpSped);

        Image.color = new Color(Image.color.r, Image.color.g, Image.color.b, alpha);
        rectTrans.localScale = new Vector3(originalScale.x * scale,originalScale.y * scale,originalScale.z);
        rectTrans.localPosition = new Vector3(OriginalPos.x, OriginalPos.y + Mathf.Sin(angle) * maxOffsetSin, OriginalPos.z);
    }
}
