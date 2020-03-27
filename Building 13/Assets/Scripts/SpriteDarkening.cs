using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDarkening : MonoBehaviour
{
    private SpriteRenderer spriteRenderer = null;
    private Color32 spriteColor;
    public static bool StartDarkening 
    {
        get { return startDarkening; }
        set { startDarkening = value; }
    }

    private static bool startDarkening = false;

    private byte rgbValue = 255;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (startDarkening)
        {
            Debug.Log("startDarkening = true");
            Debug.Log("calling DarkenSprite()");
            DarkenSprite();
        }
    }
    void DarkenSprite()
    {
        if (rgbValue != 0) 
        {
            rgbValue--;
            Debug.Log(rgbValue);
            spriteColor = new Color32(rgbValue, rgbValue, rgbValue, 255);
            spriteRenderer.color = spriteColor;
        }
    }
}
