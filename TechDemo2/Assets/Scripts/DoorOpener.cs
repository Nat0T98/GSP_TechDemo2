using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    
    public KeypadControl script;
    void Update()
    {
        if (script.doorLocked == false) 
        {
            Destroy(gameObject);
        }
    }
}

