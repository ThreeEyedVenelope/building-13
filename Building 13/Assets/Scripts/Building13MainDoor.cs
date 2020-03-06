using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building13MainDoor : MonoBehaviour
{
    private Animator doorAnimator;

    // Start is called before the first frame update
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
    }

    public void DoorPowerUpComplete()
    {
        doorAnimator.SetBool("PowerUpComplete", true);
        doorAnimator.SetBool("PowerUp", false);
    }
}
