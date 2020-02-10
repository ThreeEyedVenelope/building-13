using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    [Header("Drag and drop PopUpText game object.")]
    [SerializeField]
    private GameObject popUpText = null;

    void Awake()
    {
        popUpText.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the GameObject colliding with the space rewind collider is a player
        if (other.gameObject.CompareTag("Player"))
        {
            popUpText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            popUpText.SetActive(false);
        }
    }
}
