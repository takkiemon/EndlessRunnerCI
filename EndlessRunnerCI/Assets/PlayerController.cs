using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] lanes;
    public int currentLane;

    // Start is called before the first frame update
    void Start()
    {
        currentLane = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentLane > 1)
            {
                currentLane--;
                transform.position = lanes[currentLane - 1].transform.position;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentLane < lanes.Length)
            {
                currentLane++;
                transform.position = lanes[currentLane - 1].transform.position;
            }
        }
    }
}
