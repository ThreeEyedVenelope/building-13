using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaileyDialogueFirstScene : MonoBehaviour
{
    [Header("Drag and drop Bailey's dialogue text UI")]
    [SerializeField]
    private Text baileysText =  null;

    [SerializeField]
    private string baileysDialogue0 = "Hey Fred.";

    private bool kittyMetBailey = false;

    void Awake()
    {
        if(!kittyMetBailey)
        {
            baileysText.text = baileysDialogue0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
