using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltBehavior : MonoBehaviour
{
    public float movingSpeed;
    public float spawnType;
    public int spawnNumber;
    public GameObject[] itemLanes;
    public List<GameObject> itemsOnTheBelt;
    public List<GameObject> inactiveItems;
    public float coinSpawnWeight, wallSpawnWeight;

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

    public GameObject SpawnSomething()
    {
        spawnType = Random.Range(0f, coinSpawnWeight + wallSpawnWeight);
        if (spawnType <= coinSpawnWeight)
        {
            spawnNumber = 1;
        }
        else if (spawnType > coinSpawnWeight && spawnType <= coinSpawnWeight + wallSpawnWeight)
        {
            spawnNumber = 2;
        }

        int lane = Random.Range(1, 4);
        switch(spawnNumber)
        {
            case 0:
                //do nothing;
                break;
            case 1:
                return SpawnCoin(lane);
            case 2:
                return SpawnWall(lane);
            default:
                break;
        }
        return null;
    }

    public GameObject SpawnCoin(int lane)
    {
        foreach(GameObject currentObject in inactiveItems)
        {
            if (currentObject.GetComponent<CoinBehavior>())
            {
                itemsOnTheBelt.Add(currentObject);
                inactiveItems.Remove(currentObject);
                currentObject.transform.position = itemLanes[lane - 1].transform.position;
                return currentObject;
            }
        }

        foreach(GameObject currentObject in itemsOnTheBelt)
        {
            if (currentObject.GetComponent<CoinBehavior>())
            {
                currentObject.transform.position = itemLanes[lane - 1].transform.position;
                return currentObject;
            }
        }
        Debug.Log("the inactiveItems and itemsOnTheBelt lists both do not contain any objects with the 'Coinbehavior.cs' component: there are no coins in the game or the 'SpawnCoin' function doesn't work properly");
        return null;
    }

    public GameObject SpawnWall(int lane)
    {
        foreach (GameObject currentObject in inactiveItems)
        {
            if (currentObject.GetComponent<WallBehavior>())
            {
                itemsOnTheBelt.Add(currentObject);
                inactiveItems.Remove(currentObject);
                currentObject.transform.position = itemLanes[lane - 1].transform.position;
                return currentObject;
            }
        }

        foreach (GameObject currentObject in itemsOnTheBelt)
        {
            if (currentObject.GetComponent<WallBehavior>())
            {
                currentObject.transform.position = itemLanes[lane - 1].transform.position;
                return currentObject;
            }
        }
        Debug.Log("the inactiveItems and itemsOnTheBelt lists both do not contain any objects with the 'WallBehavior.cs' component: there are no coins in the game or the 'SpawnCoin' function doesn't work properly");
        return null;
    }
}
