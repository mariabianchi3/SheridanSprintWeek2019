using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public float RedP;
    public float BlueP;
    public float MaxP;

    public Image RedSlider;
    public Image BlueSlider;

    public MineGun Plat;
    // Start is called before the first frame update
    void Start()
    {
        RedP = 0;
        //BlueP = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (RedP > MaxP)
        {
            RedP = MaxP;
        }
        else if (BlueP > MaxP)
        {
            BlueP = MaxP;
        }

        DisplayVal();

        if (Input.GetButtonDown("Fire2"))
        {
            if (BlueP > 10)
            {
                Plat.Craft();
                BlueP -= 10;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("RedP"))
        {
            RedP += 5;
        }
        else if (other.gameObject.CompareTag("BlueP"))
        {
            BlueP += 5;
        }
    }

    void DisplayVal()
    {
        RedSlider.fillAmount = RedP / MaxP;
        BlueSlider.fillAmount = BlueP / MaxP;
    }
}
