using UnityEngine;
using UnityEngine.UI;


public class PlayerAim : MonoBehaviour
{
    public Transform headPos;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.transform.GetComponent<KeypadKey>() != null)
                {
                    hit.transform.GetComponent<KeypadKey>().SendKey();
                }
                
            }

        }
    }
}

