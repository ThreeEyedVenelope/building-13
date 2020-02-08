using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceRewind : MonoBehaviour
{
    [Header("Mark the side the collider is on")]

    [Tooltip("Check if the collider is on the left side of the screen")]
    [SerializeField]
    private bool leftCollider = false;

    [Tooltip("Check if the collider is on the right side of the screen")]
    [SerializeField]
    private bool rightCollider = false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the GameObject colliding with the space rewind collider is a player
        if (other.gameObject.CompareTag("Player"))
        {
            // Player is colliding with space rewind collider on the left side 
            if (leftCollider)
            {
                Debug.Log("Player is collidng with the left space rewind collider.");
                // Move the player to the right edge of the scene
                //other.gameObject.transform
            }
            // Player is colliding with space rewind collider on the right side 
            else if (rightCollider)
            {
                Debug.Log("Player is colliding with the right space rewind collider.");
                // Move the player to the left edge of the scene
            }
        }
    }
}
