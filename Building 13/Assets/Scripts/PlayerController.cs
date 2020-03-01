using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static bool PlayerCanMove
    {
        get { return playerCanMove; }
        set { playerCanMove = value; }
    }

    [SerializeField]
    private float playerSpeed = 3.0f;

    private static bool playerCanMove = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCanMove)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector2 position = transform.position;
            position.x = position.x + playerSpeed * horizontal * Time.deltaTime;
            position.y = position.y + playerSpeed * vertical * Time.deltaTime;
            transform.position = position;
        }
    }
}
