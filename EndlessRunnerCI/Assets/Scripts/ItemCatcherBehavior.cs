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
        if (!conveyorBelt.inactiveItems.Contains(other.gameObject))
        {
            conveyorBelt.inactiveItems.Add(other.gameObject);
        }
        if (conveyorBelt.itemsOnTheBelt.Contains(other.gameObject))
        {
            conveyorBelt.itemsOnTheBelt.Remove(other.gameObject);
        }
        other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y + transform.localScale.y + transform.position.y + 2, other.gameObject.transform.position.z - transform.localScale.z + transform.position.z - 2);
    }
}
