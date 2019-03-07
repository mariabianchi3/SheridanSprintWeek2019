using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody2D playerRB;
    [HideInInspector]
    public MineGun mineGun;
    [HideInInspector]
    public bool Grounded;

    public LayerMask groundLayers;
    public float MoveSpeed = 10;
    public float JumpPower = 200.0f;
    public float Boost=  500.0f;

    float xmove;
    [HideInInspector]
    public SpriteRenderer myChar;
    [HideInInspector]
    public Inventory RVal;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        mineGun = GetComponentInChildren<MineGun>();
        RVal = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()

    {
        CheckFacing();
        playerRB.velocity = new Vector2(xmove * MoveSpeed, playerRB.velocity.y);
 
        //
        Grounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f), 
            new Vector2(transform.position.x + 0.5f, transform.position.y - 0.51f), groundLayers);
    }

    public void doJump()
    {
        if (!mineGun.isMining)
        {
            if (Grounded)
            {
                playerRB.AddForce(transform.up * JumpPower);
                //Debug.Log("Do Jump");
            }
        }
    }


    void CheckFacing()
    {
        

        if (xmove<0)
        {
            //myChar.flipX = true;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (xmove>0)
        {
            //myChar.flipX = false;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    public void movement(int i)
    {
        if(mineGun != null)
        {
            if(!mineGun.isMining)
            {
                xmove = i;
            }
        }
    }
}
