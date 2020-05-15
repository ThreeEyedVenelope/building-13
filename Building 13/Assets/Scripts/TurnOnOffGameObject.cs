using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script turns on/off select game object based on a UNITY UI button. 
public class TurnOnOffGameObject : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToOnOff;

    public void TurnOnObject()
    {
        objectToOnOff.SetActive(true);
    }

    public void TurnOffObject()
    {
        objectToOnOff.SetActive(false);
    }
}
