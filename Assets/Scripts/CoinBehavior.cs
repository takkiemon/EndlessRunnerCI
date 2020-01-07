using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    public bool isJumping1;
    public bool isJumping2;
    public float jumpHeight;
    public float jumpDuration1; // how long it takes to jump from the ground to the target (in seconds)
    public float jumpDuration2;
    Vector3 jumpFrom;
    Vector3 jumpTarget1;
    GameObject jumpTarget2;
    float jumpTimer;
    ItemCatcherBehavior itemCatcher;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isJumping1)
        {
            transform.position = Vector3.Lerp(jumpFrom, jumpTarget1, jumpTimer);
            jumpTimer += Time.deltaTime / jumpDuration1;

            if (jumpTimer >= 1f)
            {
                Jump2();
            }
        }

        if (isJumping2)
        {
            transform.position = Vector3.Lerp(jumpTarget1, jumpTarget2.transform.position, jumpTimer);
            jumpTimer += Time.deltaTime / jumpDuration2;
            if (jumpTimer >= 1f)
            {
                itemCatcher.RemoveItemFromConveyorBelt(this.gameObject);
                isJumping2 = false;
            }
        }
    }

    public void Jump(GameObject jumpTargetLocation, ItemCatcherBehavior itemCatcher)
    {
        jumpFrom = transform.position;
        this.itemCatcher = itemCatcher;
        isJumping1 = true;
        isJumping2 = false;
        jumpTimer = 0f;
        jumpTarget1 = jumpFrom + new Vector3(0f, jumpHeight, 0f);
        jumpTarget2 = jumpTargetLocation;
    }

    public void Jump2()
    {
        jumpTimer = 0f;
        isJumping1 = false;
        isJumping2 = true;
    }
}
