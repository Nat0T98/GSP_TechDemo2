using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ToolTip : MonoBehaviour
{
    private bool ToolTipStatus;
    public GameObject note;

    public void ToggleToolTip()
    {
        ToolTipStatus = !ToolTipStatus;
        note.SetActive(ToolTipStatus);
    }

    public bool GetToolTipStatus()
    {
        return ToolTipStatus;
    }
}
