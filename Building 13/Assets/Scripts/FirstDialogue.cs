using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstDialogue : MonoBehaviour
{
    public static bool BaileyNeedsToRespond
    {
        get { return baileyNeedsToRespond; }
        set { baileyNeedsToRespond = value; }
    }
    public static string BaileyDialogueString
    {
        get { return baileyDialogueString; }
        set { baileyDialogueString = value; }
    }

    public static string EyeballString
    {
        get { return eyeballString;}
        set { eyeballString = value; }
    }

    [Header("Universal Dialgoue Game Objects ")]
    [SerializeField]
    private GameObject dialogueCanvas = null;
    [SerializeField]
    private Image portraitImage = null;
    [SerializeField]
    private Text portraitTitle = null;

    [Header("Bailey Dialogue UI")]
    [SerializeField]
    private GameObject baileyDialoguePanel = null;
    [SerializeField]
    private GameObject baileyPortraitPanel = null;
    [SerializeField]
    private Text dialogueText = null;

    [Header("Kitty Dialogue UI")]
    [SerializeField]
    private GameObject kittyDialoguePanel = null;
    [SerializeField]
    private GameObject kittyPortraitPanel = null;

    [Header("Eyeball Dialogue UI")]
    [SerializeField]
    private Sprite eyeballPortraitSprite = null;
    [SerializeField]
    private string eyeballName = "Eyeball";

    private static bool baileyNeedsToRespond = false;
    private static string baileyDialogueString = "";

    private static string eyeballString = "";


    private bool dialogueComplete = false;
    private bool eyeballsTurn = false;

    void Awake()
    {
        PlayerController.PlayerCanMove = false;
        kittyDialoguePanel.SetActive(false);
        kittyPortraitPanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            NextDialogue();
        }
    }

    public void NextDialogue()
    {
        if (!dialogueComplete)
        {
            if (!eyeballsTurn)
            {
                if (!baileyNeedsToRespond)
                {
                    //Kitty's 1st dialogue choice 
                    kittyDialoguePanel.SetActive(true);
                    kittyPortraitPanel.SetActive(true);
                    baileyDialoguePanel.SetActive(false);
                    baileyPortraitPanel.SetActive(false);
                }
                else if (baileyNeedsToRespond)
                {
                    //Bailey is responding to Kitty's 1st dialogue choice. 
                    //Bailey's response has been set in KittyDialogueChoice.cs
                    kittyDialoguePanel.SetActive(false);
                    kittyPortraitPanel.SetActive(false);
                    baileyDialoguePanel.SetActive(true);
                    baileyPortraitPanel.SetActive(true);
                    dialogueText.text = BaileyDialogueString;

                    //Bailey's turn has ended and it is no Eyeball's turn to speak
                    eyeballsTurn = true;
                }
            }
            else if (eyeballsTurn)
            {
                portraitImage.sprite = eyeballPortraitSprite;
                portraitTitle.text = eyeballName;
                dialogueText.text = eyeballString;
                dialogueComplete = true; //The end of the First Dialgoue at the moment!
            }
        }
        else if (dialogueComplete)
        {
            dialogueCanvas.SetActive(false);
            PlayerController.PlayerCanMove = true;
            Debug.Log("The dialogue has ended.");
        }
    }

    public void ResponseSelected()
    {
        if(BaileyNeedsToRespond)
        {
            baileyDialoguePanel.SetActive(true);
            baileyPortraitPanel.SetActive(true);
            kittyDialoguePanel.SetActive(false);
            kittyPortraitPanel.SetActive(false);
            dialogueText.text = baileyDialogueString;
        }
    }   
}
