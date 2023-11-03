using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTooltip : MonoBehaviour
{
    private ToolTip activeToolTip;
    private GameObject ToolTipMessage;

    void Start()
    {
        ToolTipMessage = GameObject.Find("ToolTipMessage");
        ToolTipMessage.SetActive(false);
    }

    /*void Update()
    {
        if (activeToolTip)
        {
            if (Input.GetMouseButtonDown(0))
            {
                activeToolTip.ToggleToolTip();
            }
        }
    }*/

    private void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "ToolTip")
        {
            
            ToolTipMessage.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider Col)
    {
        if (Col.gameObject.tag == "ToolTip")
        {
            
            ToolTipMessage.SetActive(false);
        }
    }
}
