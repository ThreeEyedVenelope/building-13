using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaileyTextTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject popUpText = null;

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

    private bool pendingDialogue = true;

    private bool playerColliding = false;

    private string baileyName = "Bailey";
    private string baileyFirstString = "HELLO! Ahem, I mean, hello, and welcome to Building 13! So Fred, how may I assist you today?";

    void Awake()
    {
        popUpText.SetActive(false);
        portraitTitle.text = baileyName.ToUpper();
        portraitImage.sprite = baileyHeadshot;
        dialogueText.text = baileyFirstString;
    }
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            Debug.Log("Kitty is attempting to interact.");
            if (pendingDialogue)
            {
                Debug.Log("There is a pending dialouge.");
                dialogueCanvas.SetActive(true);
                baileyDialoguePanel.SetActive(true);
                baileyPortraitPanel.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the GameObject colliding with the space rewind collider is a player
        if (other.gameObject.CompareTag("Player"))
        {
            popUpText.SetActive(true);
            playerColliding = true;
            Debug.Log("The player is colliding with Bailey.");
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            popUpText.SetActive(false);
            playerColliding = false;
            Debug.Log("The player is no longer colliding with Bailey.");
        }
    }
}
