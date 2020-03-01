using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaileyDialogue : MonoBehaviour
{
    public static string BaileyDialogueString
    {
        get { return baileyDialogueString; }
        set { baileyDialogueString = value; }
    }

    [Header("Dialogue Canvas")]
    [SerializeField]
    private GameObject dialogueCanvas = null;

    [Header("Bailey Dialogue UI Objects")]

    [SerializeField]
    private GameObject baileyDialoguePanel = null;

    [SerializeField]
    private GameObject baileyPortraitPanel = null;

    [SerializeField]
    private Text dialogueText = null;

    [Header("Kitty Dialogue UI Objects")]
  
    [SerializeField]
    private GameObject kittyDialoguePanel = null;

    [SerializeField]
    private GameObject kittyPortraitPanel = null;

    public static bool BaileyNeedsToRespond
    {
        get { return baileyNeedsToRespond; }
        set { baileyNeedsToRespond = value; }
    }

    private static bool baileyNeedsToRespond = false;
    private bool dialogueComplete = false;
    

    private static string baileyDialogueString = "";

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
            if (!baileyNeedsToRespond)
            {
                Debug.Log("It is not Bailey's turn to respond.");
                kittyDialoguePanel.SetActive(true);
                kittyPortraitPanel.SetActive(true);
                baileyDialoguePanel.SetActive(false);
                baileyPortraitPanel.SetActive(false);
            }
            if (baileyNeedsToRespond)
            {
                Debug.Log("It is  Bailey's turn to respond.");
                kittyDialoguePanel.SetActive(false);
                kittyPortraitPanel.SetActive(false);
                baileyDialoguePanel.SetActive(true);
                baileyPortraitPanel.SetActive(true);
                dialogueText.text = baileyDialogueString;
                dialogueComplete = true;
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
