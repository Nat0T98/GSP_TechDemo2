using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool isLockedByPassword;

    public Animator anim;

    public void OpenClose()
    {
        if (isLockedByPassword)
        {
            Debug.Log("Locked by password");
            return;
        }

        anim.SetTrigger("DoorOpen");
    }

}
