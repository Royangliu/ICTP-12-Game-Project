using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{
    [SerializeField] Toggle toggle;
    [SerializeField] GameObject options;
    public bool isFullOnStart;

    // Update is called once per frame
    private void Start()
    {
        if (Screen.fullScreen)
        {
            isFullOnStart = true;
            toggle.isOn = true;
        }
        else
        {
            isFullOnStart = false;
            toggle.isOn = false;
        }
    }
}