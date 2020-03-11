using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyeballTextTrigger : MonoBehaviour
{
    [Header("Eyeball's name tag UI")]
    [SerializeField]
    private GameObject popUpText;

    [Header("Eyeball's UI game objects")]
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
    private Sprite eyeballPortraitSprite = null;

    private string eyeballName = "Mr.Eyeball";
    private string eyeballFirstString = "Hello, Kitty. Welcome to Purrgatory. I am Eyeball, an extended organ of the building manager for Building 13. Building 13 is a welcoming place, and it was built in universal year 333 by the Purrgatory Whores. You will be staying here until you feel comfortable enough to venture into the greater part of Purrgatory. Lisa, the building manager, will be here in a moment to take you to your room. I thank you in advance for your patience.";

    private bool pendingDialogue = false;

    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if (!FirstDialogue.DialogueComplete)
            {
                if (pendingDialogue)
                {
                    Debug.Log("There is a pending dialouge with Eyeball.");
                    TurningOnEyeballDialogue();
                    FirstDialogue.ConversationStarter = "Eyeball";
                    Debug.Log("First dialogue conversation starter set as Eyeball");

                    // Bailey's turn upcoming 

                    FirstDialogue.BaileyString = "Well, well, well... You think you are better than me? You would rather talk to that robotic eyeball instead of me? ";

                    FirstDialogue.EyeballsTurn = false;
                    FirstDialogue.BaileysTurn = true;
                    FirstDialogue.KittysTurn = false;
                }
            }
            else if (FirstDialogue.DialogueComplete)
            {
                Debug.Log("Kitty has already completed the first dialogue.");
            }
            
        }
    }

    void TurningOnEyeballDialogue()
    {
        Debug.Log("Turning on Eyeball dialogue");
        portraitTitle.text = eyeballName.ToUpper();
        portraitImage.sprite = eyeballPortraitSprite;
        dialogueText.text = eyeballFirstString;
        dialogueCanvas.SetActive(true);
        dialoguePanel.SetActive(true);
        portraitPanel.SetActive(true);
        Debug.Log("Finished turning on Eyeball dialogue");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
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
        Debug.Log("Kitty is entering Eyeball's trigger zone.");
        popUpText.SetActive(true);
        pendingDialogue = true;
    }

    void KittyExitingTrigger()
    {
        Debug.Log("Kitty is exiting Eyeball's trigger zone.");
        popUpText.SetActive(false);
        pendingDialogue = false;
    }
}
