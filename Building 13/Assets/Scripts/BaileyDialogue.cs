using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaileyDialogue : MonoBehaviour
{
    [Header("Dialogue Canvas")]
    [SerializeField]
    private GameObject dialogueCanvas = null;

    [Header("Portrait Panel")]
    [SerializeField]
    private Image portraitImage = null;

    [Header("Bailey's headshot")]
    [SerializeField]
    private Sprite baileyHeadshot = null;

    [Header("Portrait Title")]
    [SerializeField]
    private Text portraitTitle = null;

    [Header("Dialogue Text")]
    [SerializeField]
    private Text dialogueText = null;

    private string charactereName = "Bailey";

    private bool playerColliding = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if (playerColliding)
            {
                portraitImage.sprite = baileyHeadshot;
                portraitTitle.text = charactereName;
                dialogueText.text = "HELLO! Ahem, I mean, hello, and welcome to Building 13! So Fred, how may I assist you today?";
                dialogueCanvas.SetActive(true);
            }
        }

        if (Input.GetButtonDown("Submit"))
        {
            dialogueCanvas.SetActive(false);
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
}
