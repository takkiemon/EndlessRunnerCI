using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] lanes;
    public int currentLane;
    public bool moving;
    public float moveTimer;
    public float timeToMove;

    // Start is called before the first frame update
    void Start()
    {
        currentLane = 2;
        moveTimer = 0f;
        timeToMove = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentLane > 1)
            {
                currentLane--;
                moving = true;
                moveTimer = 0f;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentLane < lanes.Length)
            {
                currentLane++;
                moving = true;
                moveTimer = 0f;
            }
        }

        if (moving)
        {
            MovePlayerSlerp(transform.position, lanes[currentLane - 1].transform.position);
        }
    }

    public void MovePlayerSlerp(Vector3 startingPosition, Vector3 finishingPosition)
    {
        moveTimer += Time.deltaTime / timeToMove;
        if (moveTimer >= 1f)
        {
            moving = false;
            moveTimer = 1f;
        }
        transform.position = Vector3.Lerp(startingPosition, finishingPosition, moveTimer);
    }
}