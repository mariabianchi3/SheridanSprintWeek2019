using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineGun : MonoBehaviour
{
    public bool isMining = false;
    public float bulletRate = 0.4f;
    private float bulletTime = 0.0f;
    private bool doShoot = false;
    public Transform FirePoint;
    public GameObject bulletPrefab;
    public Transform PlatPoint;
    public GameObject PlatPrefab;
    public float heightRand;
    private Transform newPos;
    //private float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        bulletTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMining)
        {
            bulletTime += Time.deltaTime;
            Aim();
            if(bulletTime >= bulletRate)
            {
                if(doShoot)
                {
                    Shoot();
                    bulletTime = 0;
                }
            }
        }
    }

    void Shoot()
    {
        heightRand = Random.Range(-0.1f, 0.1f);
        //Transform newPos = FirePoint;
        //newPos.position = new Vector2(FirePoint.position.x, FirePoint.position.y + heightRand);
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);

    }

    void Aim()
    {
        //Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //diff.Normalize();

        //float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0f, 0f, rot_z);


        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (isMining)
            {
                // Move the cube if the screen has the finger moving.
                if (touch.phase == TouchPhase.Moved)
                {
                    Vector2 pos = touch.position;
                    Vector3 test = Camera.main.ScreenToWorldPoint(new Vector3(pos.x, pos.y, 0));
                    Vector3 diff = test - transform.position;
                    diff.Normalize();
                    float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(0f, 0f, rot_z);

                }
                else if(touch.phase == TouchPhase.Began)
                {
                    doShoot = true;
                }
                else if(touch.phase == TouchPhase.Ended)
                {
                    doShoot = false;
                }
            }
            
        }

    }

    public void Craft()
    {


        Instantiate(PlatPrefab, PlatPoint.position, PlatPoint.rotation);

    }

    public void toggleMine()
    {
        isMining = !isMining;
    }
}
