using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyPosForMenu : MonoBehaviour
{
    public GameObject leftButton;
    public GameObject RightButton;

    private void Start()
    {
        if (PlayerPrefs.GetString("JoyPos") == "Left")
        {
            leftButton.SetActive(false);
            RightButton.SetActive(true);
        }

        if (PlayerPrefs.GetString("JoyPos") == "Right")
        {
            leftButton.SetActive(true);
            RightButton.SetActive(false);
        }
    }
    public void Left()
    {
        PlayerPrefs.SetString("JoyPos", "Left");
    }


    public void Right()
    {
        PlayerPrefs.SetString("JoyPos", "Right");
    }
}
