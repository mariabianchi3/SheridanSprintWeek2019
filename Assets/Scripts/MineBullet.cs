using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBullet : MonoBehaviour
{
    private Rigidbody2D bulletRB;
    public float bulletSpeed;
    private float bulletHP;
    //public float heightRand;
    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        bulletRB.velocity = transform.right * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // heightRand = Random.Range(0, 5);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
        }
        else if (!other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }

}
