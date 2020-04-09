using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building13MainDoor : MonoBehaviour
{
    private Animator doorAnimator;

    [Header("Lisa related")]
    private GameObject lisa;
    private LisaDialogue lisaDialogue;

    void Awake()
    {
        if(GameObject.Find("Lisa") != null)
        {
            lisa = GameObject.Find("Lisa");
            lisaDialogue = lisa.GetComponent<LisaDialogue>();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
       
        // Make Lisa invisible so she doesn't show up behind the door accidentally
        lisa.SetActive(false);

        // Make sure that the door's animator variables are set properly
        doorAnimator.SetBool("PowerUpComplete", false);
        doorAnimator.SetBool("PowerUp", false);
        doorAnimator.SetBool("Door_IsClosed", true);
        doorAnimator.SetBool("Door_IsClosing", false);
        doorAnimator.SetBool("Door_IsOpen", false);
        doorAnimator.SetBool("Door_IsOpening", false);
    }

    public void DoorPowerUpComplete()
    {
        doorAnimator.SetBool("PowerUpComplete", true);
        doorAnimator.SetBool("PowerUp", false);
    }

    public void StartOpeningDoor()
    {
        // Make Lisa visible when the door starts to open
        lisa.SetActive(true);
        doorAnimator.SetBool("Door_IsOpening", true);
    }

    public void DoorFinishedOpening()
    {
        doorAnimator.SetBool("Door_IsOpening", false);
        doorAnimator.SetBool("Door_IsOpen", true);

        // Lisa's dialogue should appear after Building 13's front door has opened. 
        
        lisaDialogue.ShowLisaDialogue();
    }

    public void DoorFinishedClosing()
    {
        doorAnimator.SetBool("Door_IsClosing", true);
        doorAnimator.SetBool("Door_IsClosed", true);
    }
}
