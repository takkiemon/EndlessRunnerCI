using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] lanes;
    public ItemCatcherBehavior itemCatcher;
    public int currentLane;
    public int points;
    public int lives;
    public bool moving;
    public float moveTimer;
    public float timeToMove;
    public Text scoreText;
    public Text livesText;

    private Vector3 previousPosition;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        lives = 3; 
        moveTimer = 0f;
        FastSetThePlayerToLane(2); // set the player to the middle lane
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PressLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            PressRight();
        }

        if (moving)
        {
            MovePlayerLerp(lanes[currentLane - 1].transform.position);
        }
    }

    public void MovePlayerLerp(Vector3 finishingPosition)
    {
        moveTimer += Time.deltaTime / timeToMove;
        if (moveTimer >= 1f)
        {
            moving = false;
            moveTimer = 1f;
        }
        transform.position = Vector3.Lerp(previousPosition, finishingPosition, moveTimer);
    }

    public void UpdatePoints(int points)
    {
        this.points = points;
        scoreText.text = points.ToString();
    }

    public void UpdateLives(int lives)
    {
        this.lives = lives;
        livesText.text = lives.ToString();
        if (lives <= 0)
        {
            Debug.Log("You are dead.");
            Application.Quit();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CoinBehavior>() && !other.gameObject.GetComponent<CoinBehavior>().isJumping1 && !other.gameObject.GetComponent<CoinBehavior>().isJumping2)
        {
            other.gameObject.GetComponent<CoinBehavior>().Jump(gameObject, itemCatcher);
            UpdatePoints(++points);
        }
        if (other.gameObject.GetComponent<WallBehavior>())
        {
            itemCatcher.RemoveItemFromConveyorBelt(other.gameObject);
            UpdateLives(--lives);
        }
    }

    public void FastSetThePlayerToLane(int laneNumber)
    {
        currentLane = laneNumber;
        transform.position = lanes[laneNumber - 1].transform.position;
    }

    public void PressLeft()
    {
        if (!moving && currentLane > 1)
        {
            currentLane--;
            moving = true;
            moveTimer = 0f;
            previousPosition = transform.position;
        }
    }

    public void PressRight()
    {
        if (!moving && currentLane < lanes.Length)
        {
            currentLane++;
            moving = true;
            moveTimer = 0f;
            previousPosition = transform.position;
        }
    }
}