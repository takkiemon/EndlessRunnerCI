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
        //if (other.gameObject.GetComponent<CoinBehavior>())
        //{
            //SuspendItemFromConveyorBelt(other.gameObject);
        //}
        //else
        //{
            RemoveItemFromConveyorBelt(other.gameObject);
        //}
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

    /*
    public void SuspendItemFromConveyorBelt(GameObject itemToSuspend) // same as RemoveItemFromConveyorBelt(), but doesn't change its position, so that it can animate (needs a better name, probably)
    {
        if (!conveyorBelt.inactiveItems.Contains(itemToSuspend))
        {
            conveyorBelt.inactiveItems.Add(itemToSuspend);
        }
        if (conveyorBelt.itemsOnTheBelt.Contains(itemToSuspend))
        {
            conveyorBelt.itemsOnTheBelt.Remove(itemToSuspend);
        }
    }
    */
}
