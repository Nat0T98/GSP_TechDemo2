using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNote : MonoBehaviour
{
    private NoteScript activeNote;
    private GameObject interactMessage;

    void Start()
    {
        interactMessage = GameObject.Find("InteractMessage");
        interactMessage.SetActive(false);
    }

    void Update()
    {
        if (activeNote)
        {
            if (Input.GetKeyDown(KeyCode.R)) 
            {
                activeNote.ToggleNote();
            }
        }
    }

    private void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Note")
        {
            Col.gameObject.TryGetComponent(out activeNote);
            interactMessage.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider Col)
    {
        if(Col.gameObject.tag == "Note")
        {
            if(activeNote.GetNoteStatus())
            {
                activeNote.ToggleNote();
            }
            activeNote = null;
            interactMessage.SetActive(false);
        }
    }
}
