
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstDialogue : MonoBehaviour
{
    // There are 2 conversation starters for the first dialogue. They are Mr.Eyeball and Bailey. 
    // Value of this variable is set in EyeballTextTrigger or BaileyTextTrigger.
    public static string ConversationStarter
    {
        get { return conversationStarter; }
        set { conversationStarter = value; }
    }

    public static bool DialogueComplete
    {
        get { return dialogueComplete; }
        set { dialogueComplete = value; }
    }

    // DIALOGUE TURNS //
    public static bool EyeballsTurn
    {
        get { return eyeballsTurn; }
        set { eyeballsTurn = value; }
    }
    public static bool BaileysTurn
    {
        get { return baileysTurn; }
        set { baileysTurn = value; }
    }
    public static bool KittysTurn
    {
        get { return kittysTurn; }
        set { kittysTurn = value; }
    }

    // DIALOGUE TURNS //
    public static bool BaileyNeedsToRespond
    {
        get { return baileyNeedsToRespond; }
        set { baileyNeedsToRespond = value; }
    } // DO NOT USE   
    public static string BaileyDialogueString
    {
        get { return baileyDialogueString; }
        set { baileyDialogueString = value; }
    } // DO NOT USE 

    // DIALOGUE STRING //
    public static string EyeballString
    {
        get { return eyeballString;}
        set { eyeballString = value; }
    }

    public static string BaileyString
    {
        get { return baileyString; }
        set { baileyString = value; }
    }

    // DIALOGUE STRING //
    
    private Animator building13Door;

    [Header("Universal Dialgoue Game Objects ")]
    [SerializeField]
    private GameObject dialogueCanvas = null;
    [SerializeField]
    private Image portraitImage = null;
    [SerializeField]
    private Text portraitTitle = null;

    [Header("NPC Dialogue UI")]
    [SerializeField]
    private GameObject dialoguePanel = null;
    [SerializeField]
    private GameObject portraitPanel = null;
    [SerializeField]
    private Text dialogueText = null;

    [Header("Kitty Dialogue UI")]
    [SerializeField]
    private GameObject kittyDialoguePanel = null;
    [SerializeField]
    private GameObject kittyPortraitPanel = null;
    [SerializeField]
    private GameObject kittyChoicePanel = null;
    [SerializeField]
    private Text kittyDialogueText = null;
    [SerializeField]
    private Text kittyChoiceOneText = null;
    [SerializeField]
    private Text kittyChoiceTwoText = null;

    [Header("Eyeball Portrait Elements")]
    [SerializeField]
    private Sprite eyeballPortraitSprite = null;
    [SerializeField]
    private string eyeballName = "Eyeball";

    [Header("Bailey Portrait Elements")]
    [SerializeField]
    private Sprite baileyPortraitSprite = null;
    [SerializeField]
    private string baileyName = "Bailey";

    // First dialogue has two conversation starters: Bailey & Eyeball. 
    // The value of this variable will be set in BaileyTextTrigger & EyeballTextTrigger
    private static string conversationStarter = "";
    private static bool dialogueComplete = false;

    private static bool eyeballsTurn = false;
    private static bool baileysTurn = false;
    private static bool kittysTurn = false;

    private static bool baileyNeedsToRespond = false;
    private static string baileyDialogueString = "";

    private static string eyeballString = "";
    private static string baileyString = "";

    private bool reachingTheEndOfDialogue = false;

    void Awake()
    {
        PlayerController.PlayerCanMove = false;
        kittyDialoguePanel.SetActive(false);
        kittyPortraitPanel.SetActive(false);

        // Get door animator
        building13Door = GameObject.Find("Building13_Door").GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            Debug.Log("_Submit_ button pressed");
            NextDialogue();
        }
    }

    public void NextDialogue()
    {
        if (!dialogueComplete)
        {
            if(conversationStarter == "Eyeball")
            {
                Debug.Log("Initiating Choice 1. Conversation with Mr. Eyeball");

                if (!eyeballsTurn && baileysTurn && !kittysTurn) // BAILEYS TURN
                {
                    // Turn off kitty's dialogue 
                    Debug.Log("Turning off Kitty's dialogue panels");
                    kittyDialoguePanel.SetActive(false);
                    kittyPortraitPanel.SetActive(false);

                    //Turn on NPC dialogue 
                    Debug.Log("Turning on NPC dialogue panels");
                    dialoguePanel.SetActive(true);
                    portraitPanel.SetActive(true);

                    portraitImage.sprite = baileyPortraitSprite;
                    portraitTitle.text = baileyName;
                    dialogueText.text = baileyString;

                    // Kitty's turn upcoming 
                    eyeballsTurn = false;
                    baileysTurn = false;
                    kittysTurn = true;

                    if (reachingTheEndOfDialogue)
                    {
                        dialogueComplete = true;
                    }
                }
                else if (!eyeballsTurn && !baileysTurn && kittysTurn) // KITTYS TURN 
                {
                    // Turn off NPC dialogue 
                    Debug.Log("Turning off NPC dialogue panels");
                    dialoguePanel.SetActive(false);
                    portraitPanel.SetActive(false);

                    // Kitty turn
                    Debug.Log("Turning on Kitty's dialogue panels");
                    kittyChoiceOneText.text = "Oh sir, I’m sorry. I didn’t mean to offend you.";
                    kittyChoiceTwoText.text = "I don’t think I’m better than you, but maybe I am.Only God could tell if I am.";
                    kittyDialoguePanel.SetActive(true);
                    kittyPortraitPanel.SetActive(true);
                    kittyChoicePanel.SetActive(true);

                    // Bailey's turn upcoming
                    baileyString = "I’M A LADY!";
                    eyeballsTurn = false;
                    baileysTurn = true;
                    kittysTurn = false;
                }
            }
            else if (conversationStarter == "Bailey")
            {
                Debug.Log("Initating Choice 2. Conversation with Bailey");

                if (!eyeballsTurn && !baileysTurn && kittysTurn) // KITTYS TURN
                {
                    Debug.Log("It is Kitty's turn to speak");

                    // Turn off NPC dialogue panels 
                    Debug.Log("Turning off NPC dialgoue panels");
                    dialoguePanel.SetActive(false);
                    portraitPanel.SetActive(false);
                    // Kitty's 1st dialogue choice 
                    Debug.Log("Turning on Kitty's dialogue panels");
                    kittyDialoguePanel.SetActive(true);
                    kittyPortraitPanel.SetActive(true);
                }
                else if (!eyeballsTurn && baileysTurn && !kittysTurn) // BAILEYS TURN
                {
                    // Set Baileys' dialogue 
                    // Bailey's response has been set in KittyDialogueChoice.cs
                    dialogueText.text = BaileyDialogueString;

                    //Turn off Kitty's dialogue panels 
                    kittyDialoguePanel.SetActive(false);
                    kittyPortraitPanel.SetActive(false);
                    // Turn on NPC dialogue paneles 
                    dialoguePanel.SetActive(true);
                    portraitPanel.SetActive(true);

                    // Bailey's turn has ended and it is now Eyeball's turn to speak
                    ItIsEyeballsTurn();
                }
                else if (eyeballsTurn && !baileysTurn && !kittysTurn) // MR. EYEBALLS TURN
                {
                    // Set up Mr.Eyeball's dialogue 
                    portraitImage.sprite = eyeballPortraitSprite;
                    portraitTitle.text = eyeballName;
                    dialogueText.text = eyeballString;
                    dialogueComplete = true; // The end of the First dialogue at the moment! 
                }
            }  
        }
        else if (dialogueComplete)
        {
            dialogueCanvas.SetActive(false);
            PlayerController.PlayerCanMove = true;
            Debug.Log("The dialogue has ended.");
            
            //Animate door powering up
            building13Door.SetBool("PowerUp", true);
            
            //Door open animation
        }
    }

    public void KittyResponseOne()
    {
        Debug.Log("Kitty chose response number 1");
        if (ConversationStarter == "Eyeball")
        {
            BaileyString = "I’M A LADY!";
        }
        else if (ConversationStarter == "Bailey")
        {
            BaileyDialogueString = "I am Lisa. The building manager of Building 13. And you are Fred.";
            EyeballString = "Identity theft threat has been detected. Bailey is pretending to be Lisa. Lisa will be here shortly to detain and question Bailey.";
            BaileysTurn = true;
            ItIsBaileysTurn();
        }
        reachingTheEndOfDialogue = true;
        NextDialogue();
    }

    public void KittyResponseTwo()
    {
        Debug.Log("Kitty chose response number 2");
        if (ConversationStarter == "Eyeball")
        {
            BaileyString = "Wow, ok.";
        }
        else if (ConversationStarter == "Bailey")
        {
            BaileyDialogueString = "Ah, you are Fred indeed! It is I the fantastic and wonderous, Lisa!!! I am the building manager of Building 13.";
            EyeballString = "Dear Fred, please step back from the imposter. The imposter’s name is Bailey, and she has triggered an identity theft alert. Lisa will be down shortly to detain and question Bailey.";
            ItIsBaileysTurn();
        }
        reachingTheEndOfDialogue = true;
        NextDialogue();
    }

    public void ItIsEyeballsTurn()
    {
        eyeballsTurn = true;
        baileysTurn = false;
        kittysTurn = false;
    }

    public void ItIsBaileysTurn()
    {
        baileysTurn = true;
        eyeballsTurn = false;
        kittysTurn = false;
    }
}
