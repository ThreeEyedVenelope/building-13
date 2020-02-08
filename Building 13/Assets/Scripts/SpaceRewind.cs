using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceRewind : MonoBehaviour
{
    [Header("Space Rewind Collider Offset")]
    [SerializeField]
    private float offset = 0.2f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the GameObject colliding with the space rewind collider is a player
        if (other.gameObject.CompareTag("Player"))
        {
            // Retrieve player's current location
            Vector2 playerPosition = other.gameObject.transform.position;
            Debug.Log("Player's current location: " + playerPosition);
            if (playerPosition.x < 0) // Player is on the left side 
            {
                playerPosition.x = -playerPosition.x - offset; // Assign new value to x coordinate
            }
            else if (playerPosition.x > 0) // Player is on the right side
            {
                playerPosition.x = -playerPosition.x + offset; // Assig new value to x coordinate
            }
            other.gameObject.transform.position = playerPosition; // Assign new x coordinates to the player position
            Debug.Log("Player's new location: " + playerPosition);
        }
    }
}
