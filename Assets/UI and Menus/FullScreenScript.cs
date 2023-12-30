using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenScript : MonoBehaviour
{
    public void ChangeScreen()
    {
        if (Screen.fullScreen)
        {
            Screen.SetResolution(1440, 810, false);
        }
        else
        {
            Screen.SetResolution(1920, 1080, true);
        }
    }
}
