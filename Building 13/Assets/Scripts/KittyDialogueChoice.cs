﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittyDialogueChoice : MonoBehaviour
{
    public void KittyResponseOne()
    {
        Debug.Log("Kitty chose response number 1");
        if (FirstDialogue.ConversationStarter == "Eyeball")
        {
            FirstDialogue.BaileyString = "I’M A LADY!";
        }
        else if (FirstDialogue.ConversationStarter == "Bailey")
        {
            FirstDialogue.BaileyDialogueString = "I am Lisa. The building manager of Building 13. And you are Fred.";
            FirstDialogue.EyeballString = "Identity theft threat has been detected. Bailey is pretending to be Lisa. Lisa will be here shortly to detain and question Bailey.";
            FirstDialogue.BaileysTurn = true;  
        }   
    }

    public void KittyResponseTwo()
    {
        Debug.Log("Kitty chose response number 2");
        if (FirstDialogue.ConversationStarter == "Eyeball")
        {
            FirstDialogue.BaileyString = "Wow, ok.";
        }
        else if (FirstDialogue.ConversationStarter == "Bailey")
        {
            FirstDialogue.BaileyDialogueString = "Ah, you are Fred indeed! It is I the fantastic and wonderous, Lisa!!! I am the building manager of Building 13.";
            FirstDialogue.EyeballString = "Dear Fred, please step back from the imposter. The imposter’s name is Bailey, and she has triggered an identity theft alert. Lisa will be down shortly to detain and question Bailey.";
            FirstDialogue.BaileysTurn = true;
        }
    }
}
