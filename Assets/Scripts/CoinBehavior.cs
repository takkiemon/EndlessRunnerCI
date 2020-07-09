using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    public bool isPickedUp;
    bool isJumping1;
    bool isHangTime;
    bool isJumping2;
    public float jumpHeight;
    public float jumpDuration1; // how long it takes to jump from the ground to the target (in seconds)
    public float jumpDuration2;
    public float hangTimeDuration;
    public float spinningSpeed1;
    public float spinningSpeed2;
    Vector3 jumpFrom;
    Vector3 jumpTarget1;
    GameObject jumpTarget2;
    float jumpTimer;
    ItemCatcherBehavior itemCatcher;
    public ParticleSystem shiniesSlow;
    public ParticleSystem shiniesFast;


    // Start is called before the first frame update
    void Start() // create initilaize function and call it in here instead of setting the booleans in the start()
    {
        isJumping1 = false;
        isHangTime = false;
        isJumping2 = false;
        shiniesFast.Stop();
        shiniesSlow.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (isJumping1)
        {
            transform.position = Vector3.Lerp(jumpFrom, jumpTarget1, jumpTimer);
            jumpTimer += Time.deltaTime / jumpDuration1;
            gameObject.transform.eulerAngles += new Vector3(0, Time.deltaTime * spinningSpeed1, 0);
            if (jumpTimer >= 1f)
            {
                HangTime();
            }
        }
        else if (isHangTime)
        {
            jumpTimer += Time.deltaTime / hangTimeDuration;
            if (jumpTimer >= 1f)
            {
                Jump2();
            }
        }
        else if (isJumping2)
        {
            transform.position = Vector3.Lerp(jumpTarget1, jumpTarget2.transform.position, jumpTimer);
            jumpTimer += Time.deltaTime / jumpDuration2;
            gameObject.transform.eulerAngles += new Vector3(0, Time.deltaTime * spinningSpeed2, 0);
            if (jumpTimer >= 1f)
            {
                isJumping2 = false;
                CoinDeath();
            }
        }
    }

    public void Jump(GameObject jumpTargetLocation, ItemCatcherBehavior itemCatcher)
    {
        isPickedUp = true;
        jumpFrom = transform.position;
        this.itemCatcher = itemCatcher;
        isJumping1 = true;
        jumpTimer = 0f;
        jumpTarget1 = jumpFrom + new Vector3(0f, jumpHeight, 0f);
        jumpTarget2 = jumpTargetLocation;
        //shiniesFast.emissionRate = 1000f;
        shiniesFast.Play();
        shiniesSlow.Stop();
    }

    public void HangTime()
    {
        jumpTimer = 0f;
        isJumping1 = false;
        isHangTime = true;
    }

    public void Jump2()
    {
        jumpTimer = 0f;
        isHangTime = false;
        isJumping2 = true;
    }

    public void CoinDeath()
    {
        isPickedUp = false;
        itemCatcher.PlaceItemOutOfSight(gameObject);
    }
}
