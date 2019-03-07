using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public float rockHealth;
    public float hitDmg;
    public bool Hit;
    public float cooldown = 2;
    public SpriteRenderer crystalImg;
    public GameObject RedPrefab;
    public GameObject BluePrefab;
    private Vector3 ScatterPos;

    // Start is called before the first frame update
    void Start()
    {
        Hit = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        
       
        if (rockHealth <= 0)
        {
            for (int i = 0; i < 3; i++)
            {
                ScatterPos = new Vector3(transform.position.x + Random.Range(-1, 1), transform.position.y + Random.Range(0, 1), transform.position.z);
                Instantiate(RedPrefab, ScatterPos, transform.rotation);
            }

            Destroy(this.gameObject);
        }

        if (Hit)
        {
            cooldown -= 0.2f;
        }

        if(cooldown <= 0)
        {
            crystalImg.color = Color.white;
            Hit = false;
            cooldown = 2;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            RockHit();
            DoCool();
            //cooldown -= 0.2f * Time.deltaTime;

        }
    }

    void RockHit()
    {
        Color OrangeGlow = new Color(255, 182, 0, 68);
        rockHealth -= hitDmg;
        Hit = true;
        crystalImg.color = OrangeGlow;
        //cooldown -= 0.2f * Time.deltaTime;



    }
    void DoCool()
    {
        cooldown -= 0.2f;
    }


}
