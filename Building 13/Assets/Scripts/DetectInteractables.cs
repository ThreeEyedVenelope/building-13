using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectInteractables : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D playerInteractableArea = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        Debug.Log(other.gameObject.name + " is in Kitty's interactable area.");
    }
}
