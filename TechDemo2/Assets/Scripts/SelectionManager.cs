using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private Material highlightMaterial;
    
    [SerializeField] private Material defaultMaterial;


    private Transform _selection;
    private void Update()
    {

        if (_selection = null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            //_selection.GetComponent<Renderer>.
            _selection = null;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) 
        {
            var selection = hit.transform;
            if(selection.CompareTag("Selectable")) 
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                  if (selectionRenderer != null) 
                  {
                     selectionRenderer.material = highlightMaterial;
                  }
            }
            _selection = selection;
        }
    }
}

/*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
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
          */