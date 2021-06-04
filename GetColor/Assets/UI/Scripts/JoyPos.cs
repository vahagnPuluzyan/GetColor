using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoyPos : MonoBehaviour
{
    public GameObject joystick;
    RectTransform joyPos;
    FloatingJoystick joy;
    public GameObject leftButton;
    public GameObject RightButton;

    // Start is called before the first frame update
    void Start()
    {
        joy = FindObjectOfType<FloatingJoystick>();
        joystick = joy.gameObject;
        joyPos = joystick.GetComponent<RectTransform>();
        if (PlayerPrefs.GetString("JoyPos") == "Left")
        {
            Left();
            leftButton.SetActive(false);
            RightButton.SetActive(true);
        }

        if (PlayerPrefs.GetString("JoyPos") == "Right")
        {
            Right();
            leftButton.SetActive(true);
            RightButton.SetActive(false);
        }
    }


    public void Left()
    {
        joyPos.localPosition = new Vector3(500f,-1650f);
        PlayerPrefs.SetString("JoyPos","Left");
    }


    public void Right()
    {
        joyPos.localPosition = new Vector3(-500f,-1650f);
        PlayerPrefs.SetString("JoyPos", "Right");
    }
}
