using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item Item;


    void PickUp()
    {
        InventoryManager.Instance.Add(Item);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        PickUp();
    }
}
