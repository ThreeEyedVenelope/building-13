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

                // Retrieve player's current location
                Vector2 playerPosition = other.gameObject.transform.position;
                Debug.Log("Player's current location: " + playerPosition);

                // Move the player to the right edge of the scene 
                playerPosition.x = 8.5f; // Assign new value to x coordinate
                other.gameObject.transform.position = playerPosition; // Assign new x coordinate to the player position
                Debug.Log("Player's new location: " + playerPosition); 
            }
            // Player is colliding with space rewind collider on the right side 
            else if (rightCollider)
            {
                Debug.Log("Player is colliding with the right space rewind collider.");

                // Retrieve player's current location
                Vector2 playerPosition = other.gameObject.transform.position;
                Debug.Log("Player's current location: " + playerPosition);

                // Move the player to the left edge of the scene
                playerPosition.x = -8.5f; // Assign new value to x coordinate 
                other.gameObject.transform.position = playerPosition; // Assign new x coordinate to the player position
                Debug.Log("Player's new location: " + playerPosition);
            }
            
        }
    }
}
