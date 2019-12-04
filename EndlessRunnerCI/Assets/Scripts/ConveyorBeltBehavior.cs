using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltBehavior : MonoBehaviour
{
    public float movingSpeed;
    public int spawnType;
    public GameObject[] itemLanes;
    public List<GameObject> itemsOnTheBelt;
    public List<GameObject> inactiveItems;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnSomething", 1f, .75f);
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject beltObject in itemsOnTheBelt)
        {
            beltObject.transform.position = new Vector3(beltObject.transform.position.x, beltObject.transform.position.y, beltObject.transform.position.z - movingSpeed);
        }
    }

    public void SpawnSomething()
    {
        spawnType = Random.Range(1, 3);
        int lane = Random.Range(1, 4);
        switch(spawnType)
        {
            case 0:
                //do nothing;
                break;
            case 1:
                SpawnCoin(lane);
                break;
            default:
                break;
        }
    }

    public void SpawnCoin(int lane)
    {
        foreach(GameObject currentObject in inactiveItems)
        {
            if (currentObject.GetComponent<CoinBehavior>())
            {
                itemsOnTheBelt.Add(currentObject);
                inactiveItems.Remove(currentObject);
                currentObject.transform.position = itemLanes[lane - 1].transform.position;
                return;
            }
        }

        foreach(GameObject currentObject in itemsOnTheBelt)
        {
            if (currentObject.GetComponent<CoinBehavior>())
            {
                currentObject.transform.position = itemLanes[lane - 1].transform.position;
                return;
            }
        }
        Debug.Log("the inactiveItems and itemsOnTheBelt lists both do not contain any objects with the 'Coinbehavior.cs' component: there are no coins in the game or the 'SpawnCoin' function doesn't work properly");
    }
}
