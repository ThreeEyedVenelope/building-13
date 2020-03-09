using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameTagTrigger : MonoBehaviour
{
    [Header("This object's name tag")]
    [SerializeField]
    private GameObject PopUpText;

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
        PopUpText.SetActive(true);
    }

    void KittyExitingTrigger()
    {
        PopUpText.SetActive(false);
    }
}
