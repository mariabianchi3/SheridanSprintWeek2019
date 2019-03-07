using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchExample : MonoBehaviour
{
    public bool isMining = false;
    public float jumpForce = 200.0f;
    private Rigidbody rb;
    private Vector3 position;
    private float width;
    private float height;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        width = (float)Screen.width;// / 2.0f;
        height = (float)Screen.height;// / 2.0f;

        // Position used for the cube.
        position = new Vector3(0.0f, 0.0f, 0.0f);
    }

    public void toggleMining()
    {
        isMining = !isMining;
        if (rb != null)
        {
            if (isMining)
            {
                rb.isKinematic = true;
            }
            else
            {
                rb.isKinematic = false;
            }
        }
    }


    public void doJump()
    {
        if(rb != null && !isMining)
        {
            Debug.Log("Do Jump");
            rb.AddForce(Vector3.up * jumpForce);
        }

    }
    void Update()
    { 
        // Handle screen touches.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(isMining)
            {
                // Move the cube if the screen has the finger moving.
                if (touch.phase == TouchPhase.Moved)
                {
                    Vector2 pos = touch.position;
                    Vector3 test = Camera.main.ScreenToWorldPoint(new Vector3(pos.x, pos.y, 0));
                    Vector3 res = test - transform.position;
                    Vector3 res2 = new Vector3(res.x, res.y, 0.0f);

                    float angle = Vector3.SignedAngle(res2, Vector3.up, -Vector3.forward);

                    transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);

                }
            }
        }
    }
}
