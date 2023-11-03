using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAim : MonoBehaviour
{
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
                else if (hit.transform.name == "DoorMesh")
                {
                    hit.transform.GetComponent<DoorController>().OpenClose();
                }
            }
          
        }
    }
}

//Physics.Raycast(headPos.position, headPos.TransformDirection(Vector3.forward)