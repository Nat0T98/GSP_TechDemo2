using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadControl : MonoBehaviour
{
    public string password;
    public int passwordLimit;
    public Text passwordText;
    public Animator anim;
    public bool doorLocked;

    private void Start()
    {
        doorLocked = true;
        passwordText.text = "";
    }

   

    public void PasswordEntry(string number)
    {
        if (number == "Clear")
        {
            Clear();
            return;
        }
        else if(number == "Enter")
        {
            Enter();
            return;
        }

        int length = passwordText.text.ToString().Length;
        if(length<passwordLimit)
        {
            passwordText.text = passwordText.text + number;
        }
    }

    public void Clear()
    {
        passwordText.text = "";
        passwordText.color = Color.white;
    }

    private void Enter()
    {
        if (passwordText.text == password)
        {
            doorLocked = false;

            AudioManager.Manager.PlaySFX("KeypadCorrect");
            passwordText.color = Color.green;
            DoorOpen();
            StartCoroutine(waitAndClear());
            
        }
        else
        {
            AudioManager.Manager.PlaySFX("KeypadWrong");
            passwordText.color = Color.red;
            StartCoroutine(waitAndClear());

        }
    }

    IEnumerator waitAndClear()
    {
        yield return new WaitForSeconds(0.75f);
        Clear();
    }

    public void DoorOpen()
    {
        Vector3 newPos = new Vector3(0, 270, 0);
        gameObject.transform.position = newPos;
    }
}
