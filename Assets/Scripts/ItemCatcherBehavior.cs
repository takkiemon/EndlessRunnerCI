using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCatcherBehavior : MonoBehaviour
{
    public ConveyorBeltBehavior conveyorBelt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        RemoveItemFromConveyorBelt(other.gameObject);
    }

    public void RemoveItemFromConveyorBelt(GameObject itemToRemove)
    {
        if (!conveyorBelt.inactiveItems.Contains(itemToRemove))
        {
            conveyorBelt.inactiveItems.Add(itemToRemove);
        }
        if (conveyorBelt.itemsOnTheBelt.Contains(itemToRemove))
        {
            conveyorBelt.itemsOnTheBelt.Remove(itemToRemove);
        }
        itemToRemove.transform.position = new Vector3(itemToRemove.transform.position.x, itemToRemove.transform.position.y + transform.localScale.y + transform.position.y + 2, itemToRemove.transform.position.z - transform.localScale.z + transform.position.z - 2);
    }
}
