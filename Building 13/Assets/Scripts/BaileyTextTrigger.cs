using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaileyTextTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject baileysNameTag= null;

    [SerializeField]
    private GameObject dialogueCanvas = null;

    [Header("Bailey Dialogue UI Objects")]

    [SerializeField]
    private GameObject baileyDialoguePanel = null;

    [SerializeField]
    private GameObject baileyPortraitPanel = null;

    [SerializeField]
    private Text portraitTitle = null;

    [SerializeField]
    private Text dialogueText = null;

    [SerializeField]
    private Image portraitImage = null;

    [SerializeField]
    private Sprite baileyHeadshot = null;

    private bool pendingDialogue = false;

    private string baileyName = "Bailey";
    private string baileyFirstString = "HELLO! Ahem, I mean, hello, and welcome to Building 13! So Fred, how may I assist you today?";

    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            Debug.Log("Kitty is attempting to interact with Bailey.");
            
            if (!FirstDialogue.DialogueComplete)
            {
                if (pendingDialogue)
                {
                    Debug.Log("There is a pending dialouge with Bailey.");
                    TurnOnBaileyDialogue();
                    FirstDialogue.ConversationStarter = "Bailey";
                    Debug.Log("First dialgoue conversation starter set as Bailey");

                    FirstDialogue.BaileysTurn = false;
                    FirstDialogue.EyeballsTurn = false;
                    FirstDialogue.KittysTurn = true;
                }
            }
            else if (FirstDialogue.DialogueComplete)
            {
                Debug.Log("Kitty has already completed the first dialogue.");
            }
           
        }
    }

    private void TurnOnBaileyDialogue()
    {
        Debug.Log("Turning on Bailey's dialogue");
        portraitTitle.text = baileyName.ToUpper();
        portraitImage.sprite = baileyHeadshot;
        dialogueText.text = baileyFirstString;
        dialogueCanvas.SetActive(true);
        baileyDialoguePanel.SetActive(true);
        baileyPortraitPanel.SetActive(true);
        baileysNameTag.SetActive(false); 
        Debug.Log("Finished turning on Bailey's dialogue");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the GameObject colliding with the space rewind collider is a player
        if (other.gameObject.CompareTag("Player"))
        {
            KittyEnteringTrigger();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            KittyExitingTrigger();
        }
    }

    void KittyEnteringTrigger()
    {
        Debug.Log("KItty is entering Bailey's trigger zone.");
        baileysNameTag.SetActive(true);
        pendingDialogue = true;
    }

    void KittyExitingTrigger()
    {
        Debug.Log("Kitty is exiting Bailey's trigger zone."); 
        baileysNameTag.SetActive(false);
        pendingDialogue = false;
    }
}
