using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSimpleMove : MonoBehaviour
{
    public static bool EnableMove
    {
        get { return enableMove; }
        set { enableMove = value; }
    }
    
    private static bool enableMove = false;

    private  Transform trans = null;

    private float x = 0.0f;
    private float y = 0.0f;
    private float z = 0.0f;

    private int moveCount = 0; // Counts how many times the Move...() functions are called.
    void Awake()
    {
        trans = GetComponent<Transform>();
        x = trans.position.x;
        y = trans.position.y;
        z = trans.position.z;
    }

    void FixedUpdate()
    {
        if (enableMove)
        {
            MoveBackward();
        }
    }

    void MoveForward()
    {
        Debug.Log("MoveForward() called.");
        trans.position = new Vector3(x, y - 0.004f, z);
        y = trans.position.y; // Update y location to the new y location
        moveCount += 1;
        StopMove(); // Makes sure the method does not get called more than a certain move count
    }

    void MoveBackward()
    {
        Debug.Log("MoveBackward() called.");
        trans.position = new Vector3(x, y + 0.004f, z);
        y = trans.position.y; // Update y location to the new y location
        moveCount += 1;
        StopMove(); //  // Makes sure the method does not get called more than a certain move count
    }

    void StopMove()
    {
        if (moveCount == 80)
        {
            enableMove = false;
        }
    }
}
