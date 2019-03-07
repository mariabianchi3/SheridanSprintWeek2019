using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleAbility : MonoBehaviour
{

    public bool craft = true;
    private Button abilitybutton;
    public Color craftColor = Color.cyan;
    public Color jumpColor = Color.magenta;

    public PlayerControl pc;

    public void Awake()
    {
        abilitybutton = GetComponent<Button>();
        if (abilitybutton != null)
        {
            if (craft)
            {
                ColorBlock cb = abilitybutton.colors;
                cb.normalColor = craftColor;
                cb.highlightedColor = craftColor;
                abilitybutton.colors = cb;
                //Debug.Log(abilitybutton.colors.normalColor);
            }
            else
            {
                ColorBlock cb = abilitybutton.colors;
                cb.normalColor = jumpColor;
                cb.highlightedColor = jumpColor;
                abilitybutton.colors = cb;
                //Debug.Log(abilitybutton.colors.normalColor);
            }
        }
    }
    public void toggleAbility()
    {
        craft = !craft;
        if (abilitybutton != null)
        {
            if (craft)
            {
                //abilitybutton.colors.normalColor = Color.blue;
                ColorBlock cb = abilitybutton.colors;
                cb.normalColor = craftColor;
                cb.highlightedColor = craftColor;
                abilitybutton.colors = cb;
                //Debug.Log(abilitybutton.colors.normalColor);
            }
            else
            {
                ColorBlock cb = abilitybutton.colors;
                cb.normalColor = jumpColor;
                cb.highlightedColor = jumpColor;
                abilitybutton.colors = cb;
                //Debug.Log(abilitybutton.colors.normalColor);
            }
        }
    }

    public void useAbility()
    {
        if (pc.mineGun.isMining)
        {
            //Debug.Log("ismining");
        }
        else
        {
            if (craft)
            {
                if(pc != null){
                    if (pc.RVal.BlueP > 10)
                    {
                        pc.mineGun.Craft();
                        pc.RVal.BlueP -= 10;
                    }
                }
            }
            else
            {
                if(pc != null)
                {
                    if(pc.Grounded && pc.RVal.RedP > 10)
                    {
                        pc.playerRB.AddForce(transform.up * pc.Boost);
                        pc.RVal.RedP -= 10;
                    }
                }
            }
        }
    }
}
