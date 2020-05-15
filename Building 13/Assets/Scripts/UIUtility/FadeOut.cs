using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    [SerializeField]
    private float fadeSpeed = 1.0f; // Speed of the fade effect

    private CanvasGroup fadeCanvasGroup;

    private float alpha = 1.0f;

    void Awake()
    {
        fadeCanvasGroup = GetComponent<CanvasGroup>();
        if (fadeCanvasGroup == null)
            Debug.LogError("[warning] Please add Canvas Group component to the Fade Canvas for the fade effect");
        if (fadeCanvasGroup != null) fadeCanvasGroup.alpha = alpha;
    }

    void Update()
    {
        if (alpha >= 0.0f)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            fadeCanvasGroup.alpha = alpha;
            Debug.Log(alpha);
        }
    }


}
