using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittyDialogueChoice : MonoBehaviour
{
    public void BaileyDialogueOneResponseOne()
    {
        BaileyDialogue.BaileyDialogueString = "I am Lisa. The building manager of Building 13. And you are Fred.";
        BaileyDialogue.BaileyNeedsToRespond = true;
        Debug.Log("Kitty chose response number 1");
    }

    public void BaileyDialogueOneResponseTwo()
    {
        BaileyDialogue.BaileyDialogueString = "Ah, you are Fred indeed! It is I the fantastic and wonderous, Lisa!!! I am the building manager of Building 13.";
        BaileyDialogue.BaileyNeedsToRespond = true;
        Debug.Log("Kitty chose response number 2");
    }
}
