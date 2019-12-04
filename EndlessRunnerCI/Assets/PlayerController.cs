using System.Collections;
using System.Collections.Generic;
using Unity.Input;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObjects[] lanes;
    public int currentLane;

    // Start is called before the first frame update
    void Start()
    {
        currentLane = 2;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown()) ;
    }
}
