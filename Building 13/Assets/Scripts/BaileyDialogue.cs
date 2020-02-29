using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaileyDialogue : MonoBehaviour
{
    [Header("Dialogue Canvas")]
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

    [Header("Kitty Dialogue UI Objects")]
  
    [SerializeField]
    private GameObject KittyDialoguePanel = null;

    [SerializeField]
    private GameObject KittyPortraitPanel = null;

    [SerializeField]
    private Text KittyDialogueText = null;

    private string charactereName = "Bailey";
    private bool playerColliding = false;
    private bool dialogueComplete = false;
    private bool kittysTurn = false;

    private string baileyDialogueString = "";
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if (playerColliding)
            {
                Dialogue();
            }
        }

        if (Input.GetButtonDown("Submit"))
        {
            NextDialogue();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("The player is colliding with Bailey.");
            playerColliding = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("The player is no longer colliding with Bailey.");
            playerColliding = false;
        }
    }

    void Dialogue()
    {
        KittyDialoguePanel.SetActive(false);
        KittyPortraitPanel.SetActive(false);
        portraitImage.sprite = baileyHeadshot;
        portraitTitle.text = charactereName.ToUpper();
        dialogueText.text = "HELLO! Ahem, I mean, hello, and welcome to Building 13! So Fred, how may I assist you today?";
        dialogueComplete = false;
        kittysTurn = true;
        dialogueCanvas.SetActive(true);
    }

    void NextDialogue()
    {
        if (!dialogueComplete)
        {
            baileyDialogueString = "I am Lisa. The building manager of Building 13. And you are Fred.";
            if (kittysTurn)
            {
                baileyDialoguePanel.SetActive(false);
                baileyPortraitPanel.SetActive(false);
                KittyDialoguePanel.SetActive(true);
                KittyPortraitPanel.SetActive(true);
                KittyDialogueText.text = "I'm not... Fred. May name is Kitty. Who are you?";
                kittysTurn = false;
            }
            else if (!kittysTurn)
            {
                baileyDialoguePanel.SetActive(true);
                baileyPortraitPanel.SetActive(true);
                KittyDialoguePanel.SetActive(false);
                KittyPortraitPanel.SetActive(false);
                dialogueText.text = baileyDialogueString;
                dialogueComplete = true;
            }
        }
        else if (dialogueComplete)
        {
            dialogueCanvas.SetActive(false);
        }
    }
}
