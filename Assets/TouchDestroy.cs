using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDestroy : MonoBehaviour
{
    private bool Moving;
    private GameObject Player;
    private Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        velocity = new Vector3(Player.transform.position.x, Player.transform.position.y,0);
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D myRb = GetComponent<Rigidbody2D>();
        var direction = Vector3.zero;

        if(Moving)
        {
            direction = Player.transform.position - transform.position;
            myRb.AddRelativeForce(direction.normalized * 5);
            //myRb.MovePosition(Player.transform.position * (Time.deltaTime*0.2f));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }

        if(other.gameObject.CompareTag("PlayerVis"))
        {
            Moving = true;
        }
    }
}
