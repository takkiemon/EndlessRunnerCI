using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] lanes;
    public int currentLane;
    public int points;
    public bool moving;
    public float moveTimer;
    public float timeToMove;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        currentLane = 2;
        moveTimer = 0f;
        timeToMove = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (!moving && currentLane > 1)
            {
                currentLane--;
                moving = true;
                moveTimer = 0f;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (!moving && currentLane < lanes.Length)
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

    public void UpdatePoints(int points)
    {
        this.points = points;
        scoreText.text = points.ToString();
    }
}