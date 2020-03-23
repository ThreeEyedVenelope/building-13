using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LisaDialogue : MonoBehaviour
{
    [Header("Lisa's UI game objects")]
    [SerializeField]
    private GameObject dialogueCanvas = null;
    [SerializeField]
    private GameObject dialoguePanel = null;
    [SerializeField]
    private GameObject portraitPanel = null;
    [SerializeField]
    private Text portraitTitle = null;
    [SerializeField]
    private Text dialogueText = null;
    [SerializeField]
    private Image portraitImage = null;
    [SerializeField]
    private Sprite lisaHeadshot = null;

    private string lisaName = "Lisa";
    private string lisaDialogue = "";

    public void ShowLisaDialogue()
    {
        CheckForEdition();
        TurnOnLisaDialogue();
    }

    void CheckForEdition()
    {
        if (FirstDialogue.ConversationStarter == "Eyeball")
        {
            lisaDialogue = "Welcome to Purrgatory, Kitty! Please follow me.";
            Debug.Log("Lisa Dialogue Type = First Edition");
        }
        else if (FirstDialogue.ConversationStarter == "Bailey")
        {
            lisaDialogue = "Good evening Bailey, haven’t we talked about this before? Ah and hello, Kitty. Here, let's take this inside.";
            Debug.Log("Lisa Dialogue Type = Second Edition");
        }
        dialogueText.text = lisaDialogue;
    }
    void TurnOnLisaDialogue()
    {
        Debug.Log("Turning on Bailey's dialogue");
        portraitTitle.text = lisaName.ToUpper();
        portraitImage.sprite = lisaHeadshot;
        
        dialogueCanvas.SetActive(true);
        dialoguePanel.SetActive(true);
        portraitPanel.SetActive(true);
        Debug.Log("Finished turning on Lisa's dialogue");
    }
}
