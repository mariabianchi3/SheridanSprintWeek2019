using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiningToggle : MonoBehaviour
{
    public MineGun mineGun;
    public Button leftButton;
    public Button rightButton;
    public Button jumpButton;
    public Button boostButton;
    public Button craftButton;

    public void toggleMining()
    {
        if (mineGun != null)
        {
            mineGun.isMining = !mineGun.isMining;

            if(mineGun.isMining)
            {
                //leftButton.enabled = false;
                leftButton.interactable = false;
                rightButton.interactable = false;
                jumpButton.interactable = false;
                boostButton.interactable = false;
                craftButton.interactable = false;
            }
            else
            {
                //leftButton.enabled = true;
                leftButton.interactable = true;
                rightButton.interactable = true;
                jumpButton.interactable = true;
                boostButton.interactable = true;
                craftButton.interactable = true;
            }
        }
    }
}
