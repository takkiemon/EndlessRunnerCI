using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    bool isJumping1;
    bool isJumping2;
    public float jumpHeight;
    public float jumpDuration1; // how long it takes to jump from the ground to the target (in seconds)
    public float jumpDuration2;
    Vector3 jumpFrom;
    GameObject jumpTarget;
    float jumpTimer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isJumping1)
        {
            transform.position = Vector3.Lerp(jumpFrom, jumpFrom + new Vector3(0f, jumpHeight, 0f), jumpTimer);
            jumpTimer += Time.deltaTime / jumpDuration1;
            if (jumpTimer >= 1f)
            {
                Jump2();
            }
        }

        if (isJumping2)
        {
            transform.position = Vector3.Lerp(jumpFrom, jumpTarget.transform.position, jumpTimer);
            jumpTimer += Time.deltaTime / jumpDuration2;
        }
    }

    public void Jump(GameObject jumpTargetLocation)
    {
        isJumping1 = true;
        isJumping2 = false;
        jumpTimer = 0f;
        jumpTarget = jumpTargetLocation;
        jumpFrom = transform.position;
    }

    public void Jump2()
    {
        jumpTimer = 0f;
        isJumping1 = false;
        isJumping2 = true;
    }
}
