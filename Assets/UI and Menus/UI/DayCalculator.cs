using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayCalculator : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        switch (UpgradeVariables.day)
        {
            case 1:
                text.text = "Monday";
                break;
            case 2:
                text.text = "Tuesday";
                break;
            case 3:
                text.text = "Wednesday";
                break;
            case 4:
                text.text = "Thursday";
                break;
            case 5:
                text.text = "Friday";
                break;
        }
    }
}
